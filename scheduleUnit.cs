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
    public partial class scheduleUnit : UserControl
    {
        public scheduleUnit()
        {
            InitializeComponent();
        }

        public string ScheduleTitle
        {
            get
            {
                return this.btnSchedule.Text;
            }
            set
            {
                this.btnSchedule.Text = value;
            }
        }

        public void ChangeScheduleColor(Color color)
        {
            this.btnSchedule.BorderColor = color;
        }
    }
}
