using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSCS
{
    public partial class MainForm : Form
    {
        private int year, month;
        public static int static_month, static_year;
        public static Category Category = new Category();
        public static string TabName;
        public MainForm()
        {
            InitializeComponent();
            dispalyDate();
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
    }
}
