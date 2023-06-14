using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSCS.UserControls.MainForm
{
    public partial class UserMemberStatus : UserControl
    {
        public UserMemberStatus()
        {
            InitializeComponent();
            txtLabel.BringToFront();
        }

        public void SetName(string stdNum)
        {
            txtLabel.Text = stdNum;
            this.Name = stdNum;
        }

        public void SetColor(Color color)
        {
            txtLabel.ForeColor = color;

        }
    }
}
