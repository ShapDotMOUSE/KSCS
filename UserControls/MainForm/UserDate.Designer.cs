﻿namespace KSCS
{
    partial class UserDate
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
            this.lblDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.flpEvent = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = false;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDate.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F);
            this.lblDate.Location = new System.Drawing.Point(0, 0);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(155, 26);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "1";
            this.lblDate.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpEvent
            // 
            this.flpEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpEvent.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpEvent.Location = new System.Drawing.Point(0, 26);
            this.flpEvent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpEvent.Name = "flpEvent";
            this.flpEvent.Size = new System.Drawing.Size(155, 95);
            this.flpEvent.TabIndex = 1;
            this.flpEvent.MouseLeave += new System.EventHandler(this.UserDate_MouseLeave);
            this.flpEvent.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UserDate_MouseMove);
            this.flpEvent.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UserDate_Click);
            // 
            // UserDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.flpEvent);
            this.Controls.Add(this.lblDate);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserDate";
            this.Size = new System.Drawing.Size(155, 121);
            this.MouseLeave += new System.EventHandler(this.UserDate_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UserDate_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblDate;
        private System.Windows.Forms.FlowLayoutPanel flpEvent;
    }
}