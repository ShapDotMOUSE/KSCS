namespace KSCS
{
    partial class ScheDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheDetailForm));
            this.formRadius = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.closeBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.panelLabel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ImageButton6 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButton5 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButton4 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButton3 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButton2 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.labelCategory = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.labelMemo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.labelTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.labelSchedule = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.labelPlace = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.labelMember = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.deleteBtnRadius = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.deleteBtn = new Guna.UI2.WinForms.Guna2Button();
            this.addBtnRadius = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.addBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.tsmAddmem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteMem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSchedules = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAddSchedule = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpEndTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpStartTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cbCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tbMemo = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbPlace = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbTitle = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnMemSet = new Guna.UI2.WinForms.Guna2Button();
            this.flpMember = new System.Windows.Forms.FlowLayoutPanel();
            this.txtMember = new System.Windows.Forms.TextBox();
            this.panelTop.SuspendLayout();
            this.panelLabel.SuspendLayout();
            this.guna2ContextMenuStrip1.SuspendLayout();
            this.panelSchedules.SuspendLayout();
            this.flpMember.SuspendLayout();
            this.SuspendLayout();
            // 
            // formRadius
            // 
            this.formRadius.BorderRadius = 30;
            this.formRadius.TargetControl = this;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Pink;
            this.panelTop.Controls.Add(this.closeBtn);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(650, 44);
            this.panelTop.TabIndex = 5;
            // 
            // closeBtn
            // 
            this.closeBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.closeBtn.HoverState.ImageSize = new System.Drawing.Size(0, 0);
            this.closeBtn.Image = global::KSCS.Properties.Resources.free_icon_font_cross_3917759;
            this.closeBtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.closeBtn.ImageRotate = 0F;
            this.closeBtn.ImageSize = new System.Drawing.Size(15, 15);
            this.closeBtn.Location = new System.Drawing.Point(606, 0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.PressedState.ImageSize = new System.Drawing.Size(0, 0);
            this.closeBtn.Size = new System.Drawing.Size(44, 44);
            this.closeBtn.TabIndex = 12;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // panelLabel
            // 
            this.panelLabel.Controls.Add(this.guna2ImageButton6);
            this.panelLabel.Controls.Add(this.guna2ImageButton5);
            this.panelLabel.Controls.Add(this.guna2ImageButton4);
            this.panelLabel.Controls.Add(this.guna2ImageButton3);
            this.panelLabel.Controls.Add(this.guna2ImageButton2);
            this.panelLabel.Controls.Add(this.guna2ImageButton1);
            this.panelLabel.Controls.Add(this.labelCategory);
            this.panelLabel.Controls.Add(this.labelMemo);
            this.panelLabel.Controls.Add(this.labelTitle);
            this.panelLabel.Controls.Add(this.labelSchedule);
            this.panelLabel.Controls.Add(this.labelPlace);
            this.panelLabel.Controls.Add(this.labelMember);
            this.panelLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLabel.Location = new System.Drawing.Point(208, 44);
            this.panelLabel.Name = "panelLabel";
            this.panelLabel.Size = new System.Drawing.Size(147, 546);
            this.panelLabel.TabIndex = 0;
            // 
            // guna2ImageButton6
            // 
            this.guna2ImageButton6.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton6.HoverState.ImageSize = new System.Drawing.Size(0, 0);
            this.guna2ImageButton6.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButton6.Image")));
            this.guna2ImageButton6.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton6.ImageRotate = 0F;
            this.guna2ImageButton6.ImageSize = new System.Drawing.Size(20, 20);
            this.guna2ImageButton6.Location = new System.Drawing.Point(14, 304);
            this.guna2ImageButton6.Name = "guna2ImageButton6";
            this.guna2ImageButton6.PressedState.ImageSize = new System.Drawing.Size(0, 0);
            this.guna2ImageButton6.Size = new System.Drawing.Size(39, 28);
            this.guna2ImageButton6.TabIndex = 37;
            // 
            // guna2ImageButton5
            // 
            this.guna2ImageButton5.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton5.HoverState.ImageSize = new System.Drawing.Size(0, 0);
            this.guna2ImageButton5.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButton5.Image")));
            this.guna2ImageButton5.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton5.ImageRotate = 0F;
            this.guna2ImageButton5.ImageSize = new System.Drawing.Size(20, 20);
            this.guna2ImageButton5.Location = new System.Drawing.Point(14, 235);
            this.guna2ImageButton5.Name = "guna2ImageButton5";
            this.guna2ImageButton5.PressedState.ImageSize = new System.Drawing.Size(0, 0);
            this.guna2ImageButton5.Size = new System.Drawing.Size(39, 28);
            this.guna2ImageButton5.TabIndex = 36;
            // 
            // guna2ImageButton4
            // 
            this.guna2ImageButton4.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton4.HoverState.ImageSize = new System.Drawing.Size(0, 0);
            this.guna2ImageButton4.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButton4.Image")));
            this.guna2ImageButton4.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton4.ImageRotate = 0F;
            this.guna2ImageButton4.ImageSize = new System.Drawing.Size(20, 20);
            this.guna2ImageButton4.Location = new System.Drawing.Point(14, 165);
            this.guna2ImageButton4.Name = "guna2ImageButton4";
            this.guna2ImageButton4.PressedState.ImageSize = new System.Drawing.Size(0, 0);
            this.guna2ImageButton4.Size = new System.Drawing.Size(39, 28);
            this.guna2ImageButton4.TabIndex = 35;
            // 
            // guna2ImageButton3
            // 
            this.guna2ImageButton3.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton3.HoverState.ImageSize = new System.Drawing.Size(0, 0);
            this.guna2ImageButton3.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButton3.Image")));
            this.guna2ImageButton3.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton3.ImageRotate = 0F;
            this.guna2ImageButton3.ImageSize = new System.Drawing.Size(20, 20);
            this.guna2ImageButton3.Location = new System.Drawing.Point(14, 87);
            this.guna2ImageButton3.Name = "guna2ImageButton3";
            this.guna2ImageButton3.PressedState.ImageSize = new System.Drawing.Size(0, 0);
            this.guna2ImageButton3.Size = new System.Drawing.Size(39, 28);
            this.guna2ImageButton3.TabIndex = 34;
            // 
            // guna2ImageButton2
            // 
            this.guna2ImageButton2.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton2.HoverState.ImageSize = new System.Drawing.Size(0, 0);
            this.guna2ImageButton2.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButton2.Image")));
            this.guna2ImageButton2.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton2.ImageRotate = 0F;
            this.guna2ImageButton2.ImageSize = new System.Drawing.Size(20, 20);
            this.guna2ImageButton2.Location = new System.Drawing.Point(14, 22);
            this.guna2ImageButton2.Name = "guna2ImageButton2";
            this.guna2ImageButton2.PressedState.ImageSize = new System.Drawing.Size(0, 0);
            this.guna2ImageButton2.Size = new System.Drawing.Size(39, 28);
            this.guna2ImageButton2.TabIndex = 33;
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.HoverState.ImageSize = new System.Drawing.Size(0, 0);
            this.guna2ImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButton1.Image")));
            this.guna2ImageButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton1.ImageRotate = 0F;
            this.guna2ImageButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.guna2ImageButton1.Location = new System.Drawing.Point(14, 406);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(0, 0);
            this.guna2ImageButton1.Size = new System.Drawing.Size(39, 28);
            this.guna2ImageButton1.TabIndex = 32;
            // 
            // labelCategory
            // 
            this.labelCategory.BackColor = System.Drawing.Color.Transparent;
            this.labelCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelCategory.Location = new System.Drawing.Point(59, 237);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(63, 20);
            this.labelCategory.TabIndex = 31;
            this.labelCategory.Text = "Category";
            // 
            // labelMemo
            // 
            this.labelMemo.BackColor = System.Drawing.Color.Transparent;
            this.labelMemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelMemo.Location = new System.Drawing.Point(59, 306);
            this.labelMemo.Name = "labelMemo";
            this.labelMemo.Size = new System.Drawing.Size(46, 20);
            this.labelMemo.TabIndex = 30;
            this.labelMemo.Text = "Memo";
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTitle.Location = new System.Drawing.Point(59, 24);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(30, 20);
            this.labelTitle.TabIndex = 29;
            this.labelTitle.Text = "Title";
            // 
            // labelSchedule
            // 
            this.labelSchedule.BackColor = System.Drawing.Color.Transparent;
            this.labelSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelSchedule.Location = new System.Drawing.Point(59, 89);
            this.labelSchedule.Name = "labelSchedule";
            this.labelSchedule.Size = new System.Drawing.Size(64, 20);
            this.labelSchedule.TabIndex = 26;
            this.labelSchedule.Text = "Schedule";
            // 
            // labelPlace
            // 
            this.labelPlace.BackColor = System.Drawing.Color.Transparent;
            this.labelPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelPlace.Location = new System.Drawing.Point(59, 167);
            this.labelPlace.Name = "labelPlace";
            this.labelPlace.Size = new System.Drawing.Size(40, 20);
            this.labelPlace.TabIndex = 28;
            this.labelPlace.Text = "Place";
            // 
            // labelMember
            // 
            this.labelMember.BackColor = System.Drawing.Color.Transparent;
            this.labelMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelMember.Location = new System.Drawing.Point(59, 408);
            this.labelMember.Name = "labelMember";
            this.labelMember.Size = new System.Drawing.Size(58, 20);
            this.labelMember.TabIndex = 27;
            this.labelMember.Text = "Member";
            // 
            // deleteBtnRadius
            // 
            this.deleteBtnRadius.BorderRadius = 10;
            this.deleteBtnRadius.TargetControl = this.deleteBtn;
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.deleteBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.deleteBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.deleteBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.deleteBtn.FillColor = System.Drawing.Color.LightCoral;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.deleteBtn.ForeColor = System.Drawing.Color.White;
            this.deleteBtn.Location = new System.Drawing.Point(514, 538);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(110, 40);
            this.deleteBtn.TabIndex = 29;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // addBtnRadius
            // 
            this.addBtnRadius.BorderRadius = 10;
            this.addBtnRadius.TargetControl = this.addBtn;
            // 
            // addBtn
            // 
            this.addBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addBtn.FillColor = System.Drawing.Color.CornflowerBlue;
            this.addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.ForeColor = System.Drawing.Color.White;
            this.addBtn.Location = new System.Drawing.Point(382, 538);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(110, 40);
            this.addBtn.TabIndex = 33;
            this.addBtn.Text = "Add";
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.panelTop;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddmem,
            this.tsmDeleteMem});
            this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(126, 48);
            // 
            // tsmAddmem
            // 
            this.tsmAddmem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsmAddmem.Name = "tsmAddmem";
            this.tsmAddmem.Size = new System.Drawing.Size(125, 22);
            this.tsmAddmem.Text = "멤버 추가";
            // 
            // tsmDeleteMem
            // 
            this.tsmDeleteMem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsmDeleteMem.Name = "tsmDeleteMem";
            this.tsmDeleteMem.Size = new System.Drawing.Size(125, 22);
            this.tsmDeleteMem.Text = "멤버 삭제";
            // 
            // panelSchedules
            // 
            this.panelSchedules.AutoScroll = true;
            this.panelSchedules.AutoScrollMargin = new System.Drawing.Size(0, 100);
            this.panelSchedules.AutoScrollMinSize = new System.Drawing.Size(0, 450);
            this.panelSchedules.Controls.Add(this.btnAddSchedule);
            this.panelSchedules.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSchedules.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelSchedules.Location = new System.Drawing.Point(0, 44);
            this.panelSchedules.Name = "panelSchedules";
            this.panelSchedules.Size = new System.Drawing.Size(208, 546);
            this.panelSchedules.TabIndex = 28;
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddSchedule.BorderRadius = 5;
            this.btnAddSchedule.BorderThickness = 1;
            this.btnAddSchedule.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddSchedule.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddSchedule.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddSchedule.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddSchedule.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSchedule.ForeColor = System.Drawing.Color.Black;
            this.btnAddSchedule.Image = global::KSCS.Properties.Resources.free_icon_font_plus_3917757;
            this.btnAddSchedule.Location = new System.Drawing.Point(-15, 84);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(167, 40);
            this.btnAddSchedule.TabIndex = 45;
            this.btnAddSchedule.Click += new System.EventHandler(this.btnAddSchedule_Click);
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(342, 160);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(31, 17);
            this.guna2HtmlLabel8.TabIndex = 40;
            this.guna2HtmlLabel8.Text = "End :";
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(342, 135);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(34, 17);
            this.guna2HtmlLabel7.TabIndex = 39;
            this.guna2HtmlLabel7.Text = "Start :";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtpEndTime.Checked = true;
            this.dtpEndTime.CustomFormat = "HH:mm";
            this.dtpEndTime.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtpEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(533, 159);
            this.dtpEndTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEndTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(89, 20);
            this.dtpEndTime.TabIndex = 38;
            this.dtpEndTime.Value = new System.DateTime(2023, 5, 9, 1, 5, 29, 884);
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtpStartTime.Checked = true;
            this.dtpStartTime.CustomFormat = "HH:mm";
            this.dtpStartTime.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtpStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(533, 133);
            this.dtpStartTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(89, 20);
            this.dtpStartTime.TabIndex = 37;
            this.dtpStartTime.Value = new System.DateTime(2023, 5, 9, 1, 5, 29, 884);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtpEndDate.Checked = true;
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd ddd";
            this.dtpEndDate.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.IndicateFocus = true;
            this.dtpEndDate.Location = new System.Drawing.Point(382, 159);
            this.dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(141, 20);
            this.dtpEndDate.TabIndex = 36;
            this.dtpEndDate.Value = new System.DateTime(2023, 5, 9, 1, 5, 29, 884);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtpStartDate.Checked = true;
            this.dtpStartDate.CustomFormat = "yyyy-MM-dd ddd";
            this.dtpStartDate.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.IndicateFocus = true;
            this.dtpStartDate.Location = new System.Drawing.Point(382, 133);
            this.dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(141, 20);
            this.dtpStartDate.TabIndex = 35;
            this.dtpStartDate.Value = new System.DateTime(2023, 5, 9, 1, 5, 29, 884);
            // 
            // cbCategory
            // 
            this.cbCategory.BackColor = System.Drawing.Color.Transparent;
            this.cbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbCategory.ForeColor = System.Drawing.Color.Black;
            this.cbCategory.ItemHeight = 30;
            this.cbCategory.Items.AddRange(new object[] {
            "KLAS",
            "공유 일정",
            "개인"});
            this.cbCategory.Location = new System.Drawing.Point(342, 281);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(280, 36);
            this.cbCategory.TabIndex = 34;
            this.cbCategory.DropDownClosed += new System.EventHandler(this.cbCategory_DropDownClosed);
            // 
            // tbMemo
            // 
            this.tbMemo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbMemo.DefaultText = "";
            this.tbMemo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbMemo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbMemo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbMemo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbMemo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbMemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbMemo.ForeColor = System.Drawing.Color.Black;
            this.tbMemo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbMemo.Location = new System.Drawing.Point(342, 350);
            this.tbMemo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbMemo.Name = "tbMemo";
            this.tbMemo.PasswordChar = '\0';
            this.tbMemo.PlaceholderText = "";
            this.tbMemo.SelectedText = "";
            this.tbMemo.Size = new System.Drawing.Size(280, 72);
            this.tbMemo.TabIndex = 32;
            // 
            // tbPlace
            // 
            this.tbPlace.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPlace.DefaultText = "";
            this.tbPlace.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPlace.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPlace.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPlace.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPlace.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPlace.ForeColor = System.Drawing.Color.Black;
            this.tbPlace.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPlace.Location = new System.Drawing.Point(342, 211);
            this.tbPlace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPlace.Name = "tbPlace";
            this.tbPlace.PasswordChar = '\0';
            this.tbPlace.PlaceholderText = "";
            this.tbPlace.SelectedText = "";
            this.tbPlace.Size = new System.Drawing.Size(280, 36);
            this.tbPlace.TabIndex = 31;
            // 
            // tbTitle
            // 
            this.tbTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTitle.DefaultText = "";
            this.tbTitle.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbTitle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbTitle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTitle.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTitle.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbTitle.ForeColor = System.Drawing.Color.Black;
            this.tbTitle.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTitle.Location = new System.Drawing.Point(342, 66);
            this.tbTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.PasswordChar = '\0';
            this.tbTitle.PlaceholderText = "";
            this.tbTitle.SelectedText = "";
            this.tbTitle.Size = new System.Drawing.Size(280, 36);
            this.tbTitle.TabIndex = 30;
            // 
            // btnMemSet
            // 
            this.btnMemSet.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.btnMemSet.BorderThickness = 1;
            this.btnMemSet.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMemSet.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMemSet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMemSet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMemSet.FillColor = System.Drawing.Color.White;
            this.btnMemSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnMemSet.ForeColor = System.Drawing.Color.Black;
            this.btnMemSet.Location = new System.Drawing.Point(343, 451);
            this.btnMemSet.Name = "btnMemSet";
            this.btnMemSet.Size = new System.Drawing.Size(279, 36);
            this.btnMemSet.TabIndex = 41;
            this.btnMemSet.Text = "일정 함께하는 친구 추가";
            this.btnMemSet.Click += new System.EventHandler(this.btnMemSet_Click);
            // 
            // flpMember
            // 
            this.flpMember.AutoScroll = true;
            this.flpMember.Controls.Add(this.txtMember);
            this.flpMember.Location = new System.Drawing.Point(340, 450);
            this.flpMember.Name = "flpMember";
            this.flpMember.Size = new System.Drawing.Size(284, 75);
            this.flpMember.TabIndex = 1;
            this.flpMember.Visible = false;
            // 
            // txtMember
            // 
            this.txtMember.Location = new System.Drawing.Point(3, 3);
            this.txtMember.Multiline = true;
            this.txtMember.Name = "txtMember";
            this.txtMember.Size = new System.Drawing.Size(278, 33);
            this.txtMember.TabIndex = 0;
            this.txtMember.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // ScheDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(650, 590);
            this.Controls.Add(this.flpMember);
            this.Controls.Add(this.btnMemSet);
            this.Controls.Add(this.guna2HtmlLabel8);
            this.Controls.Add(this.guna2HtmlLabel7);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.tbMemo);
            this.Controls.Add(this.tbPlace);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.panelLabel);
            this.Controls.Add(this.panelSchedules);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ScheDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "2";
            this.panelTop.ResumeLayout(false);
            this.panelLabel.ResumeLayout(false);
            this.panelLabel.PerformLayout();
            this.guna2ContextMenuStrip1.ResumeLayout(false);
            this.panelSchedules.ResumeLayout(false);
            this.flpMember.ResumeLayout(false);
            this.flpMember.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse formRadius;
        private Guna.UI2.WinForms.Guna2Panel panelLabel;
        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private Guna.UI2.WinForms.Guna2Elipse deleteBtnRadius;
        private Guna.UI2.WinForms.Guna2Elipse addBtnRadius;
        private Guna.UI2.WinForms.Guna2ImageButton closeBtn;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmAddmem;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteMem;
        private Guna.UI2.WinForms.Guna2Panel panelSchedules;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton6;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton5;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton4;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton3;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton2;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelCategory;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelMemo;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelSchedule;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelPlace;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndTime;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartTime;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartDate;
        private Guna.UI2.WinForms.Guna2ComboBox cbCategory;
        private Guna.UI2.WinForms.Guna2Button deleteBtn;
        private Guna.UI2.WinForms.Guna2Button addBtn;
        private Guna.UI2.WinForms.Guna2TextBox tbMemo;
        private Guna.UI2.WinForms.Guna2TextBox tbPlace;
        private Guna.UI2.WinForms.Guna2TextBox tbTitle;
        private Guna.UI2.WinForms.Guna2Button btnAddSchedule;
        private Guna.UI2.WinForms.Guna2Button btnMemSet;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelMember;
        private System.Windows.Forms.FlowLayoutPanel flpMember;
        private System.Windows.Forms.TextBox txtMember;
    }
}