using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using NFOGenerator.Model.FileInfo;
using NFOGenerator.Util;
using MediaInfoLib;

using NFOGenerator.Model.General;
using NFOGenerator.Model.NFO;

namespace NFOGenerator.Forms
{
    public partial class FrmMain : Form
    {

        // Create streamInfo to read info's from the file.
        ReleaseInfo releaseInfo = new ReleaseInfo();

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

        protected void MoveUp(ListBox paraBox)
        {
            this.MoveItem(paraBox, -1);
        }

        protected void MoveDown(ListBox paraBox)
        {
            this.MoveItem(paraBox, 1);
        }

        protected void MoveItem(ListBox paraBox, int direction)
        {
            // Checking selected item
            if (paraBox.SelectedItem == null || paraBox.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = paraBox.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= paraBox.Items.Count)
                return; // Index out of range - nothing to do

            object selected = paraBox.SelectedItem;

            // Removing removable element
            paraBox.Items.Remove(selected);
            // Insert it in new position
            paraBox.Items.Insert(newIndex, selected);
            // Restore selection
            paraBox.SetSelected(newIndex, true);
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
            this.cmbGeneralResolution.SelectedIndex = 1;
            this.cmbSourceResolution.SelectedIndex = 2;
        }

        private void btnGeneralGenerate_Click(object sender, EventArgs e)
        {
            // Load form infomation into releaseInfo.GI container.
            this.releaseInfo.GI.imdbLink = this.txtIMDb.Text;
            this.releaseInfo.GI.nameTitle = this.txtGeneralTitle.Text;
            this.releaseInfo.GI.nameYear = this.cmbGeneralYear.Text;
            this.releaseInfo.GI.nameEdition = this.cmbGeneralEdition.Text;
            this.releaseInfo.GI.nameHybrid = this.cmbGeneralHybrid.Text;
            this.releaseInfo.GI.nameProper = this.cmbGeneralProper.Text;
            this.releaseInfo.GI.nameResolution = this.cmbGeneralResolution.Text;
            this.releaseInfo.GI.nameSource = this.cmbSourceType.Text;
            this.releaseInfo.GI.nameAudio = this.cmbGeneralAudio.Text;
            this.releaseInfo.GI.nameVideo = this.cmbVideoCodec.Text;
            this.releaseInfo.GI.releaseNameSrc = this.txtSourceName.Text;

            // Generate the release name
            this.txtGeneralReleaseName.Text = this.releaseInfo.GI.GenerateRLZName();
            
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

            this.releaseInfo.ReadMediaInfo(this.txtInputFile.Text);

            // Display general info.
            this.txtGeneralSize.Text = this.releaseInfo.GI.fileSize;
            this.txtGeneralDuration.Text = this.releaseInfo.GI.duration;

            // Display video info.
            this.txtVideoWidth.Text = this.releaseInfo.VI.width;
            this.txtVideoHeight.Text = this.releaseInfo.VI.height;
            this.txtVideoDAR.Text = this.releaseInfo.VI.displayAR;
            this.txtVideoFramerate.Text = this.releaseInfo.VI.framerate;
            this.txtVideoBitrate.Text = this.releaseInfo.VI.bitrate;

            // Display audio info.
            this.lstAudio.Items.Clear();
            for (int i = 0; i < this.releaseInfo.MI.Count_Get(StreamKind.Audio); i++)
            {
                this.lstAudio.Items.Add(this.releaseInfo.AI[i].audioInfoFull);
            }

            // Display subtitle info.
            this.lstSubtitle.Items.Clear();
            for (int i = 0; i < this.releaseInfo.MI.Count_Get(StreamKind.Text); i++)
            {
                this.lstSubtitle.Items.Add(this.releaseInfo.SI[i].subInfoFull);
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
            if (this.lstAudio.SelectedIndex < 0 || this.lstAudio.SelectedIndex >= this.lstAudio.Items.Count)
            {
                return;
            }
            else
            {
                this.txtAudioLanguage.Text = this.releaseInfo.AI[this.lstAudio.SelectedIndex].audioLang;
                this.txtAudioCodec.Text = this.releaseInfo.AI[this.lstAudio.SelectedIndex].audioCodec;
                this.txtAudioChannels.Text = this.releaseInfo.AI[this.lstAudio.SelectedIndex].audioChan;
                this.txtAudioBitrate.Text = this.releaseInfo.AI[this.lstAudio.SelectedIndex].audioBitr;
                this.chkAudioCommentary.Checked = this.releaseInfo.AI[this.lstAudio.SelectedIndex].audioComm;
                this.txtAudioCommentaryBy.Text = this.releaseInfo.AI[this.lstAudio.SelectedIndex].audioCommentator;
            }
        }

        private void lstSubtitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstSubtitle.SelectedIndex < 0 || this.lstSubtitle.SelectedIndex >= this.lstSubtitle.Items.Count)
            {
                return;
            }
            else
            {
                this.txtSubtitleLanguage.Text = this.releaseInfo.SI[this.lstSubtitle.SelectedIndex].subLang;
                this.txtSubtitleFormat.Text = this.releaseInfo.SI[this.lstSubtitle.SelectedIndex].subFormat;
                this.txtSubtitleComment.Text = this.releaseInfo.SI[this.lstSubtitle.SelectedIndex].subComment;
                this.chkSubtitleForced.Checked = this.releaseInfo.SI[this.lstSubtitle.SelectedIndex].subForced;
                this.chkSubtitleSDH.Checked = this.releaseInfo.SI[this.lstSubtitle.SelectedIndex].subSDH;
            }
        }

        private void btnAudioEdit_Click(object sender, EventArgs e)
        {
            int editIndex = this.lstAudio.SelectedIndex;

            if (editIndex < 0 || editIndex >= this.lstAudio.Items.Count)
            {
                return;
            }
            else
            {
                this.releaseInfo.AI[editIndex].audioLang = this.txtAudioLanguage.Text;
                this.releaseInfo.AI[editIndex].audioCodec = this.txtAudioCodec.Text;
                this.releaseInfo.AI[editIndex].audioChan = this.txtAudioChannels.Text;
                this.releaseInfo.AI[editIndex].audioBitr = this.txtAudioBitrate.Text;
                this.releaseInfo.AI[editIndex].audioComm = this.chkAudioCommentary.Checked;
                this.releaseInfo.AI[editIndex].audioCommentator = this.txtAudioCommentaryBy.Text;
                this.releaseInfo.AI[editIndex].UpdateAudioInfo();
                //this.lstAudio.SelectedItem = this.releaseInfo.AI[editIndex].audioInfoFull;
                this.lstAudio.Items.RemoveAt(editIndex);
                this.lstAudio.Items.Insert(editIndex, this.releaseInfo.AI[editIndex].audioInfoFull);
            }
        }

        private void mnsToolsImageUpImagebam_Click(object sender, EventArgs e)
        {
            FrmImageUploader imageUp = new FrmImageUploader();
            imageUp.Show();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Combine all the audio info's into one string.
                string audioCombined = "";
                for (int i = 0; i < this.lstAudio.Items.Count; i++)
                {
                    audioCombined += this.lstAudio.GetItemText(i);
                }

                // Combine all the subtitle info's into one string.
                string subCombined = "";
                for (int i = 0; i < this.lstSubtitle.Items.Count; i++)
                {
                    subCombined += this.lstSubtitle.GetItemText(i);
                }

                // Convert chapters info.
                string chapters;
                if (this.chkGeneralChaptersIncluded.Checked)
                {
                    if (this.chkGeneralChaptersNamed.Checked)
                    {
                        chapters = "Included & Named";
                    }
                    else
                    {
                        chapters = "Included & Unnamed";
                    }
                }
                else
                {
                    chapters = "Not Included";
                }

                NFOStyle style = NFOStyle.ImportTemplate(@"./Templates/TAiCHi.tpl");
                NFOInfo info = new NFOInfo(this.txtGeneralReleaseName.Text,
                    Alignment.Left,
                    this.txtIMDb.Text,
                    this.txtSourceName.Text + " - Thanks!",
                    this.txtGeneralSize.Text,
                    this.txtGeneralDuration.Text,
                    this.txtVideoBitrate.Text,
                    this.txtVideoWidth.Text + " x " + this.txtVideoHeight.Text,
                    this.txtVideoFramerate.Text,
                    audioCombined,
                    subCombined,
                    chapters,
                    this.txtVideoNote.Text
                );
                NFODocument nfo = new NFODocument(info, style);
                nfo.WriteNfoFile(this.txtTargetLocation.Text + @"\" + this.txtGeneralReleaseName.Text + ".nfo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an exception when generating NFO: " + Environment.NewLine + ex.StackTrace, "Error: " + ex.Message);
            }
        }
    }
}
