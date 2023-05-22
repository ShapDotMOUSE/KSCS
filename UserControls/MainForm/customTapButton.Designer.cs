namespace KSCS
{
    partial class customTapButton
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
            this.components = new System.ComponentModel.Container();
            this.btnTap = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panelWhite = new Guna.UI2.WinForms.Guna2Panel();
            this.SuspendLayout();
            // 
            // btnTap
            // 
            this.btnTap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnTap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTap.BorderRadius = 10;
            this.btnTap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(5)))), ((int)(((byte)(31)))));
            this.btnTap.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(5)))), ((int)(((byte)(31)))));
            this.btnTap.Font = new System.Drawing.Font("Segoe UI", 6F);
            this.btnTap.ForeColor = System.Drawing.Color.White;
            this.btnTap.Location = new System.Drawing.Point(0, 0);
            this.btnTap.Name = "btnTap";
            this.btnTap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnTap.Size = new System.Drawing.Size(36, 78);
            this.btnTap.TabIndex = 23;
            this.btnTap.Click += new System.EventHandler(this.customTapButton_Click);
            this.btnTap.MouseEnter += new System.EventHandler(this.btnTab_MouseHover);
            this.btnTap.MouseLeave += new System.EventHandler(this.btnTap_MouseLeave);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // panelWhite
            // 
            this.panelWhite.BackColor = System.Drawing.Color.White;
            this.panelWhite.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelWhite.Location = new System.Drawing.Point(0, 0);
            this.panelWhite.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelWhite.Name = "panelWhite";
            this.panelWhite.Size = new System.Drawing.Size(14, 78);
            this.panelWhite.TabIndex = 25;
            this.panelWhite.MouseEnter += new System.EventHandler(this.btnTab_MouseHover);
            this.panelWhite.MouseLeave += new System.EventHandler(this.btnTap_MouseLeave);
            // 
            // customTapButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelWhite);
            this.Controls.Add(this.btnTap);
            this.Name = "customTapButton";
            this.Size = new System.Drawing.Size(36, 78);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnTap;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel panelWhite;
    }
}
