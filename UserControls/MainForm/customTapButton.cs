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
        public customTapButton()
        {
            InitializeComponent();
        }

        private void guna2Button2_MouseHover(object sender, EventArgs e)
        {
            txtboxTapButton.Visible = false;
        }

        private void btnTap_MouseLeave(object sender, EventArgs e)
        {
            txtboxTapButton.Visible = true;
        }
    }
}
