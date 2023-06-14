using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using KSCS.Forms;
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
    public partial class UserSharingAddButton : UserControl
    {
        public EventHandler CreateSharing;
        public bool Sharing;
        public UserSharingAddButton()
        {
            InitializeComponent();
            Sharing = false;
        }

        private void sharingButton_Click(object sender, EventArgs e)
        {
            if (label1.Text == "실시간 공유")
            {
                SharingClickForm sharingClickForm = new SharingClickForm();
                sharingClickForm.SharingClick += CreateSharing;
                DialogResult result = sharingClickForm.ShowDialog();
            }
            else
            {

            }
        }

        public void ChangeStatus(bool en)
        {
            if (en)
            {
                label1.Text = "나가기";
            }
            else
            {
                label1.Text = "실시간 공유";
            } 
        }
    }
}
