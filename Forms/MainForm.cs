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
            LoginForm loginForm=new LoginForm();

            DialogResult Result=loginForm.ShowDialog();

            if(Result == DialogResult.OK)
            {
                dispalyDate();
                lblStdNum.Text = stdNum;
            }
            else
            {
                Close();
            }
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

       

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Close();
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

        


    }
}
