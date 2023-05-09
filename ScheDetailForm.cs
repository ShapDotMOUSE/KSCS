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
    public partial class ScheDetailForm : Form
    {
        public ScheDetailForm()
        {
            InitializeComponent();
            InitializeGuna2DateTimePicker();
        }

        private void InitializeGuna2DateTimePicker()
        {
            dtpStartDate.Value = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd ddd"), "yyyy-MM-dd ddd", null);
            dtpStartTime.Value = DateTime.ParseExact("00:00", "HH:mm", null);
            dtpEndDate.Value = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd ddd"), "yyyy-MM-dd ddd", null);
            dtpEndTime.Value = DateTime.ParseExact("00:00", "HH:mm", null);
        }

        private DateTime GetStartDateTime()
        {
            string yyyyMMdd = dtpStartDate.Value.ToString("yyyy-MM-dd ddd");
            string HHmm = dtpStartTime.Value.ToString("HH:mm");

            return DateTime.ParseExact(yyyyMMdd + ' ' + HHmm, "yyyy-MM-dd ddd HH:mm", null);
        }

        private DateTime GetEndDateTime()
        {
            string yyyyMMdd = dtpEndDate.Value.ToString("yyyy-MM-dd ddd");
            string HHmm = dtpEndTime.Value.ToString("HH:mm");

            return DateTime.ParseExact(yyyyMMdd + ' ' + HHmm, "yyyy-MM-dd ddd HH:mm", null);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (tbTitle.Text == String.Empty)
            {
                MessageBox.Show("제목을 입력하세요");
                return;
            }
            if (cbCategory.SelectedItem == null)
            {
                MessageBox.Show("카테고리를 선택하세요");
                return;
            }
            this.Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMemSet_Click(object sender, EventArgs e)
        {
            guna2ContextMenuStrip1.Show(MousePosition);
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            addBtn.FillColor = Color.LimeGreen;
            addBtn.Text = "Modify";
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            addBtn.FillColor = Color.CornflowerBlue;
            addBtn.Text = "Add";
        }
    }
}
