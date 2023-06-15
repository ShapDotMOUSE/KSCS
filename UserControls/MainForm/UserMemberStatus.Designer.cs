namespace KSCS.UserControls.MainForm
{
    partial class UserMemberStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserMemberStatus));
            this.txtLabel = new System.Windows.Forms.Label();
            this.Circle = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.picWait = new System.Windows.Forms.PictureBox();
            this.picOK = new System.Windows.Forms.PictureBox();
            this.picNo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Circle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLabel
            // 
            this.txtLabel.AutoSize = true;
            this.txtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtLabel.Location = new System.Drawing.Point(52, 10);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(174, 32);
            this.txtLabel.TabIndex = 3;
            this.txtLabel.Text = "2019203055";
            // 
            // Circle
            // 
            this.Circle.BackColor = System.Drawing.SystemColors.Control;
            this.Circle.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Circle.ImageRotate = 0F;
            this.Circle.Location = new System.Drawing.Point(16, 16);
            this.Circle.Name = "Circle";
            this.Circle.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Circle.Size = new System.Drawing.Size(20, 19);
            this.Circle.TabIndex = 2;
            this.Circle.TabStop = false;
            // 
            // picWait
            // 
            this.picWait.Image = ((System.Drawing.Image)(resources.GetObject("picWait.Image")));
            this.picWait.Location = new System.Drawing.Point(180, -13);
            this.picWait.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.picWait.Name = "picWait";
            this.picWait.Size = new System.Drawing.Size(99, 85);
            this.picWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWait.TabIndex = 4;
            this.picWait.TabStop = false;
            // 
            // picOK
            // 
            this.picOK.Image = ((System.Drawing.Image)(resources.GetObject("picOK.Image")));
            this.picOK.Location = new System.Drawing.Point(216, 11);
            this.picOK.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.picOK.Name = "picOK";
            this.picOK.Size = new System.Drawing.Size(32, 32);
            this.picOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOK.TabIndex = 5;
            this.picOK.TabStop = false;
            this.picOK.Visible = false;
            // 
            // picNo
            // 
            this.picNo.Image = global::KSCS.Properties.Resources.free_icon_font_cross_3917759;
            this.picNo.Location = new System.Drawing.Point(216, 13);
            this.picNo.Margin = new System.Windows.Forms.Padding(5);
            this.picNo.Name = "picNo";
            this.picNo.Size = new System.Drawing.Size(32, 32);
            this.picNo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNo.TabIndex = 6;
            this.picNo.TabStop = false;
            this.picNo.Visible = false;
            // 
            // UserMemberStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picNo);
            this.Controls.Add(this.picOK);
            this.Controls.Add(this.picWait);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.Circle);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "UserMemberStatus";
            this.Size = new System.Drawing.Size(276, 50);
            ((System.ComponentModel.ISupportInitialize)(this.Circle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtLabel;
        private Guna.UI2.WinForms.Guna2CirclePictureBox Circle;
        private System.Windows.Forms.PictureBox picWait;
        private System.Windows.Forms.PictureBox picOK;
        private System.Windows.Forms.PictureBox picNo;
    }
}
