using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;
using KSCS.Class;
using MySql.Data.MySqlClient;
using static KSCS.Class.KSCS_static;

namespace KSCS
{
    public partial class MainForm : Form
    {
        //탭 & 카테고리 관련
        public static string TabName;
        //스케줄 관련
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            KLAS.initializeKLAS();
            LoginForm loginForm = new LoginForm();
            DialogResult Result = loginForm.ShowDialog();
            if (Result == DialogResult.OK)
                LoadMagam();
            else
                Close();
            lblStdNum.Text = stdNum;
            category.TestCategory();
            Database.ReadCategory();
            //초기 탭 설정 
            TabName = btnTab1.Name; //수정되어야함
            btnTab1.Clicked += ChangeTab;
            btnTab2.Clicked += ChangeTab;
            btnTab3.Clicked += ChangeTab;
            dispalyDate();
            DisplayCategery();
            SetCheckedCategoryByTab();
        }

        private async void LoadMagam()
        {
            await KLAS.LoadMagamData();
            MagamButtonEnable();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(1280, 960);
        }


        //카테고리 함수---------------------------------------------------------------------------------------------------------------------------------------
        private void DisplayCategery()
        {

            foreach (var item in category.ParentCategorys["SchoolCategory"] as HashSet<string>)
            {
                UserCategory uc = new UserCategory();
                uc.SetBasicMode(item);
                uc.MouseDoubleClick += UcCategory_MouseDoubleClick;
                flpSchoolCategory.Controls.Add(uc);
            }

            foreach (var item in category.ParentCategorys["PersonalCategory"] as HashSet<string>)
            {
                UserCategory uc = new UserCategory();
                uc.SetBasicMode(item);
                uc.MouseDoubleClick += UcCategory_MouseDoubleClick;
                flpPersonalCategory.Controls.Add(uc);
            }

            foreach (var item in category.ParentCategorys["EtcCategory"] as HashSet<string>)
            {
                UserCategory uc = new UserCategory();
                uc.SetBasicMode(item);
                uc.MouseDoubleClick += UcCategory_MouseDoubleClick;
                flpEtcCategory.Controls.Add(uc);
            }
        }

        //탭 함수-------------------------------------------------------------------------------------------------------------------------------------------
        private void ChangeTab(object sender, EventArgs e)
        {
            /*
             * TODO: 이 부분에 DB에 연결하는 함수 추가 필요
             */
            customTapButton btn = sender as customTapButton;
            TabName = btn.Name;
            SetCheckedCategoryByTab();
        }
        private void SetCheckedCategoryByTab()
        {
            FlowLayoutPanel[] flp = { flpSchoolCategory, flpPersonalCategory, flpEtcCategory };
            foreach (FlowLayoutPanel panel in flp)
            {
                foreach (UserCategory userCategory in panel.Controls)
                {
                    userCategory.SetChecked(category.IsChecked(TabName, userCategory.GetText()));
                }
            }
        }

        //달력 함수-----------------------------------------------------------------------------------------------------------------------------------------
        private void dispalyDate()
        {
            DateTime now = DateTime.Now;

            year = now.Year;
            month = now.Month;
            createDates();
        }

        private void createDates()
        {
            Database.ReadScheduleList();

            lblMonth.Text = month.ToString() + "월";
            lblMonth.TextAlign = ContentAlignment.MiddleCenter;

            DateTime startOfMonth = new DateTime(year, month, 1);
            int dates = DateTime.DaysInMonth(year, month);
            int dayOfWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d")) + 1;
            int index = 0;
            int date = 1;

            foreach (UserDate userDate in flpDays.Controls.OfType<UserDate>())
            {
                if (++index < dayOfWeek) userDate.ChangeBlank();
                else if (date <= dates) userDate.SetDate(date++);
                else userDate.ChangeBlank();

                if (index % 7 == 0) userDate.ChangeColor(Color.Blue);
                else if (index % 7 == 1) userDate.ChangeColor(Color.Red);
            }
        }


        //컨트롤 함수------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //화면 컨트롤-------------------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //마감 일정 컨트롤---------------------------------------------------------------------------------------------------------------
        private void MagamButtonEnable()
        {
            btnMagam_Click(btnMagam_Task, new EventArgs());
            btnMagam_Quiz.Enabled = true;
            btnMagam_Task.Enabled = true;
            btnMagam_Online.Enabled = true;
            btnMagam_Prjct.Enabled = true;
        }

        //마감 버튼 클릭 시, 각 일정에 따른 KLAS 클래스에 정의 된 Dictionary 접근하여 데이터 확인.
        //@todo: 개인 마감일정 관리 개별로 할지 논의 필요.
        private void btnMagam_Click(object sender, EventArgs e)
        {
            Guna2CircleButton btn = (Guna2CircleButton)sender;
            Panel panel = (Panel)btn.Parent;
            foreach (Guna2CircleButton magamBtn in panel.Controls)
            {
                magamBtn.FillColor = SystemColors.HotTrack;
            }
            btn.FillColor = Color.SteelBlue;
            panelMagam.Controls.Clear();
            int index = 0;

            Dictionary<string, int[]> MagamLectureDic = new Dictionary<string, int[]>();
            Dictionary<string, DateTime> MagamMinDate = new Dictionary<string, DateTime>();

            foreach (Schedule schedule in KlasSchedule[btn.Name.Substring(9)])
            {
                //총 개수 구하는 부분
                //ex) 몇 개 중
                if (MagamLectureDic.ContainsKey(schedule.content))
                    MagamLectureDic[schedule.content][0] += 1;
                else
                {
                    MagamLectureDic.Add(schedule.content, new int[2]);
                    MagamLectureDic[schedule.content][0] = 1;
                    MagamLectureDic[schedule.content][1] = 0;
                }
                //가장 최근 마감 일정 남은 시간 구하는 부분
                //ex) 몇 일/시간 남았습니다.
                if (MagamMinDate.ContainsKey(schedule.content))
                {
                    if (MagamMinDate[schedule.content] < schedule.endDate) MagamMinDate[schedule.content] = schedule.endDate;
                }
                else MagamMinDate.Add(schedule.content, schedule.endDate);
            }
            foreach (Schedule schedule in KlasSchedule[btn.Name.Substring(9)])
            {
                //가장 최근 마감 일정 갯수 구하는 부분
                //ex) 몇 개가
                if (MagamMinDate[schedule.content] == schedule.endDate)
                {
                    MagamLectureDic[schedule.content][1] += 1;
                }
            }
            foreach (KeyValuePair<string, int[]> items in MagamLectureDic)
            {
                Label lbl = new Label
                {
                    Name = "KLAS_" + btn.Name.Substring(9) + "_" + index.ToString(),
                    Text = items.Key + " " + KLAS.klasMagamNames[btn.Name.Substring(9)] + " " + items.Value[0] + " 개 중 " + items.Value[1] + " 개가 " + Schedule.MagamDateFrom(MagamMinDate[items.Key]) + " 남았습니다.",
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                };
                lbl.Location = new Point(0, index * (lbl.Height + 3));
                //panelMagam.Controls.Add(lbl);
                if (panel.InvokeRequired) panelMagam.Invoke(new MethodInvoker(delegate { panelMagam.Controls.Add(lbl); }));
                else panelMagam.Controls.Add(lbl);
                index++;
            }
        }

        //달력 컨트롤--------------------------------------------------------------------------------------------------------------------------------------
        private void btnMonth_Click(object sender, EventArgs e)
        {
            switch (((Guna2Button)sender).Name.Substring(3))
            {
                case "Next":
                    if (month == 12) { month = 1; year++; }
                    else month++;
                    break;
                case "Previsous":
                    if (month == 1) { month = 12; year--; }
                    else month--;
                    break;
            }
            createDates();
        }

        //카테고리 컨트롤------------------------------------------------------------------------------------------------------------------------------------
        private void btnSchoolCategory_Click(object sender, EventArgs e)
        {
            flpSchoolCategory.Visible = !flpSchoolCategory.Visible;
        }

        private void btnPersonalCategory_Click(object sender, EventArgs e)
        {
            flpPersonalCategory.Visible = !flpPersonalCategory.Visible;
        }

        private void btnEtcCategory_Click(object sender, EventArgs e)
        {
            flpEtcCategory.Visible = !flpEtcCategory.Visible;
        }

        private void btnPlusCategory_Click(object sender, EventArgs e)
        {
            UserCategory category = new UserCategory();
            category.MouseDoubleClick += UcCategory_MouseDoubleClick;
            flpEtcCategory.Controls.Add(category);
        }

        ////카테고리 유저 컨트롤------------------------------------------------------------------------------------------------------------------------------------
        private UserCategory draggedUcCategory; // 드래그 중인 카테고리 유저 컨트롤
        private UserCategory cloneUcCategory; // 드래그 중인 카테고리 유저 컨트롤 복사본
        private Point MouseLocation;

        public void UndoCategory()
        {
            this.Controls.Remove(cloneUcCategory);
            cloneUcCategory.Dispose();
            draggedUcCategory.Visible = true;
        }
        private void UcCategory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            draggedUcCategory = (UserCategory)sender;
            draggedUcCategory.Visible = false;

            // 드래그 중인 버튼의 복사본 생성
            MouseLocation = new Point((Cursor.Position.X - e.X) - Left, (Cursor.Position.Y - e.Y) - Top); // 현제 마우스 위치
            cloneUcCategory = new UserCategory { Location = MouseLocation };
            cloneUcCategory.DragMode(draggedUcCategory.GetText());
            this.Controls.Add(cloneUcCategory);
            flpMainCategory.SendToBack();
            cloneUcCategory.MouseMove += UcCategory_MouseMove;
            cloneUcCategory.MouseClick += UcCategory_MouseClick;
        }

        private void UcCategory_MouseClick(object sender, MouseEventArgs e)
        {
            string NewMainCategory;
            if (MouseLocation.Y < flpMainCategory.Location.Y + flpPersonalCategory.Location.Y)
            {
                //학교
                NewMainCategory = "SchoolCategory";

            }
            else if (MouseLocation.Y < flpMainCategory.Location.Y + flpEtcCategory.Location.Y)
            {
                //개인
                NewMainCategory = "PersonalCategory";
            }
            else
            {
                //기타
                NewMainCategory = "EtcCategory";
            }

            if (NewMainCategory.Length > 0)
            {
                draggedUcCategory.Visible = true;
                string OringMainCategory = category.SubCategorys[cloneUcCategory.GetText()] as string;
                if (OringMainCategory == NewMainCategory)
                {
                    UndoCategory();
                }
                else
                {
                    this.Controls.Remove(cloneUcCategory);
                    FlowLayoutPanel FlpNewCategory = flpMainCategory.Controls["flp" + NewMainCategory] as FlowLayoutPanel;
                    FlowLayoutPanel FlpOriginCategory = flpMainCategory.Controls["flp" + OringMainCategory] as FlowLayoutPanel;
                    FlpOriginCategory.Controls.Remove(draggedUcCategory);
                    FlpNewCategory.Controls.Add(draggedUcCategory);
                    category.ChangeParentOfSub(NewMainCategory, cloneUcCategory.GetText());
                    draggedUcCategory = null;
                    cloneUcCategory = null;
                }
            }
        }

        private void UcCategory_MouseMove(object sender, MouseEventArgs e)
        {
            MouseLocation = new Point((Cursor.Position.X - cloneUcCategory.Width / 2) - Left, (Cursor.Position.Y - cloneUcCategory.Height / 2) - Top);
            if ((MouseLocation.X < flpMainCategory.Location.X - 100 || MouseLocation.X > flpMainCategory.Location.X + 130)
                || (MouseLocation.Y < flpMainCategory.Location.Y || MouseLocation.Y > flpMainCategory.Location.Y + 450))
            {
                UndoCategory();
            }
            cloneUcCategory.Location = MouseLocation;
        }


    }
}
