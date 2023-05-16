using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace KSCS
{
    public partial class KSCS : Form
    {
        private int year, month;
        public static int static_month, static_year;
        public static Category Category = new Category();
        public KSCS()
        {
            InitializeComponent();
        }

        private void KSCS_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(58, 5, 31);
            seperator_vertical.FillColor = Color.FromArgb(245, 245, 245);
            seperator_horizon.FillColor = Color.FromArgb(245, 245, 245);
            
            dispalyDate();
            DisplayCategery();
        }

        private void DisplayCategery()
        {
            
            foreach (var item in Category.MainCategory["ShcoolCategory"] as HashSet<string>)
            {
                UserCategory uc = new UserCategory();
                uc.SetBasicMode(item);
                uc.MouseDoubleClick += UcCategory_MouseDoubleClick;
                flpSchoolCategory.Controls.Add(uc);
            }

            foreach (var item in Category.MainCategory["PersonalCategory"] as HashSet<string>)
            {
                UserCategory uc = new UserCategory();
                uc.SetBasicMode(item);
                uc.MouseDoubleClick += UcCategory_MouseDoubleClick;
                flpPersonalCategory.Controls.Add(uc);
            }

            foreach (var item in Category.MainCategory["EtcCategory"] as HashSet<string>)
            {
                UserCategory uc = new UserCategory();
                uc.SetBasicMode(item);
                uc.MouseDoubleClick += UcCategory_MouseDoubleClick;
                flpEtcCategory.Controls.Add(uc);
            }
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
            flpEtcCategory.Controls.Add(category);
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

        private UserCategory draggedUcCategory; // 드래그 중인 카테고리 유저 컨트롤
        private UserCategory cloneUcCategory; // 드래그 중인 카테고리 유저 컨트롤 복사본

        private void UcCategory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
               UserCategory ucCategory = (UserCategory)sender;
                draggedUcCategory = ucCategory;
                Point Position = new Point((Cursor.Position.X - e.X) - Left, (Cursor.Position.Y - e.Y) - Top);

                // 드래그 중인 버튼의 복사본 생성
                cloneUcCategory = new UserCategory{Location = Position};
                cloneUcCategory.DragMode(ucCategory.GetName());
                this.Controls.Add(cloneUcCategory);
            flpMainCategory.SendToBack();
                cloneUcCategory.MouseMove += UcCategory_MouseMove;
                cloneUcCategory.MouseUp += UcCategory_MouseUp;
        }

        private void UcCategory_MouseUp(object sender, MouseEventArgs e)
        {
            this.Controls.Remove(cloneUcCategory);
            cloneUcCategory.Dispose();
        }

        private void UcCategory_MouseMove(object sender, MouseEventArgs e)
        {
            Point Position = new Point((Cursor.Position.X - cloneUcCategory.Width/2) - Left, (Cursor.Position.Y - cloneUcCategory.Height / 2) - Top);
            cloneUcCategory.Location = Position;
        }

    }
}
