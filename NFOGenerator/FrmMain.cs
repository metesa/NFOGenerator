using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using MediaInfoLib;
using NFOGenerator.Model.FileInfo;
using NFOGenerator.Model.General;
using NFOGenerator.Model.NFO;
using NFOGenerator.Model.SomeDb;
using NFOGenerator.Tools.ImageUploader;
using NFOGenerator.Util;

namespace NFOGenerator.Forms
{
    public partial class FrmMain : Form
    {
        #region Private Fields
        private ReleaseInfo releaseInfo = new ReleaseInfo();
        private bool autoGenerate = false;
        #endregion

        #region Constructor
        public FrmMain()
        {
            InitializeComponent();
        }
        #endregion

        #region Protected Methods
        /*-------------------------------------------------------------------------
         * Protected custom methods down below
         * ------------------------------------------------------------------------*/
        #region Any Control Edit Methods
        /// <summary>
        /// Turn the corresponding Label's ForeColor to Red if the TextBox's Text is empty, or unknown.
        /// Otherwise set the ForeColor to Black.
        /// </summary>
        /// <param name="txt">TextBox control to check if whose Text is empty.</param>
        /// <param name="lbl">Label control to set ForeColor</param>
        protected void TurnRed(Control txt, Control lbl)
        {
            TurnRed((this.txtInputFile.Text != "") && (txt.Text == "" || txt.Text.ToLower() == "unknown"), lbl);
        }

        protected void TurnRed(bool turn, Control lbl)
        {
            if (turn)
            {
                lbl.ForeColor = Color.Red;
            }
            else
            {
                lbl.ForeColor = Color.Black;
            }
        }

        protected void ClearChildTextBoxExceptOne(Control parent, Control exception)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox && c.Name != exception.Name)
                {
                    c.Text = "";
                }
            }
        }

        protected void ResetAllWindowExceptOne(Control exception)
        {
            this.ClearChildTextBoxExceptOne(this, exception);

            foreach (Control c in this.Controls)
            {
                this.ClearChildTextBoxExceptOne(c, exception);

                foreach (Control childC in c.Controls)
                {
                    this.ClearChildTextBoxExceptOne(childC, exception);
                }
            }

            foreach (Control c in this.Controls)
            {
                foreach (Control childC in c.Controls)
                {
                    foreach (Control grandChildC in childC.Controls)
                    {
                        foreach (Control greatGrandChildC in grandChildC.Controls)
                        {
                            if (greatGrandChildC is ListBox)
                            {
                                ((ListBox)greatGrandChildC).Items.Clear();
                            }
                        }
                    }
                }
            }
        }

        protected void ClearChildTextBox(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
        }

        protected void ResetWindow()
        {
            this.ClearChildTextBox(this);

            foreach (Control c in this.Controls)
            {
                this.ClearChildTextBox(c);

                foreach (Control childC in c.Controls)
                {
                    this.ClearChildTextBox(childC);
                }
            }

            foreach (Control c in this.Controls)
            {
                foreach (Control childC in c.Controls)
                {
                    foreach (Control grandChildC in childC.Controls)
                    {
                        foreach (Control greatGrandChildC in grandChildC.Controls)
                        {
                            if (greatGrandChildC is ListBox)
                            {
                                ((ListBox)greatGrandChildC).Items.Clear();
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region ListBox Edit Methods
        /// <summary>
        /// Swap two item in a ListBox
        /// </summary>
        /// <param name="lb">the ListBox</param>
        /// <param name="index1">first index</param>
        /// <param name="index2">second index</param>
        private void SwapListItem(ListBox lb, int index1, int index2)
        {
            if (index1 != index2)
            {
                if (index1 < lb.Items.Count && index2 < lb.Items.Count)
                {
                    var temp = lb.Items[index1];
                    lb.Items[index1] = lb.Items[index2];
                    lb.Items[index2] = temp;
                }
            }
        }
        #endregion
        /*-------------------------------------------------------------------------
         * Protected custom methods up above
         * ------------------------------------------------------------------------*/
        #endregion

        #region Release Category
        private void cmbReleaseCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cmbReleaseCategory.SelectedIndex)
            {
                case 0: // Movie
                    this.lblSomeDbLink.Text = "IMDb:";
                    break;
                case 1: // TV
                    this.lblSomeDbLink.Text = "TheTVDb:";
                    break;
            }
        }
        #endregion

        #region Load & Dispose
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.cmbReleaseCategory.SelectedIndex = 0;
            this.cmbReleaseMedium.SelectedIndex = 0;

            switch (this.cmbReleaseCategory.SelectedIndex)
            {
                // TO-DO: Define a function to switch between panels
                case 0: // Movie
                    LoadMovie();
                    break;
                case 1: // TV
                    break;
                case 2: // Documentary
                    break;
                case 3: // Sport
                    break;
                case 4: // Music
                    break;
                case 5: /// XXX
                    break;
            }
        }

        private void LoadMovie()
        {
            // Add items to general year comboBox and set default to current year
            int currentYear = DateTime.Now.Year;
            while (currentYear >= 1900)
            {
                this.cmbGeneralYear.Items.Add(currentYear);
                currentYear -= 1;
            }
            //this.cmbGeneralYear.SelectedIndex = 0;
            this.cmbGeneralResolution.SelectedIndex = 1;
            this.cmbSourceType.SelectedIndex = 0;
            this.cmbSourceResolution.SelectedIndex = 2;
            this.cmbSeparateChar.SelectedIndex = 0;

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
            this.txtInputFile.Text = aryFiles.GetValue(0).ToString();
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
            this.ResetAllWindowExceptOne(txtInputFile);
            this.chkGeneralChaptersIncluded.Checked = false;
            this.chkGeneralChaptersNamed.Checked = false;

            if (this.txtInputFile.Text == "")
            {
                return;
            }

            guessReleaseNameFromFilename(this.txtInputFile.Text);

            this.releaseInfo.ReadMediaInfo(this.txtInputFile.Text);

            // Display general info.
            this.txtGeneralSize.Text = this.releaseInfo.GI.fileSize;
            this.txtGeneralDuration.Text = this.releaseInfo.GI.duration;

            // Display menu/chapter info
            this.chkGeneralChaptersIncluded.Checked = this.releaseInfo.ChapterIncluded;
            this.chkGeneralChaptersNamed.Checked = this.releaseInfo.ChapterNamed;

            // Display video info.
            this.txtVideoWidth.Text = this.releaseInfo.VI.width;
            this.txtVideoHeight.Text = this.releaseInfo.VI.height;
            this.txtVideoDAR.Text = this.releaseInfo.VI.displayAR;
            this.txtVideoFramerate.Text = this.releaseInfo.VI.framerate;
            this.txtVideoBitrate.Text = this.releaseInfo.VI.bitrate;
            this.cmbVideoCodec.Text = this.releaseInfo.VI.codec;

            // Display audio info.
            bool haventFoundMainAudio = true;
            this.lstAudio.Items.Clear();
            int count = this.releaseInfo.AudioCount;
            for (int i = 0; i < count; i++)
            {
                if (haventFoundMainAudio && !this.releaseInfo.AI[i].AudioCommentary)
                {
                    this.cmbGeneralAudio.Text = this.releaseInfo.AI[0].AudioTitleInfo;
                    haventFoundMainAudio = false;
                }
                this.lstAudio.Items.Add(this.releaseInfo.AI[i].ToString());
            }
            this.TurnRed(this.releaseInfo.AudioContainsUnknownItem, grpAudio);
            if (count > 1)
            {
                this.btnAudioUp.Enabled = true;
                this.btnAudioDown.Enabled = true;
            }
            else
            {
                this.btnAudioUp.Enabled = false;
                this.btnAudioDown.Enabled = false;
            }

            // Display subtitle info.
            this.lstSubtitle.Items.Clear();
            count = this.releaseInfo.SubtitleCount;
            for (int i = 0; i < count; i++)
            {
                this.lstSubtitle.Items.Add(this.releaseInfo.SI[i].ToString());
            }
            this.TurnRed(this.releaseInfo.SubtitleContainsUnknownItem, grpSubtitle);
            if (count > 1)
            {
                this.btnSubtitleUp.Enabled = true;
                this.btnSubtitleDown.Enabled = true;
            }
            else
            {
                this.btnSubtitleUp.Enabled = false;
                this.btnSubtitleDown.Enabled = false;
            }


            // Add default output folder
            txtTargetLocation.Text = new FileInfo(this.txtInputFile.Text).DirectoryName;

            updateReleaseName();

            // Update label colors and set the color of empty items to red
            txtGeneralTitle_TextChanged(this, null);
            cmbGeneralAudio_TextChanged(this, null);
            cmbVideoCodec_SelectedIndexChanged(this, null);
            txtIMDb_TextChanged(this, null);
            txtSourceName_TextChanged(this, null);

            autoGenerate = true;
        }

        private void btnInputBrowse_Click(object sender, EventArgs e)
        {
            this.txtInputFile.Text = openFile();
        }

        private void btnTargetBrowse_Click(object sender, EventArgs e)
        {
            // Displays a FolderBrowserDialog so the user can select a location to put the NFO
            FolderBrowserDialog selectTargetLocation = new FolderBrowserDialog();

            // Set default path if there is an existing path.
            if (txtTargetLocation.Text != "")
            {
                selectTargetLocation.SelectedPath = txtTargetLocation.Text;
            }

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
            this.ResetWindow();
        }

        private void mnsFileOpen_Click(object sender, EventArgs e)
        {
            this.txtInputFile.Text = openFile();
        }

        private void mnsToolsImageUploader_Click(object sender, EventArgs e)
        {
            FrmImageUploader imageUp = new FrmImageUploader();
            imageUp.ShowDialog();
        }
        #endregion

        #region Process
        private bool containsUnknownItems()
        {
            if (this.releaseInfo.AudioContainsUnknownItem)
            {
                return true;
            }

            if (this.releaseInfo.SubtitleContainsUnknownItem)
            {
                return true;
            }

            if (this.txtGeneralTitle.Text == "")
            {
                return true;
            }
            if (this.txtSomeDbLink.Text == "")
            {
                return true;
            }
            if (this.cmbGeneralAudio.Text == "")
            {
                return true;
            }
            if (this.cmbSourceType.Text == "")
            {
                return true;
            }
            if (this.cmbVideoCodec.Text == "")
            {
                return true;
            }
            return false;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (this.cmbNfoTemplate.Items.Count < 1)
            {
                MessageBox.Show(@"Cannot find any template on '.\Template\' folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (containsUnknownItems())
                {
                    if (MessageBox.Show("There are some \"Unknown\" items. Do you want to continue?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }

                string audioCombined = "";
                string subCombined = "";
                string chapters = "";

                try
                {
                    // Combine all the audio info's into one string.
                    audioCombined = this.releaseInfo.AudioInfo;

                    // Combine all the subtitle info's into one string.
                    subCombined = this.releaseInfo.SubtitleInfo;

                    // Convert chapters info.
                    chapters = this.releaseInfo.ChapterInfo;
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
                        this.txtSomeDbLink.Text == "" ? "N/A" : this.txtSomeDbLink.Text,
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
        /// <summary>
        /// Guess the release name from a release which has possibly standard release name.
        /// 
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
                Regex resolutionRgx = new Regex(@"(576)|([0-9]{2,3}0)p");

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
                this.cmbGeneralAudio.Text = "";
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
                            this.cmbGeneralAudio.Text = audioValue;
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
                                    this.cmbGeneralAudio.Text = audioValue;
                                }
                            }
                        }
                    }
                }

                //Special Edition
                this.cmbGeneralEdition.SelectedIndex = 0;
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
                this.txtGeneralTitle.Text = firstIndex < 1 ? "" : (name.Substring(0, firstIndex).Replace('.', ' ').Trim().Replace("  ", " "));
            }
            catch
            {
                SetStatus("Failed to guess release name from file name. Please set them manually");
            }
        }

        private void updateReleaseName()
        {
            // Load form infomation into releaseInfo.GI container.
            this.releaseInfo.GI.imdbLink = this.txtSomeDbLink.Text;
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

        private string openFile()
        {
            // Displays an OpenFileDialog so the user can select an MKV.  
            OpenFileDialog openFileInput = new OpenFileDialog();
            openFileInput.Filter = "mkv media file(*.mkv)|*.mkv|mp4 media file(*.mp4)|*.mp4|all files|*.*";
            openFileInput.ValidateNames = true;
            openFileInput.CheckPathExists = true;
            openFileInput.CheckFileExists = true;
            openFileInput.Title = "Select an Media File";

            if (txtInputFile.Text != "")
            {
                openFileInput.InitialDirectory = Path.GetDirectoryName(txtInputFile.Text);
                openFileInput.FileName = Path.GetFileName(txtInputFile.Text);
            }

            // Show the dialog.  
            // If the user clicked OK in the dialog and a .MKV file was selected,
            //  send the file path to input file textBox.
            if (openFileInput.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return openFileInput.FileName;
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region Status Strip
        private void SetStatus(string status)
        {
            stsStatusLabel.Text = status;
        }
        #endregion

        #region Info Edit Event Handler

        #region --Update Release Name and NFO if happen

        #region ----Mandatory (can turn red if empty)
        private void txtGeneralTitle_TextChanged(object sender, EventArgs e)
        {
            if (autoGenerate)
            {
                updateReleaseName();
            }
            this.TurnRed(this.txtInputFile, lblGeneralTitle);
        }

        private void cmbGeneralAudio_TextChanged(object sender, EventArgs e)
        {
            if (autoGenerate)
            {
                updateReleaseName();
            }
            this.TurnRed(this.cmbGeneralAudio, this.lblGeneralAudio);
        }

        private void cmbVideoCodec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (autoGenerate)
            {
                updateReleaseName();
            }
            this.TurnRed(this.cmbVideoCodec, this.lblVideoCodec);
        }
        #endregion

        #region ----Not Mandatory (can't turn red if empty)
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

        private void cmbSourceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (autoGenerate)
            {
                updateReleaseName();
            }
        }

        private void cmbSeparateChar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (autoGenerate)
            {
                updateReleaseName();
            }
        }
        #endregion

        #endregion

        #region --Update NFO only if happen

        #region ----Mandatory (can turn red if empty)
        private void txtSourceName_TextChanged(object sender, EventArgs e)
        {
            this.TurnRed(txtSourceName, lblSourceName);
        }

        private void txtAudioLanguage_TextChanged(object sender, EventArgs e)
        {
            this.TurnRed(this.txtAudioLanguage, this.lblAudioLanguage);
        }

        private void txtAudioCodec_TextChanged(object sender, EventArgs e)
        {
            this.TurnRed(this.txtAudioCodec, this.lblAudioCodec);
        }

        private void txtAudioChannels_TextChanged(object sender, EventArgs e)
        {
            this.TurnRed(this.txtAudioChannels, this.lblAudioChannels);
        }

        private void txtAudioBitrate_TextChanged(object sender, EventArgs e)
        {
            this.TurnRed(this.txtAudioBitrate, this.lblAudioBitrate);
        }

        private void txtSubtitleLanguage_TextChanged(object sender, EventArgs e)
        {
            this.TurnRed(this.txtSubtitleLanguage, this.lblSubtitleLanguage);
        }

        private void txtSubtitleFormat_TextChanged(object sender, EventArgs e)
        {
            this.TurnRed(this.txtSubtitleFormat, this.lblSubtitleFormat);
        }

        private void txtSubtitleComment_TextChanged(object sender, EventArgs e)
        {
            this.TurnRed(this.txtSubtitleComment, this.lblSubtitleComment);
        }

        private void txtIMDb_TextChanged(object sender, EventArgs e)
        {
            if (this.txtSomeDbLink.Text == "")
            {
                this.btnOpenIMDb.Enabled = false;
            }
            else
            {
                this.btnOpenIMDb.Enabled = true;
            }
            this.TurnRed(this.txtSomeDbLink, this.lblSomeDbLink);
        }
        #endregion

        #region ----Not Mandatory (can't turn red if empty)
        private void chkGeneralChaptersIncluded_CheckedChanged(object sender, EventArgs e)
        {
            if (this.releaseInfo != null)
            {
                this.releaseInfo.ChapterIncluded = chkGeneralChaptersIncluded.Checked;
            }
        }

        private void chkGeneralChaptersNamed_CheckedChanged(object sender, EventArgs e)
        {
            if (this.releaseInfo != null)
            {
                this.releaseInfo.ChapterNamed = chkGeneralChaptersNamed.Checked;
            }
        }
        #endregion

        #region ----Audio & Subtitle Item Edit
        private void chkAudioCommentary_CheckedChanged(object sender, EventArgs e)
        {
            this.txtAudioCommentaryBy.Visible = this.chkAudioCommentary.Checked;
        }

        private void btnAudioUp_Click(object sender, EventArgs e)
        {
            int selected = lstAudio.SelectedIndex;
            if (selected > -1)
            {
                if (selected > 0)
                {
                    SwapListItem(lstAudio, selected, selected - 1);
                    this.releaseInfo.SwapIndex(StreamKind.Audio, selected, selected - 1);
                    lstAudio.SelectedIndex = selected - 1;
                }
            }
        }

        private void btnAudioDown_Click(object sender, EventArgs e)
        {
            int selected = lstAudio.SelectedIndex;
            if (selected > -1)
            {
                if (selected < lstAudio.Items.Count - 1)
                {
                    SwapListItem(lstAudio, selected, selected + 1);
                    this.releaseInfo.SwapIndex(StreamKind.Audio, selected, selected + 1);
                    lstAudio.SelectedIndex = selected + 1;
                }
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
                if (this.lstAudio.SelectedIndex == 0)
                {
                    this.btnAudioUp.Enabled = false;
                }
                else
                {
                    this.btnAudioUp.Enabled = true;
                }
                if (this.lstAudio.SelectedIndex == this.lstAudio.Items.Count - 1)
                {
                    this.btnAudioDown.Enabled = false;
                }
                else
                {
                    this.btnAudioDown.Enabled = true;
                }
                this.txtAudioLanguage.Text = this.releaseInfo.AI[this.releaseInfo.audioIndex[this.lstAudio.SelectedIndex]].AudioLanguage;
                this.txtAudioCodec.Text = this.releaseInfo.AI[this.releaseInfo.audioIndex[this.lstAudio.SelectedIndex]].AudioCodec;
                this.txtAudioChannels.Text = this.releaseInfo.AI[this.releaseInfo.audioIndex[this.lstAudio.SelectedIndex]].AudioChannel;
                this.txtAudioBitrate.Text = this.releaseInfo.AI[this.releaseInfo.audioIndex[this.lstAudio.SelectedIndex]].AudioBitrate;
                this.chkAudioCommentary.Checked = this.releaseInfo.AI[this.releaseInfo.audioIndex[this.lstAudio.SelectedIndex]].AudioCommentary;
                this.txtAudioCommentaryBy.Text = this.releaseInfo.AI[this.releaseInfo.audioIndex[this.lstAudio.SelectedIndex]].AudioCommentator;
            }
        }

        private void btnSubtitleUp_Click(object sender, EventArgs e)
        {
            int selected = lstSubtitle.SelectedIndex;
            if (selected > -1)
            {
                if (selected > 0)
                {
                    SwapListItem(lstSubtitle, selected, selected - 1);
                    this.releaseInfo.SwapIndex(StreamKind.Text, selected, selected - 1);
                    lstSubtitle.SelectedIndex = selected - 1;
                }
            }
        }

        private void btnSubtitleDown_Click(object sender, EventArgs e)
        {
            int selected = lstSubtitle.SelectedIndex;
            if (selected > -1)
            {
                if (selected < lstSubtitle.Items.Count - 1)
                {
                    SwapListItem(lstSubtitle, selected, selected + 1);
                    this.releaseInfo.SwapIndex(StreamKind.Text, selected, selected + 1);
                    lstSubtitle.SelectedIndex = selected + 1;
                }
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
                if (this.lstSubtitle.SelectedIndex == 0)
                {
                    this.btnSubtitleUp.Enabled = false;
                }
                else
                {
                    this.btnSubtitleUp.Enabled = true;
                }
                if (this.lstSubtitle.SelectedIndex == this.lstSubtitle.Items.Count - 1)
                {
                    this.btnSubtitleDown.Enabled = false;
                }
                else
                {
                    this.btnSubtitleDown.Enabled = true;
                }
                this.txtSubtitleLanguage.Text = this.releaseInfo.SI[this.releaseInfo.subtitleIndex[this.lstSubtitle.SelectedIndex]].SubtitleLanguage;
                this.txtSubtitleFormat.Text = this.releaseInfo.SI[this.releaseInfo.subtitleIndex[this.lstSubtitle.SelectedIndex]].SubtitleFormat;
                this.txtSubtitleComment.Text = this.releaseInfo.SI[this.releaseInfo.subtitleIndex[this.lstSubtitle.SelectedIndex]].SubtitleComment;
                this.chkSubtitleForced.Checked = this.releaseInfo.SI[this.releaseInfo.subtitleIndex[this.lstSubtitle.SelectedIndex]].SubtitleForced;
                this.chkSubtitleSDH.Checked = this.releaseInfo.SI[this.releaseInfo.subtitleIndex[this.lstSubtitle.SelectedIndex]].SubtitleSDH;
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
                try
                {
                    this.releaseInfo.AI[this.releaseInfo.audioIndex[editIndex]].UpdateAudioInfo(
                                       this.txtAudioLanguage.Text,
                                       this.txtAudioCodec.Text,
                                       this.txtAudioChannels.Text,
                                       this.txtAudioBitrate.Text,
                                       this.chkAudioCommentary.Checked,
                                       this.txtAudioCommentaryBy.Text);
                    this.lstAudio.Items.RemoveAt(editIndex);
                    this.lstAudio.Items.Insert(editIndex, this.releaseInfo.AI[this.releaseInfo.audioIndex[editIndex]].ToString());
                    this.lstAudio.SelectedIndex = editIndex;
                    this.TurnRed(this.releaseInfo.AudioContainsUnknownItem, grpAudio);
                }
                catch (ArgumentOutOfRangeException aoore)
                {
                    MessageBox.Show(ExceptionUtil.FullMessage(new Exception("[Audio Groupbox Update Error]: Index is out of range when removing or inserting. " + editIndex.ToString() + "vs" + (this.lstAudio.Items.Count - 1).ToString(), aoore)), "Error", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ExceptionUtil.FullMessage(new Exception("[Audio Groupbox Update Error]: Invalid audio channel. " + this.txtAudioChannels.Text, ex)), "Error", MessageBoxButtons.OK); ;
                    this.txtAudioChannels.Text = this.releaseInfo.AI[editIndex].AudioChannel;
                }
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
                this.releaseInfo.SI[this.releaseInfo.subtitleIndex[editIndex]].UpdateSubtitleInfo(
                    this.txtSubtitleLanguage.Text,
                    this.txtSubtitleFormat.Text,
                    this.txtSubtitleComment.Text,
                    this.chkSubtitleForced.Checked,
                    this.chkSubtitleSDH.Checked
                );
                this.lstSubtitle.Items.RemoveAt(editIndex);
                this.lstSubtitle.Items.Insert(editIndex, this.releaseInfo.SI[this.releaseInfo.subtitleIndex[editIndex]].ToString());
                this.lstSubtitle.SelectedIndex = editIndex;
                this.TurnRed(this.releaseInfo.SubtitleContainsUnknownItem, grpSubtitle);
            }
        }
        #endregion

        #endregion

        #endregion

        #region SomeDB
        private void btnSearchIMDb_Click(object sender, EventArgs e)
        {
            switch (this.cmbReleaseCategory.SelectedIndex)
            {
                case 0: // Movie
                    this.SearchIMDb();
                    break;
                case 1: // TV/Season
                    this.SearchTVDb();
                    break;
            }
        }

        private void SearchIMDb()
        {
            IMDbReader IMDb = new IMDbReader();
            IMDb.SearchIMDb(this.txtGeneralTitle.Text, this.cmbGeneralYear.Text);
            SearchResults resultDialog = new SearchResults(this.txtGeneralTitle.Text,
                this.cmbGeneralYear.Text, this.txtSomeDbLink.Text);

            for (int i = 0; i < IMDb.resultCount; i++)
            {
                SingleMatch result = new SingleMatch(resultDialog);
                result.DisplayMovie(IMDb.poster[i], IMDb.title[i], IMDb.year[i], IMDb.IMDbID[i], IMDb.plot[i]);
                if (!IMDb.isResponding)
                {
                    result.btnSelect.Hide();
                }

                resultDialog.flpSomeDbResults.Controls.Add(result);
            }

            resultDialog.ShowDialog();
            this.txtGeneralTitle.Text = resultDialog.selectedTitle;
            this.cmbGeneralYear.Text = resultDialog.selectedYear;
            this.txtSomeDbLink.Text = resultDialog.selectedLink;
        }

        private void SearchTVDb()
        {
            TVDbReader TVDb = new TVDbReader();
            TVDb.Login();
            TVDb.Search(this.txtGeneralTitle.Text);
            SearchResults resultDialog = new SearchResults(this.txtGeneralTitle.Text,
                this.cmbGeneralYear.Text, this.txtSomeDbLink.Text);

            for (int i = 0; i < TVDb.results.match.Length; i++)
            {
                SingleMatch result = new SingleMatch(resultDialog);
                string poster = TVDb.FindPoster(TVDb.results.match[i].ID);
                result.DisplaySeries(poster, TVDb.results.match[i].seriesName, TVDb.results.match[i].firstAired,
                    TVDb.results.match[i].ID, TVDb.results.match[i].overview);
                
                resultDialog.flpSomeDbResults.Controls.Add(result);
            }

            resultDialog.ShowDialog();
            this.txtGeneralTitle.Text = resultDialog.selectedTitle;
            this.cmbGeneralYear.Text = resultDialog.selectedYear;
            this.txtSomeDbLink.Text = resultDialog.selectedLink;
        }

        private void btnOpenIMDb_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.txtSomeDbLink.Text);
        }
        #endregion
    }
}