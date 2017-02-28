using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MediaInfoLib;

namespace NFOGenerator.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /*-------------------------------------------------------------------------
         * Private custom methods down below
         * ------------------------------------------------------------------------*/

        // Show an error message.
        private void showErrorMessage(string errorInfo)
        {
            System.Windows.Forms.MessageBox.Show(errorInfo, "ERROR!");
        }

        // Clear a textBox.
        private void clearTextBox(TextBox boxToClear)
        {
            boxToClear.Text = "";
        }

        // Decide which unit to display, such as MB or GB, Kbps or Mbps, etc.
        private string getDisplayUnit(double paraSmall, double paraBig, string unitSmall, string unitBig, int decimals)
        {
            string result;
            if (paraBig < 1)
            {
                result = Math.Round(paraSmall, decimals).ToString() + " " + unitSmall;
            }
            else
            {
                result = Math.Round(paraBig, decimals).ToString() + " " + unitBig;
            }
            return result;
        }

        private string getDisplayUnit(double paraSmall, double paraBig, double criteria, string unitSmall, string unitBig,
            int decimalSmall, int decimalBig)
        {
            string result;
            if (paraSmall < criteria)
            {
                result = Math.Round(paraSmall, decimalSmall).ToString() + " " + unitSmall;
            }
            else
            {
                result = Math.Round(paraBig, decimalBig).ToString() + " " + unitBig;
            }
            return result;
        }
        
        // Get the size of the selected file.
        private string getFileSize(string paraFileSize)
        {
            // Calculate the file size.
            Int64 fileSizeBytes = Convert.ToInt64(paraFileSize);
            double fileSizeMBytes;
            double fileSizeGBytes;
            string result;
            
            // Display the file size in proper format. If it's smaller than 1GB, then display it in MB.
            // Otherwise, display it in GB.
            fileSizeMBytes = Convert.ToDouble(fileSizeBytes) / (1024 * 1024);
            fileSizeGBytes = fileSizeMBytes / 1024;
            result = this.getDisplayUnit(fileSizeMBytes, fileSizeGBytes, "MB", "GB", 2);
            return result;
        }

        // Calculate the duration.
        private string getDuration(string paraDuration)
        {
            Int64 durationMilliSecond = Convert.ToInt64(paraDuration);
            string result;
            DateTime duration = new DateTime(durationMilliSecond * 10000);
            result = duration.ToString("HH") + "h " + duration.ToString("mm") + "mn " + duration.ToString("ss") + "s";
            return result;
        }

        // Calculate the video bitrate.
        private string getVideoBitrate(string paraBitrate)
        {
            string result;
            Int32 bitrate = Convert.ToInt32(paraBitrate);
            double bitrateKbps = bitrate / 1000;
            double bitrateMbps = bitrateKbps / 1000;
            result = this.getDisplayUnit(bitrateKbps, bitrateMbps, 10000, "Kbps", "Mbps", 0, 1);
            return result;
        }

        /*-------------------------------------------------------------------------
         * Private custom methods up above
         * ------------------------------------------------------------------------*/

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Initialize form.

            // Add items to general year comboBox and set default to current year
            int currentYear = DateTime.Now.Year;
            while (currentYear >= 1900)
            {
                this.cmbGeneralYear.Items.Add(currentYear);
                currentYear -= 1;
            }
            this.cmbGeneralYear.SelectedIndex = 0;
            
            // Add items to general edition comboBox and set default to blank
            this.cmbGeneralEdition.Items.Add("");
            this.cmbGeneralEdition.Items.Add("Theatrical.Cut");
            this.cmbGeneralEdition.Items.Add("Director's.Cut");
            this.cmbGeneralEdition.Items.Add("Extended.Cut");
            this.cmbGeneralEdition.Items.Add("Unrated");
            this.cmbGeneralEdition.Items.Add("Criterion");
            this.cmbGeneralEdition.SelectedIndex = 0;
            
            // Add items to general resolution comboBox and set default to 720p
            this.cmbGeneralResolution.Items.Add("1080p");
            this.cmbGeneralResolution.Items.Add("720p");
            this.cmbGeneralResolution.Items.Add("576p");
            this.cmbGeneralResolution.Items.Add("480p");
            this.cmbGeneralResolution.SelectedIndex = 1;

            // Add items to general hybrid comboBox and set default to no
            this.cmbGeneralHybrid.Items.Add("");
            this.cmbGeneralHybrid.Items.Add("Hybrid");
            this.cmbGeneralHybrid.SelectedIndex = 0;

            // Add items to general proper comboBox and set default to blank
            this.cmbGeneralProper.Items.Add("");
            this.cmbGeneralProper.Items.Add("PROPER");
            this.cmbGeneralProper.Items.Add("REPACK");
            this.cmbGeneralProper.Items.Add("PROPER.REPACK");
            this.cmbGeneralProper.Items.Add("REPACK.PROPER");
            this.cmbGeneralProper.SelectedIndex = 0;

            // Add items to general audio comboBox and set default to DTS
            this.cmbGeneralAudio.Items.Add("DTS");
            this.cmbGeneralAudio.Items.Add("DTS-ES");
            this.cmbGeneralAudio.Items.Add("DD5.1");
            this.cmbGeneralAudio.Items.Add("AAC2.0");
            this.cmbGeneralAudio.Items.Add("AAC1.0");
            this.cmbGeneralAudio.Items.Add("FLAC2.0");
            this.cmbGeneralAudio.Items.Add("FLAC1.0");
            this.cmbGeneralAudio.SelectedIndex = 0;

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
            // Create a new releaseInfo class
            NFOGenerator.ReleaseInfo anotherRelease = new NFOGenerator.ReleaseInfo(this.txtGeneralTitle.Text,
                this.cmbGeneralYear.SelectedItem.ToString(), this.cmbGeneralEdition.Text, this.cmbGeneralHybrid.Text,
                this.cmbGeneralProper.Text, this.cmbGeneralResolution.Text, this.cmbSourceType.Text,
                this.cmbGeneralAudio.Text, this.cmbVideoCodec.Text);

            // Generate the release name
            this.txtGeneralReleaseName.Text = anotherRelease.generateRLZName();
            
            // Enable process button after generating release name
            this.btnProcess.Enabled = true;
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
                this.clearTextBox(this.txtGeneralDuration);

                this.clearTextBox(this.txtVideoWidth);
                this.clearTextBox(this.txtVideoHeight);
                this.clearTextBox(this.txtVideoDAR);
                this.clearTextBox(this.txtVideoFramerate);
                this.clearTextBox(this.txtVideoBitrate);
                return;
            }

            // Read info from MediaInfo and fill in corresponding texBoxes
            MediaInfo MI = new MediaInfo();
            MI.Open(this.txtInputFile.Text);
            this.txtGeneralSize.Text = this.getFileSize(MI.Get(StreamKind.General, 0, "FileSize"));
            this.txtGeneralDuration.Text = this.getDuration(MI.Get(StreamKind.General, 0, "Duration"));

            // Get video info.
            this.txtVideoWidth.Text = MI.Get(StreamKind.Video, 0, "Width");
            this.txtVideoHeight.Text = MI.Get(StreamKind.Video, 0, "Height");
            this.txtVideoDAR.Text = MI.Get(StreamKind.Video, 0, "DisplayAspectRatio");
            this.txtVideoFramerate.Text = MI.Get(StreamKind.Video, 0, "FrameRate") + " FPS";
            this.txtVideoBitrate.Text = this.getVideoBitrate(MI.Get(StreamKind.Video, 0, "BitRate"));
        }

        private void mnsHelpAboutUs_Click(object sender, EventArgs e)
        {
            frmAboutUs dialogAbout = new frmAboutUs();
            dialogAbout.ShowDialog();
        }

        private void mnsFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnsFileClear_Click(object sender, EventArgs e)
        {
            // Clear textBoxes
            this.clearTextBox(this.txtInputFile);
            this.clearTextBox(this.txtGeneralReleaseName);
            this.clearTextBox(this.txtGeneralTitle);
            this.clearTextBox(this.txtTargetLocation);
        }

        private void mnsFileOpen_Click(object sender, EventArgs e)
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
    }
}
