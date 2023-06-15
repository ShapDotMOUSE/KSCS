using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket
{
    [Serializable]
    public class CreateShareSchedule : Packet
    {
        //카테고리 고정
        //맴버 고정

        public string title;
        public string content;
        public string place;
        public DateTime startDate;
        public DateTime endDate;

        public CreateShareSchedule(string title, string content, string place, DateTime startDate, DateTime endDate)
        {
            this.title = title;
            this.content = content;
            this.place = place;
            this.startDate = startDate;
            this.endDate = endDate;
        }
        


    }
}
