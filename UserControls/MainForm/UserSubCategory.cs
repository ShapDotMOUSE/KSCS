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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KSCS
{
    public partial class UserSubCategory : UserControl
    {
        string MainCategory;
        bool isRemove;
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
            if (TabName == "All")
            {
                chkCategory.Enabled = false;
                chkCategory.Checked = true;
            }
            isRemove = false;
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
                    //카테고리 이름 중복
                    if (!category.IsExitsSubCategory(txtCategory.Text))
                    {
                        if (lblCategory.Text.Length > 0)
                        {
                            //기존 카테고리인 경우
                            Database.UpdateSubCategory(txtCategory.Text, lblCategory.Text);
                            category.ChageSubdivisionName((this.Parent).Parent.Name, lblCategory.Text, txtCategory.Text);
                            ((UserLabel)MainForm.flowLayoutPanelLable.Controls["label" + lblCategory.Text]).SetName(txtCategory.Text);
                        }
                        else
                        {
                            //신규 카테고리인 경우
                            category.AddSubdivision(MainCategory, txtCategory.Text);
                            //All 탭에 추가
                            HashSet<string> TabCategory = category.Tabs["All"] as HashSet<string>;
                            TabCategory.Add(txtCategory.Text);
                            category.Tabs["All"] = TabCategory;
                            //DB 추가
                            Database.CreateSubCategory(MainCategory, txtCategory.Text);
                            lblCategory.ForeColor = Color.Black;
                            category.SetColor(txtCategory.Text, Color.Black);
                            if (TabName == "All")
                                MainForm.flowLayoutPanelLable.Controls.Add(
                                     new UserLabel(txtCategory.Text, category.GetColor(txtCategory.Text)));
                        }

                        //텍스트 박스 DisVisible 카테고리 이름 Visible
                        lblCategory.Text = txtCategory.Text;
                        this.Name = txtCategory.Text;
                        txtCategory.Visible = false;
                        lblCategory.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("이미 존재하는 카테고리 이름입니다!");
                    }
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
                    if(!isRemove) ((FlowLayoutPanel)this.Parent).Controls.Remove(this);
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
            if(lblCategory.Text.Length == 0 && !isRemove)
                ((FlowLayoutPanel)this.Parent).Controls.Remove(this);
        }

        //카테고리 체크 여부 확인해서 탭에 추가 및 삭제
        private void chkCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCategory.Checked)
            {
                category.AddChecked(TabName, lblCategory.Text);
                if(lblCategory.Text.Length != 0 )
                    MainForm.flowLayoutPanelLable.Controls.Add(
                        new UserLabel(lblCategory.Text, category.GetColor(lblCategory.Text)));
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

        private void menuDelete_Click(object sender, EventArgs e)
        {
            if(MainCategory == "KLAS" || this.Name == "기타")
            {
                MessageBox.Show("삭제할 수 없는 카테고리입니다.");
            }
            else
            {
                if(chkCategory.Checked)
                {
                    MainForm.flowLayoutPanelLable.Controls.Remove(MainForm.flowLayoutPanelLable.Controls["label" + lblCategory.Text]);
                }
                ((FlowLayoutPanel)this.Parent).Controls.Remove(this);
                Database.DeleteSubCategory(this.Name);
            }
        }
    }
}
