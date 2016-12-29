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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAccount = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransmitContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnStartMonitor = new System.Windows.Forms.Button();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.btnMonitorSetting = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblAccount);
            this.panel1.Controls.Add(this.picAvatar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1042, 100);
            this.panel1.TabIndex = 0;
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
            this.picAvatar.Location = new System.Drawing.Point(27, 25);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(56, 57);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1042, 590);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imgList;
            this.tabControl1.ItemSize = new System.Drawing.Size(118, 32);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1042, 590);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 36);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1034, 550);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "监控模式(&M)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1028, 464);
            this.panel3.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRowNo,
            this.colTransmitContent,
            this.colFrom,
            this.colCreateTime,
            this.colStatus});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1028, 464);
            this.dataGridView1.TabIndex = 0;
            // 
            // colRowNo
            // 
            this.colRowNo.HeaderText = "序号";
            this.colRowNo.Name = "colRowNo";
            // 
            // colTransmitContent
            // 
            this.colTransmitContent.HeaderText = "转发内容";
            this.colTransmitContent.Name = "colTransmitContent";
            // 
            // colFrom
            // 
            this.colFrom.HeaderText = "消息来自";
            this.colFrom.Name = "colFrom";
            // 
            // colCreateTime
            // 
            this.colCreateTime.HeaderText = "添加时间";
            this.colCreateTime.Name = "colCreateTime";
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "转发状态";
            this.colStatus.Name = "colStatus";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnStartMonitor);
            this.panel4.Controls.Add(this.btnMonitorSetting);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 467);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1028, 80);
            this.panel4.TabIndex = 0;
            // 
            // btnStartMonitor
            // 
            this.btnStartMonitor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartMonitor.ImageIndex = 3;
            this.btnStartMonitor.ImageList = this.imgList;
            this.btnStartMonitor.Location = new System.Drawing.Point(741, 23);
            this.btnStartMonitor.Name = "btnStartMonitor";
            this.btnStartMonitor.Size = new System.Drawing.Size(125, 38);
            this.btnStartMonitor.TabIndex = 1;
            this.btnStartMonitor.Text = "启动监控/转发";
            this.btnStartMonitor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartMonitor.UseVisualStyleBackColor = true;
            this.btnStartMonitor.Click += new System.EventHandler(this.btnStartMonitor_Click);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "monitor.png");
            this.imgList.Images.SetKeyName(1, "qq-group.png");
            this.imgList.Images.SetKeyName(2, "setting.png");
            this.imgList.Images.SetKeyName(3, "start.png");
            // 
            // btnMonitorSetting
            // 
            this.btnMonitorSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMonitorSetting.ImageIndex = 2;
            this.btnMonitorSetting.ImageList = this.imgList;
            this.btnMonitorSetting.Location = new System.Drawing.Point(882, 23);
            this.btnMonitorSetting.Name = "btnMonitorSetting";
            this.btnMonitorSetting.Size = new System.Drawing.Size(125, 38);
            this.btnMonitorSetting.TabIndex = 0;
            this.btnMonitorSetting.Text = "监控/转发设置";
            this.btnMonitorSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMonitorSetting.UseVisualStyleBackColor = true;
            this.btnMonitorSetting.Click += new System.EventHandler(this.btnMonitorSetting_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 36);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1034, 550);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "群发模式(&G)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 690);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.Text = "淘宝客";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransmitContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnStartMonitor;
        private System.Windows.Forms.Button btnMonitorSetting;
    }
}

