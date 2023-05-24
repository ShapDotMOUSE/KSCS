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
    public partial class UserTapButton : UserControl
    {
        public event EventHandler Clicked;
        public UserTapButton()
        {
            InitializeComponent();
        }

        protected override void OnClick(EventArgs e)
        {
            Clicked?.Invoke(this, e);
        }

        private void btnTab_MouseHover(object sender, EventArgs e)
        {
            btnTap.BringToFront();
            //panelWhite.Visible = false;
        }

        private void btnTap_MouseLeave(object sender, EventArgs e)
        {
            //panelWhite.Visible = true;
            panelWhite.BringToFront();
        }

        private void customTapButton_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
    }
}
