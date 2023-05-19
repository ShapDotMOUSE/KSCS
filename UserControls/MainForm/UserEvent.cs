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
    public partial class UserEvent : UserControl
    {
        public enum EventType
        {
            None = 0,
            School = 1,
            Personal = 2,
            Etc = 3
        }
        public UserEvent()
        {
            InitializeComponent();
        }


        public void SetEventInfo(string enventInfo)
        {
            txtEventInfo.Text = enventInfo;
        }

        public void SetColor(int type)
        {
            switch((EventType)type)
            {
                case EventType.None:
                    pnl.BackColor= Color.SteelBlue;
                    flpEventInfo.BackColor= Color.LightSkyBlue;
                    break;
                case EventType.School:
                    pnl.BackColor = Color.FromArgb(205,80,80);
                    flpEventInfo.BackColor = Color.FromArgb(211, 149, 149);
                    break;
                case EventType.Personal:
                    pnl.BackColor = Color.FromArgb(160, 223, 80);
                    flpEventInfo.BackColor = Color.FromArgb(189, 220, 149);
                    break;
                case EventType.Etc:
                    pnl.BackColor = Color.SteelBlue;
                    flpEventInfo.BackColor = Color.LightSkyBlue;
                    break;
                default: break;
            }
        }
    }
}
