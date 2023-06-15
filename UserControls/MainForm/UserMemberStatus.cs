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
            picNo.Visible = false;
            picOK.Visible = false;
        }

        public void SetName(string stdNum)
        {
            txtLabel.Text = stdNum;
            this.Name = stdNum;
        }

        public void SetColor(Color color)
        {
            txtLabel.ForeColor = color;
            Circle.FillColor = color;
        }

        public void SetStatus(bool enable)
        {
            picWait.Visible = false;
            picOK.Visible = enable;
            picNo.Visible = !enable;
        }
    }
}
