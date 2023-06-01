using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Socket
{
    public class SocketClient
    {
        //본인 학번
        public string clientStdNum;
        //다른 학번들과 연결 클라이언트 딕셔너리
        public Dictionary<string,TcpClient> clientSocketDict;

        //데이터베이스에서 얻어온 address 딕셔너리
        public Dictionary<string, string> addressDict;
        
        private byte[] sendBuffer=new byte[1024 * 4];
        private byte[] readBuffer=new byte[1024 * 4];
        
        public Init InitClass; 

        public SocketClient(string studentNum)
        {
            this.clientStdNum = studentNum;
            clientSocketDict=new Dictionary<string, TcpClient>();
        }

        public delegate void ConnectClientHandler(string sender,List<string> todo);
        public event ConnectClientHandler OnConnect;

        public delegate void MessageHandler(string message);
        public event MessageHandler OnMessage;

        public delegate void LoadAddress();
        public event LoadAddress OnLoadAddress;

        public async Task Send(NetworkStream networkStream)
        {
            await networkStream.WriteAsync(this.sendBuffer, 0, this.sendBuffer.Length).ConfigureAwait(false);
            await networkStream.FlushAsync();

            for (int i = 0; i < 1024 * 4; i++)
            {
                this.sendBuffer[i] = 0;
            }
        }

        public void sendClientTodo()
        {
            List<string> todoLink=InitClass.todoLink.ToList();
            foreach (string todo in InitClass.todoLink)
            {
                if (!addressDict.ContainsKey(todo))
                {
                    Trace.WriteLine(string.Format("연결 실패 + {0}: 실시간 일정 공유에 접속되어 있지 않습니다.", todo));
                    continue;
                }
                todoLink.Remove(todo);
                Task.Run(() => createConnection(todo,todoLink));
                
            }
        }
        private async void createConnection(string stdNum,List<string> todoLink)
        {
            if (stdNum != null)
            {
                NetworkStream networkStream=null;
                try
                {
                    OnMessage("연결 시도" + stdNum);
                    TcpClient todoClient = new TcpClient();
                    //각 사용자 들에게 접속 시도
                    todoClient.Connect(addressDict[stdNum], 7777);

                    networkStream = todoClient.GetStream();
                    //접속 후 추가
                    clientSocketDict.Add(stdNum, todoClient);

                    Init init = InitClass;
                    init.sender = clientStdNum;
                    init.todoLink = todoLink;

                    Packet.Serialize(init).CopyTo(this.sendBuffer, 0);
                    await Send(networkStream);
                }
                catch
                {
                    Trace.WriteLine(string.Format("연결 실패 + {0}: 실시간 일정 공유에 접속되어 있지 않습니다.", stdNum));
                }
            }
        }
        public async void readStreamData(TcpClient connectSocket)
        {
            NetworkStream stream = null;
            int bytes = 0;
            try
            {
                while (connectSocket.Connected)
                {
                    stream = connectSocket.GetStream();
                    bytes = await stream.ReadAsync(readBuffer, 0, readBuffer.Length).ConfigureAwait(false);
                    Packet packet = (Packet)Packet.Deserialize(readBuffer);
                    switch ((int)packet.Type)
                    {
                        case (int)PacketType.INIT:
                            {
                                InitClass = (Init)Packet.Deserialize(readBuffer);
                                clientSocketDict.Add(InitClass.sender, connectSocket);

                                if (OnConnect != null)
                                    OnConnect(InitClass.sender, InitClass.todoLink);

                                if (InitClass.todoLink.Count > 0 && OnLoadAddress != null)
                                    OnLoadAddress();

                                //보낸 사람이 boss가 아니거나 더 이상 보낼 사람 없으면 종료.
                                if (!InitClass.boss.Equals(InitClass.sender) || InitClass.todoLink.Count == 0)
                                    break;

                                sendClientTodo();
                                break;
                            }

                    }
                }
            }
            catch (SocketException se)
            {
                Trace.WriteLine(string.Format("doConnect - SocketException : {0}", se.Message));

                if (clientSocketDict.Count>0)
                {
                    foreach(TcpClient tcpClient in clientSocketDict.Values)
                        tcpClient.Close();
                    stream.Close();
                    
                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("doConnect - Exception : {0}", ex.Message));

                if (clientSocketDict.Count > 0)
                {
                    foreach (TcpClient tcpClient in clientSocketDict.Values)
                        tcpClient.Close();
                    stream.Close();
                }
            }
        }
    }
}
