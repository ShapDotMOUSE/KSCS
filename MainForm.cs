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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void KSCS_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(251, 183, 183);
            category_underline.BackColor = Color.FromArgb(58, 5, 31);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(1280, 960);
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
