using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            // Add items to general year comboBox and set default to current year
            int currentYear = DateTime.Now.Year;
            while (currentYear >= 1900)
            {
                this.cmbGeneralYear.Items.Add(currentYear);
                currentYear -= 1;
            }
            this.cmbGeneralYear.SelectedIndex = 0;
            
            // Add items to general edition comboBox and set default to blank
            this.cmbGeneralEdition.Items.Add("(Blank)");
            this.cmbGeneralEdition.Items.Add("Theatrical Cut");
            this.cmbGeneralEdition.Items.Add("Director's Cut");
            this.cmbGeneralEdition.Items.Add("Extended Cut");
            this.cmbGeneralEdition.Items.Add("Unrated");
            this.cmbGeneralEdition.Items.Add("Criterion");
            this.cmbGeneralEdition.SelectedIndex = 0;
            
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
            // Displays an OpenFileDialog so the user can select an MKV.  
            OpenFileDialog openFileInput = new OpenFileDialog();
            openFileInput.Filter = "MKV files|*.mkv";
            openFileInput.Title = "Select an MKV File";

            // Show the dialog.  
            // If the user clicked OK in the dialog and a .MKV file was selected,
            //  send the file path to input file textBox.
            if (openFileInput.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtInputFile.Text = openFileInput.FileName;
            }
        }

        private void btnInputClear_Click(object sender, EventArgs e)
        {
            // Clear input file textBox
            this.clearTextBox(this.txtInputFile);
        }

        private void btnTargetBrowse_Click(object sender, EventArgs e)
        {
            // Displays a FolderBrowserDialog so the user can select a location to put the NFO
            FolderBrowserDialog selectTargetLocation = new FolderBrowserDialog();
            
            // Show the dialog.
            // When the user selected a folder, send the location to target location textBox.
            if (selectTargetLocation.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtTargetLocation.Text = selectTargetLocation.SelectedPath;
            }
        }

        private void txtInputFile_TextChanged(object sender, EventArgs e)
        {
            // Do nothing if the input file is empty.
            if (this.txtInputFile.Text == "")
            {
                this.clearTextBox(this.txtGeneralSize);
                return;
            }
            
            // Get the file size of the selected media file.
            string inputFile = this.txtInputFile.Text;
            FileInfo inputFileInfo = new FileInfo(inputFile);
            if (!inputFileInfo.Exists)
            {
                // Show an error message if the selected file doesn't exist.
                this.showErrorMessage("File doesn't exist!");
                this.clearTextBox(this.txtGeneralSize);
            }
            else if (inputFileInfo.Extension != ".mkv")
            {
                // Show an error message if the selected file isn't an MKV file.
                this.showErrorMessage(inputFileInfo.Extension);
                this.clearTextBox(this.txtGeneralSize);
            }
            else
            {
                // Calculate the file size.
                long fileSizeBytes = inputFileInfo.Length;
                double fileSizeMBytes;
                double fileSizeGBytes;
                fileSizeMBytes = Convert.ToDouble(fileSizeBytes) / (1024 * 1024);
                fileSizeGBytes = fileSizeMBytes / 1024;
                if (fileSizeGBytes < 1)
                {
                    this.txtGeneralSize.Text = Math.Round(fileSizeMBytes, 2).ToString() + " MB";
                }
                else
                {
                    this.txtGeneralSize.Text = Math.Round(fileSizeGBytes, 2).ToString() + " GB";
                }
            }
        }

        /*-------------------------------------------------------------------------
         * Private custom methods down below
         * ------------------------------------------------------------------------*/

        // Used for showing an error message
        private void showErrorMessage(string errorInfo)
        {
            System.Windows.Forms.MessageBox.Show(errorInfo, "ERROR!");
        }

        private void clearTextBox(TextBox boxToClear)
        {
            boxToClear.Text = "";
        }
    }
}
