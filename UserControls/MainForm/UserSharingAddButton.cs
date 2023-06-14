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
        public UserSharingAddButton()
        {
            InitializeComponent();
        }

        private void sharingButton_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SharingClickForm sharingClickForm = new SharingClickForm();
            DialogResult result = sharingClickForm.ShowDialog();
        }
    }
}
