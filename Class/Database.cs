using KSCS.Class;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static KSCS.Class.KSCS_static;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KSCS
{
    public static class Database
    {
        static MySqlConnection connection = null;
        public static MySqlConnection getDBConnection()
        {
            if (connection == null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString;
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            return connection;
        }

        //초기 데이터 생성================================================================
        public static void CreateData()
        {
            string selectQuery = string.Format("SELECT id from Student WHERE id='{0}';", stdNum);

            MySqlCommand cmd = new MySqlCommand(selectQuery, getDBConnection());
            MySqlDataReader table = cmd.ExecuteReader();
            if (!table.HasRows)
            {
                table.Close();
                cmd.CommandText = string.Format("INSERT INTO Student(id) VALUES('{0}')", stdNum);
                if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to insert Data.");

                cmd.CommandText = string.Format("INSERT INTO Category(category_name, parent_category_id, color, student_id) VALUES" +
                        "('KLAS', null, null, '{0}')," +
                        "('개인', null, null, '{0}')," +
                        "('기타', null, null, '{0}')", stdNum);
                if (cmd.ExecuteNonQuery() != 3) MessageBox.Show("Failed to insert Data.");

                string idQuery1 = string.Format("SELECT id FROM Category WHERE category_name='KLAS' AND student_id={0}", stdNum);
                MySqlCommand cmd1 = new MySqlCommand(idQuery1, getDBConnection());
                MySqlDataReader table1 = cmd1.ExecuteReader();
                table1.Read();
                int idKLAS = int.Parse(table1["id"].ToString());
                table1.Close();

                string idQuery2 = string.Format("SELECT id FROM Category WHERE category_name='기타' AND student_id={0}", stdNum);
                MySqlCommand cmd2 = new MySqlCommand(idQuery2, getDBConnection());
                MySqlDataReader table2 = cmd2.ExecuteReader();
                table2.Read();
                int idETC = int.Parse(table2["id"].ToString());
                table2.Close();

                cmd.CommandText = string.Format(
                    "INSERT INTO Category(category_name, parent_category_id, color, student_id) VALUES " +
                       "('학사일정','{1}', '{3}', '{0}')," +
                       "('과제', '{1}', '{3}', '{0}')," +
                       "('퀴즈', '{1}', '{3}', '{0}')," +
                       "('온라인 강의', '{1}', '{3}', '{0}')," +
                       "('기타', '{2}', '{4}', '{0}')," +
                       "('공유 일정', '{2}', '{4}', '{0}')", stdNum, idKLAS, idETC, Color.FromArgb(58,5,31).ToArgb(), Color.Black.ToArgb());
                if (cmd.ExecuteNonQuery() != 6) MessageBox.Show("Failed to insert Data.");

                cmd.CommandText = string.Format("INSERT INTO StudentTab(tab_name, student_id) VALUES " +
                        "('All','{0}')," +
                        "('Tab1','{0}')," +
                        "('Tab2','{0}')," +
                        "('Tab3','{0}')," +
                        "('Tab4','{0}')", stdNum);
                if (cmd.ExecuteNonQuery() != 5) MessageBox.Show("Failed to insert Data.");

            }
            else table.Close();
        }


        //아이피 얻기
        public static Dictionary<string,string> GetAddress(List<string> stdNumList)
        {
            Dictionary<string, string> addressList = new Dictionary<string, string>();
            string selectQuery = string.Format("SELECT * FROM Student WHERE id IN ({0})", string.Join(",", stdNumList.Select(id => string.Format("'{0}'", id))));
            MySqlCommand cmd = new MySqlCommand(selectQuery, getDBConnection());
            MySqlDataReader table = cmd.ExecuteReader();
            while (table.Read())
            {
                if (!string.IsNullOrEmpty(table["address"].ToString()))
                    addressList[table["id"].ToString()]= table["address"].ToString();
            }
            table.Close();
            return addressList;
        }

        public static void SetAddress()
        {
            string localIP = string.Empty;
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            string updateQuery = string.Format("UPDATE Student SET address='{0}' WHERE id='{1}'",localIP, stdNum);
            MySqlCommand cmd = new MySqlCommand(updateQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to insert Data.");
        }   

        public static void DeleteAddress()
        {
            string updateQuery = string.Format("UPDATE Student SET address='' WHERE id='{0}'", stdNum);
            MySqlCommand cmd = new MySqlCommand(updateQuery, getDBConnection());
            cmd.ExecuteNonQuery();
        }

        //스케줄 관련======================================================================
        public static void ReadScheduleList() //이제 사용 X
        {
            string selectQuery = string.Format("SELECT * FROM Schedule JOIN Category ON Schedule.category_id=Category.id" +
            " WHERE Schedule.student_id={0} AND (startDate BETWEEN DATE_FORMAT('{1}', '%Y-%m-%d') AND LAST_DAY('{1}') OR" +
            " endDate BETWEEN DATE_FORMAT('{1}', '%Y-%m-%d') AND LAST_DAY('{1}')) ORDER BY startDate ASC;", stdNum, new DateTime(year, month, 1).ToString("yyyy-MM-dd"));
            MySqlCommand cmd = new MySqlCommand(selectQuery, getDBConnection());
            MySqlDataReader table = cmd.ExecuteReader();
            monthScheduleList.Clear(); //한달 스케줄 초기화

            //하루 단위 리스트 생성
            for (int i = 0; i < DateTime.DaysInMonth(year, month); i++)
            {
                monthScheduleList.Add(new List<Schedule>());
            }

            while (table.Read())
            {
                Schedule schedule = new Schedule(
                    table["title"].ToString(),
                    table["content"].ToString(),
                    table["place"].ToString(),
                    table["category_name"].ToString(),
                    DateTime.Parse(table["startDate"].ToString()),
                    DateTime.Parse(table["endDate"].ToString()),
                    null //쿼리바꾸고, 가져오는걸로 바꿔야 함.
                    )
                {
                    id = int.Parse(table["id"].ToString()),
                };

                /* 리스트 추가 */
                //startDate와 endDate 일자가 다른 경우도 포함
                TimeSpan duration = schedule.endDate - schedule.startDate;
                for (int i = 0; i <= duration.Days; i++)
                {
                    if (Convert.ToInt32(schedule.startDate.AddDays(i).ToString("MM")) == month)
                    {
                        monthScheduleList[Convert.ToInt32(schedule.startDate.AddDays(i).ToString("dd")) - 1].Add(schedule);
                    }
                }
            }

            table.Close();
        }


        public static void CreateScheudle(Schedule schedule, String studentId)
        {
            string insertQuery = string.Format("INSERT INTO Schedule(student_id,title,content,place,category_id,startDate,endDate)" +
                "VALUES ('{0}','{1}','{2}','{3}',(SELECT id FROM Category WHERE category_name='{4}' and student_id='{0}' and parent_category_id IS NOT NULL),'{5}','{6}');",
                    studentId,
                    schedule.title,
                    schedule.content,
                    schedule.place,
                    schedule.category,
                    schedule.startDate.ToString("yyyy-MM-dd HH:mm"),
                    schedule.endDate.ToString("yyyy-MM-dd HH:mm"));
            MySqlCommand cmd = new MySqlCommand(insertQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to insert Data.");
            //추가 후, id 값 가져오기
            cmd.CommandText = "SELECT LAST_INSERT_ID() AS id";
            MySqlDataReader table = cmd.ExecuteReader();
            table.Read();
            schedule.id = int.Parse(table["id"].ToString());
            table.Close();
        }

        //추가(공유 멤버가 존재하는 경우)
        public static void CreateMember(Schedule schedule)
        {
            for (int i = 0; i < schedule.members.Count; i++)
            {
                Schedule sharedSchedule = new Schedule(schedule.title, schedule.content, schedule.place, schedule.category, schedule.startDate, schedule.endDate, schedule.members);
                CreateScheudle(sharedSchedule,schedule.members[i]); // 멤버들도 스케줄 추가

                string insertQuery = string.Format("INSERT INTO Members(schedule_id,student_id,main_schedule_id) VALUES ({0},'{1}',{2});", sharedSchedule.id, schedule.members[i], schedule.id);
                MySqlCommand cmd = new MySqlCommand(insertQuery, getDBConnection());
                if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to insert Data.");
            }
            //main_schedule_id 도 db에 추가
            string insertQuery2 = string.Format("INSERT INTO Members(schedule_id,student_id,main_schedule_id) VALUES ({0},'{1}',{2});", schedule.id, stdNum, schedule.id);
            MySqlCommand cmd2 = new MySqlCommand(insertQuery2, getDBConnection());
            if (cmd2.ExecuteNonQuery() != 1) MessageBox.Show("Failed to insert Data.");
        }

        public static void UpdateSchedule(Schedule schedule, string studentId)
        {
            string updateQuery = string.Format("UPDATE Schedule SET title='{0}', content='{1}', place='{2}', category_id=(SELECT id FROM Category WHERE category_name='{3}' AND student_id='{4}' AND parent_category_id IS NOT NULL),startDate='{5}', endDate='{6}' WHERE id={7};",
                    schedule.title,
                    schedule.content,
                    schedule.place,
                    schedule.category,
                    studentId,
                    schedule.startDate.ToString("yyyy-MM-dd, HH:mm"),
                    schedule.endDate.ToString("yyyy-MM-dd, HH:mm"),
                    schedule.id
                    //monthScheduleList[UserDate.static_date - 1][index].id
                    );
            MySqlCommand cmd = new MySqlCommand(updateQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Update Data.");
        }

        //멤버 스케줄 수정
        public static void UpdateMemberSchedule(Schedule schedule, string studentId)
        {
            string updateQuery = string.Format("UPDATE Schedule SET title='{0}', content='{1}', place='{2}', category_id=(SELECT id FROM Category WHERE category_name='{3}' AND student_id='{4}'),startDate='{5}', endDate='{6}' WHERE id IN (SELECT schedule_id FROM Members WHERE student_id='{4}' AND main_schedule_id IN (SELECT main_schedule_id FROM Members WHERE schedule_id={7}));",
                    schedule.title,
                    schedule.content,
                    schedule.place,
                    schedule.category,
                    studentId,
                    schedule.startDate.ToString("yyyy-MM-dd, HH:mm"),
                    schedule.endDate.ToString("yyyy-MM-dd, HH:mm"),
                    schedule.id
                    //monthScheduleList[UserDate.static_date - 1][index].id
                    );
            MySqlCommand cmd = new MySqlCommand(updateQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Update Data.");
        }

        public static void DeleteSchedule(int index)
        {
            string deleteQuery = string.Format("DELETE FROM Schedule WHERE id='{0}';", monthScheduleList[UserDate.static_date - 1][index].id);
            MySqlCommand cmd = new MySqlCommand(deleteQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Delete Data.");
        }

        //멤버 스케줄 삭제(cascade Delete)
        public static void DeleteMemberSchedule(int index, string studentId)
        {
            string deleteQuery = string.Format("DELETE FROM Schedule WHERE id = (SELECT schedule_id FROM Members WHERE student_id='{1}' AND main_schedule_id = (SELECT main_schedule_id FROM Members WHERE schedule_id={0}));", monthScheduleList[UserDate.static_date - 1][index].id,studentId);
            MySqlCommand cmd = new MySqlCommand(deleteQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Delete Data.");
        }

        //멤버 삭제(사용 X)
        //public static void DeleteMember(int index, string studentId)
        //{
        //    string deleteQuery = string.Format("DELETE FROM Members WHERE main_schedule_id IN (SELECT main_schedule_id FROM Members WHERE schedule_id = {0}) AND student_id = '{1}';", monthScheduleList[UserDate.static_date - 1][index].id, studentId);
        //    MySqlCommand cmd = new MySqlCommand(deleteQuery, getDBConnection());
        //    if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Delete Data.");
        //}

        //tabScheduleList
        public static void ReadTabScheduleList()
        {
            string selectQuery = string.Format("SELECT * FROM (SELECT Schedule.id AS schedule_id, Schedule.student_id, Category.id AS category_id, Schedule.startDate, Schedule.endDate," +
                "Schedule.status, Schedule.title, Schedule.content, Schedule.place, Schedule.alarmStatus, Category.category_name, Category.parent_category_id, Category.color " +
                "FROM Schedule JOIN Category ON Schedule.category_id = Category.id " +
                "WHERE Schedule.student_id = '{0}' AND (startDate BETWEEN DATE_FORMAT('{1}', '%Y-%m-%d') AND LAST_DAY('{1}') " +
                "OR endDate BETWEEN DATE_FORMAT('{1}', '%Y-%m-%d') AND LAST_DAY('{1}')) AND Schedule.category_id " +
                "IN(SELECT TabCategory.category_id FROM TabCategory JOIN StudentTab ON StudentTab.id = TabCategory.tab_id WHERE StudentTab.tab_name = '{2}' AND Schedule.student_id = '{0}')) AS AllSchedule " +
                "LEFT OUTER JOIN (SELECT m1.schedule_id, GROUP_CONCAT(m2.student_id) AS concatenated_student_ids FROM Members m1 INNER JOIN Members m2 ON m1.main_schedule_id = m2.main_schedule_id GROUP BY m1.schedule_id) AS MemberList ON AllSchedule.schedule_id = MemberList.schedule_id ORDER BY startDate ASC;",
                stdNum, new DateTime(year, month, 1).ToString("yyyy-MM-dd"), TabName);
            MySqlCommand cmd = new MySqlCommand(selectQuery, getDBConnection());
            MySqlDataReader table = cmd.ExecuteReader();
            monthScheduleList.Clear(); //한달 스케줄 초기화

            //하루 단위 리스트 생성
            for (int i = 0; i < DateTime.DaysInMonth(year, month); i++)
            {
                monthScheduleList.Add(new List<Schedule>());
            }

            while (table.Read())
            {
                char delimiter = ','; // 구분자
                string[] parts = table["concatenated_student_ids"].ToString().Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
                List<string> members = new List<string>(parts);
                members.Remove(stdNum); //자신의 학번은 삭제

                Schedule schedule = new Schedule(
                    table["title"].ToString(),
                    table["content"].ToString(),
                    table["place"].ToString(),
                    table["category_name"].ToString(),
                    DateTime.Parse(table["startDate"].ToString()),
                    DateTime.Parse(table["endDate"].ToString()),
                    members
                    )
                {
                    id = int.Parse(table["schedule_id"].ToString()),
                };

                /* 리스트 추가 */
                //startDate와 endDate 일자가 다른 경우도 포함
                TimeSpan duration = schedule.endDate - schedule.startDate;
                for (int i = 0; i <= duration.Days; i++)
                {
                    if (Convert.ToInt32(schedule.startDate.AddDays(i).ToString("MM")) == month)
                    {
                        monthScheduleList[Convert.ToInt32(schedule.startDate.AddDays(i).ToString("dd")) - 1].Add(schedule);
                    }
                }
            }

            table.Close();
        }

        public static void ReadShareScheduleList(string shareNum,List<string> categoryList)
        {
            string selectQuery = string.Format("SELECT * FROM (SELECT Schedule.id AS schedule_id, Schedule.student_id, Category.id AS category_id, Schedule.startDate, Schedule.endDate, Schedule.status, Schedule.title, Schedule.content, Schedule.place, Schedule.alarmStatus, Category.category_name, Category.parent_category_id, Category.color " +
                "FROM Schedule JOIN Category ON Schedule.category_id = Category.id " +
                "WHERE Schedule.student_id = '{0}' AND(startDate BETWEEN DATE_FORMAT('{1}', '%Y-%m-%d') AND LAST_DAY('{1}') " +
                "OR endDate BETWEEN DATE_FORMAT('{1}', '%Y-%m-%d') AND LAST_DAY('{1}')) AND Schedule.category_id " +
                "IN(SELECT Category.id FROM Category WHERE(Category.student_id = '{0}' AND Category.parent_category_id IS NOT NULL) AND Category.category_name IN {2})) AS AllSchedule",
                shareNum, new DateTime(2023, 6, 1).ToString("yyyy-MM-dd"), string.Join(",", categoryList)); //categoryList->string.Join(",", categoryList) 로 수정
            MySqlCommand cmd = new MySqlCommand(selectQuery, getDBConnection());
            MySqlDataReader table = cmd.ExecuteReader();
            monthScheduleList.Clear(); //한달 스케줄 초기화

            //하루 단위 리스트 생성
            for (int i = 0; i < DateTime.DaysInMonth(year, month); i++)
            {
                monthScheduleList.Add(new List<Schedule>());
            }

            while (table.Read())
            {
                char delimiter = ','; // 구분자
                string[] parts = table["concatenated_student_ids"].ToString().Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
                List<string> members = new List<string>(parts);
                members.Remove(stdNum); //자신의 학번은 삭제

                Schedule schedule = new Schedule(
                    table["title"].ToString(),
                    table["content"].ToString(),
                    table["place"].ToString(),
                    table["category_name"].ToString(),
                    DateTime.Parse(table["startDate"].ToString()),
                    DateTime.Parse(table["endDate"].ToString()),
                    members
                    )
                {
                    id = int.Parse(table["schedule_id"].ToString()),
                };

                /* 리스트 추가 */
                //startDate와 endDate 일자가 다른 경우도 포함
                TimeSpan duration = schedule.endDate - schedule.startDate;
                for (int i = 0; i <= duration.Days; i++)
                {
                    if (Convert.ToInt32(schedule.startDate.AddDays(i).ToString("MM")) == month)
                    {
                        monthScheduleList[Convert.ToInt32(schedule.startDate.AddDays(i).ToString("dd")) - 1].Add(schedule);
                    }
                }
            }

            table.Close();
        }


        //탭관련=============================
        public static List<string> ReadTab()
        {
            List<string> list = new List<string>();
            string selectQuery = string.Format("SELECT * FROM StudentTab WHERE student_id='{0}' ORDER BY id", stdNum);
            MySqlCommand cmd = new MySqlCommand(selectQuery, getDBConnection());
            MySqlDataReader table = cmd.ExecuteReader();

            while (table.Read())
            {
                list.Add(table["tab_name"].ToString());
            }
            table.Close();
            return list;
        }

        public static void ReadTabAndCategory()//탭 이름 얻어오기
        {
            string selectQuery = string.Format("SELECT * FROM StudentTab LEFT OUTER JOIN TabCategory on StudentTab.id=TabCategory.tab_id" +
                " LEFT OUTER JOIN Category on Category.id=TabCategory.category_id WHERE StudentTab.student_id='{0}' ORDER BY StudentTab.id", stdNum);
            MySqlCommand cmd = new MySqlCommand(selectQuery, getDBConnection());
            MySqlDataReader table = cmd.ExecuteReader();
            Hashtable tabCategories = new Hashtable();
            while (table.Read())
            {
                if (TabName == null) TabName = table["tab_name"].ToString();
                if (!tabCategories.Contains(table["tab_name"].ToString()))//탭 이름 존재 안하면 추가
                    tabCategories[table["tab_name"].ToString()] = new HashSet<string>();
                if (table["category_name"] != null)
                    (tabCategories[table["tab_name"].ToString()] as HashSet<string>).Add(table["category_name"].ToString());
            }
            category.LoadTab(tabCategories);

            table.Close();
        }

        public static void UpdateTabName(string name, int index)
        {
            string updateQuery = string.Format(" UPDATE StudentTab SET tab_name={0} WHERE student_id={1} ORDER BY id LIMIT 1 OFFSET {2}", name, stdNum, index);
            MySqlCommand cmd = new MySqlCommand(updateQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Update Data.");
        }

        public static void InsertTabCategory(string Tab, string Sub)
        {
            string insertQuery = string.Format("INSERT INTO TabCategory(tab_id,category_id) VALUES (" +
                    "(SELECT id FROM StudentTab WHERE tab_name='{0}' AND student_id='{1}')," +
                    "(SELECT id FROM Category WHERE student_id='{1}' AND category_name='{2}' AND parent_category_id IS NOT NULL))", Tab, stdNum, Sub);

            MySqlCommand cmd = new MySqlCommand(insertQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Insert Data.");
        }

        public static void DeleteTabCategory(string Tab, string Sub)
        {
            string deleteQuery = string.Format("DELETE FROM TabCategory WHERE" +
                " tab_id=(SELECT id FROM StudentTab WHERE tab_name='{0}' AND student_id='{1}') AND" +
                " category_id=(SELECT id FROM Category WHERE student_id='{1}' AND category_name='{2}' AND parent_category_id IS NOT NULL)", Tab, stdNum, Sub);
            MySqlCommand cmd = new MySqlCommand(deleteQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Delete Data.");
        }

        public static void ReadCategoryList()
        {
            //대분류 소분류 한번에
            string selectQuery = string.Format("SELECT parent.category_name AS parent_category_name, category.category_name AS category_name, category.color AS color FROM KSCS.Category AS parent RIGHT OUTER JOIN KSCS.Category AS category on category.parent_category_id=parent.id WHERE category.student_id='{0}';", stdNum);
            MySqlCommand cmd = new MySqlCommand(selectQuery, getDBConnection());
            MySqlDataReader table = cmd.ExecuteReader();
            while (table.Read())
            {
                if (!string.IsNullOrEmpty(table["parent_category_name"].ToString()))
                {
                    category.AddSubdivision(table["parent_category_name"].ToString(), table["category_name"].ToString());
                    category.SetColor(table["category_name"].ToString(), Color.FromArgb(int.Parse(table["color"].ToString())));
                }
                else
                {
                    category.AddParent(table["category_name"].ToString());
                }
            }

            table.Close();
        }

        public static void CreateSubCategory(string Parent, string Sub)
        {
            string insertQuery = string.Format("INSERT INTO Category(category_name, parent_category_id,color,student_id) VALUES (" +
                "'{0}'," +
                "(SELECT id FROM (SELECT id FROM Category WHERE category_name='{1}' and student_id={2} AND parent_category_id IS NULL) A)," +
                "{3}, '{2}');", Sub,Parent,stdNum, Color.Black.ToArgb());
            MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            cmd.ExecuteNonQuery();

            string insertQueryTab = string.Format("INSERT INTO TabCategory(tab_id,category_id) VALUES (" +
                    "(SELECT id FROM StudentTab WHERE tab_name='All' AND student_id={0})," +
                    "(SELECT id FROM Category WHERE student_id={0} AND category_name='{1}' AND parent_category_id IS NOT NULL))", stdNum, Sub);
            MySqlCommand cmd2 = new MySqlCommand(insertQueryTab, connection);
            if (cmd2.ExecuteNonQuery() != 1) MessageBox.Show("Failed to insert Data.");
            //cmd.CommandText = "SELECT LAST_INSERT_ID() AS id";
            //MySqlDataReader table = cmd.ExecuteReader();
            //table.Read();
            //.id = int.Parse(table["id"].ToString());
            //table.Close();
        }

        public static void UpdateSubCategory(string New, string old)
        {
            string updateQuery = string.Format("UPDATE Category SET category_name='{0}'" +
                "WHERE category_name='{1}' AND student_id={2} AND parent_category_id IS NOT NULL", New, old, stdNum);
            MySqlCommand cmd = new MySqlCommand(updateQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Update Data.");
        }

        public static void UpdateParentCategoryOfSubCategory(string NewMain, string Sub)
        {
            //KEY가 아닌 값을 이용한 업데이트를 위한 일시적인 안전모드 해제
            string setQuery = string.Format("set sql_safe_updates=0");
            MySqlCommand cmd2 = new MySqlCommand(setQuery, getDBConnection());
            cmd2.ExecuteNonQuery();

            string updateQuery = string.Format("UPDATE Category SET parent_category_id=" +
                "(SELECT id FROM " +
                "(SELECT id FROM Category WHERE category_name='{0}' AND student_id={2} AND parent_category_id IS NULL) A )" +
                "WHERE category_name='{1}' AND student_id={2} AND parent_category_id IS NOT NULL", NewMain, Sub, stdNum);
            MySqlCommand cmd = new MySqlCommand(updateQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Update Data.");
        }

        public static void UpdateSubCategoryColor(string Sub, Color color)
        {
            string updateQuery = string.Format("UPDATE Category SET color=" +
                "{0} WHERE category_name='{1}' AND student_id={2} AND parent_category_id IS NOT NULL", color.ToArgb(), Sub, stdNum);
            MySqlCommand cmd = new MySqlCommand(updateQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Update Data.");
        }

        public static void DeleteSubCategory(string Sub)
        {
            //해당 카테고리를 참고하던 스케줄 기타 카테고리로 변경
            string setQuery = string.Format("set sql_safe_updates=0");
            MySqlCommand cmd = new MySqlCommand(setQuery, getDBConnection());
            cmd.ExecuteNonQuery();

            string updateSheduleQuery = string.Format("UPDATE Schedule SET category_id=" +
                "(SELECT id FROM Category WHERE category_name='기타' AND student_id={0} AND parent_category_id IS NOT NULL) " +
                "WHERE student_id={0} AND category_id=" +
                "(SELECT id FROM Category WHERE student_id={0} AND category_name='{1}' AND parent_category_id IS NOT NULL)",
                stdNum,Sub);
            MySqlCommand cmd1 = new MySqlCommand(updateSheduleQuery, getDBConnection());
            if (cmd1.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Update Data.");

            //해당 카테고리를 참고하던 탭에서 해당 카테고리 삭제
            string deleteTabQuery = string.Format("DELETE FROM TabCategory WHERE category_id=" +
                "(SELECT id FROM Category WHERE student_id={0} AND category_name='{1}' AND parent_category_id IS NOT NULL);",
                stdNum,Sub);
            MySqlCommand cmd2 = new MySqlCommand(deleteTabQuery, getDBConnection());
            if (cmd2.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Delete Data.");

            //카테고리 삭제
            string deleteQuery = string.Format("DELETE FROM Category " +
                "WHERE student_id={0} AND category_name='{1}' AND parent_category_id IS NOT NULL;",
                stdNum, Sub);
            MySqlCommand cmd3 = new MySqlCommand(deleteQuery, getDBConnection());
            if (cmd3.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Delete Data.");
        }

        public static void CreateParentCategory(string Main)
        {
            string insertQuery = string.Format("INSERT INTO Category(category_name, student_id) VALUES ('{0}', {1});", Main, stdNum);
            MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to insert Data.");
            //cmd.CommandText = "SELECT LAST_INSERT_ID() AS id";
            //MySqlDataReader table = cmd.ExecuteReader();
            //table.Read();
            //.id = int.Parse(table["id"].ToString());
            //table.Close();
        }
        public static void UpdateParentCategory(string Old, string New)
        {
            string updateQuery = string.Format("UPDATE Category SET category_name = '{0}'" +
                "WHERE category_name='{1}' AND student_id={2} AND parent_category_id IS NULL", New,Old,stdNum);
            MySqlCommand cmd = new MySqlCommand(updateQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Update Data.");
        }

        public static void DeleteParentCategory(string Parent)
        {
            string deleteQuery = string.Format("DELETE FROM Category WHERE category_name='{0}' AND parent_category_id IS NULL", Parent);
            MySqlCommand cmd = new MySqlCommand(deleteQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Delete Data.");
        }



    }
}
