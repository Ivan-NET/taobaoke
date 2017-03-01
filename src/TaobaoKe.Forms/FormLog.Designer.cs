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
            this.bsLogs = new System.Windows.Forms.BindingSource(this.components);
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.Location = new System.Drawing.Point(0, 798);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1286, 119);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1112, 38);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(147, 50);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkTopMost
            // 
            this.chkTopMost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTopMost.AutoSize = true;
            this.chkTopMost.Location = new System.Drawing.Point(893, 50);
            this.chkTopMost.Margin = new System.Windows.Forms.Padding(4);
            this.chkTopMost.Name = "chkTopMost";
            this.chkTopMost.Size = new System.Drawing.Size(186, 28);
            this.chkTopMost.TabIndex = 1;
            this.chkTopMost.Text = "保持窗口最前";
            this.chkTopMost.UseVisualStyleBackColor = true;
            this.chkTopMost.CheckedChanged += new System.EventHandler(this.chkTopMost_CheckedChanged);
            // 
            // cboxLevel
            // 
            this.cboxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxLevel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboxLevel.FormattingEnabled = true;
            this.cboxLevel.Location = new System.Drawing.Point(23, 39);
            this.cboxLevel.Margin = new System.Windows.Forms.Padding(4);
            this.cboxLevel.Name = "cboxLevel";
            this.cboxLevel.Size = new System.Drawing.Size(214, 39);
            this.cboxLevel.TabIndex = 0;
            this.cboxLevel.SelectedIndexChanged += new System.EventHandler(this.cboxLevel_SelectedIndexChanged);
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
            this.gridLogs.MultiSelect = false;
            this.gridLogs.Name = "gridLogs";
            this.gridLogs.ReadOnly = true;
            this.gridLogs.RowHeadersVisible = false;
            this.gridLogs.Size = new System.Drawing.Size(1286, 798);
            this.gridLogs.TabIndex = 1;
            this.gridLogs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridLogs_CellFormatting);
            this.gridLogs.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.gridLogs_RowPrePaint);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 40;
            // 
            // colCreateTime
            // 
            this.colCreateTime.DataPropertyName = "CreateTime";
            this.colCreateTime.HeaderText = "时间";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.ReadOnly = true;
            this.colCreateTime.Width = 120;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "TypeName";
            this.colType.HeaderText = "类型";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 60;
            // 
            // colContent
            // 
            this.colContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colContent.DataPropertyName = "Content";
            this.colContent.HeaderText = "内容";
            this.colContent.Name = "colContent";
            this.colContent.ReadOnly = true;
            // 
            // FormLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 917);
            this.Controls.Add(this.gridLogs);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormLog";
            this.Text = "FormLog";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLog_FormClosed);
            this.Shown += new System.EventHandler(this.FormLog_Shown);
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
        private System.Windows.Forms.BindingSource bsLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContent;
    }
}