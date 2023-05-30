using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSCS.Forms
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();

        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = (this.ClientSize.Height - pictureBox1.Height) / 2;
            //pictureBox2.Left = (this.ClientSize.Width - pictureBox2.Width) / 2;
            //pictureBox2.Top = (this.ClientSize.Height - pictureBox2.Height) / 2;
            //pictureBox3.Left = (this.ClientSize.Width - pictureBox3.Width) / 2;
            //pictureBox3.Top = (this.ClientSize.Height - pictureBox3.Height) / 2;
            //pictureBox4.Left = (this.ClientSize.Width - pictureBox4.Width) / 2;
            //pictureBox4.Top = (this.ClientSize.Height - pictureBox4.Height) / 2;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;

            timer1.Start();
        }
        int a = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {

            switch(a)
            {
                case 0:
                    pictureBox1.Image = pictureBox5.Image;
                    break;
                case 1:
                    pictureBox1.Image = pictureBox2.Image;
                    break;
                case 2:
                    pictureBox1.Image = pictureBox3.Image;
                    break;
                case 3:
                    pictureBox1.Image = pictureBox4.Image;
                    break;
            }
            a++;
            if(a==4)
            {
                a = 0;
            }
        }
    }
}
