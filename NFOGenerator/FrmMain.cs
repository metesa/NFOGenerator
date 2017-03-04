using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using MediaInfoLib;
using NFOGenerator.Model.FileInfo;
using NFOGenerator.Model.General;
using NFOGenerator.Model.NFO;
using NFOGenerator.Util;

namespace NFOGenerator.Forms
{
    public partial class FrmMain : Form
    {

        // Create streamInfo to read info's from the file.
        ReleaseInfo releaseInfo = new ReleaseInfo();
        private bool autoGenerate = false;

        public FrmMain()
        {
            InitializeComponent();
        }

        #region Protected Methods
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
        #endregion

        #region Load & Dispose
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
            this.cmbSourceType.SelectedIndex = 0;
            this.cmbSourceResolution.SelectedIndex = 2;
            this.cmbSeparateChar.SelectedIndex = 0;
            this.cmbReleaseCategory.SelectedIndex = 0;
            this.cmbReleaseMedium.SelectedIndex = 0;

            // Check all available template
            this.cmbNfoTemplate.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(@".\Templates");
            if (di.Exists)
            {
                FileInfo[] fis = di.GetFiles("*.tpl", SearchOption.AllDirectories);
                if (fis.Length > 0)
                {
                    foreach (FileInfo item in fis)
                    {
                        this.cmbNfoTemplate.Items.Add(item.Name);
                    }
                    this.cmbNfoTemplate.SelectedIndex = 0;
                }
            }
        }
        #endregion

        #region Input & Output
        private void grpInput_DragDrop(object sender, DragEventArgs e)
        {
            Array aryFiles = ((System.Array)e.Data.GetData(DataFormats.FileDrop));
            txtInputFile.Text = aryFiles.GetValue(0).ToString();
        }

        private void grpInput_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void txtInputFile_TextChanged(object sender, EventArgs e)
        {
            autoGenerate = false;

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

            guessReleaseNameFromFilename(this.txtInputFile.Text);
            
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
            this.cmbVideoCodec.Text = this.releaseInfo.VI.codec;

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

            // Add default output folder
            txtTargetLocation.Text = new FileInfo(this.txtInputFile.Text).DirectoryName;

            updateReleaseName();
            autoGenerate = true;
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
        #endregion

        #region MenuStrip
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

        private void mnsToolsImageUploader_Click(object sender, EventArgs e)
        {
            FrmImageUploader imageUp = new FrmImageUploader();
            imageUp.ShowDialog();
        }
        #endregion

        #region Audio & Subtitle
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
                this.lstAudio.Items.RemoveAt(editIndex);
                this.lstAudio.Items.Insert(editIndex, this.releaseInfo.AI[editIndex].audioInfoFull);
            }
        }

        private void btnSubtitleEdit_Click(object sender, EventArgs e)
        {
            int editIndex = this.lstSubtitle.SelectedIndex;

            if (editIndex < 0 || editIndex >= this.lstSubtitle.Items.Count)
            {
                return;
            }
            else
            {
                this.releaseInfo.SI[editIndex].subLang = this.txtSubtitleLanguage.Text;
                this.releaseInfo.SI[editIndex].subFormat = this.txtSubtitleFormat.Text;
                this.releaseInfo.SI[editIndex].subComment = this.txtSubtitleComment.Text;
                this.releaseInfo.SI[editIndex].subForced = this.chkSubtitleForced.Checked;
                this.releaseInfo.SI[editIndex].subSDH = this.chkSubtitleSDH.Checked;
                this.releaseInfo.SI[editIndex].UpdateSubtitleInfo();
                this.lstSubtitle.Items.RemoveAt(editIndex);
                this.lstSubtitle.Items.Insert(editIndex, this.releaseInfo.SI[editIndex].subInfoFull);
            }
        }
        #endregion

        #region Process
        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (this.cmbNfoTemplate.Items.Count < 1)
            {
                MessageBox.Show(@"Cannot find any template on '.\Template\' folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string audioCombined = "";
                string subCombined = "";
                string chapters = "";

                try
                {
                    // Combine all the audio info's into one string.
                    for (int i = 0; i < this.lstAudio.Items.Count; i++)
                    {
                        audioCombined += this.lstAudio.Items[i].ToString() + Environment.NewLine;
                    }

                    // Combine all the subtitle info's into one string.
                    for (int i = 0; i < this.lstSubtitle.Items.Count; i++)
                    {
                        subCombined += this.lstSubtitle.Items[i].ToString() + ", ";
                    }

                    // Convert chapters info.
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ExceptionUtil.FullMessage(ex) + "There is an exception when gathering info from the Window: " + Environment.NewLine + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    NFOStyle style = NFOStyle.ImportTemplate(@"./Templates/" + cmbNfoTemplate.SelectedItem.ToString());
                    NFOInfo info = new NFOInfo(this.txtGeneralReleaseName.Text,
                        Alignment.Left,
                        this.txtIMDb.Text == "" ? "N/A" : this.txtIMDb.Text,
                        this.txtSourceName.Text == "" ? "N/A" : (this.txtSourceName.Text + " - Thanks!"),
                        this.txtGeneralSize.Text,
                        this.txtGeneralDuration.Text,
                        this.txtVideoBitrate.Text,
                        this.txtVideoWidth.Text + " x " + this.txtVideoHeight.Text,
                        this.txtVideoFramerate.Text,
                        audioCombined == "" ? "N/A" : audioCombined,
                        subCombined == "" ? "N/A" : subCombined,
                        chapters,
                        this.txtVideoNote.Text
                    );
                    NFODocument nfo = new NFODocument(info, style);
                    nfo.WriteNfoFile(this.txtTargetLocation.Text + @"\" + this.txtGeneralReleaseName.Text + ".nfo");
                    SetStatus("File saved! " + this.txtTargetLocation.Text + @"\" + this.txtGeneralReleaseName.Text + ".nfo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ExceptionUtil.FullMessage(ex) + "There is an exception when generating NFO: " + Environment.NewLine + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Status Strip
        private void SetStatus(string status)
        {
            stsStatusLabel.Text = status;
        }
        #endregion

        #region Auto Generate Release Name
        /// <summary>
        /// Video Codec  : x264 H.264 x265 MPEG2 VC-1 AVC XviD
        /// Audio Codec  : DTS DTS-ES DD-EX DD5.1 DD2.1 DD2.0 AAC2.0 AAC1.0 FLAC2.0 FLAC1.0
        /// Source Media : BluRay HDDVD DVDRip WEB-DL WEBRip HDTV
        /// Edition Info : PROPER REPACK PROPER.REPACK REPACK.PROPER
        ///                Theatrical.Cut Director's.Cut Extended.Cut Unrated Criterion
        ///                Hybrid
        /// </summary>
        /// <param name="filename"></param>
        private void guessReleaseNameFromFilename(string filename)
        {
            try
            {
                string name = Path.GetFileNameWithoutExtension(filename);
                string lower = name.ToLower();
                int firstIndex = lower.Length;
                Match m;
                int comboBoxIndex = -1;

                Regex yearRgx = new Regex(@"((19)|(20))\d{2}");
                Regex resolutionRgx = new Regex(@"[0-9]{2,3}0p");

                Regex sourceRgx = new Regex(@"(bluray)|(blu-ray)|(hddvd)|(hd-dvd)|(dvdrip)|(web-dl)|(webrip)|(hdtv)");
                Regex specialEditionRgx = new Regex(@"(tc)|(dc)|(theatrical)|(extended)|(theatrical cut)|(extended cut)|(theatrical.cut)|(extended.cut)|(cc)|(criterion collection)|(criterion.collection)|(criterion)|(unrated)|(directors cut)|(directors.cut)|(director's cut)|(directors's.cut)|(directors)|(director's)");
                Regex videoRgx = new Regex(@"(x264)|(h264)|(h.264)|(h 264)|(x265)|(xvid)|(mpeg2)|(mpeg-2)|(mpeg 2)|(avc)|(vc1)|(vc 1)|(vc-1)");

                Regex properRgx = new Regex(@"proper");
                Regex repackRgx = new Regex(@"repack");
                Regex hybridRgx = new Regex(@"hybrid");

                Regex audioWithChRgx = new Regex(@"(?<codec>(dts)|(dts-es)|(dd)|(ac3)|(dd-ex)|(aac)|(flac))(?<channel>[0-9]{1,2}.[0-9])");
                Regex audioWithoutChRgx = new Regex(@"(dts)|(dts-es)|(dd)|(ac3)|(dd-ex)|(aac)|(flac)");

                //Year
                MatchCollection yearMC = yearRgx.Matches(lower);
                int yearIndexFirst = -1;
                int yearIndexSelect = -1;
                int yearCount = 0;
                string yearValue = "";
                if (yearMC != null)
                {
                    yearCount = yearMC.Count;
                    if (yearCount > 0)
                    {
                        yearIndexFirst = yearMC[0].Index;
                        yearIndexSelect = yearMC[yearCount - 1].Index;
                        yearValue = yearMC[yearCount - 1].Value;
                        firstIndex = Math.Min(firstIndex, yearIndexSelect);
                        try
                        {
                            comboBoxIndex = this.cmbGeneralYear.FindStringExact(yearValue);
                            this.cmbGeneralYear.SelectedIndex = comboBoxIndex;
                        }
                        catch
                        {
                            SetStatus("Failed to guess some info from file name. Please set them manually");
                        }
                        
                    }
                }

                //Resolution
                MatchCollection resolutionMC = resolutionRgx.Matches(lower);
                int resolutionIndexFirst = -1;
                int resolutionIndexSelect = -1;
                int resolutionCount = 0;
                string resolutionValue = "";
                if (resolutionMC != null)
                {
                    resolutionCount = resolutionMC.Count;
                    if (resolutionCount > 0)
                    {
                        resolutionIndexFirst = resolutionMC[0].Index;
                        resolutionIndexSelect = resolutionMC[resolutionCount - 1].Index;
                        resolutionValue = resolutionMC[resolutionCount - 1].Value;
                        firstIndex = Math.Min(firstIndex, resolutionIndexSelect);
                        try
                        {
                            comboBoxIndex = this.cmbGeneralResolution.FindString(resolutionValue);
                            this.cmbGeneralResolution.SelectedIndex = comboBoxIndex;
                        }
                        catch
                        {
                            SetStatus("Failed to guess some info from file name. Please set them manually");
                        }
                    }
                }

                //Source
                MatchCollection sourceMC = sourceRgx.Matches(lower);
                int sourceIndexFirst = -1;
                int sourceIndexSelect = -1;
                int sourceCount = 0;
                string sourceValue = "";
                if (sourceMC != null)
                {
                    sourceCount = sourceMC.Count;
                    if (sourceCount > 0)
                    {
                        sourceIndexFirst = sourceMC[0].Index;
                        sourceIndexSelect = sourceMC[sourceCount - 1].Index;
                        sourceValue = sourceMC[sourceCount - 1].Value;
                        firstIndex = Math.Min(firstIndex, sourceIndexSelect);
                        switch (sourceValue)
                        {
                            case "bluray":
                                sourceValue = "BluRay";
                                break;
                            case "blu-ray":
                                sourceValue = "BluRay";
                                break;
                            case "hddvd":
                                sourceValue = "HDDVD";
                                break;
                            case "hd-dvd":
                                sourceValue = "HDDVD";
                                break;
                            case "dvdrip":
                                sourceValue = "DVDRip";
                                break;
                            case "web-dl":
                                sourceValue = "WEB-DL";
                                break;
                            case "webrip":
                                sourceValue = "WEBRip";
                                break;
                            case "hdtv":
                                sourceValue = "HDTV";
                                break;
                        }
                        try
                        {
                            comboBoxIndex = this.cmbSourceType.FindStringExact(sourceValue);
                            this.cmbSourceType.SelectedIndex = comboBoxIndex;
                        }
                        catch
                        {
                            SetStatus("Failed to guess some info from file name. Please set them manually");
                        }
                    }
                }

                //Video
                MatchCollection videoMC = videoRgx.Matches(lower);
                int videoIndexFirst = -1;
                int videoIndexSelect = -1;
                int videoCount = 0;
                string videoValue = "";
                if (videoMC != null)
                {
                    videoCount = videoMC.Count;
                    if (videoCount > 0)
                    {
                        videoIndexFirst = videoMC[0].Index;
                        videoIndexSelect = videoMC[videoCount - 1].Index;
                        videoValue = videoMC[videoCount - 1].Value;
                        firstIndex = Math.Min(firstIndex, videoIndexSelect);
                        switch (videoValue)
                        {
                            case "x264":
                                videoValue = "x264";
                                break;
                            case "h264":
                                videoValue = "H.264";
                                break;
                            case "h.264":
                                videoValue = "H.264";
                                break;
                            case "h 264":
                                videoValue = "H.264";
                                break;
                            case "x265":
                                videoValue = "x265";
                                break;
                            case "xvid":
                                videoValue = "XviD";
                                break;
                            case "mpeg2":
                                videoValue = "MPEG-2";
                                break;
                            case "mpeg-2":
                                videoValue = "MPEG-2";
                                break;
                            case "mpeg 2":
                                videoValue = "MPEG-2";
                                break;
                            case "avc":
                                videoValue = "AVC";
                                break;
                            case "vc1":
                                videoValue = "x264";
                                break;
                            case "vc 1":
                                videoValue = "VC-1";
                                break;
                            case "vc-1":
                                videoValue = "VC-1";
                                break;
                        }
                        try
                        {
                            comboBoxIndex = this.cmbVideoCodec.FindStringExact(videoValue);
                            this.cmbVideoCodec.SelectedIndex = comboBoxIndex;
                        }
                        catch
                        {
                            SetStatus("Failed to guess some info from file name. Please set them manually");
                        }
                    }
                }

                //Audio
                MatchCollection audioWithChMC = audioWithChRgx.Matches(lower);
                int audioIndexFirst = -1;
                int audioIndexSelect = -1;
                int audioCount = 0;
                string audioCodec = "";
                string audioChannel = "";
                string audioValue = "";
                if (audioWithChMC != null)
                {
                    audioCount = audioWithChMC.Count;
                    if (audioCount > 0)
                    {
                        m = audioWithChMC[audioCount - 1];
                        audioIndexFirst = audioWithChMC[0].Index;
                        audioIndexSelect = m.Index;
                        audioChannel = m.Groups["channel"].Value;
                        audioCodec = m.Groups["codec"].Value;
                        audioValue = audioWithChMC[audioCount - 1].Value;
                        firstIndex = Math.Min(firstIndex, audioIndexSelect);
                        switch (audioCodec)
                        {
                            //DTS  DTS-ES  DD5.1  DD2.1  DD2.0  AAC2.0  AAC1.0  FLAC2.0  FLAC1.0
                            case "dts":
                                audioCodec = "DTS";
                                audioValue = "DTS";
                                break;
                            case "dts-es":
                                audioCodec = "DTS-ES";
                                audioValue = "DTS-ES";
                                break;
                            case "dd":
                                audioCodec = "DD";
                                audioValue = "DD" + audioChannel;
                                break;
                            case "ac3":
                                audioCodec = "DD";
                                audioValue = "DD" + audioChannel;
                                break;
                            case "dd-ex":
                                audioCodec = "DD-EX";
                                audioValue = "DD-EX";
                                break;
                            case "aac":
                                audioCodec = "AAC";
                                audioValue = "AAC" + audioChannel;
                                break;
                            case "flac":
                                audioCodec = "FLAC";
                                audioValue = "FLAC" + audioChannel;
                                break;
                        }
                        try
                        {
                            comboBoxIndex = this.cmbGeneralAudio.FindStringExact(audioValue);
                            this.cmbGeneralAudio.SelectedIndex = comboBoxIndex;
                        }
                        catch
                        {
                            SetStatus("Failed to guess some info from file name. Please set them manually");
                        }
                    }
                }
                else
                {
                    MatchCollection audioWithoutChMC = audioWithoutChRgx.Matches(lower);
                    if (audioWithoutChMC != null)
                    {
                        audioCount = audioWithoutChMC.Count;
                        if (audioCount > 0)
                        {
                            audioIndexFirst = audioWithoutChMC[0].Index;
                            audioIndexSelect = audioWithoutChMC[audioCount - 1].Index;
                            audioValue = audioWithoutChMC[audioCount - 1].Value;
                            if (audioValue == "dts" || audioValue == "dts-es" || audioValue == "dd-ex")
                            {
                                firstIndex = Math.Min(firstIndex, audioIndexSelect);
                                audioValue = audioValue.ToUpper();
                                try
                                {
                                    comboBoxIndex = this.cmbGeneralAudio.FindStringExact(audioValue);
                                    this.cmbGeneralAudio.SelectedIndex = comboBoxIndex;
                                }
                                catch
                                {
                                    SetStatus("Failed to guess some info from file name. Please set them manually");
                                }
                            }
                        }
                    }
                }

                //Special Edition
                MatchCollection specialEditionMC = specialEditionRgx.Matches(lower);
                int specialEditionIndexFirst = -1;
                int specialEditionIndexSelect = -1;
                int specialEditionCount = 0;
                string specialEditionValue = "";
                if (specialEditionMC != null)
                {
                    specialEditionCount = specialEditionMC.Count;
                    if (specialEditionCount > 0)
                    {
                        specialEditionIndexFirst = specialEditionMC[0].Index;
                        specialEditionIndexSelect = specialEditionMC[specialEditionCount - 1].Index;
                        specialEditionValue = specialEditionMC[specialEditionCount - 1].Value;
                        firstIndex = Math.Min(firstIndex, specialEditionIndexSelect);
                        switch (specialEditionValue)
                        {
                            case "tc":
                                specialEditionValue = "Theatrical Cut";
                                break;
                            case "theatrical":
                                specialEditionValue = "Theatrical Cut";
                                break;
                            case "theatrical cut":
                                specialEditionValue = "Theatrical Cut";
                                break;
                            case "theatrical.cut":
                                specialEditionValue = "Theatrical Cut";
                                break;
                            case "dc":
                                specialEditionValue = "Director's Cut";
                                break;
                            case "directors cut":
                                specialEditionValue = "Director's Cut";
                                break;
                            case "directors.cut":
                                specialEditionValue = "Director's Cut";
                                break;
                            case "director's cut":
                                specialEditionValue = "Director's Cut";
                                break;
                            case "directors's.cut":
                                specialEditionValue = "Director's Cut";
                                break;
                            case "directors":
                                specialEditionValue = "Director's Cut";
                                break;
                            case "director's":
                                specialEditionValue = "Director's Cut";
                                break;
                            case "extended":
                                specialEditionValue = "Extended Cut";
                                break;
                            case "extended cut":
                                specialEditionValue = "Extended Cut";
                                break;
                            case "extended.cut":
                                specialEditionValue = "Extended Cut";
                                break;
                            case "cc":
                                specialEditionValue = "Criterion";
                                break;
                            case "criterion collection":
                                specialEditionValue = "Criterion";
                                break;
                            case "criterion.collection":
                                specialEditionValue = "Criterion";
                                break;
                            case "criterion":
                                specialEditionValue = "Criterion";
                                break;
                            case "unrated":
                                specialEditionValue = "Unrated";
                                break;
                        }
                        try
                        {
                            comboBoxIndex = this.cmbGeneralEdition.FindStringExact(specialEditionValue);
                            this.cmbGeneralEdition.SelectedIndex = comboBoxIndex;
                        }
                        catch
                        {
                            SetStatus("Failed to guess some info from file name. Please set them manually");
                        }
                    }
                }

                //Additional
                MatchCollection properMC = properRgx.Matches(lower);
                MatchCollection repackMC = repackRgx.Matches(lower);
                MatchCollection hybridMC = hybridRgx.Matches(lower);
                int properCount = 0;
                int repackCount = 0;
                if (properMC != null)
                {
                    properCount = properMC.Count;
                    if (properCount > 0 && firstIndex > properMC[properCount - 1].Index)
                    {
                        properCount = 0;
                    }
                }
                if (repackMC != null)
                {
                    repackCount = repackMC.Count;
                    if (repackCount > 0 && firstIndex > repackMC[repackCount - 1].Index)
                    {
                        repackCount = 0;
                    }
                }
                if (properCount < 1)
                {
                    if (repackCount < 1)
                    {
                        this.cmbGeneralProper.SelectedIndex = 0;
                    }
                    else
                    {
                        this.cmbGeneralProper.SelectedIndex = 2;
                    }
                }
                else
                {
                    if (repackCount < 1)
                    {
                        this.cmbGeneralProper.SelectedIndex = 1;
                    }
                    else
                    {
                        this.cmbGeneralProper.SelectedIndex = 3;
                    }
                }
                int hybridIndexFirst = -1;
                int hybridIndexSelect = -1;
                int hybridCount = 0;
                string hybridValue = "";
                if (hybridMC != null)
                {
                    hybridCount = hybridMC.Count;
                    if (hybridCount > 0)
                    {
                        hybridIndexFirst = properMC[0].Index;
                        hybridIndexSelect = properMC[hybridCount - 1].Index;
                        hybridValue = properMC[hybridCount - 1].Value;
                        if (firstIndex < hybridIndexSelect)
                        {
                            this.cmbGeneralHybrid.SelectedIndex = 1;
                        }
                        else
                        {
                            this.cmbGeneralHybrid.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        this.cmbGeneralHybrid.SelectedIndex = 0;
                    }
                }

                //Movie name
                if (firstIndex > 0)
                {
                    this.txtGeneralTitle.Text = name.Substring(0, firstIndex).Replace('.', ' ').Trim().Replace("  ", " ");
                }

            }
            catch
            {
                SetStatus("Failed to guess release name from file name. Please set them manually");
            }
        }

        private void updateReleaseName()
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
            string sep = this.cmbSeparateChar.SelectedIndex == 0 ? " " : ".";
            string group = this.cmbNfoTemplate.Text == "" ? "TAiCHi" : this.cmbNfoTemplate.Text.Replace(".tpl", "");
            this.txtGeneralReleaseName.Text = this.releaseInfo.GI.GenerateRLZName(sep, group);
        }

        private void txtGeneralTitle_TextChanged(object sender, EventArgs e)
        {
            if (autoGenerate)
            {
                updateReleaseName();
            }
        }

        private void cmbGeneralYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (autoGenerate)
            {
                updateReleaseName();
            }
        }

        private void cmbGeneralEdition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (autoGenerate)
            {
                updateReleaseName();
            }
        }

        private void cmbGeneralResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (autoGenerate)
            {
                updateReleaseName();
            }
        }

        private void cmbGeneralHybrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (autoGenerate)
            {
                updateReleaseName();
            }
        }

        private void cmbGeneralProper_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (autoGenerate)
            {
                updateReleaseName();
            }
        }

        private void cmbGeneralAudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (autoGenerate)
            {
                updateReleaseName();
            }
        }

        private void cmbSourceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (autoGenerate)
            {
                updateReleaseName();
            }
        }

        private void cmbVideoCodec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (autoGenerate)
            {
                updateReleaseName();
            }
        }

        private void cmbSeparateChar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        private void cmbReleaseCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cmbReleaseCategory.SelectedIndex)
            {
                // TO-DO: Define a function to switch between panels
                case 0: // Movie
                    this.pnlMovieEncode.Show();
                    break;
                case 1: // TV
                    this.pnlMovieEncode.Hide();
                    break;
                case 2: // Documentary
                    this.pnlMovieEncode.Hide();
                    break;
                case 3: // Sport
                    this.pnlMovieEncode.Hide();
                    break;
                case 4: // Music
                    this.pnlMovieEncode.Hide();
                    break;
                case 5: /// XXX
                    this.pnlMovieEncode.Hide();
                    break;
            }
        }

        private void btnSearchIMDb_Click(object sender, EventArgs e)
        {
            IMDbReader IMDb = new IMDbReader();
            IMDb.title = this.txtGeneralTitle.Text;
            IMDb.SendIMDbRequest();
            IMDb.ReadIMDbID();
            this.txtIMDb.Text = "http://www.imdb.com/title/" + IMDb.IMDbID + "/";
        }

        private void txtIMDb_TextChanged(object sender, EventArgs e)
        {
            if (this.txtIMDb.Text == "")
            {
                this.btnOpenIMDb.Enabled = false;
            }
            else
            {
                this.btnOpenIMDb.Enabled = true;
            }
        }

        private void btnOpenIMDb_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.txtIMDb.Text);
        }
    }
}