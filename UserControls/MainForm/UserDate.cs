using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static KSCS.Class.KSCS_static;

namespace KSCS
{
    public partial class UserDate : UserControl
    {
        public static int static_date; //클릭한 날

        public UserDate()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 18, 18)); //폼 모양 둥글게
        }

        private void LoadUserDate()
        {
            flpEvent.Controls.Clear(); //userEvent 컨트롤 초기화
            foreach (Schedule schedule in monthScheduleList[Convert.ToInt32(lblDate.Text) - 1])
                AddEvent(schedule.title, category.GetColor(schedule.category));
            this.Refresh();
        }

        public void ChangeBlank()
        {
            flpEvent.Controls.Clear();
            if (lblDate.Visible)
            {
                lblDate.Text = "";
                BackColor = Color.White;
                lblDate.Visible = false;
                Cursor = Cursors.Default;
                btnTransparent.MouseEnter -= UserDate_MouseEnter;
                btnTransparent.MouseLeave -= UserDate_MouseLeave;
                btnTransparent.MouseClick -= UserDate_Click;
            }
        }

        public void ChangeColor(Color color)
        {
            lblDate.ForeColor=color;
        }

        //Form 모양 둥글게 하는 함수, 필요 시 전역으로 따로 관리
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);


        //Date 설정 함수
        public void SetDate(int date)
        {
            if (!lblDate.Visible)
            {
                BackColor = Color.FromArgb(255, 249, 229);
                lblDate.Visible = true;
                Cursor = Cursors.Hand;
                btnTransparent.MouseEnter += UserDate_MouseEnter;
                btnTransparent.MouseLeave += UserDate_MouseLeave;
                btnTransparent.MouseClick += UserDate_Click;
            }
            lblDate.Text = date.ToString();
            LoadUserDate();
        }

        private void UserDate_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(218, 213, 196);
        }

        private void UserDate_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(255, 249, 229);
        }

        private void UserDate_Click(object sender, MouseEventArgs e)
        {
            static_date = Convert.ToInt32(lblDate.Text); //날
            ScheDetailForm eventForm = new ScheDetailForm();
            eventForm.AddEvent += new EventHandler(SaveEvent); //이벤트 발생
            eventForm.ShowDialog();
        }

        // update(add/modify,delete) event & public 으로 수정
        public void SaveEvent(object sender, EventArgs e)
        {
            flpEvent.Controls.Clear(); //userEvent 컨트롤 초기화
            LoadUserDate();
        }

        private void AddEvent(string dateEvent, Color eventColor) //userEvent 생성
        {
            if (dateEvent.Equals(string.Empty))
                return;
            UserEvent userEvent = new UserEvent();
            userEvent.SetEventInfo(dateEvent);
            userEvent.SetColor(eventColor);
            flpEvent.Controls.Add(userEvent);
        }
        public string GetLblDate()
        {
            return lblDate.Text;
        }
    }
}
