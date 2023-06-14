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
    public partial class UserSharingSubCategory : UserControl
    {
        string MainCategory;

        public UserSharingSubCategory()
        {
            InitializeComponent();
        }

        public void SetColor(Color color)
        {
            lblCategory.ForeColor = color;
        }

        public string GetText()
        {
            return lblCategory.Text;
        }

        public void setMain(string Main)
        {
            MainCategory = Main;
        }

        public void SetBasicMode(string txt)
        {
            this.Name = "Sharing"+txt;
            lblCategory.Text = txt;
        }

        private void chkCategory_Click(object sender, EventArgs e)
        {
            SharingCategory[lblCategory.Text] = chkCategory.Checked;
            if(chkCategory.Checked )
            {
                MainForm.flowLayoutPanelLable.Controls.Add(new UserLabel(lblCategory.Text, Color.Black));
            }
            else
            {
                MainForm.flowLayoutPanelLable.Controls.Remove(MainForm.flowLayoutPanelLable.Controls["label" + lblCategory.Text]);
            }
        }
    }
}
