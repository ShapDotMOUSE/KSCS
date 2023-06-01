using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;
using KSCS.Class;
using static KSCS.Class.KSCS_static;
using System.Net.Sockets;
using Socket;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;

namespace KSCS
{
    public partial class MainForm : Form
    {
        //스케줄 관련
        public MainForm()
        {
            InitializeComponent();
        }
        TcpListener listener;
        SocketClient s_client = null;
        public static FlowLayoutPanel flowLayoutPanelLable;
        private void MainForm_Load(object sender, EventArgs e)
        {

            flowLayoutPanelLable = flpLabel;

            KLAS.initializeKLAS();
            LoginForm loginForm = new LoginForm();
            DialogResult Result = loginForm.ShowDialog();
            if (Result == DialogResult.OK)
            {
                LoadMagam();
                lblStdNum.Text = stdNum;
                //초기 메인 카테고리 설정
                Database.ReadCategoryList();
                Database.ReadTabAndCategory();
                foreach (string Main in category.Categories.Keys)
                {
                    UserMainCategory category = new UserMainCategory();
                    category.SetAddMode(Main);
                    panelMainCategory.Controls.Add(category);
                }


                //초기 탭 설정 
                TabAll.Clicked += ChangeTab;
                Tab1.Clicked += ChangeTab;
                Tab2.Clicked += ChangeTab;
                Tab3.Clicked += ChangeTab;
                Tab4.Clicked += ChangeTab;
                //btnSharing.Clicked += CreateSharing;
                btnSharing.Clicked += btnShare_Click;
                //btnSharing.DoubleClicked += CreateSharing;
                setTab();

                //달력 (탭 위에 위치 -> 현재)
                dispalyDate();
                DisplayCategery();

                //탭 로드
                SetCheckedCategoryByTab();
                TabAll.ShowTab();
            }
            else
                Close();

            this.Size = new Size(1360, 960);

        }

        private void setTab()
        {
            List<string> tabNameList = Database.ReadTab();
            TabAll.Name = tabNameList[0];
            Tab1.Name = tabNameList[1];
            Tab2.Name = tabNameList[2];
            Tab3.Name = tabNameList[3];
            Tab4.Name = tabNameList[4];
        }
        private async void LoadMagam()
        {
            await KLAS.LoadMagamData();
            MagamButtonEnable();
        }

        //private void MainForm_Resize(object sender, EventArgs e)
        //{
        //    this.Size = new Size(1340, 960);
        //    this.MaximumSize = new Size(1340, 960);
        //    this.MinimumSize = new Size(1340, 960);
        //}


        //카테고리 함수---------------------------------------------------------------------------------------------------------------------------------------
        private void DisplayCategery()
        {
            foreach (var key in category.Categories.Keys)
            {
                foreach (var item in category.Categories[key])
                {
                    UserSubCategory uc = new UserSubCategory();
                    uc.SetBasicMode(item);
                    ((FlowLayoutPanel)((UserMainCategory)panelMainCategory.Controls[key]).flpSubCategory).Controls.Add(uc);
                }
            }
        }



        //탭 함수-------------------------------------------------------------------------------------------------------------------------------------------
        private void ChangeTab(object sender, EventArgs e)
        {
            /*
             * TODO: 이 부분에 DB에 연결하는 함수 추가 필요
             */
            UserTabButton OldTab = this.Controls[TabName] as UserTabButton;
            UserTabButton btn = sender as UserTabButton;
            TabName = btn.Name;
            OldTab.HideTab();
            SetCheckedCategoryByTab();

            LoadMainForm(); //추가
        }
        private void SetCheckedCategoryByTab()
        {
            flpLabel.Controls.Clear();
            foreach (string key in category.Categories.Keys)
            {
                FlowLayoutPanel flp = ((UserMainCategory)panelMainCategory.Controls[key]).flpSubCategory;
                foreach (UserSubCategory subCategory in flp.Controls)
                {
                    Color subColor = KSCS_static.category.GetColor(subCategory.GetText());
                    if (TabName != TabAll.Name)
                    {
                        bool check = category.IsChecked(TabName, subCategory.GetText());
                        subCategory.SetCheckedEnable(true);
                        subCategory.SetChecked(check);
                    }
                    else
                    {
                        subCategory.SetCheckedEnable(false);
                        subCategory.SetChecked(true);
                    }

                    subCategory.SetColor(subColor);
                }
            }
        }

        //달력 함수-----------------------------------------------------------------------------------------------------------------------------------------
        private void dispalyDate()
        {
            DateTime now = DateTime.Now; //수정 필요

            year = now.Year;
            month = now.Month;
            createDates();
        }

        private void createDates()
        {
            //Database.ReadScheduleList();
            Database.ReadTabScheduleList();

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
            btnMagam_Click(btnMagam_Online, new EventArgs());
            btnMagam_Quiz.Enabled = true;
            btnMagam_Online.Enabled = true;
            btnMagam_Task.Enabled = true;
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
                magamBtn.FillColor = Color.FromArgb(217, 217, 217); ;
            }
            //btn.FillColor = Color.FromArgb(217,217,217);
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

        private void btnPlusCategory_Click(object sender, EventArgs e)
        {
            UserMainCategory category = new UserMainCategory();
            category.SetNewMode();
            panelMainCategory.Controls.Add(category);
        }

        public IEnumerable<UserDate> GetUserDate()
        {
            return flpDays.Controls.OfType<UserDate>();
        }




        //    //실시간 일정 공유 생성 : 현재 더블클릭
        //    //사용자 본인은 포트를 열지 않음. 모두 Listner에게 연결시도
        public void CreateSharing(object sender, EventArgs e)
        {

            MessageBox.Show("실시간 일정 공유 생성");

            List<string> testStdnums = new List<string>
                {
                    "2019203055",
                    "2019203018",
                    "2019203082",
                };

            List<string> testTodo = testStdnums.ToList();
            testTodo.Remove(stdNum);


            s_client = new SocketClient(stdNum);
            s_client.OnConnect += new SocketClient.ConnectClientHandler(ConnectClient);
            s_client.OnLoadAddress += new SocketClient.LoadAddress(LoadAddress);
            s_client.OnMessage += new SocketClient.MessageHandler(Message);
            s_client.addressDict = Database.GetAddress(testStdnums);
            //Init 데이터 생성
            s_client.InitClass = new Init
            {
                Type = (int)PacketType.INIT,
                members = testStdnums,
                todoLink = testTodo,
                boss = stdNum,
                sender = stdNum
            };
            s_client.sendClientTodo();
        }

        public void ConnectClient(string sender, List<string> todo)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                MessageBox.Show("연결 성공!\r\n"
                    + "\r\n 연결된 사람 : " + sender
                    + "\r\n todo : " + string.Join(",", todo.Select(std => string.Format("'{0}'", std))));
            }));
        }

        public void Message(string message)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                MessageBox.Show(message);
            }));
        }

        public void LoadAddress()
        {
            if (s_client != null)
            {
                s_client.addressDict = Database.GetAddress(s_client.InitClass.todoLink);
            }
        }
        async public Task ParticipateSharing()
        {
            Database.SetAddress();
            listener = new TcpListener(IPAddress.Any, 7777);
            listener.Start();
            Console.WriteLine("Start Listener");
            s_client = new SocketClient(stdNum);
            s_client.OnConnect += new SocketClient.ConnectClientHandler(ConnectClient);
            s_client.OnLoadAddress += new SocketClient.LoadAddress(LoadAddress);
            s_client.OnMessage += new SocketClient.MessageHandler(Message);
            while (true)
            {
                try
                {
                    TcpClient client = await listener.AcceptTcpClientAsync().ConfigureAwait(false); //주최자 접속
                    Task.Run(() => s_client.readStreamData(client));

                }
                catch (SocketException se)
                {
                    Trace.WriteLine(string.Format("ParticipateSharing - SocketException : {0}", se.Message));
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(string.Format("ParticipateSharing - Exception : {0}", ex.Message));
                }
            }

        }

        

        //실시간 일정 공유 참가 : 현재 클릭
        public void btnShare_Click(object sender, EventArgs e)
        {
            MessageBox.Show("시작");
            Task.Run(()=>ParticipateSharing());
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (listener != null)
            {
                this.listener.Stop();
            }
            if (s_client.clientSocketDict.Count > 0)
            {
                foreach (KeyValuePair<string, TcpClient> keyValue in s_client.clientSocketDict)
                    keyValue.Value.Close();
            }
            Database.DeleteAddress();
        }
        public static void LoadMainForm()
        {
            Database.ReadTabScheduleList();

            DateTime startOfMonth = new DateTime(year, month, 1);
            int dates = DateTime.DaysInMonth(year, month);
            int dayOfWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d")) + 1;
            int index = 0;
            int date = 1;

            foreach (UserDate userDate in Application.OpenForms.OfType<MainForm>().FirstOrDefault().GetUserDate())
            {
                if (++index < dayOfWeek) userDate.ChangeBlank();
                else if (date <= dates) userDate.SetDate(date++);
                else userDate.ChangeBlank();

                if (index % 7 == 0) userDate.ChangeColor(Color.Blue);
                else if (index % 7 == 1) userDate.ChangeColor(Color.Red);
            }
        }
    }
}
