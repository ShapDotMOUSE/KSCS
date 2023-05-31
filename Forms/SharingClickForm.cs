using KSCS.UserControls.MainForm;
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
    public partial class SharingClickForm : Form
    {
        public SharingClickForm()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void flpAddMember()
        {
            if (txtMember.Text.Length > 0)
            {
                MemberAdd memberAdd = new MemberAdd();
                memberAdd.txtMember.Text = txtMember.Text;
                memberAdd.txtMember.Font = new Font(memberAdd.txtMember.Font.FontFamily, 12f, FontStyle.Regular);

                Size size = TextRenderer.MeasureText(memberAdd.txtMember.Text, memberAdd.txtMember.Font);
                memberAdd.txtMember.ClientSize = new Size(size.Width, size.Height);
                memberAdd.ClientSize = new Size(size.Width + 25, 22);
                memberAdd.btnClose.ClientSize = new Size(10, 9);
                txtMember.Text = "";
                flpMember.Controls.Add(memberAdd);
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            flpAddMember();
        }

        private void txtMember_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                e.Handled = true;
                flpAddMember();
            }

        }
    }
}
