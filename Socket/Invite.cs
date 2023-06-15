using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket
{
    [Serializable]
    public class Invite : Packet
    {
        public List<string> members;
        public List<string> todoLink;
        public string boss;

        public Invite()
        {
            members = new List<string>();
            todoLink = new List<string>();
        }
    }
}
