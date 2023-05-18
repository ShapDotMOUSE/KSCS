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
            this.txtboxTapButton = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
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
            this.btnTap.MouseLeave += new System.EventHandler(this.btnTap_MouseLeave);
            this.btnTap.MouseHover += new System.EventHandler(this.guna2Button2_MouseHover);
            // 
            // txtboxTapButton
            // 
            this.txtboxTapButton.BorderThickness = 0;
            this.txtboxTapButton.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtboxTapButton.DefaultText = "";
            this.txtboxTapButton.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtboxTapButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtboxTapButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtboxTapButton.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtboxTapButton.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtboxTapButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtboxTapButton.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtboxTapButton.Location = new System.Drawing.Point(0, 0);
            this.txtboxTapButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtboxTapButton.Name = "txtboxTapButton";
            this.txtboxTapButton.PasswordChar = '\0';
            this.txtboxTapButton.PlaceholderText = "";
            this.txtboxTapButton.SelectedText = "";
            this.txtboxTapButton.Size = new System.Drawing.Size(18, 78);
            this.txtboxTapButton.TabIndex = 24;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // customTapButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtboxTapButton);
            this.Controls.Add(this.btnTap);
            this.Name = "customTapButton";
            this.Size = new System.Drawing.Size(36, 78);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnTap;
        private Guna.UI2.WinForms.Guna2TextBox txtboxTapButton;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}
