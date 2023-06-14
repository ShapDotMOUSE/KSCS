using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Socket
{
    public enum PacketType
    {
        INVITE,//최초 연결 생성
        INIT_MESH,//연결 안된 노드들 연결
        SHARE_SCHEDULE,//일정 공유
        CREATE_SHARE_SCHEDULE,//공유 일정 생성
        AGREE_SHARE_SCHEDULE//공유 일정 생성 동의
    }
    public enum PacketSendERROR
    {
        Normal = 0,
        Error
    }


    [Serializable]
    public class Packet
    {
        public int Length;
        public int Type;

        public Packet()
        {
            this.Length = 0;
            this.Type = 0;
        }

        public static byte[] Serialize(Object o)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }

        public static Object Deserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            foreach (byte b in bt)
            {
                ms.WriteByte(b);
            }
            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }
}
