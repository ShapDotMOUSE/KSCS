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
    public partial class UserTabButton : UserControl
    {
        public event EventHandler Clicked;
        public UserTabButton()
        {
            InitializeComponent();
        }

        public void HideTab()
        {
            btnTap.Text = "";
            panelWhite.BringToFront();
        }

        public void ShowTab()
        {
            btnTap.Text = this.Name;
            btnTap.BringToFront();
        }
        protected override void OnClick(EventArgs e)
        {
            if (MainForm.TabName != this.Name)
            {
                Clicked?.Invoke(this, e);
            }
        }

        private void btnTab_MouseHover(object sender, EventArgs e)
        {
            if (MainForm.TabName != this.Name)
            {
                ShowTab();
                //panelWhite.Visible = false;
            }
        }

        private void btnTap_MouseLeave(object sender, EventArgs e)
        {
            if (MainForm.TabName != this.Name)
            {
                //panelWhite.Visible = true;
                HideTab();
            }
        }

        private void customTapButton_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void btnTap_DoubleClick(object sender, EventArgs e)
        {
            if (MainForm.TabName == this.Name)
            {
                txtTab.Visible = true;
                txtTab.Focus();
                txtTab.BringToFront();
            }
        }

        private void UserTabButton_Load(object sender, EventArgs e)
        {
            txtTab.Parent = this;
            txtTab.MaxLength = 4;
        }

        private void txtTab_Leave(object sender, EventArgs e)
        {
            btnTap.Visible = true;
            txtTab.Visible = false;
            txtTab.Clear();
        }

        private void txtTab_KeyDown(object sender, KeyEventArgs e)
        {
            //카테고리 이름 변경 사항 저장
            if (e.KeyCode == Keys.Enter)
            {
                if (txtTab.Text.Length > 0)
                {
                    MainForm.Category.ChangeTabName(this.Name, txtTab.Text);
                    btnTap.Text = txtTab.Text;
                    this.Name = txtTab.Text;
                    txtTab.Visible = false;
                    MainForm.TabName = this.Name;
                    
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                //카테고리 이름 변경 사항 취소
                if (btnTap.Text.Length > 0)
                {
                    //기존 카테고리인 경우 원복
                    txtTab.Visible = false;
                    txtTab.Clear();
                }
            }
        }
    }
}
