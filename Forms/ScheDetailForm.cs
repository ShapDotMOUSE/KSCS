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
using static KSCS.Class.KSCS_static;

namespace KSCS
{
    public partial class ScheDetailForm : Form
    {
        public event EventHandler AddEvent;

        int selectedScheduleIndex=-1; 
        DateTime click_date = new DateTime(year, month, UserDate.static_date); //추가
        public ScheDetailForm()
        {
            InitializeComponent();
            InitializeGuna2DateTimePicker();
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
                Database.CreateScheudle(schedule);
            }
            else if(addBtn.Text == "Modify")
            {
                if (selectedScheduleIndex != -1)
                {
                    Database.UpdateSchedule(schedule, selectedScheduleIndex);
                }
            }

            AddEvent?.Invoke(this, new EventArgs());
            ClearForm();
            //스케줄 유닛 다시 load
            InitializeScheDetailForm();
        }

        private void deleteBtn_Click(object sender, EventArgs e) //삭제
        {
            if (selectedScheduleIndex != -1)
            {
                Database.DeleteSchedule(selectedScheduleIndex);

                AddEvent?.Invoke(this, new EventArgs());
                ClearForm();
                //스케줄 유닛 다시 load
                InitializeScheDetailForm();
            }
        }

        private void btnMemSet_Click(object sender, EventArgs e)
        {
            guna2ContextMenuStrip1.Show(MousePosition);
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            scheduleUnit scheduleUnit = (scheduleUnit)sender;
            int index = panelSchedules.Controls.IndexOf(scheduleUnit);
            tbTitle.Text = monthScheduleList[UserDate.static_date - 1][index].title;
            tbMemo.Text = monthScheduleList[UserDate.static_date - 1][index].content;
            tbPlace.Text = monthScheduleList[UserDate.static_date - 1][index].place;
            dtpStartDate.Value = monthScheduleList[UserDate.static_date - 1][index].startDate;
            dtpStartTime.Value = monthScheduleList[UserDate.static_date - 1][index].startDate;
            int categoryIndex = cbCategory.Items.IndexOf(monthScheduleList[UserDate.static_date - 1][index].category);
            panelTop.BackColor = Color.FromArgb(int.Parse(categoryDict[monthScheduleList[UserDate.static_date - 1][index].category][1]));
            cbCategory.SelectedIndex = categoryIndex;
            cbCategory.Text= monthScheduleList[UserDate.static_date - 1][index].category;
            dtpEndDate.Value = monthScheduleList[UserDate.static_date - 1][index].endDate;
            dtpEndTime.Value = monthScheduleList[UserDate.static_date - 1][index].endDate;

            selectedScheduleIndex = index;
            addBtn.FillColor = Color.LimeGreen;
            addBtn.Text = "Modify";

            deleteBtn.Visible = true; // 스케줄 클릭하고 나서야 활성화
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
                scheduleUnit.ChangeScheduleColor(Color.FromArgb(int.Parse(categoryDict[cbCategory.Text][1]))); //수정
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
            for (int i = 0; i < monthScheduleList[UserDate.static_date-1].Count; i++)
            {
                scheduleUnit scheduleUnit = new scheduleUnit
                {
                    Name = "scdUnit" + index.ToString(),
                    ScheduleTitle = monthScheduleList[UserDate.static_date - 1][i].title
                };
                scheduleUnit.ChangeScheduleColor(Color.FromArgb(int.Parse(categoryDict[monthScheduleList[UserDate.static_date - 1][i].category][1])));
                scheduleUnit.btnClick += btnSchedule_Click;
                scheduleUnit.Location = new Point(9, 12 + index * (scheduleUnit.Height + 3));
                panelSchedules.Controls.Add(scheduleUnit);
                index++;
            }

            cbCategory.Items.Clear();
            foreach (string Key in categoryDict.Keys)
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
