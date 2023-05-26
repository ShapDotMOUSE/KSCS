using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KSCS.Class.KSCS_static;

namespace KSCS.Forms
{
    public partial class TempCategorySetting : Form
    {
        string originMain;
        string originSub;
        FlowLayoutPanel MainCategory;

        //폼 호출 시 해당 카테고리의 이름과 상위 카테고리의 이름 넘겨받기
        public TempCategorySetting(FlowLayoutPanel MainCategory, string Main, string Sub)
        {
            InitializeComponent();
            originMain = Main;
            originSub = Sub;
            this.MainCategory = MainCategory;
        }

        //처음 폼 로드 시 카테고리 정보 세팅
        private void TempCategorySetting_Load(object sender, EventArgs e)
        {
            foreach(string Main in category.Categories.Keys)
            {
                cmbMain.Items.Add(Main);
                if (originMain== Main)
                {
                    cmbMain.SelectedItem = Main;
                }
            }
           
            txtboxSub.Text = originSub;
            txtboxSub.MaxLength = 4;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (originMain != cmbMain.SelectedItem.ToString())
            {
                string NewMain = cmbMain.SelectedItem.ToString();
                //변경 사항 Category에 적용
                category.ChangeParentOfSub(originMain, NewMain, originSub);
                //변경 사항 MainForm에 적용
                FlowLayoutPanel NewParent = MainCategory.Controls[NewMain] as FlowLayoutPanel;
                FlowLayoutPanel OldParent = MainCategory.Controls[originMain] as FlowLayoutPanel;
                UserSubCategory OldUc = (OldParent).Controls[originSub] as UserSubCategory;
                UserSubCategory NewUc = new UserSubCategory();
                NewUc.SetBasicMode(originSub);
                NewParent.Controls.Add(NewUc);
                OldParent.Controls.Remove(OldUc);
                

                originMain = NewMain;
            }
            if (originSub != txtboxSub.Text)
            {
                string NewSub = txtboxSub.Text;
                //변경 사항 Category에 적용
                category.ChageSubdivisionName(originMain, originSub, NewSub);
                FlowLayoutPanel Parent = MainCategory.Controls[originMain] as FlowLayoutPanel;
                ((UserSubCategory)Parent.Controls[originSub]).SetBasicMode(NewSub);

            }
            Close();

        }
    }
}
