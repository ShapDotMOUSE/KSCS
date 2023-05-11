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
    public partial class TempAddEventForm : Form
    {
        public event EventHandler AddEvent;
        
        public TempAddEventForm()
        {
            InitializeComponent();
        }

        private void TempAddEventForm_Load(object sender, EventArgs e)
        {
            TxtBoxDate.Text = KSCS.static_year.ToString() + "/" + KSCS.static_month.ToString() + "/" + UserDate.static_date;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(AddEvent != null)
            {
                AddEvent(this, new EventArgs());
            }
        }

        public string GetTxtboxEvent()
        {
            return TxtBoxEvent.Text;
        }

        public int GetCmbType()
        {
            return cmbType.SelectedIndex;
        }

    }
}
