﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Windows.Forms;
using static KSCS.Class.KSCS_static;


namespace KSCS
{
    public partial class UserMainCategory : UserControl
    {
        public UserMainCategory()
        {
            InitializeComponent();
        }

        
        public void SetNewMode()
        {
            txtMainCategory.Enabled= true;
            txtMainCategory.Visible = true;
            lblMainCategory.Visible = false;
            lblMainCategory.Text = "";
            txtMainCategory.Text = lblMainCategory.Text;
            txtMainCategory.Focus();
        }

        public void SetAddMode(string Main)
        {
            txtMainCategory.Enabled= false;
            txtMainCategory.Visible = false;
            lblMainCategory.Visible = true;
            lblMainCategory.Text = Main;
            this.Name= Main;
        }

        private void ResetName()
        {
            lblMainCategory.Visible = true;
            txtMainCategory.Visible = false;
            txtMainCategory.Enabled = false;
            txtMainCategory.Clear();
        }

        public void SetSharing(bool enable)
        {
            if(enable)
            {
                lblMainCategory.DoubleClick -= lblMainCategory_DoubleClick;
            }
            else
            {
                lblMainCategory.DoubleClick += lblMainCategory_DoubleClick;
            }
            btnAddSubCategory.Visible = !enable;
        }

        //이벤트 핸들러 ----------------------------------------------------------------------------------------------
        private void btnShowSubCategory_Click(object sender, EventArgs e)
        {
            flpSubCategory.Visible = !flpSubCategory.Visible;
        }
        private void lblMainCategory_DoubleClick(object sender, EventArgs e)
        {
            txtMainCategory.Enabled= true;
            txtMainCategory.Visible = true;
            lblMainCategory.Visible = false;
            txtMainCategory.BringToFront();
            txtMainCategory.Focus();
            txtMainCategory.Text = lblMainCategory.Text;
        }

        private void txtMainCategory_KeyDown(object sender, KeyEventArgs e)
        {
            //카테고리 이름 변경 사항 저장
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMainCategory.Text.Length > 0)
                {
                    //입력된 내용이 있을 경우
                    if (lblMainCategory.Text.Length > 0)
                    {
                        category.ChangeMainName(lblMainCategory.Text, txtMainCategory.Text);
                        Database.UpdateParentCategory(lblMainCategory.Text, txtMainCategory.Text);
                    }
                    else
                    {
                        //신규 카테고리인 경우
                        category.Categories.Add(txtMainCategory.Text, new HashSet<string>());
                        Database.CreateParentCategory(txtMainCategory.Text);
                    }
                    this.Name = txtMainCategory.Text;
                    lblMainCategory.Text = txtMainCategory.Text;
                    txtMainCategory.Visible = false;
                    txtMainCategory.Enabled= false;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                //카테고리 이름 변경 사항 취소
                if (lblMainCategory.Text.Length > 0)
                {
                    //기존 메인 카테고리인 경우 원복
                    ResetName();
                }
                else
                {
                    //새로 만든 메인 카테고리인 경우 추가된 카테고리 삭제
                    ((FlowLayoutPanel)this.Parent).Controls.Remove(this);
                }
            }
        }

        private void txtMainCategory_Leave(object sender, EventArgs e)
        {
            ResetName();
            if (lblMainCategory.Text.Length == 0)
            {
                ((FlowLayoutPanel)this.Parent).Controls.Remove(this);
            }
        }

        private void btnAddSubCategory_Click(object sender, EventArgs e)
        {
            UserSubCategory userSub = new UserSubCategory();
            userSub.setMain(this.Name);
            flpSubCategory.Controls.Add(userSub);
        }

        private void UserMainCategory_Load(object sender, EventArgs e)
        {
            txtMainCategory.Focus();
        }

        private void MenuDelete_Click(object sender, EventArgs e)
        {
            if (this.Name == "KLAS" || this.Name == "개인" || this.Name == "기타")
            {
                MessageBox.Show("해당 카테고리는 지울 수 없습니다!");
            }
            else
            {
                if (flpSubCategory.Controls.Count == 0)
                {
                    Database.DeleteParentCategory(this.Name);
                    ((FlowLayoutPanel)this.Parent).Controls.Remove(this);
                }
                else
                {
                    MessageBox.Show("하위 카테고리가 존재합니다!");
                }
            }
        }
    }
}
