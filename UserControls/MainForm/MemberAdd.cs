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
    public partial class MemberAdd : UserControl
    {
        public event EventHandler AddEvent; //추가
        public MemberAdd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            AddEvent?.Invoke(this, EventArgs.Empty); //이벤트 핸들러 발생
            //((FlowLayoutPanel)this.Parent).Controls.Remove(this);
        }
    }
}
