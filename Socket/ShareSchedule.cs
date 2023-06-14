using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket
{
    [Serializable]
    public class ShareSchedule : Packet
    {
        public string stdnum;
        public List<int> categoryList;

        public ShareSchedule()
        {
            this.categoryList = new List<int>();
        }
    }
}
