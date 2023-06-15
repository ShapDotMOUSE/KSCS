using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public static string TabName = null; //null -> 수정
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
        //실시간 공유
        public static Dictionary<string, bool> SharingCategory;
        public static Dictionary<string, Color> testStdNumColor = new Dictionary<string, Color>()
        {
             {"2019203082", Color.Red}, 
            {"2019203018",Color.Purple }, 
            {"2019203055", Color.PowderBlue},
            {"2019203045", Color.Pink },
            { "2021203078",Color.Aqua}

        };
        public static List<string> sharingMember;

        public static Dictionary<string, List<string>> ShareNumCategory=new Dictionary<string, List<string>>(); //추가
    }
}
