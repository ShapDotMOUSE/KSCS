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

        public Schedule() { }
        
        public Schedule(string title, string content, string place,string category, DateTime startDate, DateTime endDate)
        {
            this.title = title;
            this.content = content;
            this.place = place;
            this.category = category;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public static Schedule KLAS_Schedule(string title,string type, string subjNm, string endDate)
        {
            Schedule schedule= new Schedule();
            schedule.title = title;
            schedule.content = subjNm;
            schedule.place = "KLAS";
            schedule.category = type;
            schedule.startDate =  DateTime.Parse(endDate);
            schedule.endDate = DateTime.Parse(endDate);
            return schedule;
        }

        public double getDiffDays()
        {
            DateTime now = DateTime.Now;
            TimeSpan ts = endDate - now;
            return ts.TotalDays;

        }
        public bool MagamBeforeNow()
        {
            DateTime now = DateTime.Now;
            return (DateTime.Compare(now, endDate) < 0);
        }
        static public string MagamDateFrom(DateTime dateTime)
        {
            DateTime now = DateTime.Now;
            TimeSpan ts = dateTime - now;
            if (DateTime.Compare(now, dateTime) < 0)
            {
                if (ts.TotalDays < 1)
                    return ts.Hours.ToString() + "시간";
                else 
                    return ts.Days + "일";
            }
            return "";
        }
    }
}
