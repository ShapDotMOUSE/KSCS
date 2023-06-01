using KSCS.Class;
using KSCS.Forms;
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

namespace KSCS
{
    public partial class UserSubCategory : UserControl
    {
        string MainCategory;
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

        public void setMain(string Main)
        {
            MainCategory = Main;
        }

        public void SetChecked(bool check)
        {
           chkCategory.Checked = check;
        }

        public void SetCheckedEnable(bool enable)
        {
            chkCategory.Enabled = enable;
        }

        public void SetBasicMode(string txt)
        {
            this.Name = txt;
            lblCategory.Text = txt;
            txtCategory.Visible = false;
        }

        public void SetColor(Color color)
        {
            lblCategory.ForeColor = color;
        }
        private void UserCategory_Load(object sender, EventArgs e)
        {
            if (KSCS_static.TabName == "All")
            {
                chkCategory.Enabled = false;
                chkCategory.Checked = true;
            }
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
                        category.ChageSubdivisionName(((FlowLayoutPanel)this.Parent).Name,lblCategory.Text, txtCategory.Text);
                    }
                    else
                    {
                        //신규 카테고리인 경우
                        KSCS_static.category.AddSubdivision(MainCategory, txtCategory.Text);
                        Database.CreateSubCategory(MainCategory, txtCategory.Text);
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
            if(lblCategory.Text.Length == 0 )
                ((FlowLayoutPanel)this.Parent).Controls.Remove(this);
        }

        //카테고리 체크 여부 확인해서 탭에 추가 및 삭제
        private void chkCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCategory.Checked)
            {
                category.AddChecked(TabName, lblCategory.Text);
                MainForm.flowLayoutPanelLable.Controls.Add(new UserLabel(lblCategory.Text, KSCS_static.category.GetColor(lblCategory.Text)));
            }
            else
            {
                category.DeletChecked(TabName, lblCategory.Text);
                MainForm.flowLayoutPanelLable.Controls.Remove(MainForm.flowLayoutPanelLable.Controls["label" + lblCategory.Text]);
            }
            MainForm.LoadMainForm(); //추가
        }

        //유저 카테고리 수정 폼 로드
        private void UserCategory_DoubleClick(object sender, EventArgs e)
        {
            UserMainCategory parent = (UserMainCategory)((FlowLayoutPanel)this.Parent).Parent;
           AddCategoryForm temp = new AddCategoryForm((FlowLayoutPanel)(parent.Parent), parent.Name, lblCategory.Text);
           temp.ShowDialog();
        }

        
    }
}
