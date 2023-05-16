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

        MySqlConnection connection=DatabaseConnection.getDBConnection();
        List<Schedule> scheduleList = new List<Schedule>();
        Dictionary<string, string[]> categoryDict = new Dictionary<string, string[]>();
        string student_id = "2019203082";
        int selectedScheduleIndex=-1;
        public ScheDetailForm()
        {
            InitializeComponent();
            InitializeGuna2DateTimePicker();
            connection.Open();
            InitializeDatabase();
            panelSchedules.VerticalScroll.Visible = false;
        }

        public void InitializeDatabase()    
        {
            string selectQuery = string.Format("SELECT * from Schedule JOIN Category ON Schedule.category_id=Category.id JOIN StudentCategory ON StudentCategory.student_id=Schedule.student_id and Schedule.category_id=Category.id and Category.id=StudentCategory.category_id WHERE Schedule.student_id={0} ORDER BY startDate DESC;", student_id);
            MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
            MySqlDataReader table = cmd.ExecuteReader();
            int index = 0;
            scheduleList.Clear();
            panelSchedules.Controls.Clear();

            while (table.Read())
            {
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
                scheduleList.Add(schedule);
                
                scheduleUnit scheduleUnit = new scheduleUnit
                {
                    Name = "scdUnit" + index.ToString(),
                    ScheduleTitle = schedule.title
                };
                scheduleUnit.ChangeScheduleColor(Color.FromArgb(int.Parse(table["color"].ToString())));
                scheduleUnit.btnClick += btnSchedule_Click;
                scheduleUnit.Location = new Point(9, 12 + index * (scheduleUnit.Height + 3));
                panelSchedules.Controls.Add(scheduleUnit);
                index++;
            }
            table.Close();
            LoadCategory();
            btnAddSchedule.Location = new Point(24, 12 + index * 55 );
            panelSchedules.Controls.Add(btnAddSchedule);
        }

        private void LoadCategory()
        {
            cbCategory.Items.Clear();
            categoryDict.Clear();
            string selectQuery = string.Format("SELECT * from Category JOIN StudentCategory ON Category.id=StudentCategory.category_id WHERE student_id='{0}';", student_id);
            MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
            MySqlDataReader table = cmd.ExecuteReader();
            while (table.Read())
            {
                if (!cbCategory.Items.Contains(table["type"].ToString()))
                {
                    cbCategory.Items.Add(table["type"].ToString());
                    categoryDict.Add(table["type"].ToString(), new string[2] {table["id"].ToString(), table["color"].ToString()});
                }
            }
            table.Close();
        }

        private void InitializeGuna2DateTimePicker()
        {
            dtpStartDate.Value = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd ddd"), "yyyy-MM-dd ddd", null);
            dtpStartTime.Value = DateTime.ParseExact("00:00", "HH:mm", null);
            dtpEndDate.Value = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd ddd"), "yyyy-MM-dd ddd", null);
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

        private void addBtn_Click(object sender, EventArgs e)
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
                    int.Parse(categoryDict[schedule.category][0]),
                    schedule.startDate.ToString("yyyy-MM-dd, HH:mm"),
                    schedule.endDate.ToString("yyyy-MM-dd, HH:mm"));
                MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
                if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to insert Data.");
            }else if(addBtn.Text == "Modify")
            {
                if (selectedScheduleIndex != -1)
                {
                    string updateQuery = string.Format("UPDATE Schedule SET title='{0}', content='{1}', place='{2}', category_id='{3}',startDate='{4}', endDate='{5}' WHERE id={6};",
                    schedule.title,
                    schedule.content,
                    schedule.place,
                    int.Parse(categoryDict[schedule.category][0]),
                    schedule.startDate.ToString("yyyy-MM-dd, HH:mm"),
                    schedule.endDate.ToString("yyyy-MM-dd, HH:mm"),
                    scheduleList[selectedScheduleIndex].id);
                    MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
                    if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Update Data.");
                }
            }

            if (AddEvent != null)
            {
                AddEvent(this, new EventArgs());
            }

            ClearForm();
            InitializeDatabase();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (selectedScheduleIndex != -1)
            {
                string deleteQuery = string.Format("DELETE FROM Schedule WHERE id='{0}';", scheduleList[selectedScheduleIndex].id);
                MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
                if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Delete Data.");
            }
            InitializeDatabase();
        }

        private void btnMemSet_Click(object sender, EventArgs e)
        {
            guna2ContextMenuStrip1.Show(MousePosition);
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            scheduleUnit scheduleUnit = (scheduleUnit)sender;
            int index = panelSchedules.Controls.IndexOf(scheduleUnit);
            tbTitle.Text = scheduleList[index].title;
            tbMemo.Text = scheduleList[index].content;
            tbPlace.Text = scheduleList[index].place;
            dtpStartDate.Value = scheduleList[index].startDate;
            dtpStartTime.Value = scheduleList[index].startDate;
            int categoryIndex = cbCategory.Items.IndexOf(scheduleList[index].category);
            panelTop.BackColor = Color.FromArgb(int.Parse(categoryDict[scheduleList[index].category][1]));
            cbCategory.SelectedIndex = categoryIndex;
            cbCategory.Text= scheduleList[index].category;
            dtpEndDate.Value = scheduleList[index].endDate;
            dtpEndTime.Value = scheduleList[index].endDate;

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
                scheduleUnit.ChangeScheduleColor(Color.FromArgb(int.Parse(categoryDict[cbCategory.Text][1])));
            }
        }

        public string GetTbTitle()
        {
            return tbTitle.Text;
        }

        public int GetCbCategory()
        {
            return cbCategory.SelectedIndex;
        }
    }
}
