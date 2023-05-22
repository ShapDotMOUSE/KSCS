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
    public partial class TempCategorySetting : Form
    {
        string originMain;
        string originSub;
        
        //폼 호출 시 해당 카테고리의 이름과 상위 카테고리의 이름 넘겨받기
        public TempCategorySetting(string Main, string Sub)
        {
            InitializeComponent();
            originMain = Main;
            originSub = Sub;
        }

        //처음 폼 로드 시 카테고리 정보 세팅
        private void TempCategorySetting_Load(object sender, EventArgs e)
        {
            foreach(string Main in MainForm.Category.Categories.Keys)
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
                MainForm.Category.ChangeParentOfSub(originMain, cmbMain.SelectedItem.ToString(), originSub);
            if(originSub != txtboxSub.Text)
                MainForm.Category.ChageSubdivisionName(originMain,originSub,txtboxSub.Text);
        }
    }
}
