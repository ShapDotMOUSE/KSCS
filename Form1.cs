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
    public partial class KSCS : Form
    {
        private Point mousePoint;
        private int year;
        private int month;
        public KSCS()
        {
            InitializeComponent();
            
        }

        private void KSCS_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(58, 5, 31);
            seperator_vertical.FillColor = Color.FromArgb(245, 245, 245);
            seperator_horizon.FillColor = Color.FromArgb(245, 245, 245);
            category_underline.BackColor = Color.FromArgb(58, 5, 31);
            dispalyDate();
        }

        private void dispalyDate()
        {
            DateTime now = DateTime.Now;

            year = now.Year;
            month = now.Month;
            createDates();
        }

        private void createDates()
        {
            lblMonth.Text = month.ToString() + "월";
            lblMonth.TextAlign = ContentAlignment.MiddleCenter;

            DateTime startOfMonth = new DateTime(year, month, 1);
            int dates = DateTime.DaysInMonth(year, month);
            int dayOfWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d")) + 1;

            daysConatiner.Controls.Clear();
            for (int i = 1; i < dayOfWeek; i++)
            {
                UserBlankDate userblankDate = new UserBlankDate();
                daysConatiner.Controls.Add(userblankDate);
            }

            for (int i = 1; i < dates; i++)
            {
                UserDate userDate = new UserDate();
                userDate.SetDate(i);
                daysConatiner.Controls.Add(userDate);
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void KSCS_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint=new Point(e.X, e.Y);
        }

        private void KSCS_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                int x = mousePoint.X - e.X;
                int y = mousePoint.Y - e.Y;
                Location = new Point(this.Left - x, this.Top - y);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(month == 12)
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
