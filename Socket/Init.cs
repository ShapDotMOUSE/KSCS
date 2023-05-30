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
        public Dictionary<string, string> addressDict;
        public List<string> members;

        public Init()
        {
            addressDict = new Dictionary<string, string>();
            members = new List<string>();
        }
    }
}
