namespace KSCS.UserControls.MainForm
{
    partial class SharingButton
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
            this.btnSharing = new Guna.UI2.WinForms.Guna2Button();
            this.panelWhite = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.SuspendLayout();
            // 
            // btnSharing
            // 
            this.btnSharing.BackColor = System.Drawing.SystemColors.Control;
            this.btnSharing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSharing.BorderRadius = 10;
            this.btnSharing.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSharing.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSharing.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSharing.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSharing.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSharing.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(5)))), ((int)(((byte)(31)))));
            this.btnSharing.Font = new System.Drawing.Font("Segoe UI", 6F);
            this.btnSharing.ForeColor = System.Drawing.Color.White;
            this.btnSharing.Location = new System.Drawing.Point(0, 0);
            this.btnSharing.Margin = new System.Windows.Forms.Padding(4);
            this.btnSharing.Name = "btnSharing";
            this.btnSharing.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSharing.Size = new System.Drawing.Size(45, 94);
            this.btnSharing.TabIndex = 26;
            this.btnSharing.Click += new System.EventHandler(this.SharingButton_Click);
            this.btnSharing.MouseLeave += new System.EventHandler(this.btnSharing_MouseLeave);
            this.btnSharing.MouseHover += new System.EventHandler(this.btnSharing_MouseHover);
            // 
            // panelWhite
            // 
            this.panelWhite.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelWhite.BorderThickness = 0;
            this.panelWhite.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.panelWhite.DefaultText = "";
            this.panelWhite.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.panelWhite.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.panelWhite.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.panelWhite.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.panelWhite.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.panelWhite.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.panelWhite.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.panelWhite.Location = new System.Drawing.Point(0, 0);
            this.panelWhite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelWhite.Name = "panelWhite";
            this.panelWhite.PasswordChar = '\0';
            this.panelWhite.PlaceholderText = "";
            this.panelWhite.SelectedText = "";
            this.panelWhite.Size = new System.Drawing.Size(18, 94);
            this.panelWhite.TabIndex = 27;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // SharingButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelWhite);
            this.Controls.Add(this.btnSharing);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SharingButton";
            this.Size = new System.Drawing.Size(45, 94);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnSharing;
        private Guna.UI2.WinForms.Guna2TextBox panelWhite;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}
