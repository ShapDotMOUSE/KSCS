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
    public partial class UserDate : UserControl
    {
        public static int static_date;

        public UserDate()
        {
            InitializeComponent();
        }

        public void SetDate(int date)
        {
            lblDate.Text = date.ToString();
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
            static_date = Convert.ToInt32(lblDate.Text);
            TempAddEventForm eventForm = new TempAddEventForm();
            eventForm.AddEvent += new EventHandler(SaveEvent);
            eventForm.Show();
        }

        private void SaveEvent(object sender, EventArgs e)
        {
            TempAddEventForm userControl = sender as TempAddEventForm;
             AddEvent(userControl.GetTxtboxEvent(), userControl.GetCmbType());
        }

        private void AddEvent(string dateEvent, int eventType)
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
