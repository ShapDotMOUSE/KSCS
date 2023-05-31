namespace KSCS.UserControls.MainForm
{
    partial class UserLabel
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
            this.Circle = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.txtLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Circle)).BeginInit();
            this.SuspendLayout();
            // 
            // Circle
            // 
            this.Circle.ImageRotate = 0F;
            this.Circle.Location = new System.Drawing.Point(16, 10);
            this.Circle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Circle.Name = "Circle";
            this.Circle.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Circle.Size = new System.Drawing.Size(12, 12);
            this.Circle.TabIndex = 0;
            this.Circle.TabStop = false;
            // 
            // txtLabel
            // 
            this.txtLabel.AutoSize = true;
            this.txtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtLabel.Location = new System.Drawing.Point(38, 6);
            this.txtLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(53, 20);
            this.txtLabel.TabIndex = 1;
            this.txtLabel.Text = "label1";
            // 
            // UserLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.Circle);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserLabel";
            this.Size = new System.Drawing.Size(142, 31);
            ((System.ComponentModel.ISupportInitialize)(this.Circle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox Circle;
        private System.Windows.Forms.Label txtLabel;
    }
}
