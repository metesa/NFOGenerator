using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NFOGenerator
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Add items to general resolution comboBox and set default to 720p
            this.cmbGeneralResolution.Items.Add("1080p");
            this.cmbGeneralResolution.Items.Add("720p");
            this.cmbGeneralResolution.Items.Add("576p");
            this.cmbGeneralResolution.Items.Add("480p");
            this.cmbGeneralResolution.SelectedIndex = 1;

            // Add items to source type comboBox and set default to BluRay
            this.cmbSourceType.Items.Add("BluRay");
            this.cmbSourceType.Items.Add("HDDVD");
            this.cmbSourceType.Items.Add("DVDRip");
            this.cmbSourceType.Items.Add("WEB-DL");
            this.cmbSourceType.Items.Add("WEBRip");
            this.cmbSourceType.Items.Add("HDTV");
            this.cmbSourceType.SelectedIndex = 0;

            // Add items to source resolution comboBox and set default to 1080p
            this.cmbSourceResolution.Items.Add("4K");
            this.cmbSourceResolution.Items.Add("2160p");
            this.cmbSourceResolution.Items.Add("1080p");
            this.cmbSourceResolution.Items.Add("1080i");
            this.cmbSourceResolution.Items.Add("720p");
            this.cmbSourceResolution.Items.Add("720i");
            this.cmbSourceResolution.SelectedIndex = 2;

            // Add items to video framerate comboBox and set default to 23.976 FPS
            this.cmbVideoFramerate.Items.Add("23.976 FPS (24000/1001)");
            this.cmbVideoFramerate.Items.Add("24.000 FPS");
            this.cmbVideoFramerate.Items.Add("25.000 FPS");
            this.cmbVideoFramerate.Items.Add("29.97 FPS");
            this.cmbVideoFramerate.Items.Add("30.000 FPS");
            this.cmbVideoFramerate.Items.Add("50.000 FPS");
            this.cmbVideoFramerate.Items.Add("59.94 FPS");
            this.cmbVideoFramerate.Items.Add("60.000 FPS");
            this.cmbVideoFramerate.Items.Add("120.000 FPS");
            this.cmbVideoFramerate.SelectedIndex = 0;

            // Add items to video codec comboBox and set default to x264
            this.cmbVideoCodec.Items.Add("x264");
            this.cmbVideoCodec.Items.Add("H.264");
            this.cmbVideoCodec.Items.Add("x265");
            this.cmbVideoCodec.Items.Add("MPEG2");
            this.cmbVideoCodec.Items.Add("VC-1");
            this.cmbVideoCodec.Items.Add("AVC");
            this.cmbVideoCodec.Items.Add("XviD");
            this.cmbVideoCodec.SelectedIndex = 0;
        }

        private void btnGeneralGenerate_Click(object sender, EventArgs e)
        {
            
            // Enable process button after generating release name
            this.btnProcess.Enabled = true;
        }

        private void btnInputBrowse_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog openFileInput = new OpenFileDialog();
            openFileInput.Filter = "MKV files|*.mkv";
            openFileInput.Title = "Select an MKV File";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and a .MKV file was selected, open it.  
            if (openFileInput.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Send the file path to input file textBox  
                this.txtInputFile.Text = openFileInput.FileName;
            }
        }

        private void btnInputClear_Click(object sender, EventArgs e)
        {
            // Clear input file textBox
            this.txtInputFile.Text = "";
        }
    }
}
