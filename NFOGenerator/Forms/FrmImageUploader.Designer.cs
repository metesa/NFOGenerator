namespace NFOGenerator.Forms
{
    partial class FrmImageUploader
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
            this.lblImagesToUpload = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblImagesToUpload
            // 
            this.lblImagesToUpload.AutoSize = true;
            this.lblImagesToUpload.Location = new System.Drawing.Point(13, 13);
            this.lblImagesToUpload.Name = "lblImagesToUpload";
            this.lblImagesToUpload.Size = new System.Drawing.Size(107, 12);
            this.lblImagesToUpload.TabIndex = 0;
            this.lblImagesToUpload.Text = "Images to upload:";
            // 
            // FrmImageUploader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 582);
            this.Controls.Add(this.lblImagesToUpload);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImageUploader";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Image Uploader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblImagesToUpload;


    }
}