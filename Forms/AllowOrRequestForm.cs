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
    public partial class AllowOrRequestForm : Form
    {
        public AllowOrRequestForm()
        {
            InitializeComponent();
        }


        private void btnRefuse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgree_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
