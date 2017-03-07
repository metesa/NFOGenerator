namespace NFOGenerator.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.btnInputBrowse = new System.Windows.Forms.Button();
            this.lblInputFile = new System.Windows.Forms.Label();
            this.cmbNfoTemplate = new System.Windows.Forms.ComboBox();
            this.lblNfoTemplate = new System.Windows.Forms.Label();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.btnOpenIMDb = new System.Windows.Forms.Button();
            this.btnSearchIMDb = new System.Windows.Forms.Button();
            this.cmbGeneralProper = new System.Windows.Forms.ComboBox();
            this.cmbGeneralHybrid = new System.Windows.Forms.ComboBox();
            this.cmbGeneralEdition = new System.Windows.Forms.ComboBox();
            this.cmbGeneralYear = new System.Windows.Forms.ComboBox();
            this.cmbSeparateChar = new System.Windows.Forms.ComboBox();
            this.cmbGeneralAudio = new System.Windows.Forms.ComboBox();
            this.cmbGeneralResolution = new System.Windows.Forms.ComboBox();
            this.lblGeneralReleaseName = new System.Windows.Forms.Label();
            this.chkGeneralChaptersNamed = new System.Windows.Forms.CheckBox();
            this.txtGeneralReleaseName = new System.Windows.Forms.TextBox();
            this.chkGeneralChaptersIncluded = new System.Windows.Forms.CheckBox();
            this.lblGeneralChapters = new System.Windows.Forms.Label();
            this.lblGeneralAudio = new System.Windows.Forms.Label();
            this.lblGeneralResolution = new System.Windows.Forms.Label();
            this.lblGeneralDuration = new System.Windows.Forms.Label();
            this.lblGeneralHybrid = new System.Windows.Forms.Label();
            this.lblGeneralSize = new System.Windows.Forms.Label();
            this.lblGeneralYear = new System.Windows.Forms.Label();
            this.lblGeneralProper = new System.Windows.Forms.Label();
            this.txtGeneralDuration = new System.Windows.Forms.TextBox();
            this.lblGeneralEdition = new System.Windows.Forms.Label();
            this.txtGeneralSize = new System.Windows.Forms.TextBox();
            this.txtIMDb = new System.Windows.Forms.TextBox();
            this.lblIMDb = new System.Windows.Forms.Label();
            this.txtGeneralTitle = new System.Windows.Forms.TextBox();
            this.lblGeneralTitle = new System.Windows.Forms.Label();
            this.grpAudio = new System.Windows.Forms.GroupBox();
            this.chkAudioCommentary = new System.Windows.Forms.CheckBox();
            this.btnAudioDown = new System.Windows.Forms.Button();
            this.btnAudioUp = new System.Windows.Forms.Button();
            this.btnAudioEdit = new System.Windows.Forms.Button();
            this.lstAudio = new System.Windows.Forms.ListBox();
            this.txtAudioCommentaryBy = new System.Windows.Forms.TextBox();
            this.txtAudioBitrate = new System.Windows.Forms.TextBox();
            this.txtAudioChannels = new System.Windows.Forms.TextBox();
            this.lblAudioBitrate = new System.Windows.Forms.Label();
            this.txtAudioCodec = new System.Windows.Forms.TextBox();
            this.lblAudioChannels = new System.Windows.Forms.Label();
            this.lblAudioCodec = new System.Windows.Forms.Label();
            this.txtAudioLanguage = new System.Windows.Forms.TextBox();
            this.lblAudioLanguage = new System.Windows.Forms.Label();
            this.grpSubtitle = new System.Windows.Forms.GroupBox();
            this.btnSubtitleEdit = new System.Windows.Forms.Button();
            this.lstSubtitle = new System.Windows.Forms.ListBox();
            this.txtSubtitleComment = new System.Windows.Forms.TextBox();
            this.txtSubtitleFormat = new System.Windows.Forms.TextBox();
            this.lblSubtitleComment = new System.Windows.Forms.Label();
            this.lblSubtitleFormat = new System.Windows.Forms.Label();
            this.txtSubtitleLanguage = new System.Windows.Forms.TextBox();
            this.chkSubtitleSDH = new System.Windows.Forms.CheckBox();
            this.lblSubtitleLanguage = new System.Windows.Forms.Label();
            this.chkSubtitleForced = new System.Windows.Forms.CheckBox();
            this.txtTargetLocation = new System.Windows.Forms.TextBox();
            this.lblTargetLocation = new System.Windows.Forms.Label();
            this.txtVideoBitrate = new System.Windows.Forms.TextBox();
            this.lblVideoFramerate = new System.Windows.Forms.Label();
            this.lblVideoBitrate = new System.Windows.Forms.Label();
            this.lblVideoNote = new System.Windows.Forms.Label();
            this.txtVideoNote = new System.Windows.Forms.TextBox();
            this.lblVideoWidth = new System.Windows.Forms.Label();
            this.txtVideoWidth = new System.Windows.Forms.TextBox();
            this.grpVideo = new System.Windows.Forms.GroupBox();
            this.cmbVideoCodec = new System.Windows.Forms.ComboBox();
            this.txtVideoDAR = new System.Windows.Forms.TextBox();
            this.lblVideoDAR = new System.Windows.Forms.Label();
            this.txtVideoHeight = new System.Windows.Forms.TextBox();
            this.lblVideoHeight = new System.Windows.Forms.Label();
            this.lblVideoCodec = new System.Windows.Forms.Label();
            this.txtVideoFramerate = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnTargetBrowse = new System.Windows.Forms.Button();
            this.grpSource = new System.Windows.Forms.GroupBox();
            this.cmbSourceResolution = new System.Windows.Forms.ComboBox();
            this.cmbSourceType = new System.Windows.Forms.ComboBox();
            this.lblSourceType = new System.Windows.Forms.Label();
            this.lblSourceName = new System.Windows.Forms.Label();
            this.btnSourceGuess = new System.Windows.Forms.Button();
            this.txtSourceName = new System.Windows.Forms.TextBox();
            this.lblSourceResolution = new System.Windows.Forms.Label();
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.mnsFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsFileClear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsFileMediaInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsFileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnsFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsToolsImageUploader = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsToolsZonesCommand = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsToolsAutoTest = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsHelpAboutUs = new System.Windows.Forms.ToolStripMenuItem();
            this.stsStatus = new System.Windows.Forms.StatusStrip();
            this.stsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tblAudioAndSubtitle = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMovieEncode = new System.Windows.Forms.Panel();
            this.pnlOutput = new System.Windows.Forms.Panel();
            this.lblReleaseCategory = new System.Windows.Forms.Label();
            this.cmbReleaseCategory = new System.Windows.Forms.ComboBox();
            this.cmbReleaseMedium = new System.Windows.Forms.ComboBox();
            this.lblReleaseMedium = new System.Windows.Forms.Label();
            this.pnlReleaseType = new System.Windows.Forms.Panel();
            this.grpInput.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.grpAudio.SuspendLayout();
            this.grpSubtitle.SuspendLayout();
            this.grpVideo.SuspendLayout();
            this.grpSource.SuspendLayout();
            this.mnsMain.SuspendLayout();
            this.stsStatus.SuspendLayout();
            this.tblAudioAndSubtitle.SuspendLayout();
            this.pnlMovieEncode.SuspendLayout();
            this.pnlOutput.SuspendLayout();
            this.pnlReleaseType.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInputFile
            // 
            this.txtInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputFile.Location = new System.Drawing.Point(83, 20);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.ReadOnly = true;
            this.txtInputFile.Size = new System.Drawing.Size(289, 21);
            this.txtInputFile.TabIndex = 0;
            this.txtInputFile.TextChanged += new System.EventHandler(this.txtInputFile_TextChanged);
            // 
            // grpInput
            // 
            this.grpInput.AllowDrop = true;
            this.grpInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInput.Controls.Add(this.btnInputBrowse);
            this.grpInput.Controls.Add(this.lblInputFile);
            this.grpInput.Controls.Add(this.txtInputFile);
            this.grpInput.Controls.Add(this.cmbNfoTemplate);
            this.grpInput.Controls.Add(this.lblNfoTemplate);
            this.grpInput.Location = new System.Drawing.Point(9, 52);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(662, 54);
            this.grpInput.TabIndex = 1;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Input";
            this.grpInput.DragDrop += new System.Windows.Forms.DragEventHandler(this.grpInput_DragDrop);
            this.grpInput.DragEnter += new System.Windows.Forms.DragEventHandler(this.grpInput_DragEnter);
            // 
            // btnInputBrowse
            // 
            this.btnInputBrowse.Location = new System.Drawing.Point(378, 19);
            this.btnInputBrowse.Name = "btnInputBrowse";
            this.btnInputBrowse.Size = new System.Drawing.Size(75, 21);
            this.btnInputBrowse.TabIndex = 9;
            this.btnInputBrowse.Text = "Browse";
            this.btnInputBrowse.UseVisualStyleBackColor = true;
            this.btnInputBrowse.Click += new System.EventHandler(this.btnInputBrowse_Click);
            // 
            // lblInputFile
            // 
            this.lblInputFile.AutoSize = true;
            this.lblInputFile.Location = new System.Drawing.Point(6, 23);
            this.lblInputFile.Name = "lblInputFile";
            this.lblInputFile.Size = new System.Drawing.Size(71, 12);
            this.lblInputFile.TabIndex = 1;
            this.lblInputFile.Text = "Media File:";
            // 
            // cmbNfoTemplate
            // 
            this.cmbNfoTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbNfoTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNfoTemplate.FormattingEnabled = true;
            this.cmbNfoTemplate.Location = new System.Drawing.Point(536, 20);
            this.cmbNfoTemplate.Name = "cmbNfoTemplate";
            this.cmbNfoTemplate.Size = new System.Drawing.Size(120, 20);
            this.cmbNfoTemplate.TabIndex = 8;
            // 
            // lblNfoTemplate
            // 
            this.lblNfoTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNfoTemplate.AutoSize = true;
            this.lblNfoTemplate.Location = new System.Drawing.Point(459, 23);
            this.lblNfoTemplate.Name = "lblNfoTemplate";
            this.lblNfoTemplate.Size = new System.Drawing.Size(59, 12);
            this.lblNfoTemplate.TabIndex = 4;
            this.lblNfoTemplate.Text = "Template:";
            // 
            // grpGeneral
            // 
            this.grpGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGeneral.Controls.Add(this.btnOpenIMDb);
            this.grpGeneral.Controls.Add(this.btnSearchIMDb);
            this.grpGeneral.Controls.Add(this.cmbGeneralProper);
            this.grpGeneral.Controls.Add(this.cmbGeneralHybrid);
            this.grpGeneral.Controls.Add(this.cmbGeneralEdition);
            this.grpGeneral.Controls.Add(this.cmbGeneralYear);
            this.grpGeneral.Controls.Add(this.cmbSeparateChar);
            this.grpGeneral.Controls.Add(this.cmbGeneralAudio);
            this.grpGeneral.Controls.Add(this.cmbGeneralResolution);
            this.grpGeneral.Controls.Add(this.lblGeneralReleaseName);
            this.grpGeneral.Controls.Add(this.chkGeneralChaptersNamed);
            this.grpGeneral.Controls.Add(this.txtGeneralReleaseName);
            this.grpGeneral.Controls.Add(this.chkGeneralChaptersIncluded);
            this.grpGeneral.Controls.Add(this.lblGeneralChapters);
            this.grpGeneral.Controls.Add(this.lblGeneralAudio);
            this.grpGeneral.Controls.Add(this.lblGeneralResolution);
            this.grpGeneral.Controls.Add(this.lblGeneralDuration);
            this.grpGeneral.Controls.Add(this.lblGeneralHybrid);
            this.grpGeneral.Controls.Add(this.lblGeneralSize);
            this.grpGeneral.Controls.Add(this.lblGeneralYear);
            this.grpGeneral.Controls.Add(this.lblGeneralProper);
            this.grpGeneral.Controls.Add(this.txtGeneralDuration);
            this.grpGeneral.Controls.Add(this.lblGeneralEdition);
            this.grpGeneral.Controls.Add(this.txtGeneralSize);
            this.grpGeneral.Controls.Add(this.txtIMDb);
            this.grpGeneral.Controls.Add(this.lblIMDb);
            this.grpGeneral.Controls.Add(this.txtGeneralTitle);
            this.grpGeneral.Controls.Add(this.lblGeneralTitle);
            this.grpGeneral.Location = new System.Drawing.Point(3, 5);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(662, 174);
            this.grpGeneral.TabIndex = 2;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // btnOpenIMDb
            // 
            this.btnOpenIMDb.Location = new System.Drawing.Point(581, 39);
            this.btnOpenIMDb.Name = "btnOpenIMDb";
            this.btnOpenIMDb.Size = new System.Drawing.Size(75, 23);
            this.btnOpenIMDb.TabIndex = 11;
            this.btnOpenIMDb.Text = "Open";
            this.btnOpenIMDb.UseVisualStyleBackColor = true;
            this.btnOpenIMDb.Click += new System.EventHandler(this.btnOpenIMDb_Click);
            // 
            // btnSearchIMDb
            // 
            this.btnSearchIMDb.Location = new System.Drawing.Point(459, 39);
            this.btnSearchIMDb.Name = "btnSearchIMDb";
            this.btnSearchIMDb.Size = new System.Drawing.Size(116, 23);
            this.btnSearchIMDb.TabIndex = 3;
            this.btnSearchIMDb.Text = "Search by Title";
            this.btnSearchIMDb.UseVisualStyleBackColor = true;
            this.btnSearchIMDb.Click += new System.EventHandler(this.btnSearchIMDb_Click);
            // 
            // cmbGeneralProper
            // 
            this.cmbGeneralProper.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbGeneralProper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGeneralProper.FormattingEnabled = true;
            this.cmbGeneralProper.Items.AddRange(new object[] {
            "",
            "PROPER",
            "REPACK",
            "REPACK PROPER"});
            this.cmbGeneralProper.Location = new System.Drawing.Point(289, 94);
            this.cmbGeneralProper.Name = "cmbGeneralProper";
            this.cmbGeneralProper.Size = new System.Drawing.Size(126, 20);
            this.cmbGeneralProper.TabIndex = 8;
            this.cmbGeneralProper.SelectedIndexChanged += new System.EventHandler(this.cmbGeneralProper_SelectedIndexChanged);
            // 
            // cmbGeneralHybrid
            // 
            this.cmbGeneralHybrid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGeneralHybrid.FormattingEnabled = true;
            this.cmbGeneralHybrid.Items.AddRange(new object[] {
            "",
            "Hybrid"});
            this.cmbGeneralHybrid.Location = new System.Drawing.Point(83, 94);
            this.cmbGeneralHybrid.Name = "cmbGeneralHybrid";
            this.cmbGeneralHybrid.Size = new System.Drawing.Size(91, 20);
            this.cmbGeneralHybrid.TabIndex = 8;
            this.cmbGeneralHybrid.SelectedIndexChanged += new System.EventHandler(this.cmbGeneralHybrid_SelectedIndexChanged);
            // 
            // cmbGeneralEdition
            // 
            this.cmbGeneralEdition.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbGeneralEdition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGeneralEdition.FormattingEnabled = true;
            this.cmbGeneralEdition.Items.AddRange(new object[] {
            "",
            "Theatrical.Cut",
            "Director\'s.Cut",
            "Extended.Cut",
            "Unrated",
            "Criterion"});
            this.cmbGeneralEdition.Location = new System.Drawing.Point(289, 68);
            this.cmbGeneralEdition.Name = "cmbGeneralEdition";
            this.cmbGeneralEdition.Size = new System.Drawing.Size(126, 20);
            this.cmbGeneralEdition.TabIndex = 8;
            this.cmbGeneralEdition.SelectedIndexChanged += new System.EventHandler(this.cmbGeneralEdition_SelectedIndexChanged);
            // 
            // cmbGeneralYear
            // 
            this.cmbGeneralYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGeneralYear.FormattingEnabled = true;
            this.cmbGeneralYear.Location = new System.Drawing.Point(83, 68);
            this.cmbGeneralYear.Name = "cmbGeneralYear";
            this.cmbGeneralYear.Size = new System.Drawing.Size(91, 20);
            this.cmbGeneralYear.TabIndex = 8;
            this.cmbGeneralYear.SelectedIndexChanged += new System.EventHandler(this.cmbGeneralYear_SelectedIndexChanged);
            // 
            // cmbSeparateChar
            // 
            this.cmbSeparateChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSeparateChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeparateChar.FormattingEnabled = true;
            this.cmbSeparateChar.Items.AddRange(new object[] {
            "Space",
            "Dot"});
            this.cmbSeparateChar.Location = new System.Drawing.Point(581, 147);
            this.cmbSeparateChar.Name = "cmbSeparateChar";
            this.cmbSeparateChar.Size = new System.Drawing.Size(75, 20);
            this.cmbSeparateChar.TabIndex = 8;
            this.cmbSeparateChar.SelectedIndexChanged += new System.EventHandler(this.cmbSeparateChar_SelectedIndexChanged);
            // 
            // cmbGeneralAudio
            // 
            this.cmbGeneralAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGeneralAudio.FormattingEnabled = true;
            this.cmbGeneralAudio.Items.AddRange(new object[] {
            "DTS",
            "DTS-ES",
            "DD5.1",
            "DD2.1",
            "DD2.0",
            "AAC2.0",
            "AAC1.0",
            "FLAC2.0",
            "FLAC1.0"});
            this.cmbGeneralAudio.Location = new System.Drawing.Point(536, 94);
            this.cmbGeneralAudio.Name = "cmbGeneralAudio";
            this.cmbGeneralAudio.Size = new System.Drawing.Size(120, 20);
            this.cmbGeneralAudio.TabIndex = 8;
            this.cmbGeneralAudio.SelectedIndexChanged += new System.EventHandler(this.cmbGeneralAudio_SelectedIndexChanged);
            this.cmbGeneralAudio.TextChanged += new System.EventHandler(this.cmbGeneralAudio_TextChanged);
            // 
            // cmbGeneralResolution
            // 
            this.cmbGeneralResolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGeneralResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGeneralResolution.FormattingEnabled = true;
            this.cmbGeneralResolution.Items.AddRange(new object[] {
            "2160p",
            "1080p",
            "720p",
            "576p",
            "480p"});
            this.cmbGeneralResolution.Location = new System.Drawing.Point(536, 68);
            this.cmbGeneralResolution.Name = "cmbGeneralResolution";
            this.cmbGeneralResolution.Size = new System.Drawing.Size(120, 20);
            this.cmbGeneralResolution.TabIndex = 8;
            this.cmbGeneralResolution.SelectedIndexChanged += new System.EventHandler(this.cmbGeneralResolution_SelectedIndexChanged);
            // 
            // lblGeneralReleaseName
            // 
            this.lblGeneralReleaseName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGeneralReleaseName.AutoSize = true;
            this.lblGeneralReleaseName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGeneralReleaseName.Location = new System.Drawing.Point(6, 151);
            this.lblGeneralReleaseName.Name = "lblGeneralReleaseName";
            this.lblGeneralReleaseName.Size = new System.Drawing.Size(68, 12);
            this.lblGeneralReleaseName.TabIndex = 7;
            this.lblGeneralReleaseName.Text = "RLZ Name:";
            // 
            // chkGeneralChaptersNamed
            // 
            this.chkGeneralChaptersNamed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGeneralChaptersNamed.AutoSize = true;
            this.chkGeneralChaptersNamed.Location = new System.Drawing.Point(602, 122);
            this.chkGeneralChaptersNamed.Name = "chkGeneralChaptersNamed";
            this.chkGeneralChaptersNamed.Size = new System.Drawing.Size(54, 16);
            this.chkGeneralChaptersNamed.TabIndex = 10;
            this.chkGeneralChaptersNamed.Text = "Named";
            this.chkGeneralChaptersNamed.UseVisualStyleBackColor = true;
            this.chkGeneralChaptersNamed.CheckedChanged += new System.EventHandler(this.chkGeneralChaptersNamed_CheckedChanged);
            // 
            // txtGeneralReleaseName
            // 
            this.txtGeneralReleaseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGeneralReleaseName.Location = new System.Drawing.Point(83, 148);
            this.txtGeneralReleaseName.Name = "txtGeneralReleaseName";
            this.txtGeneralReleaseName.Size = new System.Drawing.Size(492, 21);
            this.txtGeneralReleaseName.TabIndex = 6;
            // 
            // chkGeneralChaptersIncluded
            // 
            this.chkGeneralChaptersIncluded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGeneralChaptersIncluded.AutoSize = true;
            this.chkGeneralChaptersIncluded.Checked = true;
            this.chkGeneralChaptersIncluded.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGeneralChaptersIncluded.Location = new System.Drawing.Point(524, 122);
            this.chkGeneralChaptersIncluded.Name = "chkGeneralChaptersIncluded";
            this.chkGeneralChaptersIncluded.Size = new System.Drawing.Size(72, 16);
            this.chkGeneralChaptersIncluded.TabIndex = 10;
            this.chkGeneralChaptersIncluded.Text = "Included";
            this.chkGeneralChaptersIncluded.UseVisualStyleBackColor = true;
            this.chkGeneralChaptersIncluded.CheckedChanged += new System.EventHandler(this.chkGeneralChaptersIncluded_CheckedChanged);
            // 
            // lblGeneralChapters
            // 
            this.lblGeneralChapters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGeneralChapters.AutoSize = true;
            this.lblGeneralChapters.Location = new System.Drawing.Point(459, 123);
            this.lblGeneralChapters.Name = "lblGeneralChapters";
            this.lblGeneralChapters.Size = new System.Drawing.Size(59, 12);
            this.lblGeneralChapters.TabIndex = 9;
            this.lblGeneralChapters.Text = "Chapters:";
            // 
            // lblGeneralAudio
            // 
            this.lblGeneralAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGeneralAudio.AutoSize = true;
            this.lblGeneralAudio.ForeColor = System.Drawing.Color.Black;
            this.lblGeneralAudio.Location = new System.Drawing.Point(459, 97);
            this.lblGeneralAudio.Name = "lblGeneralAudio";
            this.lblGeneralAudio.Size = new System.Drawing.Size(41, 12);
            this.lblGeneralAudio.TabIndex = 4;
            this.lblGeneralAudio.Text = "Audio:";
            // 
            // lblGeneralResolution
            // 
            this.lblGeneralResolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGeneralResolution.AutoSize = true;
            this.lblGeneralResolution.Location = new System.Drawing.Point(459, 71);
            this.lblGeneralResolution.Name = "lblGeneralResolution";
            this.lblGeneralResolution.Size = new System.Drawing.Size(71, 12);
            this.lblGeneralResolution.TabIndex = 4;
            this.lblGeneralResolution.Text = "Resolution:";
            // 
            // lblGeneralDuration
            // 
            this.lblGeneralDuration.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblGeneralDuration.AutoSize = true;
            this.lblGeneralDuration.Location = new System.Drawing.Point(224, 123);
            this.lblGeneralDuration.Name = "lblGeneralDuration";
            this.lblGeneralDuration.Size = new System.Drawing.Size(59, 12);
            this.lblGeneralDuration.TabIndex = 4;
            this.lblGeneralDuration.Text = "Duration:";
            // 
            // lblGeneralHybrid
            // 
            this.lblGeneralHybrid.AutoSize = true;
            this.lblGeneralHybrid.Location = new System.Drawing.Point(6, 97);
            this.lblGeneralHybrid.Name = "lblGeneralHybrid";
            this.lblGeneralHybrid.Size = new System.Drawing.Size(47, 12);
            this.lblGeneralHybrid.TabIndex = 4;
            this.lblGeneralHybrid.Text = "Hybrid:";
            // 
            // lblGeneralSize
            // 
            this.lblGeneralSize.AutoSize = true;
            this.lblGeneralSize.Location = new System.Drawing.Point(6, 123);
            this.lblGeneralSize.Name = "lblGeneralSize";
            this.lblGeneralSize.Size = new System.Drawing.Size(35, 12);
            this.lblGeneralSize.TabIndex = 4;
            this.lblGeneralSize.Text = "Size:";
            // 
            // lblGeneralYear
            // 
            this.lblGeneralYear.AutoSize = true;
            this.lblGeneralYear.Location = new System.Drawing.Point(6, 71);
            this.lblGeneralYear.Name = "lblGeneralYear";
            this.lblGeneralYear.Size = new System.Drawing.Size(35, 12);
            this.lblGeneralYear.TabIndex = 4;
            this.lblGeneralYear.Text = "Year:";
            // 
            // lblGeneralProper
            // 
            this.lblGeneralProper.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblGeneralProper.AutoSize = true;
            this.lblGeneralProper.Location = new System.Drawing.Point(224, 97);
            this.lblGeneralProper.Name = "lblGeneralProper";
            this.lblGeneralProper.Size = new System.Drawing.Size(47, 12);
            this.lblGeneralProper.TabIndex = 2;
            this.lblGeneralProper.Text = "Proper:";
            // 
            // txtGeneralDuration
            // 
            this.txtGeneralDuration.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtGeneralDuration.Location = new System.Drawing.Point(289, 120);
            this.txtGeneralDuration.Name = "txtGeneralDuration";
            this.txtGeneralDuration.ReadOnly = true;
            this.txtGeneralDuration.Size = new System.Drawing.Size(126, 21);
            this.txtGeneralDuration.TabIndex = 5;
            // 
            // lblGeneralEdition
            // 
            this.lblGeneralEdition.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblGeneralEdition.AutoSize = true;
            this.lblGeneralEdition.Location = new System.Drawing.Point(224, 71);
            this.lblGeneralEdition.Name = "lblGeneralEdition";
            this.lblGeneralEdition.Size = new System.Drawing.Size(53, 12);
            this.lblGeneralEdition.TabIndex = 2;
            this.lblGeneralEdition.Text = "Edition:";
            // 
            // txtGeneralSize
            // 
            this.txtGeneralSize.Location = new System.Drawing.Point(83, 120);
            this.txtGeneralSize.Name = "txtGeneralSize";
            this.txtGeneralSize.ReadOnly = true;
            this.txtGeneralSize.Size = new System.Drawing.Size(91, 21);
            this.txtGeneralSize.TabIndex = 5;
            // 
            // txtIMDb
            // 
            this.txtIMDb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIMDb.Location = new System.Drawing.Point(83, 41);
            this.txtIMDb.Name = "txtIMDb";
            this.txtIMDb.Size = new System.Drawing.Size(370, 21);
            this.txtIMDb.TabIndex = 1;
            this.txtIMDb.TextChanged += new System.EventHandler(this.txtIMDb_TextChanged);
            // 
            // lblIMDb
            // 
            this.lblIMDb.AutoSize = true;
            this.lblIMDb.ForeColor = System.Drawing.Color.Black;
            this.lblIMDb.Location = new System.Drawing.Point(6, 44);
            this.lblIMDb.Name = "lblIMDb";
            this.lblIMDb.Size = new System.Drawing.Size(65, 12);
            this.lblIMDb.TabIndex = 0;
            this.lblIMDb.Text = "IMDb Link:";
            // 
            // txtGeneralTitle
            // 
            this.txtGeneralTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGeneralTitle.Location = new System.Drawing.Point(83, 14);
            this.txtGeneralTitle.Name = "txtGeneralTitle";
            this.txtGeneralTitle.Size = new System.Drawing.Size(573, 21);
            this.txtGeneralTitle.TabIndex = 1;
            this.txtGeneralTitle.TextChanged += new System.EventHandler(this.txtGeneralTitle_TextChanged);
            // 
            // lblGeneralTitle
            // 
            this.lblGeneralTitle.AutoSize = true;
            this.lblGeneralTitle.ForeColor = System.Drawing.Color.Black;
            this.lblGeneralTitle.Location = new System.Drawing.Point(6, 17);
            this.lblGeneralTitle.Name = "lblGeneralTitle";
            this.lblGeneralTitle.Size = new System.Drawing.Size(41, 12);
            this.lblGeneralTitle.TabIndex = 0;
            this.lblGeneralTitle.Text = "Title:";
            // 
            // grpAudio
            // 
            this.grpAudio.Controls.Add(this.chkAudioCommentary);
            this.grpAudio.Controls.Add(this.btnAudioDown);
            this.grpAudio.Controls.Add(this.btnAudioUp);
            this.grpAudio.Controls.Add(this.btnAudioEdit);
            this.grpAudio.Controls.Add(this.lstAudio);
            this.grpAudio.Controls.Add(this.txtAudioCommentaryBy);
            this.grpAudio.Controls.Add(this.txtAudioBitrate);
            this.grpAudio.Controls.Add(this.txtAudioChannels);
            this.grpAudio.Controls.Add(this.lblAudioBitrate);
            this.grpAudio.Controls.Add(this.txtAudioCodec);
            this.grpAudio.Controls.Add(this.lblAudioChannels);
            this.grpAudio.Controls.Add(this.lblAudioCodec);
            this.grpAudio.Controls.Add(this.txtAudioLanguage);
            this.grpAudio.Controls.Add(this.lblAudioLanguage);
            this.grpAudio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAudio.ForeColor = System.Drawing.Color.Black;
            this.grpAudio.Location = new System.Drawing.Point(3, 3);
            this.grpAudio.Name = "grpAudio";
            this.grpAudio.Size = new System.Drawing.Size(325, 179);
            this.grpAudio.TabIndex = 11;
            this.grpAudio.TabStop = false;
            this.grpAudio.Text = "Audio";
            // 
            // chkAudioCommentary
            // 
            this.chkAudioCommentary.AutoSize = true;
            this.chkAudioCommentary.Location = new System.Drawing.Point(8, 70);
            this.chkAudioCommentary.Name = "chkAudioCommentary";
            this.chkAudioCommentary.Size = new System.Drawing.Size(84, 16);
            this.chkAudioCommentary.TabIndex = 8;
            this.chkAudioCommentary.Text = "Commentary";
            this.chkAudioCommentary.UseVisualStyleBackColor = true;
            this.chkAudioCommentary.CheckedChanged += new System.EventHandler(this.chkAudioCommentary_CheckedChanged);
            // 
            // btnAudioDown
            // 
            this.btnAudioDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAudioDown.Enabled = false;
            this.btnAudioDown.Location = new System.Drawing.Point(117, 95);
            this.btnAudioDown.Name = "btnAudioDown";
            this.btnAudioDown.Size = new System.Drawing.Size(89, 21);
            this.btnAudioDown.TabIndex = 7;
            this.btnAudioDown.Text = "Move Down";
            this.btnAudioDown.UseVisualStyleBackColor = true;
            // 
            // btnAudioUp
            // 
            this.btnAudioUp.Enabled = false;
            this.btnAudioUp.Location = new System.Drawing.Point(8, 95);
            this.btnAudioUp.Name = "btnAudioUp";
            this.btnAudioUp.Size = new System.Drawing.Size(89, 21);
            this.btnAudioUp.TabIndex = 7;
            this.btnAudioUp.Text = "Move Up";
            this.btnAudioUp.UseVisualStyleBackColor = true;
            // 
            // btnAudioEdit
            // 
            this.btnAudioEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAudioEdit.Location = new System.Drawing.Point(227, 95);
            this.btnAudioEdit.Name = "btnAudioEdit";
            this.btnAudioEdit.Size = new System.Drawing.Size(89, 21);
            this.btnAudioEdit.TabIndex = 7;
            this.btnAudioEdit.Text = "Edit Audio";
            this.btnAudioEdit.UseVisualStyleBackColor = true;
            this.btnAudioEdit.Click += new System.EventHandler(this.btnAudioEdit_Click);
            // 
            // lstAudio
            // 
            this.lstAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAudio.FormattingEnabled = true;
            this.lstAudio.HorizontalScrollbar = true;
            this.lstAudio.ItemHeight = 12;
            this.lstAudio.Location = new System.Drawing.Point(8, 125);
            this.lstAudio.Name = "lstAudio";
            this.lstAudio.Size = new System.Drawing.Size(308, 40);
            this.lstAudio.TabIndex = 6;
            this.lstAudio.SelectedIndexChanged += new System.EventHandler(this.lstAudio_SelectedIndexChanged);
            // 
            // txtAudioCommentaryBy
            // 
            this.txtAudioCommentaryBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAudioCommentaryBy.Location = new System.Drawing.Point(98, 68);
            this.txtAudioCommentaryBy.Name = "txtAudioCommentaryBy";
            this.txtAudioCommentaryBy.Size = new System.Drawing.Size(218, 21);
            this.txtAudioCommentaryBy.TabIndex = 5;
            this.txtAudioCommentaryBy.Visible = false;
            // 
            // txtAudioBitrate
            // 
            this.txtAudioBitrate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAudioBitrate.Location = new System.Drawing.Point(228, 41);
            this.txtAudioBitrate.Name = "txtAudioBitrate";
            this.txtAudioBitrate.Size = new System.Drawing.Size(88, 21);
            this.txtAudioBitrate.TabIndex = 5;
            // 
            // txtAudioChannels
            // 
            this.txtAudioChannels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAudioChannels.Location = new System.Drawing.Point(228, 14);
            this.txtAudioChannels.Name = "txtAudioChannels";
            this.txtAudioChannels.Size = new System.Drawing.Size(88, 21);
            this.txtAudioChannels.TabIndex = 5;
            // 
            // lblAudioBitrate
            // 
            this.lblAudioBitrate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAudioBitrate.AutoSize = true;
            this.lblAudioBitrate.Location = new System.Drawing.Point(163, 44);
            this.lblAudioBitrate.Name = "lblAudioBitrate";
            this.lblAudioBitrate.Size = new System.Drawing.Size(53, 12);
            this.lblAudioBitrate.TabIndex = 4;
            this.lblAudioBitrate.Text = "Bitrate:";
            // 
            // txtAudioCodec
            // 
            this.txtAudioCodec.Location = new System.Drawing.Point(83, 41);
            this.txtAudioCodec.Name = "txtAudioCodec";
            this.txtAudioCodec.Size = new System.Drawing.Size(70, 21);
            this.txtAudioCodec.TabIndex = 5;
            // 
            // lblAudioChannels
            // 
            this.lblAudioChannels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAudioChannels.AutoSize = true;
            this.lblAudioChannels.Location = new System.Drawing.Point(163, 17);
            this.lblAudioChannels.Name = "lblAudioChannels";
            this.lblAudioChannels.Size = new System.Drawing.Size(59, 12);
            this.lblAudioChannels.TabIndex = 4;
            this.lblAudioChannels.Text = "Channels:";
            // 
            // lblAudioCodec
            // 
            this.lblAudioCodec.AutoSize = true;
            this.lblAudioCodec.Location = new System.Drawing.Point(6, 44);
            this.lblAudioCodec.Name = "lblAudioCodec";
            this.lblAudioCodec.Size = new System.Drawing.Size(41, 12);
            this.lblAudioCodec.TabIndex = 4;
            this.lblAudioCodec.Text = "Codec:";
            // 
            // txtAudioLanguage
            // 
            this.txtAudioLanguage.Location = new System.Drawing.Point(83, 14);
            this.txtAudioLanguage.Name = "txtAudioLanguage";
            this.txtAudioLanguage.Size = new System.Drawing.Size(70, 21);
            this.txtAudioLanguage.TabIndex = 1;
            // 
            // lblAudioLanguage
            // 
            this.lblAudioLanguage.AutoSize = true;
            this.lblAudioLanguage.Location = new System.Drawing.Point(6, 17);
            this.lblAudioLanguage.Name = "lblAudioLanguage";
            this.lblAudioLanguage.Size = new System.Drawing.Size(59, 12);
            this.lblAudioLanguage.TabIndex = 0;
            this.lblAudioLanguage.Text = "Language:";
            // 
            // grpSubtitle
            // 
            this.grpSubtitle.Controls.Add(this.btnSubtitleEdit);
            this.grpSubtitle.Controls.Add(this.lstSubtitle);
            this.grpSubtitle.Controls.Add(this.txtSubtitleComment);
            this.grpSubtitle.Controls.Add(this.txtSubtitleFormat);
            this.grpSubtitle.Controls.Add(this.lblSubtitleComment);
            this.grpSubtitle.Controls.Add(this.lblSubtitleFormat);
            this.grpSubtitle.Controls.Add(this.txtSubtitleLanguage);
            this.grpSubtitle.Controls.Add(this.chkSubtitleSDH);
            this.grpSubtitle.Controls.Add(this.lblSubtitleLanguage);
            this.grpSubtitle.Controls.Add(this.chkSubtitleForced);
            this.grpSubtitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSubtitle.Location = new System.Drawing.Point(334, 3);
            this.grpSubtitle.Name = "grpSubtitle";
            this.grpSubtitle.Size = new System.Drawing.Size(325, 179);
            this.grpSubtitle.TabIndex = 12;
            this.grpSubtitle.TabStop = false;
            this.grpSubtitle.Text = "Subtitle";
            // 
            // btnSubtitleEdit
            // 
            this.btnSubtitleEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubtitleEdit.Location = new System.Drawing.Point(249, 68);
            this.btnSubtitleEdit.Name = "btnSubtitleEdit";
            this.btnSubtitleEdit.Size = new System.Drawing.Size(70, 21);
            this.btnSubtitleEdit.TabIndex = 7;
            this.btnSubtitleEdit.Text = "Edit";
            this.btnSubtitleEdit.UseVisualStyleBackColor = true;
            this.btnSubtitleEdit.Click += new System.EventHandler(this.btnSubtitleEdit_Click);
            // 
            // lstSubtitle
            // 
            this.lstSubtitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSubtitle.FormattingEnabled = true;
            this.lstSubtitle.HorizontalScrollbar = true;
            this.lstSubtitle.ItemHeight = 12;
            this.lstSubtitle.Location = new System.Drawing.Point(6, 101);
            this.lstSubtitle.Name = "lstSubtitle";
            this.lstSubtitle.Size = new System.Drawing.Size(313, 64);
            this.lstSubtitle.TabIndex = 6;
            this.lstSubtitle.SelectedIndexChanged += new System.EventHandler(this.lstSubtitle_SelectedIndexChanged);
            // 
            // txtSubtitleComment
            // 
            this.txtSubtitleComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubtitleComment.Location = new System.Drawing.Point(83, 68);
            this.txtSubtitleComment.Name = "txtSubtitleComment";
            this.txtSubtitleComment.Size = new System.Drawing.Size(158, 21);
            this.txtSubtitleComment.TabIndex = 5;
            // 
            // txtSubtitleFormat
            // 
            this.txtSubtitleFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubtitleFormat.Location = new System.Drawing.Point(83, 41);
            this.txtSubtitleFormat.Name = "txtSubtitleFormat";
            this.txtSubtitleFormat.Size = new System.Drawing.Size(158, 21);
            this.txtSubtitleFormat.TabIndex = 5;
            // 
            // lblSubtitleComment
            // 
            this.lblSubtitleComment.AutoSize = true;
            this.lblSubtitleComment.Location = new System.Drawing.Point(6, 71);
            this.lblSubtitleComment.Name = "lblSubtitleComment";
            this.lblSubtitleComment.Size = new System.Drawing.Size(53, 12);
            this.lblSubtitleComment.TabIndex = 4;
            this.lblSubtitleComment.Text = "Comment:";
            // 
            // lblSubtitleFormat
            // 
            this.lblSubtitleFormat.AutoSize = true;
            this.lblSubtitleFormat.Location = new System.Drawing.Point(6, 44);
            this.lblSubtitleFormat.Name = "lblSubtitleFormat";
            this.lblSubtitleFormat.Size = new System.Drawing.Size(47, 12);
            this.lblSubtitleFormat.TabIndex = 4;
            this.lblSubtitleFormat.Text = "Format:";
            // 
            // txtSubtitleLanguage
            // 
            this.txtSubtitleLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubtitleLanguage.Location = new System.Drawing.Point(83, 14);
            this.txtSubtitleLanguage.Name = "txtSubtitleLanguage";
            this.txtSubtitleLanguage.Size = new System.Drawing.Size(158, 21);
            this.txtSubtitleLanguage.TabIndex = 1;
            // 
            // chkSubtitleSDH
            // 
            this.chkSubtitleSDH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSubtitleSDH.AutoSize = true;
            this.chkSubtitleSDH.Location = new System.Drawing.Point(248, 43);
            this.chkSubtitleSDH.Name = "chkSubtitleSDH";
            this.chkSubtitleSDH.Size = new System.Drawing.Size(42, 16);
            this.chkSubtitleSDH.TabIndex = 10;
            this.chkSubtitleSDH.Text = "SDH";
            this.chkSubtitleSDH.UseVisualStyleBackColor = true;
            // 
            // lblSubtitleLanguage
            // 
            this.lblSubtitleLanguage.AutoSize = true;
            this.lblSubtitleLanguage.Location = new System.Drawing.Point(6, 17);
            this.lblSubtitleLanguage.Name = "lblSubtitleLanguage";
            this.lblSubtitleLanguage.Size = new System.Drawing.Size(59, 12);
            this.lblSubtitleLanguage.TabIndex = 0;
            this.lblSubtitleLanguage.Text = "Language:";
            // 
            // chkSubtitleForced
            // 
            this.chkSubtitleForced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSubtitleForced.AutoSize = true;
            this.chkSubtitleForced.Location = new System.Drawing.Point(248, 16);
            this.chkSubtitleForced.Name = "chkSubtitleForced";
            this.chkSubtitleForced.Size = new System.Drawing.Size(60, 16);
            this.chkSubtitleForced.TabIndex = 10;
            this.chkSubtitleForced.Text = "Forced";
            this.chkSubtitleForced.UseVisualStyleBackColor = true;
            // 
            // txtTargetLocation
            // 
            this.txtTargetLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetLocation.Location = new System.Drawing.Point(110, 4);
            this.txtTargetLocation.Name = "txtTargetLocation";
            this.txtTargetLocation.ReadOnly = true;
            this.txtTargetLocation.Size = new System.Drawing.Size(394, 21);
            this.txtTargetLocation.TabIndex = 0;
            // 
            // lblTargetLocation
            // 
            this.lblTargetLocation.AutoSize = true;
            this.lblTargetLocation.Location = new System.Drawing.Point(3, 7);
            this.lblTargetLocation.Name = "lblTargetLocation";
            this.lblTargetLocation.Size = new System.Drawing.Size(101, 12);
            this.lblTargetLocation.TabIndex = 1;
            this.lblTargetLocation.Text = "Target Location:";
            // 
            // txtVideoBitrate
            // 
            this.txtVideoBitrate.Location = new System.Drawing.Point(227, 46);
            this.txtVideoBitrate.Name = "txtVideoBitrate";
            this.txtVideoBitrate.ReadOnly = true;
            this.txtVideoBitrate.Size = new System.Drawing.Size(88, 21);
            this.txtVideoBitrate.TabIndex = 5;
            // 
            // lblVideoFramerate
            // 
            this.lblVideoFramerate.AutoSize = true;
            this.lblVideoFramerate.Location = new System.Drawing.Point(162, 23);
            this.lblVideoFramerate.Name = "lblVideoFramerate";
            this.lblVideoFramerate.Size = new System.Drawing.Size(65, 12);
            this.lblVideoFramerate.TabIndex = 4;
            this.lblVideoFramerate.Text = "Framerate:";
            // 
            // lblVideoBitrate
            // 
            this.lblVideoBitrate.AutoSize = true;
            this.lblVideoBitrate.Location = new System.Drawing.Point(162, 52);
            this.lblVideoBitrate.Name = "lblVideoBitrate";
            this.lblVideoBitrate.Size = new System.Drawing.Size(53, 12);
            this.lblVideoBitrate.TabIndex = 4;
            this.lblVideoBitrate.Text = "Bitrate:";
            // 
            // lblVideoNote
            // 
            this.lblVideoNote.AutoSize = true;
            this.lblVideoNote.Location = new System.Drawing.Point(336, 23);
            this.lblVideoNote.Name = "lblVideoNote";
            this.lblVideoNote.Size = new System.Drawing.Size(35, 12);
            this.lblVideoNote.TabIndex = 7;
            this.lblVideoNote.Text = "Note:";
            // 
            // txtVideoNote
            // 
            this.txtVideoNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVideoNote.Location = new System.Drawing.Point(377, 19);
            this.txtVideoNote.Multiline = true;
            this.txtVideoNote.Name = "txtVideoNote";
            this.txtVideoNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtVideoNote.Size = new System.Drawing.Size(279, 78);
            this.txtVideoNote.TabIndex = 6;
            // 
            // lblVideoWidth
            // 
            this.lblVideoWidth.AutoSize = true;
            this.lblVideoWidth.Location = new System.Drawing.Point(6, 22);
            this.lblVideoWidth.Name = "lblVideoWidth";
            this.lblVideoWidth.Size = new System.Drawing.Size(41, 12);
            this.lblVideoWidth.TabIndex = 4;
            this.lblVideoWidth.Text = "Width:";
            // 
            // txtVideoWidth
            // 
            this.txtVideoWidth.Location = new System.Drawing.Point(83, 19);
            this.txtVideoWidth.Name = "txtVideoWidth";
            this.txtVideoWidth.ReadOnly = true;
            this.txtVideoWidth.Size = new System.Drawing.Size(73, 21);
            this.txtVideoWidth.TabIndex = 5;
            // 
            // grpVideo
            // 
            this.grpVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVideo.Controls.Add(this.cmbVideoCodec);
            this.grpVideo.Controls.Add(this.txtVideoDAR);
            this.grpVideo.Controls.Add(this.lblVideoDAR);
            this.grpVideo.Controls.Add(this.txtVideoHeight);
            this.grpVideo.Controls.Add(this.lblVideoHeight);
            this.grpVideo.Controls.Add(this.txtVideoWidth);
            this.grpVideo.Controls.Add(this.lblVideoWidth);
            this.grpVideo.Controls.Add(this.txtVideoNote);
            this.grpVideo.Controls.Add(this.lblVideoNote);
            this.grpVideo.Controls.Add(this.lblVideoCodec);
            this.grpVideo.Controls.Add(this.lblVideoBitrate);
            this.grpVideo.Controls.Add(this.lblVideoFramerate);
            this.grpVideo.Controls.Add(this.txtVideoFramerate);
            this.grpVideo.Controls.Add(this.txtVideoBitrate);
            this.grpVideo.Location = new System.Drawing.Point(3, 257);
            this.grpVideo.Name = "grpVideo";
            this.grpVideo.Size = new System.Drawing.Size(662, 104);
            this.grpVideo.TabIndex = 15;
            this.grpVideo.TabStop = false;
            this.grpVideo.Text = "Video";
            // 
            // cmbVideoCodec
            // 
            this.cmbVideoCodec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVideoCodec.FormattingEnabled = true;
            this.cmbVideoCodec.Items.AddRange(new object[] {
            "x264",
            "H.264",
            "HEVC",
            "MPEG2",
            "VC-1",
            "AVC",
            "XviD",
            "UNKNOWN"});
            this.cmbVideoCodec.Location = new System.Drawing.Point(227, 76);
            this.cmbVideoCodec.Name = "cmbVideoCodec";
            this.cmbVideoCodec.Size = new System.Drawing.Size(88, 20);
            this.cmbVideoCodec.TabIndex = 8;
            this.cmbVideoCodec.SelectedIndexChanged += new System.EventHandler(this.cmbVideoCodec_SelectedIndexChanged);
            // 
            // txtVideoDAR
            // 
            this.txtVideoDAR.Location = new System.Drawing.Point(83, 76);
            this.txtVideoDAR.Name = "txtVideoDAR";
            this.txtVideoDAR.ReadOnly = true;
            this.txtVideoDAR.Size = new System.Drawing.Size(73, 21);
            this.txtVideoDAR.TabIndex = 5;
            // 
            // lblVideoDAR
            // 
            this.lblVideoDAR.AutoSize = true;
            this.lblVideoDAR.Location = new System.Drawing.Point(6, 79);
            this.lblVideoDAR.Name = "lblVideoDAR";
            this.lblVideoDAR.Size = new System.Drawing.Size(29, 12);
            this.lblVideoDAR.TabIndex = 4;
            this.lblVideoDAR.Text = "DAR:";
            // 
            // txtVideoHeight
            // 
            this.txtVideoHeight.Location = new System.Drawing.Point(83, 49);
            this.txtVideoHeight.Name = "txtVideoHeight";
            this.txtVideoHeight.ReadOnly = true;
            this.txtVideoHeight.Size = new System.Drawing.Size(73, 21);
            this.txtVideoHeight.TabIndex = 5;
            // 
            // lblVideoHeight
            // 
            this.lblVideoHeight.AutoSize = true;
            this.lblVideoHeight.Location = new System.Drawing.Point(6, 49);
            this.lblVideoHeight.Name = "lblVideoHeight";
            this.lblVideoHeight.Size = new System.Drawing.Size(47, 12);
            this.lblVideoHeight.TabIndex = 4;
            this.lblVideoHeight.Text = "Height:";
            // 
            // lblVideoCodec
            // 
            this.lblVideoCodec.AutoSize = true;
            this.lblVideoCodec.ForeColor = System.Drawing.Color.Black;
            this.lblVideoCodec.Location = new System.Drawing.Point(162, 79);
            this.lblVideoCodec.Name = "lblVideoCodec";
            this.lblVideoCodec.Size = new System.Drawing.Size(41, 12);
            this.lblVideoCodec.TabIndex = 4;
            this.lblVideoCodec.Text = "Codec:";
            // 
            // txtVideoFramerate
            // 
            this.txtVideoFramerate.Location = new System.Drawing.Point(227, 19);
            this.txtVideoFramerate.Name = "txtVideoFramerate";
            this.txtVideoFramerate.ReadOnly = true;
            this.txtVideoFramerate.Size = new System.Drawing.Size(88, 21);
            this.txtVideoFramerate.TabIndex = 5;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnProcess.Location = new System.Drawing.Point(591, 4);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 21);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "GO!";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnTargetBrowse
            // 
            this.btnTargetBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTargetBrowse.Location = new System.Drawing.Point(510, 4);
            this.btnTargetBrowse.Name = "btnTargetBrowse";
            this.btnTargetBrowse.Size = new System.Drawing.Size(75, 21);
            this.btnTargetBrowse.TabIndex = 3;
            this.btnTargetBrowse.Text = "Browse";
            this.btnTargetBrowse.UseVisualStyleBackColor = true;
            this.btnTargetBrowse.Click += new System.EventHandler(this.btnTargetBrowse_Click);
            // 
            // grpSource
            // 
            this.grpSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSource.Controls.Add(this.cmbSourceResolution);
            this.grpSource.Controls.Add(this.cmbSourceType);
            this.grpSource.Controls.Add(this.lblSourceType);
            this.grpSource.Controls.Add(this.lblSourceName);
            this.grpSource.Controls.Add(this.btnSourceGuess);
            this.grpSource.Controls.Add(this.txtSourceName);
            this.grpSource.Controls.Add(this.lblSourceResolution);
            this.grpSource.Location = new System.Drawing.Point(3, 184);
            this.grpSource.Name = "grpSource";
            this.grpSource.Size = new System.Drawing.Size(662, 68);
            this.grpSource.TabIndex = 16;
            this.grpSource.TabStop = false;
            this.grpSource.Text = "Source";
            // 
            // cmbSourceResolution
            // 
            this.cmbSourceResolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSourceResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSourceResolution.FormattingEnabled = true;
            this.cmbSourceResolution.Items.AddRange(new object[] {
            "4K",
            "2160p",
            "1080p",
            "1080i",
            "720p",
            "720i"});
            this.cmbSourceResolution.Location = new System.Drawing.Point(421, 43);
            this.cmbSourceResolution.Name = "cmbSourceResolution";
            this.cmbSourceResolution.Size = new System.Drawing.Size(126, 20);
            this.cmbSourceResolution.TabIndex = 8;
            // 
            // cmbSourceType
            // 
            this.cmbSourceType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbSourceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSourceType.FormattingEnabled = true;
            this.cmbSourceType.Items.AddRange(new object[] {
            "BluRay",
            "HDDVD",
            "DVDRip",
            "WEB-DL",
            "WEBRip",
            "HDTV"});
            this.cmbSourceType.Location = new System.Drawing.Point(83, 43);
            this.cmbSourceType.Name = "cmbSourceType";
            this.cmbSourceType.Size = new System.Drawing.Size(126, 20);
            this.cmbSourceType.TabIndex = 8;
            this.cmbSourceType.SelectedIndexChanged += new System.EventHandler(this.cmbSourceType_SelectedIndexChanged);
            // 
            // lblSourceType
            // 
            this.lblSourceType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSourceType.AutoSize = true;
            this.lblSourceType.Location = new System.Drawing.Point(6, 46);
            this.lblSourceType.Name = "lblSourceType";
            this.lblSourceType.Size = new System.Drawing.Size(35, 12);
            this.lblSourceType.TabIndex = 8;
            this.lblSourceType.Text = "Type:";
            // 
            // lblSourceName
            // 
            this.lblSourceName.AutoSize = true;
            this.lblSourceName.Location = new System.Drawing.Point(6, 17);
            this.lblSourceName.Name = "lblSourceName";
            this.lblSourceName.Size = new System.Drawing.Size(35, 12);
            this.lblSourceName.TabIndex = 7;
            this.lblSourceName.Text = "Name:";
            // 
            // btnSourceGuess
            // 
            this.btnSourceGuess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSourceGuess.Location = new System.Drawing.Point(581, 14);
            this.btnSourceGuess.Name = "btnSourceGuess";
            this.btnSourceGuess.Size = new System.Drawing.Size(75, 21);
            this.btnSourceGuess.TabIndex = 3;
            this.btnSourceGuess.Text = "Guess";
            this.btnSourceGuess.UseVisualStyleBackColor = true;
            // 
            // txtSourceName
            // 
            this.txtSourceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceName.Location = new System.Drawing.Point(83, 14);
            this.txtSourceName.Name = "txtSourceName";
            this.txtSourceName.Size = new System.Drawing.Size(492, 21);
            this.txtSourceName.TabIndex = 6;
            this.txtSourceName.TextChanged += new System.EventHandler(this.txtSourceName_TextChanged);
            // 
            // lblSourceResolution
            // 
            this.lblSourceResolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSourceResolution.AutoSize = true;
            this.lblSourceResolution.Location = new System.Drawing.Point(344, 46);
            this.lblSourceResolution.Name = "lblSourceResolution";
            this.lblSourceResolution.Size = new System.Drawing.Size(71, 12);
            this.lblSourceResolution.TabIndex = 4;
            this.lblSourceResolution.Text = "Resolution:";
            // 
            // mnsMain
            // 
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsFile,
            this.mnsTools,
            this.mnsHelp});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Size = new System.Drawing.Size(678, 25);
            this.mnsMain.TabIndex = 17;
            this.mnsMain.Text = "menuStrip1";
            // 
            // mnsFile
            // 
            this.mnsFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsFileOpen,
            this.mnsFileClear,
            this.mnsFileMediaInfo,
            this.mnsFileSeparator1,
            this.mnsFileExit});
            this.mnsFile.Name = "mnsFile";
            this.mnsFile.Size = new System.Drawing.Size(39, 21);
            this.mnsFile.Text = "File";
            // 
            // mnsFileOpen
            // 
            this.mnsFileOpen.Name = "mnsFileOpen";
            this.mnsFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnsFileOpen.Size = new System.Drawing.Size(155, 22);
            this.mnsFileOpen.Text = "Open";
            this.mnsFileOpen.Click += new System.EventHandler(this.mnsFileOpen_Click);
            // 
            // mnsFileClear
            // 
            this.mnsFileClear.Name = "mnsFileClear";
            this.mnsFileClear.Size = new System.Drawing.Size(155, 22);
            this.mnsFileClear.Text = "Clear";
            this.mnsFileClear.Click += new System.EventHandler(this.mnsFileClear_Click);
            // 
            // mnsFileMediaInfo
            // 
            this.mnsFileMediaInfo.Name = "mnsFileMediaInfo";
            this.mnsFileMediaInfo.Size = new System.Drawing.Size(155, 22);
            this.mnsFileMediaInfo.Text = "MediaInfo";
            // 
            // mnsFileSeparator1
            // 
            this.mnsFileSeparator1.Name = "mnsFileSeparator1";
            this.mnsFileSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // mnsFileExit
            // 
            this.mnsFileExit.Name = "mnsFileExit";
            this.mnsFileExit.Size = new System.Drawing.Size(155, 22);
            this.mnsFileExit.Text = "Exit";
            this.mnsFileExit.Click += new System.EventHandler(this.mnsFileExit_Click);
            // 
            // mnsTools
            // 
            this.mnsTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsToolsImageUploader,
            this.mnsToolsZonesCommand,
            this.mnsToolsAutoTest});
            this.mnsTools.Name = "mnsTools";
            this.mnsTools.Size = new System.Drawing.Size(52, 21);
            this.mnsTools.Text = "Tools";
            // 
            // mnsToolsImageUploader
            // 
            this.mnsToolsImageUploader.Name = "mnsToolsImageUploader";
            this.mnsToolsImageUploader.Size = new System.Drawing.Size(175, 22);
            this.mnsToolsImageUploader.Text = "Image Uploader";
            this.mnsToolsImageUploader.Click += new System.EventHandler(this.mnsToolsImageUploader_Click);
            // 
            // mnsToolsZonesCommand
            // 
            this.mnsToolsZonesCommand.Enabled = false;
            this.mnsToolsZonesCommand.Name = "mnsToolsZonesCommand";
            this.mnsToolsZonesCommand.Size = new System.Drawing.Size(175, 22);
            this.mnsToolsZonesCommand.Text = "Zones Command";
            // 
            // mnsToolsAutoTest
            // 
            this.mnsToolsAutoTest.Enabled = false;
            this.mnsToolsAutoTest.Name = "mnsToolsAutoTest";
            this.mnsToolsAutoTest.Size = new System.Drawing.Size(175, 22);
            this.mnsToolsAutoTest.Text = "Automatic Test";
            // 
            // mnsHelp
            // 
            this.mnsHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsHelpAboutUs});
            this.mnsHelp.Name = "mnsHelp";
            this.mnsHelp.Size = new System.Drawing.Size(47, 21);
            this.mnsHelp.Text = "Help";
            // 
            // mnsHelpAboutUs
            // 
            this.mnsHelpAboutUs.Name = "mnsHelpAboutUs";
            this.mnsHelpAboutUs.Size = new System.Drawing.Size(130, 22);
            this.mnsHelpAboutUs.Text = "About Us";
            this.mnsHelpAboutUs.Click += new System.EventHandler(this.mnsHelpAboutUs_Click);
            // 
            // stsStatus
            // 
            this.stsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsStatusLabel});
            this.stsStatus.Location = new System.Drawing.Point(0, 693);
            this.stsStatus.Name = "stsStatus";
            this.stsStatus.Size = new System.Drawing.Size(678, 22);
            this.stsStatus.TabIndex = 19;
            this.stsStatus.Text = "statusStrip1";
            // 
            // stsStatusLabel
            // 
            this.stsStatusLabel.Name = "stsStatusLabel";
            this.stsStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // tblAudioAndSubtitle
            // 
            this.tblAudioAndSubtitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblAudioAndSubtitle.ColumnCount = 2;
            this.tblAudioAndSubtitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblAudioAndSubtitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblAudioAndSubtitle.Controls.Add(this.grpSubtitle, 1, 0);
            this.tblAudioAndSubtitle.Controls.Add(this.grpAudio, 0, 0);
            this.tblAudioAndSubtitle.Location = new System.Drawing.Point(3, 366);
            this.tblAudioAndSubtitle.Name = "tblAudioAndSubtitle";
            this.tblAudioAndSubtitle.RowCount = 1;
            this.tblAudioAndSubtitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblAudioAndSubtitle.Size = new System.Drawing.Size(662, 185);
            this.tblAudioAndSubtitle.TabIndex = 20;
            // 
            // pnlMovieEncode
            // 
            this.pnlMovieEncode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMovieEncode.Controls.Add(this.tblAudioAndSubtitle);
            this.pnlMovieEncode.Controls.Add(this.grpSource);
            this.pnlMovieEncode.Controls.Add(this.grpGeneral);
            this.pnlMovieEncode.Controls.Add(this.grpVideo);
            this.pnlMovieEncode.Location = new System.Drawing.Point(6, 112);
            this.pnlMovieEncode.Name = "pnlMovieEncode";
            this.pnlMovieEncode.Size = new System.Drawing.Size(668, 551);
            this.pnlMovieEncode.TabIndex = 21;
            // 
            // pnlOutput
            // 
            this.pnlOutput.Controls.Add(this.lblTargetLocation);
            this.pnlOutput.Controls.Add(this.txtTargetLocation);
            this.pnlOutput.Controls.Add(this.btnTargetBrowse);
            this.pnlOutput.Controls.Add(this.btnProcess);
            this.pnlOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOutput.Location = new System.Drawing.Point(0, 665);
            this.pnlOutput.Name = "pnlOutput";
            this.pnlOutput.Size = new System.Drawing.Size(678, 28);
            this.pnlOutput.TabIndex = 11;
            // 
            // lblReleaseCategory
            // 
            this.lblReleaseCategory.AutoSize = true;
            this.lblReleaseCategory.Location = new System.Drawing.Point(14, 5);
            this.lblReleaseCategory.Name = "lblReleaseCategory";
            this.lblReleaseCategory.Size = new System.Drawing.Size(59, 12);
            this.lblReleaseCategory.TabIndex = 0;
            this.lblReleaseCategory.Text = "Category:";
            // 
            // cmbReleaseCategory
            // 
            this.cmbReleaseCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReleaseCategory.FormattingEnabled = true;
            this.cmbReleaseCategory.Items.AddRange(new object[] {
            "Movie",
            "TV",
            "Documentary",
            "Sport",
            "Music",
            "XXX"});
            this.cmbReleaseCategory.Location = new System.Drawing.Point(79, 2);
            this.cmbReleaseCategory.Name = "cmbReleaseCategory";
            this.cmbReleaseCategory.Size = new System.Drawing.Size(95, 20);
            this.cmbReleaseCategory.TabIndex = 1;
            this.cmbReleaseCategory.SelectedIndexChanged += new System.EventHandler(this.cmbReleaseCategory_SelectedIndexChanged);
            // 
            // cmbReleaseMedium
            // 
            this.cmbReleaseMedium.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReleaseMedium.FormattingEnabled = true;
            this.cmbReleaseMedium.Items.AddRange(new object[] {
            "BluRay",
            "Encode",
            "Remux",
            "WEB-DL",
            "Capture"});
            this.cmbReleaseMedium.Location = new System.Drawing.Point(233, 2);
            this.cmbReleaseMedium.Name = "cmbReleaseMedium";
            this.cmbReleaseMedium.Size = new System.Drawing.Size(95, 20);
            this.cmbReleaseMedium.TabIndex = 1;
            // 
            // lblReleaseMedium
            // 
            this.lblReleaseMedium.AutoSize = true;
            this.lblReleaseMedium.Location = new System.Drawing.Point(180, 5);
            this.lblReleaseMedium.Name = "lblReleaseMedium";
            this.lblReleaseMedium.Size = new System.Drawing.Size(47, 12);
            this.lblReleaseMedium.TabIndex = 2;
            this.lblReleaseMedium.Text = "Medium:";
            // 
            // pnlReleaseType
            // 
            this.pnlReleaseType.Controls.Add(this.lblReleaseMedium);
            this.pnlReleaseType.Controls.Add(this.cmbReleaseMedium);
            this.pnlReleaseType.Controls.Add(this.cmbReleaseCategory);
            this.pnlReleaseType.Controls.Add(this.lblReleaseCategory);
            this.pnlReleaseType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReleaseType.Location = new System.Drawing.Point(0, 25);
            this.pnlReleaseType.Name = "pnlReleaseType";
            this.pnlReleaseType.Size = new System.Drawing.Size(678, 24);
            this.pnlReleaseType.TabIndex = 22;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 715);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.pnlReleaseType);
            this.Controls.Add(this.pnlOutput);
            this.Controls.Add(this.pnlMovieEncode);
            this.Controls.Add(this.stsStatus);
            this.Controls.Add(this.mnsMain);
            this.MainMenuStrip = this.mnsMain;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(694, 733);
            this.Name = "FrmMain";
            this.Text = "TAiCHi NFO Generator";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.grpAudio.ResumeLayout(false);
            this.grpAudio.PerformLayout();
            this.grpSubtitle.ResumeLayout(false);
            this.grpSubtitle.PerformLayout();
            this.grpVideo.ResumeLayout(false);
            this.grpVideo.PerformLayout();
            this.grpSource.ResumeLayout(false);
            this.grpSource.PerformLayout();
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.stsStatus.ResumeLayout(false);
            this.stsStatus.PerformLayout();
            this.tblAudioAndSubtitle.ResumeLayout(false);
            this.pnlMovieEncode.ResumeLayout(false);
            this.pnlOutput.ResumeLayout(false);
            this.pnlOutput.PerformLayout();
            this.pnlReleaseType.ResumeLayout(false);
            this.pnlReleaseType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblInputFile;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Label lblGeneralReleaseName;
        private System.Windows.Forms.TextBox txtGeneralReleaseName;
        private System.Windows.Forms.Label lblGeneralAudio;
        private System.Windows.Forms.Label lblGeneralResolution;
        private System.Windows.Forms.Label lblGeneralYear;
        private System.Windows.Forms.Label lblGeneralEdition;
        private System.Windows.Forms.TextBox txtGeneralTitle;
        private System.Windows.Forms.Label lblGeneralTitle;
        private System.Windows.Forms.GroupBox grpAudio;
        private System.Windows.Forms.Button btnAudioEdit;
        private System.Windows.Forms.ListBox lstAudio;
        private System.Windows.Forms.TextBox txtAudioCommentaryBy;
        private System.Windows.Forms.TextBox txtAudioBitrate;
        private System.Windows.Forms.TextBox txtAudioChannels;
        private System.Windows.Forms.Label lblAudioBitrate;
        private System.Windows.Forms.TextBox txtAudioCodec;
        private System.Windows.Forms.Label lblAudioChannels;
        private System.Windows.Forms.Label lblAudioCodec;
        private System.Windows.Forms.TextBox txtAudioLanguage;
        private System.Windows.Forms.Label lblAudioLanguage;
        private System.Windows.Forms.GroupBox grpSubtitle;
        private System.Windows.Forms.Button btnSubtitleEdit;
        private System.Windows.Forms.ListBox lstSubtitle;
        private System.Windows.Forms.TextBox txtSubtitleComment;
        private System.Windows.Forms.TextBox txtSubtitleFormat;
        private System.Windows.Forms.Label lblSubtitleComment;
        private System.Windows.Forms.Label lblSubtitleFormat;
        private System.Windows.Forms.TextBox txtSubtitleLanguage;
        private System.Windows.Forms.Label lblSubtitleLanguage;
        private System.Windows.Forms.TextBox txtTargetLocation;
        private System.Windows.Forms.Label lblTargetLocation;
        private System.Windows.Forms.TextBox txtGeneralDuration;
        private System.Windows.Forms.TextBox txtGeneralSize;
        private System.Windows.Forms.TextBox txtVideoBitrate;
        private System.Windows.Forms.Label lblVideoFramerate;
        private System.Windows.Forms.Label lblVideoBitrate;
        private System.Windows.Forms.Label lblGeneralDuration;
        private System.Windows.Forms.Label lblGeneralSize;
        private System.Windows.Forms.Label lblVideoNote;
        private System.Windows.Forms.TextBox txtVideoNote;
        private System.Windows.Forms.Label lblGeneralChapters;
        private System.Windows.Forms.CheckBox chkGeneralChaptersIncluded;
        private System.Windows.Forms.CheckBox chkGeneralChaptersNamed;
        private System.Windows.Forms.Label lblVideoWidth;
        private System.Windows.Forms.TextBox txtVideoWidth;
        private System.Windows.Forms.GroupBox grpVideo;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnTargetBrowse;
        private System.Windows.Forms.ComboBox cmbGeneralResolution;
        private System.Windows.Forms.GroupBox grpSource;
        private System.Windows.Forms.Label lblSourceName;
        private System.Windows.Forms.TextBox txtSourceName;
        private System.Windows.Forms.Button btnSourceGuess;
        private System.Windows.Forms.ComboBox cmbSourceType;
        private System.Windows.Forms.Label lblSourceType;
        private System.Windows.Forms.ComboBox cmbSourceResolution;
        private System.Windows.Forms.Label lblSourceResolution;
        private System.Windows.Forms.TextBox txtVideoDAR;
        private System.Windows.Forms.Label lblVideoDAR;
        private System.Windows.Forms.TextBox txtVideoHeight;
        private System.Windows.Forms.Label lblVideoHeight;
        private System.Windows.Forms.Label lblVideoCodec;
        private System.Windows.Forms.ComboBox cmbVideoCodec;
        private System.Windows.Forms.ComboBox cmbGeneralEdition;
        private System.Windows.Forms.ComboBox cmbGeneralYear;
        private System.Windows.Forms.ComboBox cmbGeneralProper;
        private System.Windows.Forms.ComboBox cmbGeneralHybrid;
        private System.Windows.Forms.Label lblGeneralHybrid;
        private System.Windows.Forms.Label lblGeneralProper;
        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem mnsFile;
        private System.Windows.Forms.ToolStripMenuItem mnsFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnsTools;
        private System.Windows.Forms.ToolStripMenuItem mnsToolsZonesCommand;
        private System.Windows.Forms.ToolStripMenuItem mnsHelp;
        private System.Windows.Forms.ToolStripMenuItem mnsHelpAboutUs;
        private System.Windows.Forms.ComboBox cmbGeneralAudio;
        private System.Windows.Forms.ToolStripMenuItem mnsFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnsFileClear;
        private System.Windows.Forms.ToolStripMenuItem mnsFileMediaInfo;
        private System.Windows.Forms.ToolStripSeparator mnsFileSeparator1;
        private System.Windows.Forms.TextBox txtVideoFramerate;
        private System.Windows.Forms.CheckBox chkAudioCommentary;
        private System.Windows.Forms.Button btnAudioDown;
        private System.Windows.Forms.Button btnAudioUp;
        private System.Windows.Forms.CheckBox chkSubtitleSDH;
        private System.Windows.Forms.CheckBox chkSubtitleForced;
        private System.Windows.Forms.ToolStripMenuItem mnsToolsImageUploader;
        private System.Windows.Forms.ToolStripMenuItem mnsToolsAutoTest;
        private System.Windows.Forms.TextBox txtIMDb;
        private System.Windows.Forms.Label lblIMDb;
        private System.Windows.Forms.ComboBox cmbNfoTemplate;
        private System.Windows.Forms.Label lblNfoTemplate;
        private System.Windows.Forms.StatusStrip stsStatus;
        private System.Windows.Forms.ToolStripStatusLabel stsStatusLabel;
        private System.Windows.Forms.ComboBox cmbSeparateChar;
        private System.Windows.Forms.TableLayoutPanel tblAudioAndSubtitle;
        private System.Windows.Forms.Panel pnlMovieEncode;
        private System.Windows.Forms.Panel pnlOutput;
        private System.Windows.Forms.Label lblReleaseCategory;
        private System.Windows.Forms.ComboBox cmbReleaseCategory;
        private System.Windows.Forms.ComboBox cmbReleaseMedium;
        private System.Windows.Forms.Label lblReleaseMedium;
        private System.Windows.Forms.Panel pnlReleaseType;
        private System.Windows.Forms.Button btnSearchIMDb;
        private System.Windows.Forms.Button btnOpenIMDb;
        private System.Windows.Forms.Button btnInputBrowse;
    }
}
