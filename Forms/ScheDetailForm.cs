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
using KSCS.UserControls.MainForm;

namespace KSCS
{
    public partial class ScheDetailForm : Form
    {
        public event EventHandler AddEvent;

        MySqlConnection connection = DatabaseConnection.getDBConnection();
        int selectedScheduleIndex=-1; 
        DateTime click_date = new DateTime(MainForm.static_year, MainForm.static_month, UserDate.static_date); //추가
        public ScheDetailForm()
        {
            InitializeComponent();
            InitializeGuna2DateTimePicker();
            //connection.Open();
            InitializeScheDetailForm();
            panelSchedules.VerticalScroll.Visible = false; 
        }

        private void InitializeGuna2DateTimePicker()
        {
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

            //추가
            panelTop.BackColor = Color.Pink;
            addBtn.FillColor = Color.CornflowerBlue;
            addBtn.Text = "Add";
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
                    int.Parse(MainForm.categoryDict[schedule.category][0]),
                    schedule.startDate.ToString("yyyy-MM-dd, HH:mm"),
                    schedule.endDate.ToString("yyyy-MM-dd, HH:mm"));
                MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
                if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to insert Data.");
                //추가 후, id 값 가져오기
                string selectQuery = string.Format("SELECT LAST_INSERT_ID() AS id");
                cmd = new MySqlCommand(selectQuery, connection);
                MySqlDataReader table = cmd.ExecuteReader();
                while (table.Read()) {
                    schedule.id = int.Parse(table["id"].ToString());
                }
                table.Close();
                //스케줄 리스트 추가
                MainForm.monthScheduleList[UserDate.static_date - 1].Add(schedule);
                //스케줄 리스트 시작 시간 순 정렬
                MainForm.monthScheduleList[UserDate.static_date - 1].OrderBy(sche => sche.startDate);
                
            }
            else if(addBtn.Text == "Modify")
            {
                if (selectedScheduleIndex != -1)
                {
                    string updateQuery = string.Format("UPDATE Schedule SET title='{0}', content='{1}', place='{2}', category_id='{3}',startDate='{4}', endDate='{5}' WHERE id={6};",
                    schedule.title,
                    schedule.content,
                    schedule.place,
                    int.Parse(MainForm.categoryDict[schedule.category][0]),
                    schedule.startDate.ToString("yyyy-MM-dd, HH:mm"),
                    schedule.endDate.ToString("yyyy-MM-dd, HH:mm"),
                    //scheduleList[selectedScheduleIndex].id
                    MainForm.monthScheduleList[UserDate.static_date - 1][selectedScheduleIndex].id
                    );
                    MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
                    if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Update Data.");
                    // 리스트 수정
                    MainForm.monthScheduleList[UserDate.static_date - 1][selectedScheduleIndex].title = schedule.title;
                    MainForm.monthScheduleList[UserDate.static_date - 1][selectedScheduleIndex].content = schedule.content;
                    MainForm.monthScheduleList[UserDate.static_date - 1][selectedScheduleIndex].place = schedule.place;
                    MainForm.monthScheduleList[UserDate.static_date - 1][selectedScheduleIndex].category = schedule.category;
                    MainForm.monthScheduleList[UserDate.static_date - 1][selectedScheduleIndex].startDate = schedule.startDate;
                    MainForm.monthScheduleList[UserDate.static_date - 1][selectedScheduleIndex].endDate = schedule.endDate;
                }
            }

            if (AddEvent != null)
            {
                AddEvent(this, new EventArgs());
            }
            ClearForm();
            //스케줄 유닛 다시 load
            InitializeScheDetailForm();
        }

        private void deleteBtn_Click(object sender, EventArgs e) //삭제
        {
            if (selectedScheduleIndex != -1)
            {
                string deleteQuery = string.Format("DELETE FROM Schedule WHERE id='{0}';", MainForm.monthScheduleList[UserDate.static_date - 1][selectedScheduleIndex].id);
                MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
                if (cmd.ExecuteNonQuery() != 1) MessageBox.Show("Failed to Delete Data.");
            }
            //리스트 삭제
            MainForm.monthScheduleList[UserDate.static_date - 1].RemoveAt(selectedScheduleIndex);
            //스케줄 유닛 다시 load
            if (AddEvent != null)
            {
                AddEvent(this, new EventArgs());
            }

            ClearForm();
            InitializeScheDetailForm();
        }

        private void btnMemSet_Click(object sender, EventArgs e)
        {
            //guna2ContextMenuStrip1.Show(MousePosition);
            btnMemSet.Visible = false;
            flpMember.Visible = true;
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            scheduleUnit scheduleUnit = (scheduleUnit)sender;
            int index = panelSchedules.Controls.IndexOf(scheduleUnit);
            tbTitle.Text = MainForm.monthScheduleList[UserDate.static_date - 1][index].title;
            tbMemo.Text = MainForm.monthScheduleList[UserDate.static_date - 1][index].content;
            tbPlace.Text = MainForm.monthScheduleList[UserDate.static_date - 1][index].place;
            dtpStartDate.Value = MainForm.monthScheduleList[UserDate.static_date - 1][index].startDate;
            dtpStartTime.Value = MainForm.monthScheduleList[UserDate.static_date - 1][index].startDate;
            int categoryIndex = cbCategory.Items.IndexOf(MainForm.monthScheduleList[UserDate.static_date - 1][index].category);
            panelTop.BackColor = Color.FromArgb(int.Parse(MainForm.categoryDict[MainForm.monthScheduleList[UserDate.static_date - 1][index].category][1]));
            cbCategory.SelectedIndex = categoryIndex;
            cbCategory.Text= MainForm.monthScheduleList[UserDate.static_date - 1][index].category;
            dtpEndDate.Value = MainForm.monthScheduleList[UserDate.static_date - 1][index].endDate;
            dtpEndTime.Value = MainForm.monthScheduleList[UserDate.static_date - 1][index].endDate;

            selectedScheduleIndex = index;
            addBtn.FillColor = Color.LimeGreen;
            addBtn.Text = "Modify";
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            ClearForm();
            panelTop.BackColor = Color.Pink;
            addBtn.FillColor = Color.CornflowerBlue;
            addBtn.Text = "Add";
        }

        private void cbCategory_DropDownClosed(object sender, EventArgs e)
        {
            if(cbCategory.SelectedIndex!=0&& addBtn.Text=="Modify") 
            {
                scheduleUnit scheduleUnit = (scheduleUnit)(panelSchedules.Controls[selectedScheduleIndex]);
                scheduleUnit.ChangeScheduleColor(Color.FromArgb(int.Parse(MainForm.categoryDict[cbCategory.Text][1]))); //수정
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
            for (int i = 0; i < MainForm.monthScheduleList[UserDate.static_date-1].Count; i++)
            {
                scheduleUnit scheduleUnit = new scheduleUnit
                {
                    Name = "scdUnit" + index.ToString(),
                    ScheduleTitle = MainForm.monthScheduleList[UserDate.static_date - 1][i].title
                };
                scheduleUnit.ChangeScheduleColor(Color.FromArgb(int.Parse(MainForm.categoryDict[MainForm.monthScheduleList[UserDate.static_date - 1][i].category][1])));
                scheduleUnit.btnClick += btnSchedule_Click;
                scheduleUnit.Location = new Point(9, 12 + index * (scheduleUnit.Height + 3));
                panelSchedules.Controls.Add(scheduleUnit);
                index++;
            }

            cbCategory.Items.Clear();
            foreach (string Key in MainForm.categoryDict.Keys)
            {
                if (!cbCategory.Items.Contains(Key)) { 
                    cbCategory.Items.Add(Key); 
                }
            }
            btnAddSchedule.Location = new Point(24, 12 + index * 55);
            panelSchedules.Controls.Add(btnAddSchedule);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter || e.KeyChar == (Char)Keys.Space)
            {
                if (txtMember.Text.Length > 0)
                {
                    MemberAdd memberAdd = new MemberAdd();
                    memberAdd.txtMember.Text = txtMember.Text;
                    Size size = TextRenderer.MeasureText(memberAdd.txtMember.Text, memberAdd.txtMember.Font);
                    memberAdd.txtMember.ClientSize = new Size(size.Width, size.Height);
                    memberAdd.ClientSize = new Size(size.Width + 25, 18);
                    memberAdd.pictureBox1.ClientSize = new Size(10, 9);
                    txtMember.Text = "";
                    flpMember.Controls.Add(memberAdd);
                }
            }
            else
        {
                if(txtMember.Text == "\r\n")
                {
                    txtMember.Text = "";
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            //if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            //{
            //    if (textBox1.Text.Length > 0)
            //    {
            //        MemberAdd memberAdd = new MemberAdd();
            //        memberAdd.txtMember.Text = textBox1.Text;
            //        Size size = TextRenderer.MeasureText(memberAdd.txtMember.Text, memberAdd.txtMember.Font);
            //        memberAdd.txtMember.ClientSize = new Size(size.Width, size.Height);
            //        memberAdd.ClientSize = new Size(size.Width + 25, 18);
            //        memberAdd.pictureBox1.ClientSize = new Size(10, 9);
            //        textBox1.Text = "";
            //        flowLayoutPanel1.Controls.Add(memberAdd);
            //    }
            //}
        }
    }
}
