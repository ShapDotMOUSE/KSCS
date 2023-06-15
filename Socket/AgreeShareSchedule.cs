using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket
{
    [Serializable]
    public class AgreeShareSchedule : Packet
    {
        public bool agree;

        public AgreeShareSchedule()
        {
        }
    }
}
