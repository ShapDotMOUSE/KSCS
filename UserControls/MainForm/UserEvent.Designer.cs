﻿namespace KSCS
{
    partial class UserEvent
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
            this.flpEventInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.pnl = new Guna.UI2.WinForms.Guna2Panel();
            this.txtEventInfo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.flpEventInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpEventInfo
            // 
            this.flpEventInfo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.flpEventInfo.Controls.Add(this.pnl);
            this.flpEventInfo.Controls.Add(this.txtEventInfo);
            this.flpEventInfo.Location = new System.Drawing.Point(0, 0);
            this.flpEventInfo.Margin = new System.Windows.Forms.Padding(4);
            this.flpEventInfo.Name = "flpEventInfo";
            this.flpEventInfo.Size = new System.Drawing.Size(146, 22);
            this.flpEventInfo.TabIndex = 0;
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.SteelBlue;
            this.pnl.Location = new System.Drawing.Point(0, 0);
            this.pnl.Margin = new System.Windows.Forms.Padding(0);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(14, 22);
            this.pnl.TabIndex = 0;
            // 
            // txtEventInfo
            // 
            this.txtEventInfo.AutoSize = false;
            this.txtEventInfo.BackColor = System.Drawing.Color.Transparent;
            this.txtEventInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtEventInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEventInfo.Location = new System.Drawing.Point(21, 0);
            this.txtEventInfo.Margin = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.txtEventInfo.Name = "txtEventInfo";
            this.txtEventInfo.Size = new System.Drawing.Size(124, 22);
            this.txtEventInfo.TabIndex = 2;
            this.txtEventInfo.Text = "일정 정보";
            // 
            // UserEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpEventInfo);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserEvent";
            this.Size = new System.Drawing.Size(146, 22);
            this.flpEventInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpEventInfo;
        private Guna.UI2.WinForms.Guna2Panel pnl;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtEventInfo;
    }
}
