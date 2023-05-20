using crypto;
using Guna.UI2.WinForms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Panel = System.Windows.Forms.Panel;
using KSCS.Class;

namespace KSCS
{
    public partial class MainForm : Form
    {
        public static KLAS klas = new KLAS();

        private int year, month;
        public static int static_month, static_year;

        public static string stdNum;
        public static Category Category = new Category();
        public static string TabName;

        

        public MainForm()
        {
            InitializeComponent();
            LoginForm loginForm = new LoginForm();

            DialogResult Result = loginForm.ShowDialog();

            if (Result == DialogResult.OK)
            {
                dispalyDate();
                lblStdNum.Text = stdNum;
                LoadMagam();
            }
            else
            {
                Close();
            }
        }

        private async void LoadMagam()
        {
            await klas.LoadMagamData();
            MagamButtonEnable();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(1280, 960);
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

            foreach (Schedule schedule in klas.KlasSchedule[btn.Name.Substring(9)])
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
            foreach (Schedule schedule in klas.KlasSchedule[btn.Name.Substring(9)])
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
                panelMagam.Controls.Add(lbl);
                index++;
            }
        }

        //달력 컨트롤--------------------------------------------------------------------------------------------------------------------------------------
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (month == 12) { month = 1; year++; }
            else month++;
            createDates();
        }

        private void btnPrvious_Click(object sender, EventArgs e)
        {
            if (month == 1) { month = 12; year--; }
            else month--;
            createDates();
        }


    }
}
