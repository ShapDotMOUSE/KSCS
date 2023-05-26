using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KSCS.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KSCS
{
    public partial class UserSubCategory : UserControl
    {
        public UserSubCategory()
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

        public void SetChecked(bool check)
        {
           chkCategory.Checked = check;
        }

        public void SetBasicMode(string txt)
        {
            this.Name = txt;
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
            //카테고리 이름 변경 사항 저장
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCategory.Text.Length > 0)
                {
                    //입력된 내용이 있을 경우
                    if (lblCategory.Text.Length > 0)
                    {
                        //기존 카테고리인 경우
                        MainForm.Category.ChageSubdivisionName(((FlowLayoutPanel)this.Parent).Name,lblCategory.Text, txtCategory.Text);
                    }
                    else
                    {
                        //신규 카테고리인 경우
                        MainForm.Category.AddSubdivision("EtcCategory", txtCategory.Text);
                    }
                    lblCategory.Text = txtCategory.Text;
                    this.Name = txtCategory.Text;
                    txtCategory.Visible = false;
                    lblCategory.Visible = true;
                }
            }else if(e.KeyCode == Keys.Escape)
            {
                //카테고리 이름 변경 사항 취소
                if (lblCategory.Text.Length > 0)
                {
                    //기존 카테고리인 경우 원복
                    lblCategory.Visible = true;
                    txtCategory.Visible = false;
                    txtCategory.Clear();
                }
                else
                {
                    //새로 만드는 카테고리인 경우 추가된 카테고리 삭제
                    ((FlowLayoutPanel)this.Parent).Controls.Remove(this);
                }
            }
        }

        //카테고리 이름 변경 시
        private void lblCategory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtCategory.Visible = true;
            lblCategory.Visible = false;
            txtCategory.Focus();
        }

        //카테고리 이름 수정 중 다른 곳 클릭
        private void txtCategory_Leave(object sender, EventArgs e)
        {
            lblCategory.Visible = true;
            txtCategory.Visible = false;
            txtCategory.Clear();
        }

        //카테고리 체크 여부 확인해서 탭에 추가 및 삭제
        private void chkCategory_CheckedChanged(object sender, EventArgs e)
        {
            if(chkCategory.Checked)
            {
                MainForm.Category.AddChecked(MainForm.TabName, lblCategory.Text);
            }
            else
            {
                MainForm.Category.DeletChecked(MainForm.TabName, lblCategory.Text);
            }
        }

        //유저 카테고리 수정 폼 로드
        private void UserCategory_DoubleClick(object sender, EventArgs e)
        {
           TempCategorySetting temp = new TempCategorySetting((FlowLayoutPanel)((FlowLayoutPanel)this.Parent).Parent, ((FlowLayoutPanel)this.Parent).Name , lblCategory.Text);
           temp.ShowDialog();
        }

        
    }
}
