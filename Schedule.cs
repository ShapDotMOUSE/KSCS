using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSCS
{
    public class Schedule
    {
        public int id;
        public string title { get; set; }
        public string content { get; set; }
        public string place { get; set; }
        public string category { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        
        public Schedule(string title, string content, string place,string category, DateTime startDate, DateTime endDate)
        {
            this.title = title;
            this.content = content;
            this.place = place;
            this.category = category;
            this.startDate = startDate;
            this.endDate = endDate;
        }
    }
}
