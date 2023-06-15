namespace KSCS.Forms
{
    partial class AllowOrRequestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllowOrRequestForm));
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lbl_StudentNumber = new System.Windows.Forms.Label();
            this.lbl_message = new System.Windows.Forms.Label();
            this.closeBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnAgree = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefuse = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.panelTop.Controls.Add(this.lbl_StudentNumber);
            this.panelTop.Controls.Add(this.lbl_message);
            this.panelTop.Controls.Add(this.closeBtn);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(669, 86);
            this.panelTop.TabIndex = 6;
            // 
            // lbl_StudentNumber
            // 
            this.lbl_StudentNumber.AutoSize = true;
            this.lbl_StudentNumber.Font = new System.Drawing.Font("나눔고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_StudentNumber.Location = new System.Drawing.Point(40, 30);
            this.lbl_StudentNumber.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_StudentNumber.Name = "lbl_StudentNumber";
            this.lbl_StudentNumber.Size = new System.Drawing.Size(140, 24);
            this.lbl_StudentNumber.TabIndex = 13;
            this.lbl_StudentNumber.Text = "2019203055";
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.Font = new System.Drawing.Font("나눔고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_message.ForeColor = System.Drawing.Color.Black;
            this.lbl_message.Location = new System.Drawing.Point(169, 30);
            this.lbl_message.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(466, 24);
            this.lbl_message.TabIndex = 7;
            this.lbl_message.Text = "님이 회원님을 실시간 일정 공유에 초대하셨습니다.";
            // 
            // closeBtn
            // 
            this.closeBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.closeBtn.HoverState.ImageSize = new System.Drawing.Size(0, 0);
            this.closeBtn.Image = global::KSCS.Properties.Resources.free_icon_font_cross_3917759;
            this.closeBtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.closeBtn.ImageRotate = 0F;
            this.closeBtn.ImageSize = new System.Drawing.Size(15, 15);
            this.closeBtn.Location = new System.Drawing.Point(758, 0);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.PressedState.ImageSize = new System.Drawing.Size(0, 0);
            this.closeBtn.Size = new System.Drawing.Size(55, 53);
            this.closeBtn.TabIndex = 12;
            // 
            // btnAgree
            // 
            this.btnAgree.BorderRadius = 10;
            this.btnAgree.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAgree.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAgree.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAgree.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAgree.FillColor = System.Drawing.Color.Silver;
            this.btnAgree.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgree.ForeColor = System.Drawing.Color.White;
            this.btnAgree.Location = new System.Drawing.Point(132, 122);
            this.btnAgree.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgree.Name = "btnAgree";
            this.btnAgree.Size = new System.Drawing.Size(135, 54);
            this.btnAgree.TabIndex = 7;
            this.btnAgree.Text = "수 락";
            this.btnAgree.Click += new System.EventHandler(this.btnAgree_Click);
            // 
            // btnRefuse
            // 
            this.btnRefuse.BorderRadius = 10;
            this.btnRefuse.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefuse.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefuse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefuse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefuse.FillColor = System.Drawing.Color.Silver;
            this.btnRefuse.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefuse.ForeColor = System.Drawing.Color.White;
            this.btnRefuse.Location = new System.Drawing.Point(390, 122);
            this.btnRefuse.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefuse.Name = "btnRefuse";
            this.btnRefuse.Size = new System.Drawing.Size(135, 54);
            this.btnRefuse.TabIndex = 7;
            this.btnRefuse.Text = "거 절";
            this.btnRefuse.Click += new System.EventHandler(this.btnRefuse_Click);
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.BorderRadius = 10;
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 10;
            this.guna2Elipse1.TargetControl = this;
            // 
            // AllowOrRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(669, 212);
            this.Controls.Add(this.btnRefuse);
            this.Controls.Add(this.btnAgree);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AllowOrRequestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AllowOrRequestForm";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnRefuse;
        private Guna.UI2.WinForms.Guna2Button btnAgree;
        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private System.Windows.Forms.Label lbl_message;
        private Guna.UI2.WinForms.Guna2ImageButton closeBtn;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        public System.Windows.Forms.Label lbl_StudentNumber;
    }
}