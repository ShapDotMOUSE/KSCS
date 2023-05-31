using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSCS.UserControls.MainForm
{
    public partial class UserLabel : UserControl
    {
        public UserLabel()
        {
            InitializeComponent();
        }

        public UserLabel(string name, Color color)
        {
            InitializeComponent();
            this.Name = "label" + name;
            txtLabel.Text = name;
            txtLabel.ForeColor = color;
            Circle.FillColor = color;
        }

        public void SetColor(Color color)
        {
            txtLabel.ForeColor = color;
            Circle.FillColor = color;
        }

    }
}
