using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSCS.Class;
using static KSCS.Class.KSCS_static; //추가

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
        public List<string> members { get; set; } //추가

        public Schedule() { }
        
        //members 추가
        public Schedule(string title, string content, string place,string category, DateTime startDate, DateTime endDate,List<string> members)
        {
            this.title = title;
            this.content = content;
            this.place = place;
            this.category = category;
            this.startDate = startDate;
            this.endDate = endDate;
            this.members = members; //추간

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

        public static Dictionary<string, string> KlasCategory = new Dictionary<string, string>()
            {
                { "Task","과제" },
                { "Quiz","퀴즈" },
                { "Online","온라인 강의" },
                { "Prjct","학사일정" }
            };

        //KlasScheduleList를 monthScehduleList 에 담는 함수
        static public void ReadTabKlasSchedule()
        {
            foreach (KeyValuePair<string, List<Schedule>> kvp in KlasSchedule)
            {
                string key = kvp.Key;
                List<Schedule> KlasScheduleList = kvp.Value;

                foreach (Schedule klasSchedule in KlasScheduleList)
                {
                    if (!klasSchedule.category.Equals("Personal"))
                    {
                        klasSchedule.category = KlasCategory[key];
                        if (Convert.ToInt32(klasSchedule.startDate.ToString("MM")) == month && KSCS_static.category.IsChecked(KSCS_static.TabName, klasSchedule.category))
                        {
                            monthScheduleList[Convert.ToInt32(klasSchedule.startDate.ToString("dd")) - 1].Add(klasSchedule);
                        }
                        
                    }
                }
            }
        }

        static public void LoadTotalScheduleList()
        {
            foreach (KeyValuePair<string, List<List<Schedule>>> kvp in ShareNum_ScheduleList)
            {
                string key = kvp.Key;
                List<List<Schedule>> memberScheduleList = kvp.Value;

                int i = 0;
                foreach (List<Schedule> dayScheduleList in memberScheduleList)
                {
                    monthScheduleList[i++].AddRange(dayScheduleList);
                }
            }
        }

    }
}
