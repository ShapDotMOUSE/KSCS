using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace KSCS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            // PW 에 Enter Key가 입력되면 btnLogin_Click 을 호출
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
                btnLogin.Select();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string ID = tbStdNum.Text;
            string PW = tbPassword.Text;

            if (EmptyCheck())
            {
                if (ID == "2019203082" && PW == "setset612@")
                {
                    this.DialogResult = DialogResult.OK;
                    KSCS.MainForm.stdNum = ID;
                    this.Close();
                }
                else
                {
                   lblMsg.Text = "죄송합니다. 학번과 비밀번호가 올바르지 않습니다.";
                    tbPassword.Focus();
                }
            }
        }

        private bool EmptyCheck()
        {
            if (String.IsNullOrEmpty(tbStdNum.Text))
            {
                lblMsg.Text = "학번을 입력해 주세요";
                tbStdNum.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(tbPassword.Text))
            {
                lblMsg.Text = "비밀번호를 입력해 주세요";
                tbPassword.Focus();
                return false;
            }

            return true;
        }

        private void LoginForm_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(800, 500);
        }
    }
}
