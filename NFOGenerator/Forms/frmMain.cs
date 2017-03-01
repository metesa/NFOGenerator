using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using NFOGenerator.Module.Main;
using NFOGenerator.Module.Utils;
using MediaInfoLib;

namespace NFOGenerator.Forms
{
    public partial class FrmMain : Form
    {

        // Create streamInfo to read info's from the file.
        StreamInfo streamInfo = new StreamInfo();

        public FrmMain()
        {
            InitializeComponent();
        }

        /*-------------------------------------------------------------------------
         * Protected custom methods down below
         * ------------------------------------------------------------------------*/

        // Clear a textBox.
        protected void ClearTextBox(TextBox boxToClear)
        {
            boxToClear.Text = "";
        }

        /*-------------------------------------------------------------------------
         * Protected custom methods up above
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
            ReleaseInfo anotherRelease = new ReleaseInfo(this.txtGeneralTitle.Text,
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
                this.ClearTextBox(this.txtGeneralSize);
                this.ClearTextBox(this.txtGeneralDuration);

                this.ClearTextBox(this.txtVideoWidth);
                this.ClearTextBox(this.txtVideoHeight);
                this.ClearTextBox(this.txtVideoDAR);
                this.ClearTextBox(this.txtVideoFramerate);
                this.ClearTextBox(this.txtVideoBitrate);
                return;
            }

            this.streamInfo.ReadMediaInfo(this.txtInputFile.Text);

            // Display general info.
            this.txtGeneralSize.Text = this.streamInfo.GI.fileSize;
            this.txtGeneralDuration.Text = this.streamInfo.GI.duration;

            // Display video info.
            this.txtVideoWidth.Text = this.streamInfo.VI.width;
            this.txtVideoHeight.Text = this.streamInfo.VI.height;
            this.txtVideoDAR.Text = this.streamInfo.VI.displayAR;
            this.txtVideoFramerate.Text = this.streamInfo.VI.framerate;
            this.txtVideoBitrate.Text = this.streamInfo.VI.bitrate;

            // Display audio info.
            this.lstAudio.Items.Clear();
            for (int i = 0; i < this.streamInfo.MI.Count_Get(MediaInfoLib.StreamKind.Audio); i++)
            {
                this.lstAudio.Items.Add(this.streamInfo.AI[i].audioInfoFull);
            }
        }

        private void mnsHelpAboutUs_Click(object sender, EventArgs e)
        {
            FrmAboutUs dialogAbout = new FrmAboutUs();
            dialogAbout.ShowDialog();
        }

        private void mnsFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnsFileClear_Click(object sender, EventArgs e)
        {
            // Clear textBoxes
            this.ClearTextBox(this.txtInputFile);
            this.ClearTextBox(this.txtGeneralReleaseName);
            this.ClearTextBox(this.txtGeneralTitle);
            this.ClearTextBox(this.txtTargetLocation);
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

        private void chkAudioCommentary_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAudioCommentary.Checked)
            {
                this.txtAudioCommentaryBy.Visible = true;
            }
            else
            {
                this.txtAudioCommentaryBy.Visible = false;
            }
        }

        private void lstAudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtAudioLanguage.Text = this.streamInfo.AI[this.lstAudio.SelectedIndex].audioLang;
            this.txtAudioCodec.Text = this.streamInfo.AI[this.lstAudio.SelectedIndex].audioCodec;
            this.txtAudioChannels.Text = this.streamInfo.AI[this.lstAudio.SelectedIndex].audioChan;
            this.txtAudioBitrate.Text = this.streamInfo.AI[this.lstAudio.SelectedIndex].audioBitr;

            if (this.streamInfo.AI[this.lstAudio.SelectedIndex].audioComm)
            {
                this.chkAudioCommentary.Checked = true;
                this.txtAudioCommentaryBy.Text = this.streamInfo.AI[this.lstAudio.SelectedIndex].audioCommentator;
            }
            else
            {
                this.chkAudioCommentary.Checked = false;
            }
        }
    }
}
