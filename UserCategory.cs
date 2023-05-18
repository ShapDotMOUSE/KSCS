using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KSCS
{
    public partial class UserCategory : UserControl
    {
        public UserCategory()
        {
            InitializeComponent();
        }

        public string GetName()
        {
            return this.Name;
        }

        public string GetText()
        {
            return lblCategory.Text;
        }

        public void DragMode(string txt)
        {
            lblCategory.Text = txt;
            txtCategory.Visible = false;
            lblCategory.MouseDoubleClick -= lblCategory_MouseDoubleClick;
        }

        public void SetBasicMode(string txt)
        {
            this.Name = "UCCategory" + txt;
            lblCategory.Text = txt;
            txtCategory.Visible = false;
        }

        private void UserCategory_Load(object sender, EventArgs e)
        {
            txtCategory.MaxLength = 4;
            this.ActiveControl = txtCategory;
            txtCategory.Focus();
        }

        private void txtCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCategory.Text.Length > 0)
                {
                    KSCS.Category.ChageSubdivisionName(lblCategory.Text, txtCategory.Text);
                    lblCategory.Text = txtCategory.Text;
                    this.Name = "UCCategory" + txtCategory.Text;
                    txtCategory.Visible= false;
                }
            }
        }

        private void lblCategory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtCategory.Visible = true;
            txtCategory.Focus();
        }
    }
}
