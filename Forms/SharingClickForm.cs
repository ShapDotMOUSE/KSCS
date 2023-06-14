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
using static KSCS.Class.KSCS_static;

namespace KSCS.Forms
{
    public partial class SharingClickForm : Form
    {
        public event EventHandler SharingClick;
        public List<string> members { get; }
        public SharingClickForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void flpAddMember()
        {
            if (txtMember.Text.Length > 0)
            {
                members.Add(txtMember.Text);

                MemberAdd memberAdd = new MemberAdd();
                memberAdd.txtMember.Text = txtMember.Text;
                memberAdd.txtMember.Font = new Font(memberAdd.txtMember.Font.FontFamily, 10f, FontStyle.Regular);

                Size size = TextRenderer.MeasureText(memberAdd.txtMember.Text, memberAdd.txtMember.Font);
                memberAdd.txtMember.ClientSize = new Size(size.Width, size.Height);
                memberAdd.ClientSize = new Size(size.Width + 25, 22);
                memberAdd.btnClose.ClientSize = new Size(10, 9);

                txtMember.Text = "";
                flpMember.Controls.Add(memberAdd);
                memberAdd.AddEvent += new EventHandler(DeleteMemberEvent); //삭제 이벤트 핸들러 추가
            }
        }

        private void DeleteMemberEvent(object sender, EventArgs e)
        {
            flpMember.Controls.Remove((Control)sender);
        }

        private void btnMemberAdd_Click(object sender, EventArgs e)
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

        public void btnCreate_Click(object sender, EventArgs e)
        {
            this.Close();

            sharingMember = members;
            SharingClick(sender, e);
        }
    }
}
