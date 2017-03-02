namespace NFOGenerator.Forms
{
    partial class FrmZones
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
            this.dgvZonesRanges = new System.Windows.Forms.DataGridView();
            this.txtZonesCommand = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZonesRanges)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvZonesRanges
            // 
            this.dgvZonesRanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvZonesRanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZonesRanges.Location = new System.Drawing.Point(12, 12);
            this.dgvZonesRanges.Name = "dgvZonesRanges";
            this.dgvZonesRanges.RowTemplate.Height = 23;
            this.dgvZonesRanges.Size = new System.Drawing.Size(576, 298);
            this.dgvZonesRanges.TabIndex = 0;
            // 
            // txtZonesCommand
            // 
            this.txtZonesCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZonesCommand.Location = new System.Drawing.Point(12, 417);
            this.txtZonesCommand.Multiline = true;
            this.txtZonesCommand.Name = "txtZonesCommand";
            this.txtZonesCommand.Size = new System.Drawing.Size(576, 86);
            this.txtZonesCommand.TabIndex = 1;
            // 
            // FrmZones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 515);
            this.Controls.Add(this.txtZonesCommand);
            this.Controls.Add(this.dgvZonesRanges);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmZones";
            this.ShowInTaskbar = false;
            this.Text = "Zones Command";
            ((System.ComponentModel.ISupportInitialize)(this.dgvZonesRanges)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvZonesRanges;
        private System.Windows.Forms.TextBox txtZonesCommand;
    }
}