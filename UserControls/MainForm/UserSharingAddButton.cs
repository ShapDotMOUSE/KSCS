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
        public static EventHandler EnableTab;
        public static EventHandler Exit;

        private bool Sharing;
        public UserSharingAddButton()
        {
            InitializeComponent();
            Sharing = false;
            AllowOrRequestForm.SharingButtonStatusChange = ChangeStatusTrueHandler;
        }

        private void sharingButton_Click(object sender, EventArgs e)
        {
            if (!Sharing)
            {
                SharingClickForm sharingClickForm = new SharingClickForm();
                sharingClickForm.SharingClick += CreateSharing;
                sharingClickForm.SharingClick += EnableTab;
                DialogResult result = sharingClickForm.ShowDialog();
            }
            else
            {
                ChangeStatus(false);
                Exit?.Invoke(this, e);
            }
        }

        public void ChangeStatus(bool en)
        {
            if (en)
            {
                label1.Text = "나가기";
                Sharing = true;
            }
            else
            {
                label1.Text = "실시간 공유";
                Sharing = false;
            }
        }

        public void ChangeStatusTrueHandler(object sender, EventArgs e)
        {
            ChangeStatus(true);
        }
    }
}
