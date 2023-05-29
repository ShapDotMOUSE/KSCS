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
    public partial class SharingButton : UserControl
    {
        public event EventHandler Clicked;
        public event MouseEventHandler DoubleClicked;

        public SharingButton()
        {
            InitializeComponent();
        }

        protected override void OnClick(EventArgs e)
        {
            Clicked?.Invoke(this, e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            DoubleClicked?.Invoke(this, e);
        }

        private void btnSharing_MouseLeave(object sender, EventArgs e)
        {
            //panelWhite.Visible = true;
            panelWhite.BringToFront();
        }

        private void SharingButton_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void SharingButton_DoubleClick(object sender, MouseEventArgs e)
        {
            OnMouseDoubleClick(e);
        }

        private void btnSharing_MouseHover(object sender, EventArgs e)
        {
            btnSharing.BringToFront();
            //panelWhite.Visible = false;
        }
    }
}
