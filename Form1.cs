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
using static Guna.UI2.WinForms.Helpers.GraphicsHelper;

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

            Category.TestCategory();
            dispalyDate();
            DisplayCategery();
        }

        //카테고리 함수---------------------------------------------------------------------------------------------------------------------------------------
        private void DisplayCategery()
        {
            
            foreach (var item in Category.ParentCategory["SchoolCategory"] as HashSet<string>)
            {
                UserCategory uc = new UserCategory();
                uc.SetBasicMode(item);
                uc.MouseDoubleClick += UcCategory_MouseDoubleClick;
                flpSchoolCategory.Controls.Add(uc);
            }

            foreach (var item in Category.ParentCategory["PersonalCategory"] as HashSet<string>)
            {
                UserCategory uc = new UserCategory();
                uc.SetBasicMode(item);
                uc.MouseDoubleClick += UcCategory_MouseDoubleClick;
                flpPersonalCategory.Controls.Add(uc);
            }

            foreach (var item in Category.ParentCategory["EtcCategory"] as HashSet<string>)
            {
                UserCategory uc = new UserCategory();
                uc.SetBasicMode(item);
                uc.MouseDoubleClick += UcCategory_MouseDoubleClick;
                flpEtcCategory.Controls.Add(uc);
            }
        }

        //탭 함수-------------------------------------------------------------------------------------------------------------------------------------------
        private void SetCheckedCategoryByTab()
        {
            foreach (FlowLayoutPanel flp in flpMainCategory.Controls)
            {
                foreach (UserCategory category in flp.Controls)
                {
                    category.SetChecked(Category.Checked.Contains(category.GetName()));
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
                string OringMainCategory = Category.SubCategory[cloneUcCategory.GetText()] as string;
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
            Category.TestTab1();
            SetCheckedCategoryByTab();
        }

        private void btnTestTab2_Click(object sender, EventArgs e)
        {
            Category.TestTab2();
            SetCheckedCategoryByTab();
        }

        private void btnTestTab3_Click(object sender, EventArgs e)
        {
            Category.TestTab3();
            SetCheckedCategoryByTab();
        }
    }
}
