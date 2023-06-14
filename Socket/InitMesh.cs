using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket
{
    public class InitMesh :Packet
    {
        public string sender;

        public InitMesh(string sender)
        { 
            this.sender = sender; 
        }
    }
}
