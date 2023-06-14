using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket
{
    [Serializable]
    public class InitMesh :Packet
    {
        public string sender;

        public InitMesh(string sender)
        { 
            this.sender = sender; 
        }
    }
}
