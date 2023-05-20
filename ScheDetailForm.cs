using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace KSCS
{
    public partial class ScheDetailForm : Form
    {
        public event EventHandler AddEvent;

        MySqlConnection connection = DatabaseConnection.getDBConnection();
        //List<Schedule> scheduleList = new List<Schedule>(); //하루 내의 schedule list
        //Dictionary<string, string[]> categoryDict = new Dictionary<string, string[]>();
        string student_id = "2019203082"; //초기 학번
        int selectedScheduleIndex=-1; 
        DateTime click_date = new DateTime(KSCS.static_year, KSCS.static_month, UserDate.static_date); //추가
        public ScheDetailForm()
        {
            InitializeComponent();
            InitializeGuna2DateTimePicker();
            //connection.Open();
            InitializeScheDetailForm();
            panelSchedules.VerticalScroll.Visible = false; 
        }

        //public void InitializeDatabase()
        //{
        //    string selectQuery = string.Format("SELECT * from Schedule JOIN Category ON Schedule.category_id=Category.id JOIN StudentCategory ON StudentCategory.student_id=Schedule.student_id and Schedule.category_id=Category.id and Category.id=StudentCategory.category_id WHERE Schedule.student_id={0} and DATE_FORMAT(startDate, '%Y-%m-%d') = '{1}' ORDER BY startDate ASC;", student_id, click_date.ToString("yyyy-MM-dd"));
        //    MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
        //    MySqlDataReader table = cmd.ExecuteReader();
        //    int index = 0;
        //    scheduleList.Clear();
        //    panelSchedules.Controls.Clear();

        //    while (table.Read())
        //    {
        //        Schedule schedule = new Schedule(
        //            table["title"].ToString(),
        //            table["content"].ToString(),
        //            table["place"].ToString(),
        //            table["type"].ToString(),
        //            DateTime.Parse(table["startDate"].ToString()),
        //            DateTime.Parse(table["endDate"].ToString())
        //            )
        //        {
        //            id = int.Parse(table["id"].ToString()),
        //        };
        //        scheduleList.Add(schedule);

        //        scheduleUnit scheduleUnit = new scheduleUnit
        //        {
        //            Name = "scdUnit" + index.ToString(),
        //            ScheduleTitle = schedule.title
        //        };

        //        scheduleUnit.ChangeScheduleColor(Color.FromArgb(int.Parse(table["color"].ToString())));
        //        scheduleUnit.btnClick += btnSchedule_Click;
        //        scheduleUnit.Location = new Point(9, 12 + index * (scheduleUnit.Height + 3));
        //        panelSchedules.Controls.Add(scheduleUnit);
        //        index++;
        //    }
        //    table.Close();
        //    //LoadCategory();
        //    btnAddSchedule.Location = new Point(24, 12 + index * 55);
        //    panelSchedules.Controls.Add(btnAddSchedule);
        //}

        //private void LoadCategory()
        //{
        //    cbCategory.Items.Clear();
        //    categoryDict.Clear();
        //    string selectQuery = string.Format("SELECT * from Category JOIN StudentCategory ON Category.id=StudentCategory.category_id WHERE student_id='{0}';", student_id);
        //    MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
        //    MySqlDataReader table = cmd.ExecuteReader();
        //    while (table.Read())
        //    {
        //        if (!cbCategory.Items.Contains(table["type"].ToString()))
        //        {
        //            cbCategory.Items.Add(table["type"].ToString());
        //            categoryDict.Add(table["type"].ToString(), new string[2] { table["id"].ToString(), table["color"].ToString() });
        //        }
        //    }
        //    table.Close();
        //}

        private void InitializeGuna2DateTimePicker()
        {
            //DateTime.Now -> 클릭한 날짜
            //DateTime click_date = new DateTime(KSCS.static_year, KSCS.static_month, UserDate.static_date);
            dtpStartDate.Value = DateTime.ParseExact(click_date.ToString("yyyy-MM-dd ddd"), "yyyy-MM-dd ddd", null);
            dtpStartTime.Value = DateTime.ParseExact("00:00", "HH:mm", null);
            dtpEndDate.Value = DateTime.ParseExact(click_date.ToString("yyyy-MM-dd ddd"), "yyyy-MM-dd ddd", null);
            dtpEndTime.Value = DateTime.ParseExact("00:00", "HH:mm", null);
        }

        private void ClearForm()
        {
            selectedScheduleIndex = -1;
            tbTitle.Text = "";
            tbMemo.Text = "";
            tbPlace.Text = "";
            cbCategory.SelectedItem= null;
            InitializeGuna2DateTimePicker();
        }

        private DateTime GetStartDateTime()
        {
            string yyyyMMdd = dtpStartDate.Value.ToString("yyyy-MM-dd ddd");
            string HHmm = dtpStartTime.Value.ToString("HH:mm");

            return DateTime.ParseExact(yyyyMMdd + ' ' + HHmm, "yyyy-MM-dd ddd HH:mm", null);
        }

        private DateTime GetEndDateTime()
        {
            string yyyyMMdd = dtpEndDate.Value.ToString("yyyy-MM-dd ddd");
            string HHmm = dtpEndTime.Value.ToString("HH:mm");

            return DateTime.ParseExact(yyyyMMdd + ' ' + HHmm, "yyyy-MM-dd ddd HH:mm", null);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e) // 추가&수정
        {
            if (tbTitle.Text == String.Empty)
            {
                MessageBox.Show("제목을 입력하세요");
                return;
            }
            if (cbCategory.SelectedItem == null)
            {
                MessageBox.Show("카테고리를 선택하세요");
                return;
            }

            Schedule schedule = new Schedule(tbTitle.Text, tbMemo.Text, tbPlace.Text, cbCategory.Text, GetStartDateTime(), GetEndDateTime());
            if (addBtn.Text == "Add")
            {
                
                
                string insertQuery = string.Format("INSERT INTO Schedule(student_id,title,content,place,category_id,startDate,endDate) VALUES ('2019203082','{0}','{1}','{2}','{3}','{4}','{5}');",
                    schedule.title,
                    schedule.content,
                    schedule.place,
                    int.Parse(KSCS.categoryDict[schedule.category][0]),
                    schedule.startDate.ToString("yyyy-MM-dd, HH:mm"),
                    schedule.endDate.ToString("yyyy-MM-dd, HH:mm"));
                MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
                if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to insert Data.");
                //스케줄 리스트 추가
                KSCS.monthScheduleList[UserDate.static_date - 1].Add(schedule);
                //스케줄 리스트 시작 시간 순 정렬
                KSCS.monthScheduleList[UserDate.static_date - 1].OrderBy(sche => sche.startDate);
                
            }
            else if(addBtn.Text == "Modify")
            {
                if (selectedScheduleIndex != -1)
                {
                    string updateQuery = string.Format("UPDATE Schedule SET title='{0}', content='{1}', place='{2}', category_id='{3}',startDate='{4}', endDate='{5}' WHERE id={6};",
                    schedule.title,
                    schedule.content,
                    schedule.place,
                    int.Parse(KSCS.categoryDict[schedule.category][0]),
                    schedule.startDate.ToString("yyyy-MM-dd, HH:mm"),
                    schedule.endDate.ToString("yyyy-MM-dd, HH:mm"),
                    //scheduleList[selectedScheduleIndex].id
                    KSCS.monthScheduleList[UserDate.static_date - 1][selectedScheduleIndex].id
                    );
                    MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
                    if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Update Data.");
                    // 리스트 수정
                    KSCS.monthScheduleList[UserDate.static_date - 1][selectedScheduleIndex].title = schedule.title;
                    KSCS.monthScheduleList[UserDate.static_date - 1][selectedScheduleIndex].content = schedule.content;
                    KSCS.monthScheduleList[UserDate.static_date - 1][selectedScheduleIndex].place = schedule.place;
                    KSCS.monthScheduleList[UserDate.static_date - 1][selectedScheduleIndex].category = schedule.category;
                    KSCS.monthScheduleList[UserDate.static_date - 1][selectedScheduleIndex].startDate = schedule.startDate;
                    KSCS.monthScheduleList[UserDate.static_date - 1][selectedScheduleIndex].endDate = schedule.endDate;
                }
            }

            if (AddEvent != null)
            {
                AddEvent(this, new EventArgs());
            }

            //InitializeDatabase();
            ClearForm();
            //스케줄 유닛 다시 load
            InitializeScheDetailForm();
        }

        private void deleteBtn_Click(object sender, EventArgs e) //삭제
        {
            if (selectedScheduleIndex != -1)
            {
                string deleteQuery = string.Format("DELETE FROM Schedule WHERE id='{0}';", KSCS.monthScheduleList[UserDate.static_date - 1][selectedScheduleIndex].id);
                MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
                if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Delete Data.");
            }
            //리스트 삭제
            KSCS.monthScheduleList[UserDate.static_date - 1].RemoveAt(selectedScheduleIndex);
            //스케줄 유닛 다시 load
            //InitializeDatabase();
            if (AddEvent != null)
            {
                AddEvent(this, new EventArgs());
            }

            ClearForm();
            InitializeScheDetailForm();
        }

        private void btnMemSet_Click(object sender, EventArgs e)
        {
            guna2ContextMenuStrip1.Show(MousePosition);
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            scheduleUnit scheduleUnit = (scheduleUnit)sender;
            int index = panelSchedules.Controls.IndexOf(scheduleUnit);
            tbTitle.Text = KSCS.monthScheduleList[UserDate.static_date - 1][index].title;
            tbMemo.Text = KSCS.monthScheduleList[UserDate.static_date - 1][index].content;
            tbPlace.Text = KSCS.monthScheduleList[UserDate.static_date - 1][index].place;
            dtpStartDate.Value = KSCS.monthScheduleList[UserDate.static_date - 1][index].startDate;
            dtpStartTime.Value = KSCS.monthScheduleList[UserDate.static_date - 1][index].startDate;
            int categoryIndex = cbCategory.Items.IndexOf(KSCS.monthScheduleList[UserDate.static_date - 1][index].category);
            panelTop.BackColor = Color.FromArgb(int.Parse(KSCS.categoryDict[KSCS.monthScheduleList[UserDate.static_date - 1][index].category][1]));
            cbCategory.SelectedIndex = categoryIndex;
            cbCategory.Text= KSCS.monthScheduleList[UserDate.static_date - 1][index].category;
            dtpEndDate.Value = KSCS.monthScheduleList[UserDate.static_date - 1][index].endDate;
            dtpEndTime.Value = KSCS.monthScheduleList[UserDate.static_date - 1][index].endDate;

            selectedScheduleIndex = index;
            addBtn.FillColor = Color.LimeGreen;
            addBtn.Text = "Modify";
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            ClearForm();
            panelTop.BackColor = Color.HotPink;
            addBtn.FillColor = Color.CornflowerBlue;
            addBtn.Text = "Add";
        }

        private void cbCategory_DropDownClosed(object sender, EventArgs e)
        {
            if(cbCategory.SelectedIndex!=0&& addBtn.Text=="Modify") 
            {
                scheduleUnit scheduleUnit = (scheduleUnit)(panelSchedules.Controls[selectedScheduleIndex]);
                scheduleUnit.ChangeScheduleColor(Color.FromArgb(int.Parse(KSCS.categoryDict[cbCategory.Text][1]))); //수정
            }
        }

        public string GetTbTitle()
        {
            return tbTitle.Text;
        }

        public string GetCbCategory()
        {
            return cbCategory.Text;
        }

        private void InitializeScheDetailForm() //스케줄 유닛들 load
        {
            panelSchedules.Controls.Clear(); //스케줄 유닛들 초기화
            int index = 0;

            //클릭한 날짜의 하루 스케줄 리스트
            for (int i = 0; i < KSCS.monthScheduleList[UserDate.static_date-1].Count; i++)
            {
                scheduleUnit scheduleUnit = new scheduleUnit
                {
                    Name = "scdUnit" + index.ToString(),
                    ScheduleTitle = KSCS.monthScheduleList[UserDate.static_date - 1][i].title
                };
                scheduleUnit.ChangeScheduleColor(Color.FromArgb(int.Parse(KSCS.categoryDict[KSCS.monthScheduleList[UserDate.static_date - 1][i].category][1])));
                scheduleUnit.btnClick += btnSchedule_Click;
                scheduleUnit.Location = new Point(9, 12 + index * (scheduleUnit.Height + 3));
                panelSchedules.Controls.Add(scheduleUnit);
                index++;
            }

            cbCategory.Items.Clear();
            foreach (string Key in KSCS.categoryDict.Keys)
            {
                if (!cbCategory.Items.Contains(Key)) { 
                    cbCategory.Items.Add(Key); 
                }
            }
            btnAddSchedule.Location = new Point(24, 12 + index * 55);
            panelSchedules.Controls.Add(btnAddSchedule);
        }
    }
}
