using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket
{
    [Serializable]
    public class Init : Packet
    {
        public List<string> members;
        public List<string> todoLink;
        public string boss;
        public string sender;

        public Init()
        {
            members = new List<string>();
        }
    }
}
