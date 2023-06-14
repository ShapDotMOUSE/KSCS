using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KSCS.Class.KSCS_static;
using System.Windows.Forms;

namespace KSCS.UserControls.MainForm
{
    public partial class SharingButton : UserControl
    {
        public event EventHandler Clicked;

        public SharingButton()
        {
            InitializeComponent();
        }

        public void HideTab()
        {
            btnSharing.Text = "";
            panelWhite.BringToFront();
        }

        public void ShowTab()
        {
            btnSharing.Text = "공유하기";
            btnSharing.BringToFront();
        }

        protected override void OnClick(EventArgs e)
        {
            //if(TabName != this.Name)
            {
                Clicked?.Invoke(this, e);
            }
            
        }

        private void SharingButton_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void btnSharing_MouseHover(object sender, EventArgs e)
        {
            if (TabName != this.Name)
            {
                ShowTab();
            }
        }
        private void btnSharing_MouseLeave(object sender, EventArgs e)
        {
            if (TabName != this.Name)
            {
                HideTab();
            }
        }

       
    }
}
