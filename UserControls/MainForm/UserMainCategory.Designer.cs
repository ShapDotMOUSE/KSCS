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
            this.components = new System.ComponentModel.Container();
            this.category_underline = new Guna.UI2.WinForms.Guna2Separator();
            this.flpSubCategory = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblMainCategory = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.txtMainCategory = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAddSubCategory = new Guna.UI2.WinForms.Guna2Button();
            this.btnShowSubCategory = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // category_underline
            // 
            this.category_underline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.category_underline.BackColor = System.Drawing.Color.White;
            this.category_underline.FillColor = System.Drawing.Color.Black;
            this.category_underline.Location = new System.Drawing.Point(-17, 62);
            this.category_underline.Margin = new System.Windows.Forms.Padding(6);
            this.category_underline.Name = "category_underline";
            this.category_underline.Size = new System.Drawing.Size(260, 14);
            this.category_underline.TabIndex = 19;
            // 
            // flpSubCategory
            // 
            this.flpSubCategory.AllowDrop = true;
            this.flpSubCategory.AutoSize = true;
            this.flpSubCategory.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSubCategory.Location = new System.Drawing.Point(0, 82);
            this.flpSubCategory.Margin = new System.Windows.Forms.Padding(17, 0, 4, 4);
            this.flpSubCategory.Name = "flpSubCategory";
            this.flpSubCategory.Size = new System.Drawing.Size(253, 134);
            this.flpSubCategory.TabIndex = 20;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 169F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.Controls.Add(this.guna2Panel1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.btnAddSubCategory, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.btnShowSubCategory, 2, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 6);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(269, 50);
            this.tableLayoutPanel.TabIndex = 21;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.lblMainCategory);
            this.guna2Panel1.Controls.Add(this.txtMainCategory);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(169, 50);
            this.guna2Panel1.TabIndex = 20;
            // 
            // lblMainCategory
            // 
            this.lblMainCategory.ContextMenuStrip = this.contextMenuStrip1;
            this.lblMainCategory.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.lblMainCategory.Location = new System.Drawing.Point(0, 6);
            this.lblMainCategory.Margin = new System.Windows.Forms.Padding(0);
            this.lblMainCategory.Name = "lblMainCategory";
            this.lblMainCategory.Size = new System.Drawing.Size(169, 50);
            this.lblMainCategory.TabIndex = 1;
            this.lblMainCategory.Text = "label1";
            this.lblMainCategory.DoubleClick += new System.EventHandler(this.lblMainCategory_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(301, 86);
            // 
            // MenuDelete
            // 
            this.MenuDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuDelete.Name = "MenuDelete";
            this.MenuDelete.Size = new System.Drawing.Size(300, 38);
            this.MenuDelete.Text = "삭제";
            this.MenuDelete.Click += new System.EventHandler(this.MenuDelete_Click);
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
            this.txtMainCategory.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.txtMainCategory.Name = "txtMainCategory";
            this.txtMainCategory.PasswordChar = '\0';
            this.txtMainCategory.PlaceholderText = "";
            this.txtMainCategory.SelectedText = "";
            this.txtMainCategory.Size = new System.Drawing.Size(184, 50);
            this.txtMainCategory.TabIndex = 0;
            this.txtMainCategory.Visible = false;
            this.txtMainCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMainCategory_KeyDown);
            this.txtMainCategory.Leave += new System.EventHandler(this.txtMainCategory_Leave);
            // 
            // btnAddSubCategory
            // 
            this.btnAddSubCategory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddSubCategory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddSubCategory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddSubCategory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddSubCategory.FillColor = System.Drawing.Color.Transparent;
            this.btnAddSubCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddSubCategory.ForeColor = System.Drawing.Color.White;
            this.btnAddSubCategory.Image = global::KSCS.Properties.Resources.free_icon_font_plus_3917757;
            this.btnAddSubCategory.Location = new System.Drawing.Point(172, 3);
            this.btnAddSubCategory.Name = "btnAddSubCategory";
            this.btnAddSubCategory.Size = new System.Drawing.Size(44, 44);
            this.btnAddSubCategory.TabIndex = 23;
            this.btnAddSubCategory.Click += new System.EventHandler(this.btnAddSubCategory_Click);
            // 
            // btnShowSubCategory
            // 
            this.btnShowSubCategory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShowSubCategory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShowSubCategory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShowSubCategory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShowSubCategory.FillColor = System.Drawing.Color.Transparent;
            this.btnShowSubCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnShowSubCategory.ForeColor = System.Drawing.Color.White;
            this.btnShowSubCategory.Image = global::KSCS.Properties.Resources.down;
            this.btnShowSubCategory.ImageSize = new System.Drawing.Size(30, 30);
            this.btnShowSubCategory.Location = new System.Drawing.Point(222, 3);
            this.btnShowSubCategory.Name = "btnShowSubCategory";
            this.btnShowSubCategory.Size = new System.Drawing.Size(44, 44);
            this.btnShowSubCategory.TabIndex = 24;
            this.btnShowSubCategory.Click += new System.EventHandler(this.btnShowSubCategory_Click);
            // 
            // UserMainCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.category_underline);
            this.Controls.Add(this.flpSubCategory);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserMainCategory";
            this.Size = new System.Drawing.Size(279, 220);
            this.Load += new System.EventHandler(this.UserMainCategory_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Separator category_underline;
        public System.Windows.Forms.FlowLayoutPanel flpSubCategory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox txtMainCategory;
        private System.Windows.Forms.Label lblMainCategory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuDelete;
        private Guna.UI2.WinForms.Guna2Button btnAddSubCategory;
        private Guna.UI2.WinForms.Guna2Button btnShowSubCategory;
    }
}
