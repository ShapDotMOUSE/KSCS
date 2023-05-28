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
        public UserEvent()
        {
            InitializeComponent();
        }

        public void SetEventInfo(string eventInfo)
        {
            txtEventInfo.Text = eventInfo;
        }

        public void SetColor(Color color)
        {
            pnl.BackColor = color; //둘이 뭐가 다른건가요
            flpEventInfo.BackColor = color;
        }
    }
}
