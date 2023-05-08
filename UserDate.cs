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
    public partial class UserDate : UserControl
    {
        public UserDate()
        {
            InitializeComponent();
        }

        public void SetDate(int date)
        {
            lblDate.Text = date.ToString();
        }

        private void UserDate_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lblDate.Text);
        }
    }
}
