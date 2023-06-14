namespace KSCS
{
    partial class UserSharingSubCategory
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCategory = new System.Windows.Forms.Label();
            this.chkCategory = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Controls.Add(this.lblCategory, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkCategory, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(210, 38);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.BackColor = System.Drawing.Color.Transparent;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblCategory.Location = new System.Drawing.Point(11, 0);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(11, 0, 6, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(0, 32);
            this.lblCategory.TabIndex = 17;
            // 
            // chkCategory
            // 
            this.chkCategory.CheckedState.BorderColor = System.Drawing.Color.Maroon;
            this.chkCategory.CheckedState.BorderRadius = 4;
            this.chkCategory.CheckedState.BorderThickness = 2;
            this.chkCategory.CheckedState.FillColor = System.Drawing.Color.White;
            this.chkCategory.CheckMarkColor = System.Drawing.Color.Maroon;
            this.chkCategory.Location = new System.Drawing.Point(173, 4);
            this.chkCategory.Margin = new System.Windows.Forms.Padding(0, 4, 6, 4);
            this.chkCategory.Name = "chkCategory";
            this.chkCategory.Size = new System.Drawing.Size(31, 30);
            this.chkCategory.TabIndex = 16;
            this.chkCategory.Text = "guna2CustomCheckBox2";
            this.chkCategory.UncheckedState.BorderColor = System.Drawing.Color.Maroon;
            this.chkCategory.UncheckedState.BorderRadius = 4;
            this.chkCategory.UncheckedState.BorderThickness = 2;
            this.chkCategory.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkCategory.Click += new System.EventHandler(this.chkCategory_Click);
            // 
            // UserSharingSubCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserSharingSubCategory";
            this.Size = new System.Drawing.Size(210, 38);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2CustomCheckBox chkCategory;
        private System.Windows.Forms.Label lblCategory;
    }
}
