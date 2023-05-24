namespace KSCS
{
    partial class UserMainCategory
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
            this.category_underline = new Guna.UI2.WinForms.Guna2Separator();
            this.flpSubCategory = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblMainCategory = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtMainCategory = new Guna.UI2.WinForms.Guna2TextBox();
            this.tableLayoutPanel.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // category_underline
            // 
            this.category_underline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.category_underline.BackColor = System.Drawing.Color.White;
            this.category_underline.FillColor = System.Drawing.Color.Black;
            this.category_underline.Location = new System.Drawing.Point(3, 31);
            this.category_underline.Name = "category_underline";
            this.category_underline.Size = new System.Drawing.Size(130, 7);
            this.category_underline.TabIndex = 19;
            // 
            // flpSubCategory
            // 
            this.flpSubCategory.AllowDrop = true;
            this.flpSubCategory.AutoScroll = true;
            this.flpSubCategory.Location = new System.Drawing.Point(0, 41);
            this.flpSubCategory.Margin = new System.Windows.Forms.Padding(9, 0, 2, 2);
            this.flpSubCategory.Name = "flpSubCategory";
            this.flpSubCategory.Size = new System.Drawing.Size(136, 67);
            this.flpSubCategory.TabIndex = 20;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel.Controls.Add(this.btn, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.guna2Panel1, 0, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(140, 25);
            this.tableLayoutPanel.TabIndex = 21;
            // 
            // btn
            // 
            this.btn.BackColor = System.Drawing.Color.White;
            this.btn.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn.FillColor = System.Drawing.Color.Transparent;
            this.btn.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btn.ForeColor = System.Drawing.Color.Black;
            this.btn.Location = new System.Drawing.Point(110, 0);
            this.btn.Margin = new System.Windows.Forms.Padding(0);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(35, 25);
            this.btn.TabIndex = 19;
            this.btn.Text = "▼";
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.lblMainCategory);
            this.guna2Panel1.Controls.Add(this.txtMainCategory);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(105, 25);
            this.guna2Panel1.TabIndex = 20;
            // 
            // lblMainCategory
            // 
            this.lblMainCategory.AutoSize = false;
            this.lblMainCategory.BackColor = System.Drawing.Color.Transparent;
            this.lblMainCategory.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.lblMainCategory.Location = new System.Drawing.Point(11, 0);
            this.lblMainCategory.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.lblMainCategory.Name = "lblMainCategory";
            this.lblMainCategory.Size = new System.Drawing.Size(99, 25);
            this.lblMainCategory.TabIndex = 1;
            this.lblMainCategory.Text = null;
            this.lblMainCategory.DoubleClick += new System.EventHandler(this.lblMainCategory_DoubleClick);
            // 
            // txtMainCategory
            // 
            this.txtMainCategory.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMainCategory.DefaultText = "";
            this.txtMainCategory.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMainCategory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMainCategory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMainCategory.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMainCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMainCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMainCategory.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMainCategory.Location = new System.Drawing.Point(0, 0);
            this.txtMainCategory.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.txtMainCategory.Name = "txtMainCategory";
            this.txtMainCategory.PasswordChar = '\0';
            this.txtMainCategory.PlaceholderText = "";
            this.txtMainCategory.SelectedText = "";
            this.txtMainCategory.Size = new System.Drawing.Size(99, 25);
            this.txtMainCategory.TabIndex = 0;
            this.txtMainCategory.Visible = false;
            this.txtMainCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMainCategory_KeyDown);
            this.txtMainCategory.Leave += new System.EventHandler(this.txtMainCategory_Leave);
            // 
            // UserMainCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.category_underline);
            this.Controls.Add(this.flpSubCategory);
            this.Name = "UserMainCategory";
            this.Size = new System.Drawing.Size(150, 110);
            this.tableLayoutPanel.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Separator category_underline;
        public System.Windows.Forms.FlowLayoutPanel flpSubCategory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private Guna.UI2.WinForms.Guna2Button btn;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMainCategory;
        private Guna.UI2.WinForms.Guna2TextBox txtMainCategory;
    }
}
