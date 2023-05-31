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
using KSCS.UserControls.MainForm;

namespace KSCS
{
    public partial class ScheDetailForm : Form
    {
        public event EventHandler AddEvent;

        int selectedScheduleIndex = -1;
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
            cbCategory.SelectedItem = null;
            InitializeGuna2DateTimePicker();

            panelTop.BackColor = Color.Pink;
            addBtn.FillColor = Color.CornflowerBlue;
            addBtn.Text = "Add";

            deleteBtn.Visible = false;
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
            else if (cbCategory.SelectedItem == null)
            {
                MessageBox.Show("카테고리를 선택하세요");
                return;
            }

            //추가
            List<string> members = new List<string>();
            foreach (MemberAdd memberAdd in flpMember.Controls.OfType<MemberAdd>())
            {
                members.Add(memberAdd.txtMember.Text);
            }
            

            Schedule schedule = new Schedule(tbTitle.Text, tbMemo.Text, tbPlace.Text, cbCategory.Text, GetStartDateTime(), GetEndDateTime(),members);
            if (addBtn.Text == "Add")
            {
                Database.CreateScheudle(schedule,stdNum); //수정

                //추가(공유 멤버가 존재하는 경우)
                if (schedule.members.Count != 0)
                {
                    Database.CreateMember(schedule);
                }

                //스케줄 리스트 추가
                TimeSpan duration = schedule.endDate - schedule.startDate;
                for (int i = 0; i <= duration.Days; i++)
                {
                    if (Convert.ToInt32(schedule.startDate.AddDays(i).ToString("MM")) == month)
                    {
                        monthScheduleList[Convert.ToInt32(schedule.startDate.AddDays(i).ToString("dd")) - 1].Add(schedule);
                        AddEvent += new EventHandler(Application.OpenForms.OfType<MainForm>().FirstOrDefault().GetUserDate().SingleOrDefault(userDate => !string.IsNullOrEmpty(userDate.GetLblDate()) && Convert.ToInt32(userDate.GetLblDate()) == Convert.ToInt32(schedule.startDate.AddDays(i).ToString("dd"))).SaveEvent);
                    }
                }
            }
            else if (addBtn.Text == "Modify")
            {
                if (selectedScheduleIndex != -1)
                {
                    Database.UpdateSchedule(schedule, selectedScheduleIndex);

                    /* 리스트 수정 로직*/
                    //수정 후, id값 가져오기
                    schedule.id = monthScheduleList[UserDate.static_date - 1][selectedScheduleIndex].id;

                    //startDate 혹은 endDate가 날짜가 바뀐 경우, 해당 일정 "삭제"
                    Schedule selectedSchedule = monthScheduleList[UserDate.static_date - 1][selectedScheduleIndex]; //클릭한 날짜의 원래 스케줄
                    if ((selectedSchedule.startDate - schedule.startDate).Days < 0)
                    {
                        TimeSpan diff = schedule.startDate - selectedSchedule.startDate;
                        for (int i = 0; i < diff.Days; i++)
                        {
                            if (Convert.ToInt32(selectedSchedule.startDate.AddDays(i).ToString("MM")) == month)
                            {
                                monthScheduleList[Convert.ToInt32(selectedSchedule.startDate.AddDays(i).ToString("dd")) - 1].Remove(selectedSchedule);
                                AddEvent += new EventHandler(Application.OpenForms.OfType<MainForm>().FirstOrDefault().GetUserDate().SingleOrDefault(userDate => !string.IsNullOrEmpty(userDate.GetLblDate()) && Convert.ToInt32(userDate.GetLblDate()) == Convert.ToInt32(selectedSchedule.startDate.AddDays(i).ToString("dd"))).SaveEvent);
                            }
                        }
                    }
                    if ((selectedSchedule.endDate - schedule.endDate).Days > 0)
                    {
                        TimeSpan diff = selectedSchedule.endDate - schedule.endDate;
                        for (int i = 1; i <= diff.Days; i++)
                        {
                            if (Convert.ToInt32(schedule.endDate.AddDays(i).ToString("MM")) == month)
                            {
                                monthScheduleList[Convert.ToInt32(schedule.endDate.AddDays(i).ToString("dd")) - 1].Remove(selectedSchedule);
                                AddEvent += new EventHandler(Application.OpenForms.OfType<MainForm>().FirstOrDefault().GetUserDate().SingleOrDefault(userDate => !string.IsNullOrEmpty(userDate.GetLblDate()) && Convert.ToInt32(userDate.GetLblDate()) == Convert.ToInt32(schedule.endDate.AddDays(i).ToString("dd"))).SaveEvent);
                            }
                        }
                    }
                    // 리스트 수정
                    TimeSpan duration = schedule.endDate - schedule.startDate;
                    for (int i = 0; i <= duration.Days; i++)
                    {
                        bool exist = false;
                        if (Convert.ToInt32(schedule.startDate.AddDays(i).ToString("MM")) == month)
                        {
                            monthScheduleList[Convert.ToInt32(schedule.startDate.AddDays(i).ToString("dd")) - 1].ForEach(sche =>
                            {
                                if (sche.Equals(selectedSchedule))
                                {
                                    sche.id = schedule.id;
                                    sche.title = schedule.title;
                                    sche.content = schedule.content;
                                    sche.place = schedule.place;
                                    sche.category = schedule.category;
                                    sche.startDate = schedule.startDate;
                                    sche.endDate = schedule.endDate;
                                    exist = true;
                                }
                            });
                            if (!exist) //startDate 혹은 endDate가 날짜가 바뀐 경우, 해당 일정 없으면 수정한 것 "추가"
                                monthScheduleList[Convert.ToInt32(schedule.startDate.AddDays(i).ToString("dd")) - 1].Add(selectedSchedule); //schedule->selectedSchedule 하니까 바로 오류 사라짐;;;

                            AddEvent += new EventHandler(Application.OpenForms.OfType<MainForm>().FirstOrDefault().GetUserDate().SingleOrDefault(userDate => !string.IsNullOrEmpty(userDate.GetLblDate()) && Convert.ToInt32(userDate.GetLblDate()) == Convert.ToInt32(schedule.startDate.AddDays(i).ToString("dd"))).SaveEvent); //이벤트 핸들러 추가
                        }

                    }   
                }
                
            }

            AddEvent?.Invoke(this, EventArgs.Empty); //이벤트 핸들러 발생

            ClearForm();
            //스케줄 유닛 다시 load
            InitializeScheDetailForm();
            ClearAllDelegatesOfTheEventHandler(); //이벤트 핸들러 초기화
        }

        private void deleteBtn_Click(object sender, EventArgs e) //삭제
        {
            if (selectedScheduleIndex != -1)
            {
                Database.DeleteSchedule(selectedScheduleIndex);

                //리스트 삭제
                Schedule selectedSchedule = monthScheduleList[UserDate.static_date - 1][selectedScheduleIndex]; //클릭한 날짜의 스케줄
                TimeSpan duration = selectedSchedule.endDate - selectedSchedule.startDate; //클릭한 날짜의 스케줄의 기간
                for (int i = 0; i <= duration.Days; i++)
                {
                    if (Convert.ToInt32(selectedSchedule.startDate.AddDays(i).ToString("MM")) == month)
                    {
                        monthScheduleList[Convert.ToInt32(selectedSchedule.startDate.AddDays(i).ToString("dd")) - 1].Remove(selectedSchedule);
                        AddEvent += new EventHandler(Application.OpenForms.OfType<MainForm>().FirstOrDefault().GetUserDate().SingleOrDefault(userDate => !string.IsNullOrEmpty(userDate.GetLblDate()) && Convert.ToInt32(userDate.GetLblDate()) == Convert.ToInt32(selectedSchedule.startDate.AddDays(i).ToString("dd"))).SaveEvent);
                    }
                }

                AddEvent?.Invoke(this, EventArgs.Empty); //이벤트 핸들러 발생

                ClearForm();
                //스케줄 유닛 다시 load
                InitializeScheDetailForm();
                ClearAllDelegatesOfTheEventHandler(); //이벤트 핸들러 초기화
            }
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
            tbTitle.Text = monthScheduleList[UserDate.static_date - 1][index].title;
            tbMemo.Text = monthScheduleList[UserDate.static_date - 1][index].content;
            tbPlace.Text = monthScheduleList[UserDate.static_date - 1][index].place;
            dtpStartDate.Value = monthScheduleList[UserDate.static_date - 1][index].startDate;
            dtpStartTime.Value = monthScheduleList[UserDate.static_date - 1][index].startDate;
            int categoryIndex = cbCategory.Items.IndexOf(monthScheduleList[UserDate.static_date - 1][index].category);
            panelTop.BackColor = category.GetColor(monthScheduleList[UserDate.static_date - 1][index].category);
            cbCategory.SelectedIndex = categoryIndex;
            cbCategory.Text = monthScheduleList[UserDate.static_date - 1][index].category;
            dtpEndDate.Value = monthScheduleList[UserDate.static_date - 1][index].endDate;
            dtpEndTime.Value = monthScheduleList[UserDate.static_date - 1][index].endDate;

            selectedScheduleIndex = index;
            addBtn.FillColor = Color.LimeGreen;
            addBtn.Text = "Modify";

            deleteBtn.Visible = true; // 스케줄 클릭하고 나서야 활성화

            btnMemSet.Visible = true;
            flpMember.Visible = false;

            //추가(공유일정인 경우, member 로드)
            if (monthScheduleList[UserDate.static_date - 1][index].members.Count > 0)
            {
                MessageBox.Show(monthScheduleList[UserDate.static_date - 1][index].members.Count.ToString());
                LoadMembers(monthScheduleList[UserDate.static_date - 1][index]);
            }
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
            if (cbCategory.SelectedIndex != 0 && addBtn.Text == "Modify")
            {
                scheduleUnit scheduleUnit = (scheduleUnit)(panelSchedules.Controls[selectedScheduleIndex]);
                scheduleUnit.ChangeScheduleColor(category.GetColor(cbCategory.Text)); //수정
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
            for (int i = 0; i < monthScheduleList[UserDate.static_date - 1].Count; i++)
            {
                scheduleUnit scheduleUnit = new scheduleUnit
                {
                    Name = "scdUnit" + index.ToString(),
                    ScheduleTitle = monthScheduleList[UserDate.static_date - 1][i].title
                };
                scheduleUnit.ChangeScheduleColor(category.GetColor(monthScheduleList[UserDate.static_date - 1][i].category));
                scheduleUnit.btnClick += btnSchedule_Click;
                scheduleUnit.Location = new Point(9, 12 + index * (scheduleUnit.Height + 3));
                panelSchedules.Controls.Add(scheduleUnit);
                index++;
            }

            cbCategory.Items.Clear();
            foreach (string Key in category.Categories.Keys)
            {
                foreach(string Value in category.Categories[Key])
                {
                    if (!cbCategory.Items.Contains(Value))
                    {
                        cbCategory.Items.Add(Value);
                    }
                }
            }
            btnAddSchedule.Location = new Point(24, 12 + index * 55);
            panelSchedules.Controls.Add(btnAddSchedule);
        }

        public void ClearAllDelegatesOfTheEventHandler()
        {
            foreach (Delegate d in AddEvent.GetInvocationList())
            {
                AddEvent -= (EventHandler)d;
            }
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
                    memberAdd.btnClose.ClientSize = new Size(10, 9);
                    txtMember.Text = "";
                    flpMember.Controls.Add(memberAdd);
                    memberAdd.AddEvent += new EventHandler(DeleteMemberEvent); //삭제 이벤트 핸들러 추가
                }
            }
            else
            {
                if (txtMember.Text == "\r\n")
                {
                    txtMember.Text = "";
                }
            }
        }

        private void DeleteMemberEvent(object sender, EventArgs e)
        {
            flpMember.Controls.Remove((Control)sender);
        }

        //추가
        private void LoadMembers(Schedule schedule)
        {
            btnMemSet.Visible = false;
            flpMember.Visible = true;
            flpMember.Controls.Clear(); //flpMember 컨트롤 초기화
            foreach ( String studentId in schedule.members)
            {
                MemberAdd memberAdd = new MemberAdd();
                memberAdd.txtMember.Text = studentId;
                Size size = TextRenderer.MeasureText(memberAdd.txtMember.Text, memberAdd.txtMember.Font);
                memberAdd.txtMember.ClientSize = new Size(size.Width, size.Height);
                memberAdd.ClientSize = new Size(size.Width + 5, 18);
                flpMember.Controls.Add(memberAdd);
                memberAdd.btnClose.Visible = false;
            }
            this.Refresh();
        }
    }
}
