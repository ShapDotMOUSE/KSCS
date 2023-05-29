using KSCS.Class;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KSCS.Class.KSCS_static;
using static System.ComponentModel.Design.ObjectSelectorEditor;

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


        //스케줄 관련======================================================================
        public static void ReadScheduleList()
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
                    DateTime.Parse(table["endDate"].ToString()))
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


        public static void CreateScheudle(Schedule schedule)
        {
            string insertQuery = string.Format("INSERT INTO Schedule(student_id,title,content,place,category_id,startDate,endDate)" +
                "VALUES ('{0}','{1}','{2}','{3}',(SELECT id FROM Category WHERE category_name='{4}' and student_id='{0}'),'{5}','{6}');",
                    stdNum,
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

        public static void UpdateSchedule(Schedule schedule, int index)
        {
            string updateQuery = string.Format("UPDATE Schedule SET title='{0}', content='{1}', place='{2}', category_id=(SELECT id FROM Category WHERE category_name='{3}' AND student_id='{4}'),startDate='{5}', endDate='{6}' WHERE id={7};",
                    schedule.title,
                    schedule.content,
                    schedule.place,
                    schedule.category,
                    stdNum,
                    schedule.startDate.ToString("yyyy-MM-dd, HH:mm"),
                    schedule.endDate.ToString("yyyy-MM-dd, HH:mm"),
                    monthScheduleList[UserDate.static_date - 1][index].id
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

        //tabScheduleList
        public static void ReadTabScheduleList()
        {
            string selectQuery = string.Format("SELECT * FROM Schedule JOIN Category ON Schedule.category_id=Category.id" +
            " WHERE Schedule.student_id='{0}' AND (startDate BETWEEN DATE_FORMAT('{1}', '%Y-%m-%d') AND LAST_DAY('{1}') OR" +
            " endDate BETWEEN DATE_FORMAT('{1}', '%Y-%m-%d') AND LAST_DAY('{1}'))" +
            "AND Schedule.category_id IN (SELECT TabCategory.category_id FROM TabCategory JOIN StudentTab ON StudentTab.id=TabCategory.tab_id WHERE StudentTab.tab_name='{2}' AND Schedule.student_id='{0}') " +
            "ORDER BY startDate ASC;", stdNum, new DateTime(year, month, 1).ToString("yyyy-MM-dd"),TabName);
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
                    DateTime.Parse(table["endDate"].ToString()))
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
                    "(SELECT id FROM Category WHERE student_id='{1}' AND category_name='{2}'))", Tab, stdNum, Sub);

            MySqlCommand cmd = new MySqlCommand(insertQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Insert Data.");
        }

        public static void DeleteTabCategory(string Tab, string Sub)
        {
            string deleteQuery = string.Format("DELETE FROM TabCategory WHERE" +
                " tab_id=(SELECT id FROM StudentTab WHERE tab_name='{0}' AND student_id='{1}') AND" +
                " category_id=(SELECT id FROM Category WHERE student_id='{1}' AND category_name='{2}')", Tab, stdNum, Sub);
            MySqlCommand cmd = new MySqlCommand(deleteQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Delete Data.");
        }

        public static void ReadCategoryList()
        {
            //대분류 소분류 한번에
            string selectQuery = string.Format("SELECT parent.category_name AS parent_category_name, category.category_name AS category_name, category.color AS color FROM KSCS.Category AS parent LEFT OUTER JOIN KSCS.Category AS category on category.parent_category_id=parent.id WHERE category.student_id='{0}';", stdNum);
            MySqlCommand cmd = new MySqlCommand(selectQuery, getDBConnection());
            MySqlDataReader table = cmd.ExecuteReader();
            while (table.Read())
            {
                category.AddSubdivision(table["parent_category_name"].ToString(), table["category_name"].ToString());
                category.SetColor(table["category_name"].ToString(), Color.FromArgb(int.Parse(table["color"].ToString())));
            }

            table.Close();
        }

        public static void CreateSubCategory()
        {
            string insertQuery = string.Format("INSERT INTO () VALUES ();");
            MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to insert Data.");
            //cmd.CommandText = "SELECT LAST_INSERT_ID() AS id";
            //MySqlDataReader table = cmd.ExecuteReader();
            //table.Read();
            //.id = int.Parse(table["id"].ToString());
            //table.Close();
        }

        public static void UpdateSubCategory()
        {
            string updateQuery = string.Format("UPDATE Schedule SET ");
            MySqlCommand cmd = new MySqlCommand(updateQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Update Data.");
        }

        public static void DeleteSubCategory()
        {
            string deleteQuery = string.Format("DELETE FROM   WHERE id='{0}';");
            MySqlCommand cmd = new MySqlCommand(deleteQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Delete Data.");
        }

        public static void CreateParentCategory()
        {
            string insertQuery = string.Format("INSERT INTO () VALUES ();");
            MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to insert Data.");
            //cmd.CommandText = "SELECT LAST_INSERT_ID() AS id";
            //MySqlDataReader table = cmd.ExecuteReader();
            //table.Read();
            //.id = int.Parse(table["id"].ToString());
            //table.Close();
        }
        public static void UpdateParentCategory()
        {
            string updateQuery = string.Format("UPDATE Schedule SET ");
            MySqlCommand cmd = new MySqlCommand(updateQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Update Data.");
        }

        public static void DeleteParentCategory()
        {
            string deleteQuery = string.Format("DELETE FROM   WHERE id='{0}';");
            MySqlCommand cmd = new MySqlCommand(deleteQuery, getDBConnection());
            if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Delete Data.");
        }



    }
}
