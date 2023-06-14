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
        public Dictionary<string, bool> isConnectedMemberDict;
        //데이터베이스에서 얻어온 address 딕셔너리
        public Dictionary<string, string> addressDict;
        
        private byte[] sendBuffer=new byte[1024 * 4];
        private byte[] readBuffer=new byte[1024 * 4];
        
        public Invite InviteClass;
        public InitMesh InitMeshClass;

        public SocketClient(string studentNum)
        {
            this.clientStdNum = studentNum;
            clientSocketDict=new Dictionary<string, TcpClient>();
            isConnectedMemberDict = new Dictionary<string, bool>();
            addressDict = new Dictionary<string, string>();
        }

        public delegate void ConnectClientHandler(string sender,List<string> todo,string type);
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

        //모든 맴버 초대 함수
        public async void inviteAllMembers()
        {
            List<string> todoLink=InviteClass.todoLink.ToList();
            foreach (string member in InviteClass.todoLink)
            {
                if (!addressDict.ContainsKey(member))
                {
                    Trace.WriteLine(string.Format("연결 실패 + {0}: 실시간 일정 공유에 접속되어 있지 않습니다.", member));
                    continue;
                }
                todoLink.Remove(member);
                await Task.Run(() => inviteMember(member, todoLink));
            }
        }

        //맴버 초대 함수
        private async void inviteMember(string stdNum,List<string> todoLink)
        {
            if (stdNum != null)
            {
                NetworkStream networkStream=null;
                try
                {
                    OnMessage("초대 시도" + stdNum);
                    TcpClient todoClient = new TcpClient();
                    //각 사용자 들에게 접속 시도
                    todoClient.Connect(addressDict[stdNum], 7777);

                    if (todoClient.Connected)
                    {
                        networkStream = todoClient.GetStream();
                        //접속 후 추가

                        Invite invite = InviteClass;
                        invite.boss = clientStdNum;
                        invite.todoLink = todoLink;

                        Packet.Serialize(invite).CopyTo(this.sendBuffer, 0);
                        await Send(networkStream);
                    }
                }
                catch
                {
                    Trace.WriteLine(string.Format("연결 실패 + {0}: 실시간 일정 공유에 접속되어 있지 않습니다.", stdNum));
                }
            }
        }

        private async void linkMesh(string stdNum)
        {
            if (stdNum != null)
            {
                NetworkStream networkStream = null;
                try
                {
                    OnMessage("Mesh 연결 시도" + stdNum);
                    TcpClient todoClient = new TcpClient();
                    //각 사용자 들에게 접속 시도
                    todoClient.Connect(addressDict[stdNum], 7777);

                    if (todoClient.Connected)
                    {
                        isConnectedMemberDict[stdNum] = true;
                        networkStream = todoClient.GetStream();
                        //접속 후 추가
                        clientSocketDict.Add(stdNum, todoClient);

                        InitMesh initMesh = new InitMesh(clientStdNum);

                        Packet.Serialize(initMesh).CopyTo(this.sendBuffer, 0);
                        await Send(networkStream);
                    }
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
                        case (int)PacketType.INVITE://보스한테 초대 받음.
                            {
                                InviteClass = (Invite)Packet.Deserialize(readBuffer);
                                //딕셔너리 초기화
                                foreach(string member in InviteClass.members)
                                {
                                    isConnectedMemberDict.Add(member, false);
                                }

                                //보스와의 연결 추가
                                clientSocketDict.Add(InviteClass.boss, connectSocket);
                                isConnectedMemberDict[InviteClass.boss]= true;

                                //연결 성공 시 메시지 출력.
                                if (OnConnect != null)
                                    OnConnect(InviteClass.boss, InviteClass.todoLink,"초대받기");

                                //데이터 베이스에서 ip 불러오기
                                OnLoadAddress();


                                //다른 todoLink에게 연결 시도 코드
                                List<string> todoLink = InviteClass.todoLink.ToList();
                                foreach (string todo in InviteClass.todoLink)
                                {
                                    Task.Run(() => linkMesh(todo));
                                }
                                break;
                            }
                            case (int)PacketType.INIT_MESH:
                            {
                                InitMeshClass=(InitMesh)Packet.Deserialize(readBuffer);
                                //다른 노드와의 연결 추가
                                clientSocketDict.Add(InitMeshClass.sender, connectSocket);
                                isConnectedMemberDict[InitMeshClass.sender]= true;
                                //연결 성공 시 메시지 출력.
                                if (OnConnect != null)
                                    OnConnect(InitMeshClass.sender,new List<string>(),"Mesh 연결");
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
