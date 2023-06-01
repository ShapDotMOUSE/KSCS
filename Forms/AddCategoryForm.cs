using KSCS.Class;
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
    public partial class AddCategoryForm : Form
    {
        public AddCategoryForm()
        {
            InitializeComponent();
        }

        string originMain;
        string originSub;
        Color originColor;
        FlowLayoutPanel MainCategory;

        //폼 호출 시 해당 카테고리의 이름과 상위 카테고리의 이름 넘겨받기
        public AddCategoryForm(FlowLayoutPanel MainCategory, string Main, string Sub)
        {
            InitializeComponent();
            originMain = Main;
            originSub = Sub;
            originColor = KSCS_static.category.GetColor(originSub);
            this.MainCategory = MainCategory;
        }

        //처음 폼 로드 시 카테고리 정보 세팅
        private void TempCategorySetting_Load(object sender, EventArgs e)
        {
            foreach (string Main in category.Categories.Keys)
            {
                cmbMain.Items.Add(Main);
                if (originMain == Main)
                {
                    cmbMain.SelectedItem = Main;
                }
            }

            boxColor.FillColor = originColor;
            txtboxColor.Text = originColor.R.ToString() + "," + originColor.G.ToString() + "," + originColor.B.ToString();
            txtboxSub.Text = originSub;
            txtboxSub.MaxLength = 4;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (originMain != cmbMain.SelectedItem.ToString())
            {
                string NewMain = cmbMain.SelectedItem.ToString();
                if (originMain == "KLAS")
                {
                    MessageBox.Show("해당 카테고리는 상위 카테고리를 변경할 수 없습니다");
                    cmbMain.SelectedItem = originMain;
                    return;
                }
                else if (NewMain == "KLAS")
                {
                    MessageBox.Show("해당 카테고리로 상위 카테고리를 변경할 수 없습니다");
                    cmbMain.SelectedItem = originMain;
                    return;
                }
                else
                {
                    //변경 사항 Category에 적용
                    category.ChangeParentOfSub(originMain, NewMain, originSub);
                    //변경 사항 MainForm에 적용
                    UserMainCategory NewParent = MainCategory.Controls[NewMain] as UserMainCategory;
                    UserMainCategory OldParent = MainCategory.Controls[originMain] as UserMainCategory;
                    UserSubCategory OldUc = ((FlowLayoutPanel)((OldParent).Controls["flpSubCategory"]))
                                            .Controls[originSub] as UserSubCategory;
                    UserSubCategory NewUc = new UserSubCategory();
                    NewUc.SetBasicMode(originSub);
                    NewParent.Controls["flpSubCategory"].Controls.Add(NewUc);
                    OldParent.Controls["flpSubCategory"].Controls.Remove(OldUc);
                    //DB 업데이트
                    Database.UpdateParentCategoryOfSubCategory(NewMain, originSub);

                    originMain = NewMain;
                }
            }
            if (originSub != txtboxSub.Text)
            {
                if (originMain == "KLAS" || originSub =="기타" || originSub=="공유일정")
                {
                    MessageBox.Show("해당 카테고리의 이름은 변경할 수 없습니다");
                    txtboxSub.Text = originSub;
                    return;
                }
                else
                {
                    string NewSub = txtboxSub.Text;
                    //변경 사항 Category에 적용
                    category.ChageSubdivisionName(originMain, originSub, NewSub);
                    FlowLayoutPanel Parent = MainCategory.Controls[originMain].Controls["flpSubCategory"] as FlowLayoutPanel;
                    ((UserSubCategory)Parent.Controls[originSub]).SetBasicMode(NewSub);
                    //DB 업데이트
                    Database.UpdateSubCategory(NewSub, originSub);
                    //라벨 수정
                    ((UserLabel)MainForm.flowLayoutPanelLable.Controls["label" + originSub]).SetName(NewSub);
                    originSub = NewSub;
                }
            }

            if(originColor != boxColor.FillColor)
            {
                //카테고리에 수정 내용 반영
                ((UserSubCategory)(MainCategory.Controls[originMain].Controls["flpSubCategory"].Controls[originSub])).SetColor(boxColor.FillColor);
                category.SetColor(originSub, boxColor.FillColor);
                //DB 업데이트
                Database.UpdateSubCategoryColor(originSub, boxColor.FillColor);
                //라벨 수정
                ((UserLabel)MainForm.flowLayoutPanelLable.Controls["label" + originSub]).SetColor(boxColor.FillColor);
            }
            Close();

        }
    

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void AddCategoryForm_ResizeBegin(object sender, EventArgs e)
        {
            this.Size = new Size(280, 240);
        }

        private void guna2TextBox2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                boxColor.FillColor = colorDialog1.Color;
                Color color = colorDialog1.Color;
                
                txtboxColor.Text = color.R.ToString() +"," +  color.G.ToString() + "," + color.B.ToString();
            }
        }
    }
}
