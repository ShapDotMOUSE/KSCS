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
        public static int static_date; //추가(클릭한 날)

        public UserDate()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 18, 18)); //폼 모양 둥글게
        }

        private void LoadUserDate()
        {
            flpEvent.Controls.Clear(); //userEvent 컨트롤 초기화
            foreach (Schedule schedule in monthScheduleList[Convert.ToInt32(lblDate.Text) - 1])
                AddEvent(schedule.title, int.Parse(categoryDict[schedule.category][1]));

        }

        public void ChangeBlank()
        {
            flpEvent.Controls.Clear();
            if (lblDate.Visible)
            {
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
                btnTransparent.MouseEnter += UserDate_MouseEnter;
                btnTransparent.MouseLeave += UserDate_MouseLeave;
                btnTransparent.MouseClick += UserDate_Click;

            }
            lblDate.Text = date.ToString();
            LoadUserDate();
        }

        private void UserDate_MouseEnter(object sender, EventArgs e)
        {
            //Cursor = Cursors.Hand;
            BackColor = Color.FromArgb(218, 213, 196);
        }

        private void UserDate_MouseLeave(object sender, EventArgs e)
        {
            //Cursor = Cursors.Default;
            BackColor = Color.FromArgb(255, 249, 229);
        }

        private void UserDate_Click(object sender, MouseEventArgs e)
        {
            //Cursor = Cursors.Default;
            static_date = Convert.ToInt32(lblDate.Text); //날
            ScheDetailForm eventForm = new ScheDetailForm();
            eventForm.AddEvent += new EventHandler(SaveEvent); //이벤트 발생
            //추가
            eventForm.ShowDialog();
        }

        // update(add/modify,delete) event
        private void SaveEvent(object sender, EventArgs e)
        {
            LoadUserDate();
            this.Refresh();
        }

        private void AddEvent(string dateEvent, int eventType) //userEvent 생성
        {
            if (dateEvent.Equals(string.Empty))
                return;
            UserEvent userEvent = new UserEvent();
            userEvent.SetEventInfo(dateEvent);
            userEvent.SetColor(eventType);
            flpEvent.Controls.Add(userEvent);
            this.Refresh();
        }
    }
}
