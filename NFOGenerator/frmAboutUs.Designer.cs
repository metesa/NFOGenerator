namespace NFOGenerator
{
    partial class frmAboutUs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAboutUs));
            this.picMain = new System.Windows.Forms.PictureBox();
            this.lblAboutInfo = new System.Windows.Forms.Label();
            this.btnHandTea = new System.Windows.Forms.Button();
            this.btnNotHandTea = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.SuspendLayout();
            // 
            // picMain
            // 
            this.picMain.Image = ((System.Drawing.Image)(resources.GetObject("picMain.Image")));
            this.picMain.InitialImage = null;
            this.picMain.Location = new System.Drawing.Point(12, 12);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(86, 92);
            this.picMain.TabIndex = 0;
            this.picMain.TabStop = false;
            // 
            // lblAboutInfo
            // 
            this.lblAboutInfo.AutoSize = true;
            this.lblAboutInfo.Location = new System.Drawing.Point(116, 21);
            this.lblAboutInfo.Name = "lblAboutInfo";
            this.lblAboutInfo.Size = new System.Drawing.Size(83, 12);
            this.lblAboutInfo.TabIndex = 1;
            this.lblAboutInfo.Text = "给m sysop递茶";
            // 
            // btnHandTea
            // 
            this.btnHandTea.Location = new System.Drawing.Point(118, 51);
            this.btnHandTea.Name = "btnHandTea";
            this.btnHandTea.Size = new System.Drawing.Size(81, 23);
            this.btnHandTea.TabIndex = 2;
            this.btnHandTea.Text = "递茶";
            this.btnHandTea.UseVisualStyleBackColor = true;
            // 
            // btnNotHandTea
            // 
            this.btnNotHandTea.Location = new System.Drawing.Point(118, 80);
            this.btnNotHandTea.Name = "btnNotHandTea";
            this.btnNotHandTea.Size = new System.Drawing.Size(81, 23);
            this.btnNotHandTea.TabIndex = 2;
            this.btnNotHandTea.Text = "不递";
            this.btnNotHandTea.UseVisualStyleBackColor = true;
            // 
            // frmAboutUs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 115);
            this.Controls.Add(this.btnNotHandTea);
            this.Controls.Add(this.btnHandTea);
            this.Controls.Add(this.lblAboutInfo);
            this.Controls.Add(this.picMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAboutUs";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ABOUT US";
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.Label lblAboutInfo;
        private System.Windows.Forms.Button btnHandTea;
        private System.Windows.Forms.Button btnNotHandTea;
    }
}