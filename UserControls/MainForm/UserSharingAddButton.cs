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

namespace KSCS.UserControls.MainForm
{
    public partial class UserSharingAddButton : UserControl
    {
        public EventHandler<EventArgs> CreateSharing;
        public UserSharingAddButton()
        {
            InitializeComponent();
        }

        private void sharingButton_Click(object sender, EventArgs e)
        {
            if (CreateSharing != null)
            {
                CreateSharing(sender, e);
            }
            //SharingClickForm sharingClickForm = new SharingClickForm();
            //DialogResult result = sharingClickForm.ShowDialog();
        }
    }
}
