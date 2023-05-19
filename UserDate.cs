using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KSCS
{
    public partial class UserDate : UserControl
    {
        public static int static_date;

        public UserDate()
        {
            InitializeComponent();
            //LoadUserDate();
        }

        private void LoadUserDate()
        {
            for (int i=0;i< KSCS.monthScheduleList[Convert.ToInt32(lblDate.Text) - 1].Count; i++)
            {
                AddEvent(KSCS.monthScheduleList[Convert.ToInt32(lblDate.Text) - 1][i].title, int.Parse(KSCS.categoryDict[KSCS.monthScheduleList[Convert.ToInt32(lblDate.Text) - 1][i].category][1]));
            }
            
        }

        public void SetDate(int date)
        {
            lblDate.Text = date.ToString();
            LoadUserDate();
        }

        private void UserDate_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.Gray;
        }

        private void UserDate_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Gainsboro;
        }

        private void UserDate_Click(object sender, MouseEventArgs e)
        {
            static_date = Convert.ToInt32(lblDate.Text); //날
            ScheDetailForm eventForm = new ScheDetailForm();
            eventForm.AddEvent += new EventHandler(SaveEvent); //이벤트 발생
            eventForm.Show();
        }

        private void SaveEvent(object sender, EventArgs e)
        {
            ScheDetailForm userControl = sender as ScheDetailForm;
            AddEvent(userControl.GetTbTitle(), userControl.GetCbCategory());

        }

        private void AddEvent(string dateEvent, int eventType) //userEvent 생성
        {
            if (dateEvent.Equals(string.Empty))
                return;
            UserEvent userEvent = new UserEvent();
            userEvent.SetEventInfo(dateEvent);
            userEvent.SetColor(eventType);
            flpEvent.Controls.Add(userEvent); 
        }
    }
}
