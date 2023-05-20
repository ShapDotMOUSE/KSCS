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
    public partial class customTapButton : UserControl
    {
        public event EventHandler Click;
        public customTapButton()
        {
            InitializeComponent();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Click?.Invoke(this, e);
        }

        private void btnTab_MouseHover(object sender, EventArgs e)
        {
            panelWhite.Visible = false;
        }

        private void btnTap_MouseLeave(object sender, EventArgs e)
        {
            panelWhite.Visible = true;
        }

        private void customTapButton_Click(object sender, EventArgs e)
        {
            OnClick(EventArgs.Empty);
        }
    }
}
