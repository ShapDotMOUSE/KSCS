using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSCS.Forms
{
    public partial class SharingScheduleForm : Form
    {
        public SharingScheduleForm()
        {
            InitializeComponent();
            tbTitle.BringToFront();
            guna2HtmlLabel7.BringToFront();
            guna2HtmlLabel8.BringToFront();
            tbPlace.BringToFront();
            tbMemo.BringToFront();
            cbCategory.BringToFront();
            flpMember.BringToFront();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
