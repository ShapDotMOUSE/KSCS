namespace KSCS
{
    partial class UserCategory
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
            this.lblCategory = new System.Windows.Forms.Label();
            this.chkCategory = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.txtCategory = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.BackColor = System.Drawing.Color.Transparent;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblCategory.Location = new System.Drawing.Point(9, 2);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(9, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(0, 25);
            this.lblCategory.TabIndex = 15;
            this.lblCategory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblCategory_MouseDoubleClick);
            // 
            // chkCategory
            // 
            this.chkCategory.CheckedState.BorderColor = System.Drawing.Color.Maroon;
            this.chkCategory.CheckedState.BorderRadius = 4;
            this.chkCategory.CheckedState.BorderThickness = 2;
            this.chkCategory.CheckedState.FillColor = System.Drawing.Color.White;
            this.chkCategory.CheckMarkColor = System.Drawing.Color.Maroon;
            this.chkCategory.Location = new System.Drawing.Point(131, 3);
            this.chkCategory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkCategory.Name = "chkCategory";
            this.chkCategory.Size = new System.Drawing.Size(26, 24);
            this.chkCategory.TabIndex = 16;
            this.chkCategory.Text = "guna2CustomCheckBox2";
            this.chkCategory.UncheckedState.BorderColor = System.Drawing.Color.Maroon;
            this.chkCategory.UncheckedState.BorderRadius = 4;
            this.chkCategory.UncheckedState.BorderThickness = 2;
            this.chkCategory.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkCategory.CheckedChanged += new System.EventHandler(this.chkCategory_CheckedChanged);
            // 
            // txtCategory
            // 
            this.txtCategory.BackColor = System.Drawing.Color.White;
            this.txtCategory.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCategory.DefaultText = "";
            this.txtCategory.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCategory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCategory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCategory.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtCategory.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCategory.Location = new System.Drawing.Point(0, 2);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.PasswordChar = '\0';
            this.txtCategory.PlaceholderText = "";
            this.txtCategory.SelectedText = "";
            this.txtCategory.Size = new System.Drawing.Size(123, 26);
            this.txtCategory.TabIndex = 17;
            this.txtCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategory_KeyDown);
            // 
            // UserCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.chkCategory);
            this.Controls.Add(this.lblCategory);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.Name = "UserCategory";
            this.Size = new System.Drawing.Size(161, 28);
            this.Load += new System.EventHandler(this.UserCategory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategory;
        private Guna.UI2.WinForms.Guna2CustomCheckBox chkCategory;
        private Guna.UI2.WinForms.Guna2TextBox txtCategory;
    }
}
