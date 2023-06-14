using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KSCS.Class.KSCS_static;

namespace KSCS
{
    public partial class UserTabButton : UserControl
    {
        public event EventHandler Clicked;
        public UserTabButton()
        {
            InitializeComponent();
        }

        public void HideTab()
        {
            btnTap.Text = "";
            panelWhite.BringToFront();
        }

        public void ShowTab()
        {
            btnTap.Text = this.Name;
            btnTap.BringToFront();
        }
        protected override void OnClick(EventArgs e)
        {
            if (TabName != this.Name)
            {
                Clicked?.Invoke(this, e);
            }
        }

        private void btnTab_MouseHover(object sender, EventArgs e)
        {
            if (TabName != this.Name)
            {
                ShowTab();
            }
        }

        private void btnTap_MouseLeave(object sender, EventArgs e)
        {
            if (TabName != this.Name)
            {
                HideTab();
            }
        }

        private void customTapButton_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
    }
}
