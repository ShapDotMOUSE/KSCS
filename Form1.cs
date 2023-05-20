using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KSCS
{
    public partial class KSCS : Form
    {
        private Point mousePoint;
        private int year, month;
        public static int static_month, static_year;
        MySqlConnection connection = DatabaseConnection.getDBConnection(); //MySQL
        public static List<List<Schedule>> monthScheduleList = new List<List<Schedule>>(); //한달 단위 schedule list
        public static Dictionary<string, string[]> categoryDict = new Dictionary<string, string[]>(); //category dictionary
        public static string student_id = "2019203082"; //초기 학번
        public KSCS()
        {
            InitializeComponent();
            connection.Open(); //MySQL 연결
            
        }

        public void InitializeDatabase()
        {
            string selectQuery = string.Format("SELECT * from Schedule JOIN Category ON Schedule.category_id=Category.id JOIN StudentCategory ON StudentCategory.student_id=Schedule.student_id and Schedule.category_id=Category.id and Category.id=StudentCategory.category_id WHERE Schedule.student_id={0} and  startDate BETWEEN DATE_FORMAT('{1}', '%Y-%m-%d') AND LAST_DAY('{1}') ORDER BY startDate ASC;", student_id, new DateTime(year, month, 1).ToString("yyyy-MM-dd"));
            MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
            MySqlDataReader table = cmd.ExecuteReader();
            //MessageBox.Show(new DateTime(year, month, 1).ToString("yyyy-MM-dd"));
            monthScheduleList.Clear(); //한달 스케줄 초기화

            //하루 단위 리스트 생성
            for (int i = 0; i < DateTime.DaysInMonth(year, month); i++)
            {
                monthScheduleList.Add(new List<Schedule>());
            }

            while (table.Read())
            {
                //MessageBox.Show(table["type"].ToString());

                Schedule schedule = new Schedule(
                    table["title"].ToString(),
                    table["content"].ToString(),
                    table["place"].ToString(),
                    table["type"].ToString(),
                    DateTime.Parse(table["startDate"].ToString()),
                    DateTime.Parse(table["endDate"].ToString()))
                {
                    id = int.Parse(table["id"].ToString()),
                };

                monthScheduleList[Convert.ToInt32(schedule.startDate.ToString("dd")) - 1].Add(schedule);
            }
            
            table.Close();
            LoadCategory(); //추가
        }

        private void LoadCategory()
        {
            categoryDict.Clear();
            string selectQuery = string.Format("SELECT * from Category JOIN StudentCategory ON Category.id=StudentCategory.category_id WHERE student_id='{0}';", student_id);
            MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
            MySqlDataReader table = cmd.ExecuteReader();
            while (table.Read())
            {
                categoryDict.Add(table["type"].ToString(), new string[2] { table["id"].ToString(), table["color"].ToString() });
            }
            table.Close();
        }

        private void KSCS_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(58, 5, 31);
            seperator_vertical.FillColor = Color.FromArgb(245, 245, 245);
            seperator_horizon.FillColor = Color.FromArgb(245, 245, 245);
            category_underline.BackColor = Color.FromArgb(58, 5, 31);
            dispalyDate();
            AddCategory("학사일정"); //수정해야 함
            AddCategory("테스트용"); //수정해야 함
        }

        private void dispalyDate()
        {
            DateTime now = DateTime.Now;

            year = now.Year;
            month = now.Month;
            createDates();
        }

        private void createDates()
        {
            static_month = month;
            static_year = year;

            InitializeDatabase(); //MySQL 에서 한달 스케줄 데이터 가져오기

            lblMonth.Text = month.ToString() + "월";
            lblMonth.TextAlign = ContentAlignment.MiddleCenter;

            DateTime startOfMonth = new DateTime(year, month, 1);
            int dates = DateTime.DaysInMonth(year, month);
            int dayOfWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d")) + 1;

            daysConatiner.Controls.Clear();
            for (int i = 1; i < dayOfWeek; i++)
            {
                UserBlankDate userblankDate = new UserBlankDate();
                daysConatiner.Controls.Add(userblankDate);
            }

            for (int i = 1; i < dates; i++)
            {
                UserDate userDate = new UserDate();
                userDate.SetDate(i);
                //UserDate userDate = new UserDate(i);
                daysConatiner.Controls.Add(userDate);
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void KSCS_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint=new Point(e.X, e.Y);
        }

        private void KSCS_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                int x = mousePoint.X - e.X;
                int y = mousePoint.Y - e.Y;
                Location = new Point(this.Left - x, this.Top - y);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(month == 12)
            {
                month = 1; year++;
            }
            else
            {
                month++;
            }
            createDates();
        }

        private void btnPrvious_Click(object sender, EventArgs e)
        {
            if (month == 1)
            {
                month = 12; year--;
            }
            else
            {
                month--;
            }
            createDates();
        }

        private void AddCategory(string category)
        {
            UserCheckedCategory checkedCategory = new UserCheckedCategory();
            checkedCategory.SetlblCategoryName(category);
            categoryContainer.Controls.Add(checkedCategory);
        }
    }
}
