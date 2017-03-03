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
            this.btnUrlTrans = new System.Windows.Forms.Button();
            this.btnAddTaskAtOnce = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.tpagePaymentDetails = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colOrderCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPaymentDetails = new System.Windows.Forms.BindingSource(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.timeTo = new System.Windows.Forms.DateTimePicker();
            this.timeFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxShortcutTimes = new System.Windows.Forms.ComboBox();
            this.cboxQueryType = new System.Windows.Forms.ComboBox();
            this.cboxPayStatus = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkTransmit = new System.Windows.Forms.LinkLabel();
            this.lnkMonitor = new System.Windows.Forms.LinkLabel();
            this.lnkSetting = new System.Windows.Forms.LinkLabel();
            this.lblAccount = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusStartAt = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusShowLog = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.tpagePaymentDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPaymentDetails)).BeginInit();
            this.panel4.SuspendLayout();
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
            this.panel2.Location = new System.Drawing.Point(0, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1004, 469);
            this.panel2.TabIndex = 1;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tpageTransmit);
            this.tabMain.Controls.Add(this.tpageAddTask);
            this.tabMain.Controls.Add(this.tpagePaymentDetails);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.ImageList = this.imgList;
            this.tabMain.ItemSize = new System.Drawing.Size(118, 42);
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1004, 469);
            this.tabMain.TabIndex = 0;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tpageTransmit
            // 
            this.tpageTransmit.Controls.Add(this.panel3);
            this.tpageTransmit.Location = new System.Drawing.Point(4, 46);
            this.tpageTransmit.Name = "tpageTransmit";
            this.tpageTransmit.Padding = new System.Windows.Forms.Padding(3);
            this.tpageTransmit.Size = new System.Drawing.Size(996, 419);
            this.tpageTransmit.TabIndex = 0;
            this.tpageTransmit.Text = "转发列表  ";
            this.tpageTransmit.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridTasks);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(990, 413);
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
            this.gridTasks.Name = "gridTasks";
            this.gridTasks.ReadOnly = true;
            this.gridTasks.RowTemplate.Height = 23;
            this.gridTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTasks.Size = new System.Drawing.Size(990, 413);
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
            this.tpageAddTask.Location = new System.Drawing.Point(4, 46);
            this.tpageAddTask.Name = "tpageAddTask";
            this.tpageAddTask.Padding = new System.Windows.Forms.Padding(3);
            this.tpageAddTask.Size = new System.Drawing.Size(996, 419);
            this.tpageAddTask.TabIndex = 1;
            this.tpageAddTask.Text = "手动添加  ";
            this.tpageAddTask.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.wbTransmit);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.panel5.Size = new System.Drawing.Size(776, 413);
            this.panel5.TabIndex = 0;
            // 
            // wbTransmit
            // 
            this.wbTransmit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbTransmit.Location = new System.Drawing.Point(0, 1);
            this.wbTransmit.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbTransmit.Name = "wbTransmit";
            this.wbTransmit.Size = new System.Drawing.Size(776, 411);
            this.wbTransmit.TabIndex = 0;
            this.wbTransmit.Resize += new System.EventHandler(this.wbTransmit_Resize);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel6.Controls.Add(this.button7);
            this.panel6.Controls.Add(this.btnUrlTrans);
            this.panel6.Controls.Add(this.btnAddTaskAtOnce);
            this.panel6.Controls.Add(this.btnAddTask);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(779, 3);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(214, 413);
            this.panel6.TabIndex = 1;
            // 
            // button7
            // 
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.Location = new System.Drawing.Point(27, 216);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(162, 46);
            this.button7.TabIndex = 6;
            this.button7.Text = "清空内容(&V)";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // btnUrlTrans
            // 
            this.btnUrlTrans.Image = ((System.Drawing.Image)(resources.GetObject("btnUrlTrans.Image")));
            this.btnUrlTrans.Location = new System.Drawing.Point(27, 30);
            this.btnUrlTrans.Name = "btnUrlTrans";
            this.btnUrlTrans.Size = new System.Drawing.Size(162, 46);
            this.btnUrlTrans.TabIndex = 5;
            this.btnUrlTrans.Text = "转换链接(&C)";
            this.btnUrlTrans.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUrlTrans.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUrlTrans.UseVisualStyleBackColor = true;
            this.btnUrlTrans.Click += new System.EventHandler(this.btnUrlTrans_Click);
            // 
            // btnAddTaskAtOnce
            // 
            this.btnAddTaskAtOnce.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTaskAtOnce.Image")));
            this.btnAddTaskAtOnce.Location = new System.Drawing.Point(27, 154);
            this.btnAddTaskAtOnce.Name = "btnAddTaskAtOnce";
            this.btnAddTaskAtOnce.Size = new System.Drawing.Size(162, 46);
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
            this.btnAddTask.Location = new System.Drawing.Point(27, 92);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(162, 46);
            this.btnAddTask.TabIndex = 3;
            this.btnAddTask.Text = "添加任务(&D)";
            this.btnAddTask.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddTask.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // tpagePaymentDetails
            // 
            this.tpagePaymentDetails.Controls.Add(this.dataGridView1);
            this.tpagePaymentDetails.Controls.Add(this.panel4);
            this.tpagePaymentDetails.Location = new System.Drawing.Point(4, 46);
            this.tpagePaymentDetails.Margin = new System.Windows.Forms.Padding(2);
            this.tpagePaymentDetails.Name = "tpagePaymentDetails";
            this.tpagePaymentDetails.Padding = new System.Windows.Forms.Padding(2);
            this.tpagePaymentDetails.Size = new System.Drawing.Size(996, 419);
            this.tpagePaymentDetails.TabIndex = 2;
            this.tpagePaymentDetails.Text = "订单明细  ";
            this.tpagePaymentDetails.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderCreateTime,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dataGridView1.DataSource = this.bsPaymentDetails;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(2, 56);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 37;
            this.dataGridView1.Size = new System.Drawing.Size(992, 361);
            this.dataGridView1.TabIndex = 1;
            // 
            // colOrderCreateTime
            // 
            this.colOrderCreateTime.DataPropertyName = "CreateTime";
            this.colOrderCreateTime.HeaderText = "创建时间";
            this.colOrderCreateTime.Name = "colOrderCreateTime";
            this.colOrderCreateTime.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "AuctionInfo";
            this.Column1.HeaderText = "商品信息";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "PayStatus";
            this.Column2.HeaderText = "订单状态";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "DiscountAndSubsidyToString";
            this.Column3.HeaderText = "收入比率";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ShareRate";
            this.Column4.HeaderText = "分成比率";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "RealPayFeeString";
            this.Column5.HeaderText = "付款金额";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "PubShareFeeString";
            this.Column6.HeaderText = "效果预估";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "EarningTime";
            this.Column7.HeaderText = "结算时间";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "TotalAlipayFeeString";
            this.Column8.HeaderText = "结算金额";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "FeeString";
            this.Column9.HeaderText = "预估收入";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "TerminalType";
            this.Column10.HeaderText = "成交平台";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.timeTo);
            this.panel4.Controls.Add(this.timeFrom);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.cboxShortcutTimes);
            this.panel4.Controls.Add(this.cboxQueryType);
            this.panel4.Controls.Add(this.cboxPayStatus);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(2, 2);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(992, 54);
            this.panel4.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Image = global::TaobaoKe.Forms.Properties.Resources.download;
            this.button1.Location = new System.Drawing.Point(944, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 30);
            this.button1.TabIndex = 3;
            this.button1.Tag = "下载报表";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // timeTo
            // 
            this.timeTo.Location = new System.Drawing.Point(386, 16);
            this.timeTo.Margin = new System.Windows.Forms.Padding(2);
            this.timeTo.Name = "timeTo";
            this.timeTo.Size = new System.Drawing.Size(128, 25);
            this.timeTo.TabIndex = 2;
            // 
            // timeFrom
            // 
            this.timeFrom.Location = new System.Drawing.Point(230, 16);
            this.timeFrom.Margin = new System.Windows.Forms.Padding(2);
            this.timeFrom.Name = "timeFrom";
            this.timeFrom.Size = new System.Drawing.Size(128, 25);
            this.timeFrom.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "至";
            // 
            // cboxShortcutTimes
            // 
            this.cboxShortcutTimes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboxShortcutTimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxShortcutTimes.FormattingEnabled = true;
            this.cboxShortcutTimes.Location = new System.Drawing.Point(518, 16);
            this.cboxShortcutTimes.Margin = new System.Windows.Forms.Padding(2);
            this.cboxShortcutTimes.Name = "cboxShortcutTimes";
            this.cboxShortcutTimes.Size = new System.Drawing.Size(106, 26);
            this.cboxShortcutTimes.TabIndex = 0;
            this.cboxShortcutTimes.SelectedIndexChanged += new System.EventHandler(this.cboxShortcutTimes_SelectedIndexChanged);
            // 
            // cboxQueryType
            // 
            this.cboxQueryType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboxQueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxQueryType.FormattingEnabled = true;
            this.cboxQueryType.Location = new System.Drawing.Point(120, 16);
            this.cboxQueryType.Margin = new System.Windows.Forms.Padding(2);
            this.cboxQueryType.Name = "cboxQueryType";
            this.cboxQueryType.Size = new System.Drawing.Size(106, 26);
            this.cboxQueryType.TabIndex = 0;
            this.cboxQueryType.SelectedIndexChanged += new System.EventHandler(this.cboxQueryType_SelectedIndexChanged);
            // 
            // cboxPayStatus
            // 
            this.cboxPayStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboxPayStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPayStatus.FormattingEnabled = true;
            this.cboxPayStatus.Location = new System.Drawing.Point(10, 16);
            this.cboxPayStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cboxPayStatus.Name = "cboxPayStatus";
            this.cboxPayStatus.Size = new System.Drawing.Size(106, 26);
            this.cboxPayStatus.TabIndex = 0;
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 74);
            this.panel1.TabIndex = 0;
            // 
            // lnkTransmit
            // 
            this.lnkTransmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkTransmit.AutoSize = true;
            this.lnkTransmit.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkTransmit.LinkColor = System.Drawing.Color.DodgerBlue;
            this.lnkTransmit.Location = new System.Drawing.Point(936, 37);
            this.lnkTransmit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkTransmit.Name = "lnkTransmit";
            this.lnkTransmit.Size = new System.Drawing.Size(65, 20);
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
            this.lnkMonitor.Location = new System.Drawing.Point(866, 37);
            this.lnkMonitor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkMonitor.Name = "lnkMonitor";
            this.lnkMonitor.Size = new System.Drawing.Size(65, 20);
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
            this.lnkSetting.Location = new System.Drawing.Point(796, 37);
            this.lnkSetting.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkSetting.Name = "lnkSetting";
            this.lnkSetting.Size = new System.Drawing.Size(65, 20);
            this.lnkSetting.TabIndex = 9;
            this.lnkSetting.TabStop = true;
            this.lnkSetting.Text = "全局设置";
            this.lnkSetting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSetting_LinkClicked);
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(99, 25);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(29, 20);
            this.lblAccount.TabIndex = 1;
            this.lblAccount.Text = "     ";
            // 
            // picAvatar
            // 
            this.picAvatar.Image = global::TaobaoKe.Forms.Properties.Resources.avatar;
            this.picAvatar.Location = new System.Drawing.Point(8, 8);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(56, 57);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStartAt,
            this.statusShowLog,
            this.toolStripStatusLabel1,
            this.statusMonitor,
            this.statusTransmit,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 543);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1004, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusStartAt
            // 
            this.statusStartAt.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusStartAt.Name = "statusStartAt";
            this.statusStartAt.Size = new System.Drawing.Size(85, 21);
            this.statusStartAt.Text = "statusStartAt";
            // 
            // statusShowLog
            // 
            this.statusShowLog.IsLink = true;
            this.statusShowLog.Name = "statusShowLog";
            this.statusShowLog.Size = new System.Drawing.Size(56, 21);
            this.statusShowLog.Text = "查看日志";
            this.statusShowLog.Click += new System.EventHandler(this.statusShowLog_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(635, 21);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // statusMonitor
            // 
            this.statusMonitor.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.statusMonitor.Name = "statusMonitor";
            this.statusMonitor.Size = new System.Drawing.Size(103, 21);
            this.statusMonitor.Text = "statusMonitor";
            // 
            // statusTransmit
            // 
            this.statusTransmit.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.statusTransmit.Name = "statusTransmit";
            this.statusTransmit.Size = new System.Drawing.Size(106, 21);
            this.statusTransmit.Text = "statusTransmit";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(12, 21);
            this.toolStripStatusLabel2.Text = " ";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 569);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(962, 566);
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
            this.tpagePaymentDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPaymentDetails)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
        private System.Windows.Forms.Button btnUrlTrans;
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
        private System.Windows.Forms.ToolStripStatusLabel statusShowLog;
        private System.Windows.Forms.TabPage tpagePaymentDetails;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cboxPayStatus;
        private System.Windows.Forms.DateTimePicker timeTo;
        private System.Windows.Forms.DateTimePicker timeFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxQueryType;
        private System.Windows.Forms.ComboBox cboxShortcutTimes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.BindingSource bsPaymentDetails;
    }
}

