namespace KSCS
{
    partial class UserDate
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.flpEvent = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTransparent = new Guna.UI2.WinForms.Guna2Button();
            this.lblUnitNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = false;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDate.Font = new System.Drawing.Font("Pretendard SemiBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.Location = new System.Drawing.Point(0, 0);
            this.lblDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(150, 33);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "1";
            this.lblDate.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpEvent
            // 
            this.flpEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpEvent.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpEvent.Location = new System.Drawing.Point(0, 33);
            this.flpEvent.Margin = new System.Windows.Forms.Padding(0);
            this.flpEvent.Name = "flpEvent";
            this.flpEvent.Size = new System.Drawing.Size(150, 85);
            this.flpEvent.TabIndex = 1;
            // 
            // btnTransparent
            // 
            this.btnTransparent.BackColor = System.Drawing.Color.Transparent;
            this.btnTransparent.BorderColor = System.Drawing.Color.Transparent;
            this.btnTransparent.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnTransparent.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTransparent.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTransparent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTransparent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTransparent.FillColor = System.Drawing.Color.Transparent;
            this.btnTransparent.FocusedColor = System.Drawing.Color.Transparent;
            this.btnTransparent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTransparent.ForeColor = System.Drawing.Color.Transparent;
            this.btnTransparent.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnTransparent.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnTransparent.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnTransparent.HoverState.ForeColor = System.Drawing.Color.Transparent;
            this.btnTransparent.Location = new System.Drawing.Point(0, 0);
            this.btnTransparent.Margin = new System.Windows.Forms.Padding(0);
            this.btnTransparent.Name = "btnTransparent";
            this.btnTransparent.PressedColor = System.Drawing.Color.Transparent;
            this.btnTransparent.Size = new System.Drawing.Size(150, 118);
            this.btnTransparent.TabIndex = 3;
            this.btnTransparent.UseTransparentBackground = true;
            this.btnTransparent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserDate_Click);
            this.btnTransparent.MouseEnter += new System.EventHandler(this.UserDate_MouseEnter);
            this.btnTransparent.MouseLeave += new System.EventHandler(this.UserDate_MouseLeave);
            // 
            // lblUnitNum
            // 
            this.lblUnitNum.AutoSize = true;
            this.lblUnitNum.BackColor = System.Drawing.Color.Transparent;
            this.lblUnitNum.Font = new System.Drawing.Font("Pretendard Light", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUnitNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUnitNum.Location = new System.Drawing.Point(122, 98);
            this.lblUnitNum.Name = "lblUnitNum";
            this.lblUnitNum.Size = new System.Drawing.Size(24, 14);
            this.lblUnitNum.TabIndex = 4;
            this.lblUnitNum.Text = "+ 0";
            this.lblUnitNum.Visible = false;
            // 
            // UserDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.lblUnitNum);
            this.Controls.Add(this.btnTransparent);
            this.Controls.Add(this.flpEvent);
            this.Controls.Add(this.lblDate);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserDate";
            this.Size = new System.Drawing.Size(150, 118);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblDate;
        private System.Windows.Forms.FlowLayoutPanel flpEvent;
        private Guna.UI2.WinForms.Guna2Button btnTransparent;
        private System.Windows.Forms.Label lblUnitNum;
    }
}
