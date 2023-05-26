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
        public static string stdNum;
        public static KLAS klas = new KLAS();
        public static Category category = new Category();
        public static Dictionary<string, string[]> categoryDict = new Dictionary<string, string[]>(); //category dictionary
        public static List<List<Schedule>> monthScheduleList = new List<List<Schedule>>(); //한달 단위 schedule list
        public static Dictionary<string, List<Schedule>> KlasSchedule = new Dictionary<string, List<Schedule>>()
        {
            { "Task",new List<Schedule>()} ,
            { "Quiz", new List<Schedule>()},
            { "Online",new List<Schedule>()} ,
            { "Prjct",new List<Schedule>()} ,
            { "Personal",new List<Schedule>()} ,
        };
        public static int year, month;

    }
}
