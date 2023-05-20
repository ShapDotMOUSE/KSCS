using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static Guna.UI2.WinForms.Helpers.GraphicsHelper;

namespace KSCS
{
    public partial class form : Form
    {
        private int year, month;
        public static int static_month, static_year;
        public static Category Category = new Category();
        public static string TabName;

        MySqlConnection connection = DatabaseConnection.getDBConnection(); //MySQL
        public static List<List<Schedule>> monthScheduleList = new List<List<Schedule>>(); //한달 단위 schedule list
        public static Dictionary<string, string[]> categoryDict = new Dictionary<string, string[]>(); //category dictionary
        
        private Dictionary<string, List<Schedule>> KlasSchedule = new Dictionary<string, List<Schedule>>();
        public static string student_id = "2019203082"; //초기 학번

        Dictionary<string, string> KLAS_LECTURE_NUM = new Dictionary<string, string>();
        public form()
        {
            InitializeComponent();
        }

        public void InitializeDatabase()
        {
            string selectQuery = string.Format("SELECT * from Schedule JOIN Category ON Schedule.category_id=Category.id JOIN StudentCategory ON StudentCategory.student_id=Schedule.student_id and Schedule.category_id=Category.id and Category.id=StudentCategory.category_id WHERE Schedule.student_id={0} and  startDate BETWEEN DATE_FORMAT('{1}', '%Y-%m-%d') AND LAST_DAY('{1}') ORDER BY startDate ASC;", student_id, new DateTime(year, month, 1).ToString("yyyy-MM-dd"));
            MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
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

        private async void KSCS_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(58, 5, 31);
            seperator_vertical.FillColor = Color.FromArgb(245, 245, 245);
            seperator_horizon.FillColor = Color.FromArgb(245, 245, 245);
            Category.TestCategory();


            //초기 탭 설정 
            TabName = btnTestTab1.Name; //수정되어야함

            dispalyDate();
            DisplayCategery();
            SetCheckedCategoryByTab();
            await Klas_Load();
            MagamButtonEnable();
            Guna2MessageDialog message = new Guna2MessageDialog();
            message.Show("KLAS 로딩 완료");
        }

        //카테고리 함수---------------------------------------------------------------------------------------------------------------------------------------
        private void DisplayCategery()
        {
            
            foreach (var item in Category.ParentCategorys["SchoolCategory"] as HashSet<string>)
            {
                UserCategory uc = new UserCategory();
                uc.SetBasicMode(item);
                uc.MouseDoubleClick += UcCategory_MouseDoubleClick;
                flpSchoolCategory.Controls.Add(uc);
            }

            foreach (var item in Category.ParentCategorys["PersonalCategory"] as HashSet<string>)
            {
                UserCategory uc = new UserCategory();
                uc.SetBasicMode(item);
                uc.MouseDoubleClick += UcCategory_MouseDoubleClick;
                flpPersonalCategory.Controls.Add(uc);
            }

            foreach (var item in Category.ParentCategorys["EtcCategory"] as HashSet<string>)
            {
                UserCategory uc = new UserCategory();
                uc.SetBasicMode(item);
                uc.MouseDoubleClick += UcCategory_MouseDoubleClick;
                flpEtcCategory.Controls.Add(uc);
            }
        }

        //탭 함수-------------------------------------------------------------------------------------------------------------------------------------------
        private void ChangeTab(object sender)
        {
            /*
             * TODO: 이 부분에 DB에 연결하는 함수 추가 필요
             */

            TabName = ((Guna2Button)sender).Name;
            SetCheckedCategoryByTab();
        }
        private void SetCheckedCategoryByTab()
        {
            FlowLayoutPanel[]flp = { flpSchoolCategory, flpPersonalCategory, flpEtcCategory };
            foreach (FlowLayoutPanel panel in flp)
            {
                foreach (UserCategory category in panel.Controls)
                {
                    
                    category.SetChecked(Category.IsChecked(TabName, category.GetText()));
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
            static_month = month;
            static_year = year;

            InitializeDatabase(); //MySQL 에서 한달 스케줄 데이터 가져오기

            lblMonth.Text = month.ToString() + "월";
            lblMonth.TextAlign = ContentAlignment.MiddleCenter;

            DateTime startOfMonth = new DateTime(year, month, 1);
            int dates = DateTime.DaysInMonth(year, month);
            int dayOfWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d")) + 1;

            flpDays.Controls.Clear();
            for (int i = 1; i < dayOfWeek; i++)
            {
                UserBlankDate userblankDate = new UserBlankDate();
                flpDays.Controls.Add(userblankDate);
            }

            for (int i = 1; i < dates; i++)
            {
                UserDate userDate = new UserDate();
                userDate.SetDate(i);
                flpDays.Controls.Add(userDate);
            }
        }

        //기타---------------------------------------------------------------------------------------------------------------------------------------------
        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

         private void MagamButtonEnable()
        {
            btnMagam_Click(btnMagam_HomeWork,new EventArgs());
            btnMagamLecture.Enabled = true;
            btnMagam_HomeWork.Enabled = true;
            btnMagam_Quiz.Enabled = true;
            btnMagam_TeamProz.Enabled = true;
        }

        private async Task Klas_Load()
        {
            KlasSchedule.Add("과제", new List<Schedule>());
            KlasSchedule.Add("퀴즈", new List<Schedule>());
            KlasSchedule.Add("강의", new List<Schedule>());
            KlasSchedule.Add("팀플", new List<Schedule>());
            KlasSchedule.Add("개인", new List<Schedule>());

            Dictionary<string, string> KLAS_URL = new Dictionary<string, string>
            {
                { "LoginSecurity", "https://klas.kw.ac.kr/usr/cmn/login/LoginSecurity.do" },
                { "LoginConfirm","https://klas.kw.ac.kr/usr/cmn/login/LoginConfirm.do" },
                { "StdHome","https://klas.kw.ac.kr/std/cmn/frame/StdHome.do" },
                { "OnlineStdList","https://klas.kw.ac.kr/std/lis/evltn/SelectOnlineCntntsStdList.do" },
                { "TaskStdList","https://klas.kw.ac.kr/std/lis/evltn/TaskStdList.do" },
                { "PrjctStdList","https://klas.kw.ac.kr/std/lis/evltn/PrjctStdList.do"},
                { "QuizStdList","https://klas.kw.ac.kr/std/lis/evltn/AnytmQuizStdList.do" }
            };


            var httpClientHandler = new HttpClientHandler()
            {
                UseProxy = true,
                UseCookies = true,
                UseDefaultCredentials = true,
                PreAuthenticate = true

            };
            CookieContainer cookieContainer = new CookieContainer();
            httpClientHandler.CookieContainer = cookieContainer;
            var httpClient = new HttpClient(httpClientHandler)
            {
                Timeout = TimeSpan.FromSeconds(30),
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36 Edge/16.16299");


            var publicKeyRequest = new HttpRequestMessage(HttpMethod.Post, KLAS_URL["LoginSecurity"]){Content = new StringContent("")};
            try
            {
                publicKeyRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=UTF-8");

                HttpResponseMessage response = await httpClient.SendAsync(publicKeyRequest);

                string responseBody = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                JObject security = JObject.Parse(responseBody);

                // 로그인 토큰 생성
                var input = new
                {
                    loginId = "2019203082",
                    loginPwd = "setset612@",
                    storeIdYn = "N"
                };

                var loginJson = JsonConvert.SerializeObject(input);


                var rsa = new RSACryptoServiceProvider();
                byte[] publicKeyBytes = Convert.FromBase64String(security["publicKey"].ToString());
                AsymmetricKeyParameter publicKey = PublicKeyFactory.CreateKey(publicKeyBytes);

                IBufferedCipher cipher = CipherUtilities.GetCipher("RSA/None/PKCS1Padding");
                cipher.Init(true, publicKey);

                byte[] encryptedBytes = cipher.DoFinal(Encoding.UTF8.GetBytes(loginJson));

                string encryptedToen = Convert.ToBase64String(encryptedBytes);

                var login = new
                {
                    loginToken = encryptedToen,
                    redirectUrl = "",
                    redirectTabUrl = ""
                };
                string loginToken = JsonConvert.SerializeObject(login);
                var loginRequest = new HttpRequestMessage(HttpMethod.Post, KLAS_URL["LoginConfirm"])
                {
                    Content = new StringContent(loginToken, Encoding.UTF8, "application/json")
                };

                HttpResponseMessage loginResponse = await httpClient.SendAsync(loginRequest);
                loginResponse.EnsureSuccessStatusCode();
                var sbjectListRequest = new HttpRequestMessage(HttpMethod.Post, KLAS_URL["StdHome"])
                {
                    Content = new StringContent("{}", Encoding.UTF8, "application/json")
                };

                HttpResponseMessage sbjectListResponse = await httpClient.SendAsync(sbjectListRequest);
                string data = await sbjectListResponse.Content.ReadAsStringAsync();
                JObject sbjectList = JObject.Parse(data);
                foreach (JToken subj in sbjectList["atnlcSbjectList"])
                {
                    var magamContent = new
                    {
                        selectSubj = subj["subj"].ToString(),
                        selectYearhakgi = "2023,1",
                        selectChangeYn = "Y"
                    };
                    Schedule schedule;
                    var magamOnlineRequest = new HttpRequestMessage(HttpMethod.Post, KLAS_URL["OnlineStdList"]) { Content = new StringContent(JsonConvert.SerializeObject(magamContent), Encoding.UTF8, "application/json") };
                    var magamTaskRequest = new HttpRequestMessage(HttpMethod.Post, KLAS_URL["TaskStdList"]) { Content = new StringContent(JsonConvert.SerializeObject(magamContent), Encoding.UTF8, "application/json") };
                    var magamPrjctRequest = new HttpRequestMessage(HttpMethod.Post, KLAS_URL["PrjctStdList"]) { Content = new StringContent(JsonConvert.SerializeObject(magamContent), Encoding.UTF8, "application/json") };
                    var magamQuizRequest = new HttpRequestMessage(HttpMethod.Post, KLAS_URL["QuizStdList"]) { Content = new StringContent(JsonConvert.SerializeObject(magamContent), Encoding.UTF8, "application/json") };
                    KLAS_LECTURE_NUM.Add(subj["subjNm"].ToString(), subj["subj"].ToString());
                    HttpResponseMessage magamOnlineResponse = await httpClient.SendAsync(magamOnlineRequest);
                    string onlineData = await magamOnlineResponse.Content.ReadAsStringAsync();
                    var online = JArray.Parse(onlineData);
                    foreach (JToken o in online)
                    {
                        schedule = Schedule.KLAS_Schedule(o["moduletitle"].ToString(), "강의", subj["subjNm"].ToString(), o["endDate"].ToString());
                        if (schedule.MagamBeforeNow())
                            KlasSchedule["강의"].Add(schedule);
                    }
                    HttpResponseMessage magamTaskResponse = await httpClient.SendAsync(magamTaskRequest);
                    string taskData = await magamTaskResponse.Content.ReadAsStringAsync();
                    JArray task = JArray.Parse(taskData);
                    foreach (JToken t in task)
                    {
                        schedule = Schedule.KLAS_Schedule(t["title"].ToString(), "과제", subj["subjNm"].ToString(), t["expiredate"].ToString());
                        if (schedule.MagamBeforeNow()) KlasSchedule["과제"].Add(schedule);
                    }
                    HttpResponseMessage magamQuizResponse = await httpClient.SendAsync(magamQuizRequest);
                    string quizData = await magamQuizResponse.Content.ReadAsStringAsync();
                    JArray quiz = JArray.Parse(quizData);
                    foreach (JToken q in quiz)
                    {
                        schedule = Schedule.KLAS_Schedule(q["papernm"].ToString(), "퀴즈", subj["subjNm"].ToString(), q["edt"].ToString());
                        if (schedule.MagamBeforeNow()) KlasSchedule["퀴즈"].Add(schedule);
                    }

                    HttpResponseMessage magamPrjctResponse = await httpClient.SendAsync(magamPrjctRequest);
                    string prjctData = await magamPrjctResponse.Content.ReadAsStringAsync();
                    JArray prjct = JArray.Parse(prjctData);
                    foreach (JToken p in prjct)
                    {
                        schedule = Schedule.KLAS_Schedule(p["title"].ToString(), "팀플", subj["subjNm"].ToString(), p["expiredate"].ToString());
                        if (schedule.MagamBeforeNow())  KlasSchedule["팀플"].Add(schedule);
                    }

                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


private void btnMagam_Click(object sender, EventArgs e)
        {
            Guna2CircleButton btn = (Guna2CircleButton)sender;
            Panel panel = (Panel)btn.Parent;
            foreach (Guna2CircleButton magamBtn in panel.Controls)
            {
                magamBtn.FillColor = SystemColors.HotTrack;
            }
            btn.FillColor = Color.SteelBlue;
            panelMagamList.Controls.Clear();
            int index = 0;

            Dictionary<string, int[]> MagamLectureDic = new Dictionary<string, int[]>();
            Dictionary<string, DateTime> MagamMinDate = new Dictionary<string, DateTime>();
            foreach (Schedule schedule in KlasSchedule[btn.Text])
            {
                if (MagamLectureDic.ContainsKey(schedule.content))
                    MagamLectureDic[schedule.content][0] += 1;
                else
                {
                    MagamLectureDic.Add(schedule.content, new int[2]);
                    MagamLectureDic[schedule.content][0] = 1;
                    MagamLectureDic[schedule.content][1] = 0;
                }
                if (MagamMinDate.ContainsKey(schedule.content))
                {
                    if (MagamMinDate[schedule.content] < schedule.endDate) MagamMinDate[schedule.content] = schedule.endDate;
                }
                else MagamMinDate.Add(schedule.content, schedule.endDate);
            }
            foreach (Schedule schedule in KlasSchedule[btn.Text])
            {
                if (MagamMinDate[schedule.content] == schedule.endDate)
                {
                    MagamLectureDic[schedule.content][1] += 1;
                }
            }
            foreach (KeyValuePair<string, int[]> items in MagamLectureDic)
            {
                Label lbl = new Label();
                lbl.Name = "KLAS_" + btn.Text + "_" + index.ToString();
                lbl.Text = items.Key + " " + btn.Text + " " + items.Value[0] + " 개 중 " + items.Value[1] + " 개가 " + Schedule.MagamDateFrom(MagamMinDate[items.Key]) + " 남았습니다.";
                lbl.ForeColor = Color.White;
                lbl.AutoSize = true;
                lbl.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
                lbl.Location = new Point(0, index * (lbl.Height + 3));
                panelMagamList.Controls.Add(lbl);
                index++;
            }

        }

        private void MagamDanger()
        {
            //foreach(var data in )
            foreach(Guna2CircleButton btn in panelMagam.Controls)
            {
                
            }
        }

        //컨트롤 함수------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //달력 컨트롤--------------------------------------------------------------------------------------------------------------------------------------
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (month == 12)
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

        //카테고리 유저 컨트롤------------------------------------------------------------------------------------------------------------------------------------
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
            cloneUcCategory = new UserCategory{Location = MouseLocation};
            cloneUcCategory.DragMode(draggedUcCategory.GetText());
            this.Controls.Add(cloneUcCategory);
            flpMainCategory.SendToBack();
            cloneUcCategory.MouseMove += UcCategory_MouseMove;
            cloneUcCategory.MouseClick += UcCategory_MouseClick;
        }

        private void UcCategory_MouseClick(object sender, MouseEventArgs e)
        {
            string NewMainCategory;
            if(MouseLocation.Y < flpMainCategory.Location.Y + flpPersonalCategory.Location.Y)
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

            if(NewMainCategory.Length > 0)
            {
                draggedUcCategory.Visible = true;
                string OringMainCategory = Category.SubCategorys[cloneUcCategory.GetText()] as string;
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
                    Category.ChangeParentOfSub(NewMainCategory, cloneUcCategory.GetText());
                    draggedUcCategory = null;
                    cloneUcCategory = null;
                }
            }
            
        }

        private void UcCategory_MouseMove(object sender, MouseEventArgs e)
        {
            MouseLocation = new Point((Cursor.Position.X - cloneUcCategory.Width/2) - Left, (Cursor.Position.Y - cloneUcCategory.Height / 2) - Top);
            if ((MouseLocation.X < flpMainCategory.Location.X - 100 || MouseLocation.X > flpMainCategory.Location.X + 130) 
                || (MouseLocation.Y < flpMainCategory.Location.Y || MouseLocation.Y > flpMainCategory.Location.Y + 450))
            {
                UndoCategory();
            }
            cloneUcCategory.Location = MouseLocation;
        }


        //탭 컨트롤------------------------------------------------------------------------------------------------------------------------------------
        private void btnTestTab1_Click(object sender, EventArgs e)
        {
            ChangeTab(sender);
        }
    }
}
