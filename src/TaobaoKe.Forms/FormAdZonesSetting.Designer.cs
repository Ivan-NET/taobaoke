namespace TaobaoKe.Forms
{
    partial class FormAdZonesSetting
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
            this.gridAdZones = new System.Windows.Forms.DataGridView();
            this.bsAdZones = new System.Windows.Forms.BindingSource(this.components);
            this.colQQGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdZoneId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridAdZones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAdZones)).BeginInit();
            this.SuspendLayout();
            // 
            // gridAdZones
            // 
            this.gridAdZones.AllowUserToAddRows = false;
            this.gridAdZones.AutoGenerateColumns = false;
            this.gridAdZones.BackgroundColor = System.Drawing.Color.White;
            this.gridAdZones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAdZones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colQQGroupName,
            this.colAdZoneId});
            this.gridAdZones.DataSource = this.bsAdZones;
            this.gridAdZones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAdZones.Location = new System.Drawing.Point(0, 0);
            this.gridAdZones.Margin = new System.Windows.Forms.Padding(6);
            this.gridAdZones.Name = "gridAdZones";
            this.gridAdZones.RowTemplate.Height = 23;
            this.gridAdZones.Size = new System.Drawing.Size(868, 481);
            this.gridAdZones.TabIndex = 0;
            // 
            // colQQGroupName
            // 
            this.colQQGroupName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colQQGroupName.DataPropertyName = "QQGroupName";
            this.colQQGroupName.FillWeight = 34F;
            this.colQQGroupName.HeaderText = "群名称";
            this.colQQGroupName.Name = "colQQGroupName";
            this.colQQGroupName.ReadOnly = true;
            // 
            // colAdZoneId
            // 
            this.colAdZoneId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAdZoneId.DataPropertyName = "AdZoneId";
            this.colAdZoneId.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colAdZoneId.FillWeight = 33F;
            this.colAdZoneId.HeaderText = "推广位";
            this.colAdZoneId.Name = "colAdZoneId";
            this.colAdZoneId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAdZoneId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FormAdZonesSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 35F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 481);
            this.Controls.Add(this.gridAdZones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.MinimumSize = new System.Drawing.Size(874, 493);
            this.Name = "FormAdZonesSetting";
            this.Text = "多推广位设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdZonesSetting_FormClosing);
            this.Load += new System.EventHandler(this.FormAdZonesSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridAdZones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAdZones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridAdZones;
        private System.Windows.Forms.BindingSource bsAdZones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQQGroupName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colAdZoneId;
    }
}