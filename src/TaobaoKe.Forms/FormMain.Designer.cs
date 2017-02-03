namespace TaobaoKe.Forms
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.timerTransmit = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tpageTransmit = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridTasks = new System.Windows.Forms.DataGridView();
            this.colRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommissionRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoupon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsTasks = new System.Windows.Forms.BindingSource(this.components);
            this.tpageAddTask = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.wbTransmit = new System.Windows.Forms.WebBrowser();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnAddTaskAtOnce = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkTransmit = new System.Windows.Forms.LinkLabel();
            this.lnkMonitor = new System.Windows.Forms.LinkLabel();
            this.lnkSetting = new System.Windows.Forms.LinkLabel();
            this.lblAccount = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusStartAt = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusMonitor = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusTransmit = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tpageTransmit.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTasks)).BeginInit();
            this.tpageAddTask.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgList
            // 
            this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgList.ImageSize = new System.Drawing.Size(16, 16);
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timerTransmit
            // 
            this.timerTransmit.Tick += new System.EventHandler(this.timerTransmit_Tick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 136);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2008, 872);
            this.panel2.TabIndex = 1;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tpageTransmit);
            this.tabMain.Controls.Add(this.tpageAddTask);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.ImageList = this.imgList;
            this.tabMain.ItemSize = new System.Drawing.Size(118, 42);
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Margin = new System.Windows.Forms.Padding(6);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(2008, 872);
            this.tabMain.TabIndex = 0;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tpageTransmit
            // 
            this.tpageTransmit.Controls.Add(this.panel3);
            this.tpageTransmit.Location = new System.Drawing.Point(8, 50);
            this.tpageTransmit.Margin = new System.Windows.Forms.Padding(6);
            this.tpageTransmit.Name = "tpageTransmit";
            this.tpageTransmit.Padding = new System.Windows.Forms.Padding(6);
            this.tpageTransmit.Size = new System.Drawing.Size(1992, 814);
            this.tpageTransmit.TabIndex = 0;
            this.tpageTransmit.Text = "转发列表  ";
            this.tpageTransmit.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridTasks);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(6, 6);
            this.panel3.Margin = new System.Windows.Forms.Padding(6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1980, 802);
            this.panel3.TabIndex = 0;
            // 
            // gridTasks
            // 
            this.gridTasks.AllowUserToAddRows = false;
            this.gridTasks.AllowUserToDeleteRows = false;
            this.gridTasks.AutoGenerateColumns = false;
            this.gridTasks.BackgroundColor = System.Drawing.Color.White;
            this.gridTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRowNo,
            this.colContent,
            this.colFrom,
            this.colCommissionRate,
            this.colCoupon,
            this.colCreateTime});
            this.gridTasks.DataSource = this.bsTasks;
            this.gridTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTasks.Location = new System.Drawing.Point(0, 0);
            this.gridTasks.Margin = new System.Windows.Forms.Padding(6);
            this.gridTasks.Name = "gridTasks";
            this.gridTasks.ReadOnly = true;
            this.gridTasks.RowTemplate.Height = 23;
            this.gridTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTasks.Size = new System.Drawing.Size(1980, 802);
            this.gridTasks.TabIndex = 0;
            this.gridTasks.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridTasks_CellFormatting);
            this.gridTasks.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridTasks_CellMouseClick);
            // 
            // colRowNo
            // 
            this.colRowNo.DataPropertyName = "RowNo";
            this.colRowNo.HeaderText = "序号";
            this.colRowNo.Name = "colRowNo";
            this.colRowNo.ReadOnly = true;
            this.colRowNo.Width = 70;
            // 
            // colContent
            // 
            this.colContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colContent.DataPropertyName = "Content";
            this.colContent.FillWeight = 15.22843F;
            this.colContent.HeaderText = "转发内容";
            this.colContent.Name = "colContent";
            this.colContent.ReadOnly = true;
            // 
            // colFrom
            // 
            this.colFrom.DataPropertyName = "From";
            this.colFrom.HeaderText = "消息来自";
            this.colFrom.Name = "colFrom";
            this.colFrom.ReadOnly = true;
            // 
            // colCommissionRate
            // 
            this.colCommissionRate.DataPropertyName = "CommissionRate";
            this.colCommissionRate.HeaderText = "佣金比例";
            this.colCommissionRate.Name = "colCommissionRate";
            this.colCommissionRate.ReadOnly = true;
            // 
            // colCoupon
            // 
            this.colCoupon.DataPropertyName = "Coupon";
            this.colCoupon.HeaderText = "优惠券";
            this.colCoupon.Name = "colCoupon";
            this.colCoupon.ReadOnly = true;
            // 
            // colCreateTime
            // 
            this.colCreateTime.DataPropertyName = "CreateTime";
            this.colCreateTime.HeaderText = "添加时间";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.ReadOnly = true;
            this.colCreateTime.Width = 150;
            // 
            // tpageAddTask
            // 
            this.tpageAddTask.Controls.Add(this.panel5);
            this.tpageAddTask.Controls.Add(this.panel6);
            this.tpageAddTask.Location = new System.Drawing.Point(8, 50);
            this.tpageAddTask.Margin = new System.Windows.Forms.Padding(6);
            this.tpageAddTask.Name = "tpageAddTask";
            this.tpageAddTask.Padding = new System.Windows.Forms.Padding(6);
            this.tpageAddTask.Size = new System.Drawing.Size(1992, 810);
            this.tpageAddTask.TabIndex = 1;
            this.tpageAddTask.Text = "手动添加  ";
            this.tpageAddTask.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.wbTransmit);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(6, 6);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(1);
            this.panel5.Size = new System.Drawing.Size(1552, 798);
            this.panel5.TabIndex = 0;
            // 
            // wbTransmit
            // 
            this.wbTransmit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbTransmit.Location = new System.Drawing.Point(1, 1);
            this.wbTransmit.Margin = new System.Windows.Forms.Padding(6);
            this.wbTransmit.MinimumSize = new System.Drawing.Size(40, 37);
            this.wbTransmit.Name = "wbTransmit";
            this.wbTransmit.Size = new System.Drawing.Size(1550, 796);
            this.wbTransmit.TabIndex = 0;
            this.wbTransmit.Resize += new System.EventHandler(this.wbTransmit_Resize);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel6.Controls.Add(this.button7);
            this.panel6.Controls.Add(this.btnCopy);
            this.panel6.Controls.Add(this.btnAddTaskAtOnce);
            this.panel6.Controls.Add(this.btnAddTask);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1558, 6);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(428, 798);
            this.panel6.TabIndex = 1;
            // 
            // button7
            // 
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.Location = new System.Drawing.Point(54, 398);
            this.button7.Margin = new System.Windows.Forms.Padding(6);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(324, 85);
            this.button7.TabIndex = 6;
            this.button7.Text = "清空内容(&V)";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.Location = new System.Drawing.Point(54, 280);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(6);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(324, 85);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "转换复制(&C)";
            this.btnCopy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = true;
            // 
            // btnAddTaskAtOnce
            // 
            this.btnAddTaskAtOnce.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTaskAtOnce.Image")));
            this.btnAddTaskAtOnce.Location = new System.Drawing.Point(54, 166);
            this.btnAddTaskAtOnce.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddTaskAtOnce.Name = "btnAddTaskAtOnce";
            this.btnAddTaskAtOnce.Size = new System.Drawing.Size(324, 85);
            this.btnAddTaskAtOnce.TabIndex = 4;
            this.btnAddTaskAtOnce.Text = "立刻转发(&F)";
            this.btnAddTaskAtOnce.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddTaskAtOnce.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddTaskAtOnce.UseVisualStyleBackColor = true;
            this.btnAddTaskAtOnce.Click += new System.EventHandler(this.btnAddTaskAtOnce_Click);
            // 
            // btnAddTask
            // 
            this.btnAddTask.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTask.Image")));
            this.btnAddTask.Location = new System.Drawing.Point(54, 50);
            this.btnAddTask.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(324, 85);
            this.btnAddTask.TabIndex = 3;
            this.btnAddTask.Text = "添加任务(&D)";
            this.btnAddTask.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddTask.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkTransmit);
            this.panel1.Controls.Add(this.lnkMonitor);
            this.panel1.Controls.Add(this.lnkSetting);
            this.panel1.Controls.Add(this.lblAccount);
            this.panel1.Controls.Add(this.picAvatar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2008, 136);
            this.panel1.TabIndex = 0;
            // 
            // lnkTransmit
            // 
            this.lnkTransmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkTransmit.AutoSize = true;
            this.lnkTransmit.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkTransmit.LinkColor = System.Drawing.Color.DodgerBlue;
            this.lnkTransmit.Location = new System.Drawing.Point(1871, 68);
            this.lnkTransmit.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lnkTransmit.Name = "lnkTransmit";
            this.lnkTransmit.Size = new System.Drawing.Size(123, 35);
            this.lnkTransmit.TabIndex = 9;
            this.lnkTransmit.TabStop = true;
            this.lnkTransmit.Text = "启用转发";
            this.lnkTransmit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTransmit_LinkClicked);
            // 
            // lnkMonitor
            // 
            this.lnkMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkMonitor.AutoSize = true;
            this.lnkMonitor.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkMonitor.LinkColor = System.Drawing.Color.DodgerBlue;
            this.lnkMonitor.Location = new System.Drawing.Point(1732, 68);
            this.lnkMonitor.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lnkMonitor.Name = "lnkMonitor";
            this.lnkMonitor.Size = new System.Drawing.Size(123, 35);
            this.lnkMonitor.TabIndex = 9;
            this.lnkMonitor.TabStop = true;
            this.lnkMonitor.Text = "启用采集";
            this.lnkMonitor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMonitor_LinkClicked);
            // 
            // lnkSetting
            // 
            this.lnkSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkSetting.AutoSize = true;
            this.lnkSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkSetting.ImageList = this.imgList;
            this.lnkSetting.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkSetting.LinkColor = System.Drawing.Color.DodgerBlue;
            this.lnkSetting.Location = new System.Drawing.Point(1593, 68);
            this.lnkSetting.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lnkSetting.Name = "lnkSetting";
            this.lnkSetting.Size = new System.Drawing.Size(123, 35);
            this.lnkSetting.TabIndex = 9;
            this.lnkSetting.TabStop = true;
            this.lnkSetting.Text = "全局设置";
            this.lnkSetting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSetting_LinkClicked);
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(198, 46);
            this.lblAccount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(55, 35);
            this.lblAccount.TabIndex = 1;
            this.lblAccount.Text = "     ";
            // 
            // picAvatar
            // 
            this.picAvatar.Image = global::TaobaoKe.Forms.Properties.Resources.avatar;
            this.picAvatar.Location = new System.Drawing.Point(16, 15);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(6);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(112, 105);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStartAt,
            this.toolStripStatusLabel1,
            this.statusMonitor,
            this.statusTransmit,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1008);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(2008, 40);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusStartAt
            // 
            this.statusStartAt.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusStartAt.Name = "statusStartAt";
            this.statusStartAt.Size = new System.Drawing.Size(166, 35);
            this.statusStartAt.Text = "statusStartAt";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1342, 35);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // statusMonitor
            // 
            this.statusMonitor.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.statusMonitor.Name = "statusMonitor";
            this.statusMonitor.Size = new System.Drawing.Size(197, 35);
            this.statusMonitor.Text = "statusMonitor";
            // 
            // statusTransmit
            // 
            this.statusTransmit.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.statusTransmit.Name = "statusTransmit";
            this.statusTransmit.Size = new System.Drawing.Size(205, 35);
            this.statusTransmit.Text = "statusTransmit";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(21, 35);
            this.toolStripStatusLabel2.Text = " ";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 35F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2008, 1048);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.MinimumSize = new System.Drawing.Size(1908, 1010);
            this.Name = "FormMain";
            this.Text = "淘宝客";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.panel2.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tpageTransmit.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTasks)).EndInit();
            this.tpageAddTask.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tpageTransmit;
        private System.Windows.Forms.TabPage tpageAddTask;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView gridTasks;
        private System.Windows.Forms.LinkLabel lnkSetting;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnAddTaskAtOnce;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.BindingSource bsTasks;
        private System.Windows.Forms.WebBrowser wbTransmit;
        private System.Windows.Forms.Timer timerTransmit;
        private System.Windows.Forms.LinkLabel lnkTransmit;
        private System.Windows.Forms.LinkLabel lnkMonitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommissionRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoupon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateTime;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusMonitor;
        private System.Windows.Forms.ToolStripStatusLabel statusTransmit;
        private System.Windows.Forms.ToolStripStatusLabel statusStartAt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}

