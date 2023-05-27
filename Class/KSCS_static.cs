using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace KSCS.Class
{
    public class KSCS_static
    {
        //학번
        public static string stdNum;
        //탭
        public static string TabName=null;
        //클라스
        public static KLAS klas = new KLAS();
        //카테고리
        public static Category category = new Category();
        //스케줄
        public static List<List<Schedule>> monthScheduleList = new List<List<Schedule>>(); //한달 단위 schedule list
        //클라스 스케줄
        public static Dictionary<string, List<Schedule>> KlasSchedule = new Dictionary<string, List<Schedule>>()
        {
            { "Task",new List<Schedule>()} ,
            { "Quiz", new List<Schedule>()},
            { "Online",new List<Schedule>()} ,
            { "Prjct",new List<Schedule>()} ,
            { "Personal",new List<Schedule>()} ,
        };
        //달력 년도, 월
        public static int year, month;

    }
}
