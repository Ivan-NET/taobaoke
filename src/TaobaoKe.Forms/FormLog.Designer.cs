namespace TaobaoKe.Forms
{
    partial class FormLog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkTopMost = new System.Windows.Forms.CheckBox();
            this.cboxLevel = new System.Windows.Forms.ComboBox();
            this.gridLogs = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsLogs = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.chkTopMost);
            this.panel1.Controls.Add(this.cboxLevel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 954);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1752, 176);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1532, 42);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(197, 66);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // chkTopMost
            // 
            this.chkTopMost.AutoSize = true;
            this.chkTopMost.Location = new System.Drawing.Point(1277, 55);
            this.chkTopMost.Margin = new System.Windows.Forms.Padding(4);
            this.chkTopMost.Name = "chkTopMost";
            this.chkTopMost.Size = new System.Drawing.Size(209, 39);
            this.chkTopMost.TabIndex = 1;
            this.chkTopMost.Text = "保持窗口最前";
            this.chkTopMost.UseVisualStyleBackColor = true;
            // 
            // cboxLevel
            // 
            this.cboxLevel.FormattingEnabled = true;
            this.cboxLevel.Location = new System.Drawing.Point(56, 66);
            this.cboxLevel.Margin = new System.Windows.Forms.Padding(4);
            this.cboxLevel.Name = "cboxLevel";
            this.cboxLevel.Size = new System.Drawing.Size(160, 43);
            this.cboxLevel.TabIndex = 0;
            // 
            // gridLogs
            // 
            this.gridLogs.AllowUserToAddRows = false;
            this.gridLogs.AllowUserToDeleteRows = false;
            this.gridLogs.AutoGenerateColumns = false;
            this.gridLogs.BackgroundColor = System.Drawing.Color.White;
            this.gridLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colCreateTime,
            this.colType,
            this.colContent});
            this.gridLogs.DataSource = this.bsLogs;
            this.gridLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLogs.Location = new System.Drawing.Point(0, 0);
            this.gridLogs.Margin = new System.Windows.Forms.Padding(4);
            this.gridLogs.Name = "gridLogs";
            this.gridLogs.Size = new System.Drawing.Size(1752, 954);
            this.gridLogs.TabIndex = 1;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            // 
            // colCreateTime
            // 
            this.colCreateTime.DataPropertyName = "CreateTime";
            this.colCreateTime.HeaderText = "时间";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.Width = 200;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "Type";
            this.colType.HeaderText = "类型";
            this.colType.Name = "colType";
            this.colType.Width = 150;
            // 
            // colContent
            // 
            this.colContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colContent.DataPropertyName = "Content";
            this.colContent.HeaderText = "内容";
            this.colContent.Name = "colContent";
            // 
            // FormLog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1752, 1130);
            this.Controls.Add(this.gridLogs);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormLog";
            this.Text = "FormLog";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLog_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridLogs;
        private System.Windows.Forms.CheckBox chkTopMost;
        private System.Windows.Forms.ComboBox cboxLevel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContent;
        private System.Windows.Forms.BindingSource bsLogs;
    }
}