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
    public partial class UserCategory : UserControl
    {
        public UserCategory()
        {
            InitializeComponent();
        }

        public void SetlblCategory(string categoryName)
        {
            lblCategory.Text = categoryName;
        }


        private void txtCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCategory.Text.Length > 0)
                {
                    lblCategory.Text = txtCategory.Text;
                    txtCategory.Visible= false;
                }
            }
        }

        private void UserCategory_Load(object sender, EventArgs e)
        {
            txtCategory.MaxLength = 4;
            this.ActiveControl= txtCategory;
            txtCategory.Focus();
        }

        private void lblCategory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtCategory.Visible = true;
            txtCategory.Focus();
        }
    }
}
