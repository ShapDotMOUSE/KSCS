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
        public List<string> categoryList;

        public ShareSchedule(string stdnum,List<string> categoryList)
        {
            this.stdnum=stdnum;
            this.categoryList = categoryList;
        }
    }
}
