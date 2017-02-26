namespace NFOGenerator
{
    partial class frmMain
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
            this.btnInputClear = new System.Windows.Forms.Button();
            this.lblInputFile = new System.Windows.Forms.Label();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.cmbGeneralResolution = new System.Windows.Forms.ComboBox();
            this.lblGeneralReleaseName = new System.Windows.Forms.Label();
            this.txtGeneralReleaseName = new System.Windows.Forms.TextBox();
            this.txtGeneralAudio = new System.Windows.Forms.TextBox();
            this.btnGeneralGenerate = new System.Windows.Forms.Button();
            this.txtGeneralYear = new System.Windows.Forms.TextBox();
            this.lblGeneralAudio = new System.Windows.Forms.Label();
            this.lblGeneralResolution = new System.Windows.Forms.Label();
            this.lblGeneralYear = new System.Windows.Forms.Label();
            this.txtGeneralEdition = new System.Windows.Forms.TextBox();
            this.lblGeneralEdition = new System.Windows.Forms.Label();
            this.txtGeneralTitle = new System.Windows.Forms.TextBox();
            this.lblGeneralTitle = new System.Windows.Forms.Label();
            this.grpAudio = new System.Windows.Forms.GroupBox();
            this.btnAudioAdd = new System.Windows.Forms.Button();
            this.lstAudio = new System.Windows.Forms.ListBox();
            this.txtAudioComment = new System.Windows.Forms.TextBox();
            this.txtAudioBitrate = new System.Windows.Forms.TextBox();
            this.lblAudioComment = new System.Windows.Forms.Label();
            this.txtAudioChannels = new System.Windows.Forms.TextBox();
            this.lblAudioBitrate = new System.Windows.Forms.Label();
            this.txtAudioCodec = new System.Windows.Forms.TextBox();
            this.lblAudioChannels = new System.Windows.Forms.Label();
            this.lblAudioCodec = new System.Windows.Forms.Label();
            this.txtAudioLanguage = new System.Windows.Forms.TextBox();
            this.lblAudioLanguage = new System.Windows.Forms.Label();
            this.grpSubtitle = new System.Windows.Forms.GroupBox();
            this.btnSubtitleAdd = new System.Windows.Forms.Button();
            this.lstSubtitle = new System.Windows.Forms.ListBox();
            this.txtSubtitleComment = new System.Windows.Forms.TextBox();
            this.txtSubtitleFormat = new System.Windows.Forms.TextBox();
            this.lblSubtitleComment = new System.Windows.Forms.Label();
            this.lblSubtitleFormat = new System.Windows.Forms.Label();
            this.txtSubtitleLanguage = new System.Windows.Forms.TextBox();
            this.lblSubtitleLanguage = new System.Windows.Forms.Label();
            this.lblFootnote = new System.Windows.Forms.Label();
            this.txtTargetLocation = new System.Windows.Forms.TextBox();
            this.lblTargetLocation = new System.Windows.Forms.Label();
            this.txtGeneralDuration = new System.Windows.Forms.TextBox();
            this.txtGeneralSize = new System.Windows.Forms.TextBox();
            this.txtVideoBitrate = new System.Windows.Forms.TextBox();
            this.lblVideoFramerate = new System.Windows.Forms.Label();
            this.lblVideoBitrate = new System.Windows.Forms.Label();
            this.lblGeneralDuration = new System.Windows.Forms.Label();
            this.lblGeneralSize = new System.Windows.Forms.Label();
            this.lblVideoNote = new System.Windows.Forms.Label();
            this.txtVideoNote = new System.Windows.Forms.TextBox();
            this.lblGeneralChapters = new System.Windows.Forms.Label();
            this.chkGeneralChaptersIncluded = new System.Windows.Forms.CheckBox();
            this.chkGeneralChaptersNamed = new System.Windows.Forms.CheckBox();
            this.lblVideoResolution = new System.Windows.Forms.Label();
            this.txtVideoResolution = new System.Windows.Forms.TextBox();
            this.grpVideo = new System.Windows.Forms.GroupBox();
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
            this.cmbVideoFramerate = new System.Windows.Forms.ComboBox();
            this.lblVideoAR = new System.Windows.Forms.Label();
            this.txtVideoAR = new System.Windows.Forms.TextBox();
            this.grpInput.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.grpAudio.SuspendLayout();
            this.grpSubtitle.SuspendLayout();
            this.grpVideo.SuspendLayout();
            this.grpSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInputFile
            // 
            this.txtInputFile.Location = new System.Drawing.Point(83, 20);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(411, 21);
            this.txtInputFile.TabIndex = 0;
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.btnInputBrowse);
            this.grpInput.Controls.Add(this.btnInputClear);
            this.grpInput.Controls.Add(this.lblInputFile);
            this.grpInput.Controls.Add(this.txtInputFile);
            this.grpInput.Location = new System.Drawing.Point(12, 12);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(662, 53);
            this.grpInput.TabIndex = 1;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Input";
            // 
            // btnInputBrowse
            // 
            this.btnInputBrowse.Location = new System.Drawing.Point(500, 20);
            this.btnInputBrowse.Name = "btnInputBrowse";
            this.btnInputBrowse.Size = new System.Drawing.Size(75, 21);
            this.btnInputBrowse.TabIndex = 3;
            this.btnInputBrowse.Text = "Browse";
            this.btnInputBrowse.UseVisualStyleBackColor = true;
            // 
            // btnInputClear
            // 
            this.btnInputClear.Location = new System.Drawing.Point(581, 20);
            this.btnInputClear.Name = "btnInputClear";
            this.btnInputClear.Size = new System.Drawing.Size(75, 21);
            this.btnInputClear.TabIndex = 3;
            this.btnInputClear.Text = "Clear";
            this.btnInputClear.UseVisualStyleBackColor = true;
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
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.cmbGeneralResolution);
            this.grpGeneral.Controls.Add(this.lblGeneralReleaseName);
            this.grpGeneral.Controls.Add(this.chkGeneralChaptersNamed);
            this.grpGeneral.Controls.Add(this.txtGeneralReleaseName);
            this.grpGeneral.Controls.Add(this.chkGeneralChaptersIncluded);
            this.grpGeneral.Controls.Add(this.txtGeneralAudio);
            this.grpGeneral.Controls.Add(this.lblGeneralChapters);
            this.grpGeneral.Controls.Add(this.btnGeneralGenerate);
            this.grpGeneral.Controls.Add(this.txtGeneralYear);
            this.grpGeneral.Controls.Add(this.lblGeneralAudio);
            this.grpGeneral.Controls.Add(this.lblGeneralResolution);
            this.grpGeneral.Controls.Add(this.lblGeneralDuration);
            this.grpGeneral.Controls.Add(this.lblGeneralSize);
            this.grpGeneral.Controls.Add(this.lblGeneralYear);
            this.grpGeneral.Controls.Add(this.txtGeneralDuration);
            this.grpGeneral.Controls.Add(this.txtGeneralEdition);
            this.grpGeneral.Controls.Add(this.lblGeneralEdition);
            this.grpGeneral.Controls.Add(this.txtGeneralSize);
            this.grpGeneral.Controls.Add(this.txtGeneralTitle);
            this.grpGeneral.Controls.Add(this.lblGeneralTitle);
            this.grpGeneral.Location = new System.Drawing.Point(12, 71);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(662, 123);
            this.grpGeneral.TabIndex = 2;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // cmbGeneralResolution
            // 
            this.cmbGeneralResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGeneralResolution.FormattingEnabled = true;
            this.cmbGeneralResolution.Location = new System.Drawing.Point(421, 42);
            this.cmbGeneralResolution.Name = "cmbGeneralResolution";
            this.cmbGeneralResolution.Size = new System.Drawing.Size(73, 20);
            this.cmbGeneralResolution.TabIndex = 8;
            // 
            // lblGeneralReleaseName
            // 
            this.lblGeneralReleaseName.AutoSize = true;
            this.lblGeneralReleaseName.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGeneralReleaseName.Location = new System.Drawing.Point(6, 98);
            this.lblGeneralReleaseName.Name = "lblGeneralReleaseName";
            this.lblGeneralReleaseName.Size = new System.Drawing.Size(68, 12);
            this.lblGeneralReleaseName.TabIndex = 7;
            this.lblGeneralReleaseName.Text = "RLZ Name:";
            // 
            // txtGeneralReleaseName
            // 
            this.txtGeneralReleaseName.Location = new System.Drawing.Point(83, 95);
            this.txtGeneralReleaseName.Name = "txtGeneralReleaseName";
            this.txtGeneralReleaseName.Size = new System.Drawing.Size(492, 21);
            this.txtGeneralReleaseName.TabIndex = 6;
            // 
            // txtGeneralAudio
            // 
            this.txtGeneralAudio.Location = new System.Drawing.Point(553, 41);
            this.txtGeneralAudio.Name = "txtGeneralAudio";
            this.txtGeneralAudio.Size = new System.Drawing.Size(103, 21);
            this.txtGeneralAudio.TabIndex = 5;
            // 
            // btnGeneralGenerate
            // 
            this.btnGeneralGenerate.Location = new System.Drawing.Point(581, 94);
            this.btnGeneralGenerate.Name = "btnGeneralGenerate";
            this.btnGeneralGenerate.Size = new System.Drawing.Size(75, 21);
            this.btnGeneralGenerate.TabIndex = 3;
            this.btnGeneralGenerate.Text = "Generate";
            this.btnGeneralGenerate.UseVisualStyleBackColor = true;
            this.btnGeneralGenerate.Click += new System.EventHandler(this.btnGeneralGenerate_Click);
            // 
            // txtGeneralYear
            // 
            this.txtGeneralYear.Location = new System.Drawing.Point(83, 41);
            this.txtGeneralYear.Name = "txtGeneralYear";
            this.txtGeneralYear.Size = new System.Drawing.Size(73, 21);
            this.txtGeneralYear.TabIndex = 5;
            // 
            // lblGeneralAudio
            // 
            this.lblGeneralAudio.AutoSize = true;
            this.lblGeneralAudio.Location = new System.Drawing.Point(506, 44);
            this.lblGeneralAudio.Name = "lblGeneralAudio";
            this.lblGeneralAudio.Size = new System.Drawing.Size(41, 12);
            this.lblGeneralAudio.TabIndex = 4;
            this.lblGeneralAudio.Text = "Audio:";
            // 
            // lblGeneralResolution
            // 
            this.lblGeneralResolution.AutoSize = true;
            this.lblGeneralResolution.Location = new System.Drawing.Point(344, 44);
            this.lblGeneralResolution.Name = "lblGeneralResolution";
            this.lblGeneralResolution.Size = new System.Drawing.Size(71, 12);
            this.lblGeneralResolution.TabIndex = 4;
            this.lblGeneralResolution.Text = "Resolution:";
            // 
            // lblGeneralYear
            // 
            this.lblGeneralYear.AutoSize = true;
            this.lblGeneralYear.Location = new System.Drawing.Point(6, 44);
            this.lblGeneralYear.Name = "lblGeneralYear";
            this.lblGeneralYear.Size = new System.Drawing.Size(35, 12);
            this.lblGeneralYear.TabIndex = 4;
            this.lblGeneralYear.Text = "Year:";
            // 
            // txtGeneralEdition
            // 
            this.txtGeneralEdition.Location = new System.Drawing.Point(227, 41);
            this.txtGeneralEdition.Name = "txtGeneralEdition";
            this.txtGeneralEdition.Size = new System.Drawing.Size(111, 21);
            this.txtGeneralEdition.TabIndex = 3;
            // 
            // lblGeneralEdition
            // 
            this.lblGeneralEdition.AutoSize = true;
            this.lblGeneralEdition.Location = new System.Drawing.Point(162, 44);
            this.lblGeneralEdition.Name = "lblGeneralEdition";
            this.lblGeneralEdition.Size = new System.Drawing.Size(53, 12);
            this.lblGeneralEdition.TabIndex = 2;
            this.lblGeneralEdition.Text = "Edition:";
            // 
            // txtGeneralTitle
            // 
            this.txtGeneralTitle.Location = new System.Drawing.Point(83, 14);
            this.txtGeneralTitle.Name = "txtGeneralTitle";
            this.txtGeneralTitle.Size = new System.Drawing.Size(573, 21);
            this.txtGeneralTitle.TabIndex = 1;
            // 
            // lblGeneralTitle
            // 
            this.lblGeneralTitle.AutoSize = true;
            this.lblGeneralTitle.Location = new System.Drawing.Point(6, 17);
            this.lblGeneralTitle.Name = "lblGeneralTitle";
            this.lblGeneralTitle.Size = new System.Drawing.Size(41, 12);
            this.lblGeneralTitle.TabIndex = 0;
            this.lblGeneralTitle.Text = "Title:";
            // 
            // grpAudio
            // 
            this.grpAudio.Controls.Add(this.btnAudioAdd);
            this.grpAudio.Controls.Add(this.lstAudio);
            this.grpAudio.Controls.Add(this.txtAudioComment);
            this.grpAudio.Controls.Add(this.txtAudioBitrate);
            this.grpAudio.Controls.Add(this.lblAudioComment);
            this.grpAudio.Controls.Add(this.txtAudioChannels);
            this.grpAudio.Controls.Add(this.lblAudioBitrate);
            this.grpAudio.Controls.Add(this.txtAudioCodec);
            this.grpAudio.Controls.Add(this.lblAudioChannels);
            this.grpAudio.Controls.Add(this.lblAudioCodec);
            this.grpAudio.Controls.Add(this.txtAudioLanguage);
            this.grpAudio.Controls.Add(this.lblAudioLanguage);
            this.grpAudio.Location = new System.Drawing.Point(12, 353);
            this.grpAudio.Name = "grpAudio";
            this.grpAudio.Size = new System.Drawing.Size(324, 198);
            this.grpAudio.TabIndex = 11;
            this.grpAudio.TabStop = false;
            this.grpAudio.Text = "Audio";
            // 
            // btnAudioAdd
            // 
            this.btnAudioAdd.Location = new System.Drawing.Point(215, 14);
            this.btnAudioAdd.Name = "btnAudioAdd";
            this.btnAudioAdd.Size = new System.Drawing.Size(102, 102);
            this.btnAudioAdd.TabIndex = 7;
            this.btnAudioAdd.Text = "Add Audio";
            this.btnAudioAdd.UseVisualStyleBackColor = true;
            // 
            // lstAudio
            // 
            this.lstAudio.FormattingEnabled = true;
            this.lstAudio.ItemHeight = 12;
            this.lstAudio.Location = new System.Drawing.Point(6, 149);
            this.lstAudio.Name = "lstAudio";
            this.lstAudio.Size = new System.Drawing.Size(309, 40);
            this.lstAudio.TabIndex = 6;
            // 
            // txtAudioComment
            // 
            this.txtAudioComment.Location = new System.Drawing.Point(83, 122);
            this.txtAudioComment.Name = "txtAudioComment";
            this.txtAudioComment.Size = new System.Drawing.Size(232, 21);
            this.txtAudioComment.TabIndex = 5;
            // 
            // txtAudioBitrate
            // 
            this.txtAudioBitrate.Location = new System.Drawing.Point(83, 95);
            this.txtAudioBitrate.Name = "txtAudioBitrate";
            this.txtAudioBitrate.Size = new System.Drawing.Size(126, 21);
            this.txtAudioBitrate.TabIndex = 5;
            // 
            // lblAudioComment
            // 
            this.lblAudioComment.AutoSize = true;
            this.lblAudioComment.Location = new System.Drawing.Point(6, 125);
            this.lblAudioComment.Name = "lblAudioComment";
            this.lblAudioComment.Size = new System.Drawing.Size(53, 12);
            this.lblAudioComment.TabIndex = 4;
            this.lblAudioComment.Text = "Comment:";
            // 
            // txtAudioChannels
            // 
            this.txtAudioChannels.Location = new System.Drawing.Point(83, 68);
            this.txtAudioChannels.Name = "txtAudioChannels";
            this.txtAudioChannels.Size = new System.Drawing.Size(126, 21);
            this.txtAudioChannels.TabIndex = 5;
            // 
            // lblAudioBitrate
            // 
            this.lblAudioBitrate.AutoSize = true;
            this.lblAudioBitrate.Location = new System.Drawing.Point(6, 98);
            this.lblAudioBitrate.Name = "lblAudioBitrate";
            this.lblAudioBitrate.Size = new System.Drawing.Size(53, 12);
            this.lblAudioBitrate.TabIndex = 4;
            this.lblAudioBitrate.Text = "Bitrate:";
            // 
            // txtAudioCodec
            // 
            this.txtAudioCodec.Location = new System.Drawing.Point(83, 41);
            this.txtAudioCodec.Name = "txtAudioCodec";
            this.txtAudioCodec.Size = new System.Drawing.Size(126, 21);
            this.txtAudioCodec.TabIndex = 5;
            // 
            // lblAudioChannels
            // 
            this.lblAudioChannels.AutoSize = true;
            this.lblAudioChannels.Location = new System.Drawing.Point(6, 71);
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
            this.txtAudioLanguage.Size = new System.Drawing.Size(126, 21);
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
            this.grpSubtitle.Controls.Add(this.btnSubtitleAdd);
            this.grpSubtitle.Controls.Add(this.lstSubtitle);
            this.grpSubtitle.Controls.Add(this.txtSubtitleComment);
            this.grpSubtitle.Controls.Add(this.txtSubtitleFormat);
            this.grpSubtitle.Controls.Add(this.lblSubtitleComment);
            this.grpSubtitle.Controls.Add(this.lblSubtitleFormat);
            this.grpSubtitle.Controls.Add(this.txtSubtitleLanguage);
            this.grpSubtitle.Controls.Add(this.lblSubtitleLanguage);
            this.grpSubtitle.Location = new System.Drawing.Point(350, 353);
            this.grpSubtitle.Name = "grpSubtitle";
            this.grpSubtitle.Size = new System.Drawing.Size(324, 198);
            this.grpSubtitle.TabIndex = 12;
            this.grpSubtitle.TabStop = false;
            this.grpSubtitle.Text = "Subtitle";
            // 
            // btnSubtitleAdd
            // 
            this.btnSubtitleAdd.Location = new System.Drawing.Point(215, 14);
            this.btnSubtitleAdd.Name = "btnSubtitleAdd";
            this.btnSubtitleAdd.Size = new System.Drawing.Size(102, 102);
            this.btnSubtitleAdd.TabIndex = 7;
            this.btnSubtitleAdd.Text = "Add Audio";
            this.btnSubtitleAdd.UseVisualStyleBackColor = true;
            // 
            // lstSubtitle
            // 
            this.lstSubtitle.FormattingEnabled = true;
            this.lstSubtitle.ItemHeight = 12;
            this.lstSubtitle.Location = new System.Drawing.Point(6, 149);
            this.lstSubtitle.Name = "lstSubtitle";
            this.lstSubtitle.Size = new System.Drawing.Size(309, 40);
            this.lstSubtitle.TabIndex = 6;
            // 
            // txtSubtitleComment
            // 
            this.txtSubtitleComment.Location = new System.Drawing.Point(83, 122);
            this.txtSubtitleComment.Name = "txtSubtitleComment";
            this.txtSubtitleComment.Size = new System.Drawing.Size(232, 21);
            this.txtSubtitleComment.TabIndex = 5;
            // 
            // txtSubtitleFormat
            // 
            this.txtSubtitleFormat.Location = new System.Drawing.Point(83, 68);
            this.txtSubtitleFormat.Name = "txtSubtitleFormat";
            this.txtSubtitleFormat.Size = new System.Drawing.Size(126, 21);
            this.txtSubtitleFormat.TabIndex = 5;
            // 
            // lblSubtitleComment
            // 
            this.lblSubtitleComment.AutoSize = true;
            this.lblSubtitleComment.Location = new System.Drawing.Point(6, 125);
            this.lblSubtitleComment.Name = "lblSubtitleComment";
            this.lblSubtitleComment.Size = new System.Drawing.Size(53, 12);
            this.lblSubtitleComment.TabIndex = 4;
            this.lblSubtitleComment.Text = "Comment:";
            // 
            // lblSubtitleFormat
            // 
            this.lblSubtitleFormat.AutoSize = true;
            this.lblSubtitleFormat.Location = new System.Drawing.Point(6, 71);
            this.lblSubtitleFormat.Name = "lblSubtitleFormat";
            this.lblSubtitleFormat.Size = new System.Drawing.Size(47, 12);
            this.lblSubtitleFormat.TabIndex = 4;
            this.lblSubtitleFormat.Text = "Format:";
            // 
            // txtSubtitleLanguage
            // 
            this.txtSubtitleLanguage.Location = new System.Drawing.Point(83, 14);
            this.txtSubtitleLanguage.Name = "txtSubtitleLanguage";
            this.txtSubtitleLanguage.Size = new System.Drawing.Size(126, 21);
            this.txtSubtitleLanguage.TabIndex = 1;
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
            // lblFootnote
            // 
            this.lblFootnote.AutoSize = true;
            this.lblFootnote.Location = new System.Drawing.Point(153, 581);
            this.lblFootnote.Name = "lblFootnote";
            this.lblFootnote.Size = new System.Drawing.Size(431, 12);
            this.lblFootnote.TabIndex = 14;
            this.lblFootnote.Text = "Under Apache License 2.0 Github: https://github.com/metesa/NFOGenerator";
            // 
            // txtTargetLocation
            // 
            this.txtTargetLocation.Location = new System.Drawing.Point(130, 557);
            this.txtTargetLocation.Name = "txtTargetLocation";
            this.txtTargetLocation.Size = new System.Drawing.Size(373, 21);
            this.txtTargetLocation.TabIndex = 0;
            // 
            // lblTargetLocation
            // 
            this.lblTargetLocation.AutoSize = true;
            this.lblTargetLocation.Location = new System.Drawing.Point(23, 561);
            this.lblTargetLocation.Name = "lblTargetLocation";
            this.lblTargetLocation.Size = new System.Drawing.Size(101, 12);
            this.lblTargetLocation.TabIndex = 1;
            this.lblTargetLocation.Text = "Target Location:";
            // 
            // txtGeneralDuration
            // 
            this.txtGeneralDuration.Location = new System.Drawing.Point(227, 68);
            this.txtGeneralDuration.Name = "txtGeneralDuration";
            this.txtGeneralDuration.Size = new System.Drawing.Size(111, 21);
            this.txtGeneralDuration.TabIndex = 5;
            // 
            // txtGeneralSize
            // 
            this.txtGeneralSize.Location = new System.Drawing.Point(83, 68);
            this.txtGeneralSize.Name = "txtGeneralSize";
            this.txtGeneralSize.Size = new System.Drawing.Size(73, 21);
            this.txtGeneralSize.TabIndex = 5;
            // 
            // txtVideoBitrate
            // 
            this.txtVideoBitrate.Location = new System.Drawing.Point(83, 20);
            this.txtVideoBitrate.Name = "txtVideoBitrate";
            this.txtVideoBitrate.Size = new System.Drawing.Size(73, 21);
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
            this.lblVideoBitrate.Location = new System.Drawing.Point(6, 23);
            this.lblVideoBitrate.Name = "lblVideoBitrate";
            this.lblVideoBitrate.Size = new System.Drawing.Size(53, 12);
            this.lblVideoBitrate.TabIndex = 4;
            this.lblVideoBitrate.Text = "Bitrate:";
            // 
            // lblGeneralDuration
            // 
            this.lblGeneralDuration.AutoSize = true;
            this.lblGeneralDuration.Location = new System.Drawing.Point(162, 71);
            this.lblGeneralDuration.Name = "lblGeneralDuration";
            this.lblGeneralDuration.Size = new System.Drawing.Size(59, 12);
            this.lblGeneralDuration.TabIndex = 4;
            this.lblGeneralDuration.Text = "Duration:";
            // 
            // lblGeneralSize
            // 
            this.lblGeneralSize.AutoSize = true;
            this.lblGeneralSize.Location = new System.Drawing.Point(6, 71);
            this.lblGeneralSize.Name = "lblGeneralSize";
            this.lblGeneralSize.Size = new System.Drawing.Size(35, 12);
            this.lblGeneralSize.TabIndex = 4;
            this.lblGeneralSize.Text = "Size:";
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
            this.txtVideoNote.Location = new System.Drawing.Point(377, 20);
            this.txtVideoNote.Multiline = true;
            this.txtVideoNote.Name = "txtVideoNote";
            this.txtVideoNote.Size = new System.Drawing.Size(279, 47);
            this.txtVideoNote.TabIndex = 6;
            // 
            // lblGeneralChapters
            // 
            this.lblGeneralChapters.AutoSize = true;
            this.lblGeneralChapters.Location = new System.Drawing.Point(344, 71);
            this.lblGeneralChapters.Name = "lblGeneralChapters";
            this.lblGeneralChapters.Size = new System.Drawing.Size(59, 12);
            this.lblGeneralChapters.TabIndex = 9;
            this.lblGeneralChapters.Text = "Chapters:";
            // 
            // chkGeneralChaptersIncluded
            // 
            this.chkGeneralChaptersIncluded.AutoSize = true;
            this.chkGeneralChaptersIncluded.Checked = true;
            this.chkGeneralChaptersIncluded.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGeneralChaptersIncluded.Location = new System.Drawing.Point(421, 70);
            this.chkGeneralChaptersIncluded.Name = "chkGeneralChaptersIncluded";
            this.chkGeneralChaptersIncluded.Size = new System.Drawing.Size(72, 16);
            this.chkGeneralChaptersIncluded.TabIndex = 10;
            this.chkGeneralChaptersIncluded.Text = "Included";
            this.chkGeneralChaptersIncluded.UseVisualStyleBackColor = true;
            // 
            // chkGeneralChaptersNamed
            // 
            this.chkGeneralChaptersNamed.AutoSize = true;
            this.chkGeneralChaptersNamed.Location = new System.Drawing.Point(508, 70);
            this.chkGeneralChaptersNamed.Name = "chkGeneralChaptersNamed";
            this.chkGeneralChaptersNamed.Size = new System.Drawing.Size(54, 16);
            this.chkGeneralChaptersNamed.TabIndex = 10;
            this.chkGeneralChaptersNamed.Text = "Named";
            this.chkGeneralChaptersNamed.UseVisualStyleBackColor = true;
            // 
            // lblVideoResolution
            // 
            this.lblVideoResolution.AutoSize = true;
            this.lblVideoResolution.Location = new System.Drawing.Point(6, 49);
            this.lblVideoResolution.Name = "lblVideoResolution";
            this.lblVideoResolution.Size = new System.Drawing.Size(71, 12);
            this.lblVideoResolution.TabIndex = 4;
            this.lblVideoResolution.Text = "Resolution:";
            // 
            // txtVideoResolution
            // 
            this.txtVideoResolution.Location = new System.Drawing.Point(83, 46);
            this.txtVideoResolution.Name = "txtVideoResolution";
            this.txtVideoResolution.Size = new System.Drawing.Size(73, 21);
            this.txtVideoResolution.TabIndex = 5;
            // 
            // grpVideo
            // 
            this.grpVideo.Controls.Add(this.cmbVideoFramerate);
            this.grpVideo.Controls.Add(this.txtVideoAR);
            this.grpVideo.Controls.Add(this.lblVideoAR);
            this.grpVideo.Controls.Add(this.txtVideoResolution);
            this.grpVideo.Controls.Add(this.lblVideoResolution);
            this.grpVideo.Controls.Add(this.txtVideoNote);
            this.grpVideo.Controls.Add(this.lblVideoNote);
            this.grpVideo.Controls.Add(this.lblVideoBitrate);
            this.grpVideo.Controls.Add(this.lblVideoFramerate);
            this.grpVideo.Controls.Add(this.txtVideoBitrate);
            this.grpVideo.Location = new System.Drawing.Point(12, 273);
            this.grpVideo.Name = "grpVideo";
            this.grpVideo.Size = new System.Drawing.Size(662, 74);
            this.grpVideo.TabIndex = 15;
            this.grpVideo.TabStop = false;
            this.grpVideo.Text = "Video";
            // 
            // btnProcess
            // 
            this.btnProcess.Enabled = false;
            this.btnProcess.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnProcess.Location = new System.Drawing.Point(590, 557);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 21);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "GO!";
            this.btnProcess.UseVisualStyleBackColor = true;
            // 
            // btnTargetBrowse
            // 
            this.btnTargetBrowse.Location = new System.Drawing.Point(509, 557);
            this.btnTargetBrowse.Name = "btnTargetBrowse";
            this.btnTargetBrowse.Size = new System.Drawing.Size(75, 21);
            this.btnTargetBrowse.TabIndex = 3;
            this.btnTargetBrowse.Text = "Browse";
            this.btnTargetBrowse.UseVisualStyleBackColor = true;
            // 
            // grpSource
            // 
            this.grpSource.Controls.Add(this.cmbSourceResolution);
            this.grpSource.Controls.Add(this.cmbSourceType);
            this.grpSource.Controls.Add(this.lblSourceType);
            this.grpSource.Controls.Add(this.lblSourceName);
            this.grpSource.Controls.Add(this.btnSourceGuess);
            this.grpSource.Controls.Add(this.txtSourceName);
            this.grpSource.Controls.Add(this.lblSourceResolution);
            this.grpSource.Location = new System.Drawing.Point(12, 200);
            this.grpSource.Name = "grpSource";
            this.grpSource.Size = new System.Drawing.Size(662, 67);
            this.grpSource.TabIndex = 16;
            this.grpSource.TabStop = false;
            this.grpSource.Text = "Source";
            // 
            // cmbSourceResolution
            // 
            this.cmbSourceResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSourceResolution.FormattingEnabled = true;
            this.cmbSourceResolution.Location = new System.Drawing.Point(421, 37);
            this.cmbSourceResolution.Name = "cmbSourceResolution";
            this.cmbSourceResolution.Size = new System.Drawing.Size(126, 20);
            this.cmbSourceResolution.TabIndex = 8;
            // 
            // cmbSourceType
            // 
            this.cmbSourceType.FormattingEnabled = true;
            this.cmbSourceType.Location = new System.Drawing.Point(83, 37);
            this.cmbSourceType.Name = "cmbSourceType";
            this.cmbSourceType.Size = new System.Drawing.Size(126, 20);
            this.cmbSourceType.TabIndex = 8;
            // 
            // lblSourceType
            // 
            this.lblSourceType.AutoSize = true;
            this.lblSourceType.Location = new System.Drawing.Point(6, 40);
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
            this.btnSourceGuess.Location = new System.Drawing.Point(581, 12);
            this.btnSourceGuess.Name = "btnSourceGuess";
            this.btnSourceGuess.Size = new System.Drawing.Size(75, 21);
            this.btnSourceGuess.TabIndex = 3;
            this.btnSourceGuess.Text = "Guess";
            this.btnSourceGuess.UseVisualStyleBackColor = true;
            // 
            // txtSourceName
            // 
            this.txtSourceName.Location = new System.Drawing.Point(83, 12);
            this.txtSourceName.Name = "txtSourceName";
            this.txtSourceName.Size = new System.Drawing.Size(492, 21);
            this.txtSourceName.TabIndex = 6;
            // 
            // lblSourceResolution
            // 
            this.lblSourceResolution.AutoSize = true;
            this.lblSourceResolution.Location = new System.Drawing.Point(344, 40);
            this.lblSourceResolution.Name = "lblSourceResolution";
            this.lblSourceResolution.Size = new System.Drawing.Size(71, 12);
            this.lblSourceResolution.TabIndex = 4;
            this.lblSourceResolution.Text = "Resolution:";
            // 
            // cmbVideoFramerate
            // 
            this.cmbVideoFramerate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVideoFramerate.FormattingEnabled = true;
            this.cmbVideoFramerate.Location = new System.Drawing.Point(227, 20);
            this.cmbVideoFramerate.Name = "cmbVideoFramerate";
            this.cmbVideoFramerate.Size = new System.Drawing.Size(88, 20);
            this.cmbVideoFramerate.TabIndex = 8;
            // 
            // lblVideoAR
            // 
            this.lblVideoAR.AutoSize = true;
            this.lblVideoAR.Location = new System.Drawing.Point(162, 49);
            this.lblVideoAR.Name = "lblVideoAR";
            this.lblVideoAR.Size = new System.Drawing.Size(83, 12);
            this.lblVideoAR.TabIndex = 4;
            this.lblVideoAR.Text = "Aspect Ratio:";
            // 
            // txtVideoAR
            // 
            this.txtVideoAR.Location = new System.Drawing.Point(251, 46);
            this.txtVideoAR.Name = "txtVideoAR";
            this.txtVideoAR.Size = new System.Drawing.Size(64, 21);
            this.txtVideoAR.TabIndex = 5;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 597);
            this.Controls.Add(this.grpSource);
            this.Controls.Add(this.btnTargetBrowse);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.grpVideo);
            this.Controls.Add(this.lblFootnote);
            this.Controls.Add(this.lblTargetLocation);
            this.Controls.Add(this.grpSubtitle);
            this.Controls.Add(this.txtTargetLocation);
            this.Controls.Add(this.grpAudio);
            this.Controls.Add(this.grpGeneral);
            this.Controls.Add(this.grpInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "TAiCHi NFO Generator";
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Button btnInputClear;
        private System.Windows.Forms.Label lblInputFile;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Label lblGeneralReleaseName;
        private System.Windows.Forms.TextBox txtGeneralReleaseName;
        private System.Windows.Forms.TextBox txtGeneralAudio;
        private System.Windows.Forms.TextBox txtGeneralYear;
        private System.Windows.Forms.Label lblGeneralAudio;
        private System.Windows.Forms.Label lblGeneralResolution;
        private System.Windows.Forms.Label lblGeneralYear;
        private System.Windows.Forms.TextBox txtGeneralEdition;
        private System.Windows.Forms.Label lblGeneralEdition;
        private System.Windows.Forms.TextBox txtGeneralTitle;
        private System.Windows.Forms.Label lblGeneralTitle;
        private System.Windows.Forms.GroupBox grpAudio;
        private System.Windows.Forms.Button btnAudioAdd;
        private System.Windows.Forms.ListBox lstAudio;
        private System.Windows.Forms.TextBox txtAudioComment;
        private System.Windows.Forms.TextBox txtAudioBitrate;
        private System.Windows.Forms.Label lblAudioComment;
        private System.Windows.Forms.TextBox txtAudioChannels;
        private System.Windows.Forms.Label lblAudioBitrate;
        private System.Windows.Forms.TextBox txtAudioCodec;
        private System.Windows.Forms.Label lblAudioChannels;
        private System.Windows.Forms.Label lblAudioCodec;
        private System.Windows.Forms.TextBox txtAudioLanguage;
        private System.Windows.Forms.Label lblAudioLanguage;
        private System.Windows.Forms.GroupBox grpSubtitle;
        private System.Windows.Forms.Button btnSubtitleAdd;
        private System.Windows.Forms.ListBox lstSubtitle;
        private System.Windows.Forms.TextBox txtSubtitleComment;
        private System.Windows.Forms.TextBox txtSubtitleFormat;
        private System.Windows.Forms.Label lblSubtitleComment;
        private System.Windows.Forms.Label lblSubtitleFormat;
        private System.Windows.Forms.TextBox txtSubtitleLanguage;
        private System.Windows.Forms.Label lblSubtitleLanguage;
        private System.Windows.Forms.Label lblFootnote;
        private System.Windows.Forms.TextBox txtTargetLocation;
        private System.Windows.Forms.Label lblTargetLocation;
        private System.Windows.Forms.Button btnInputBrowse;
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
        private System.Windows.Forms.Label lblVideoResolution;
        private System.Windows.Forms.TextBox txtVideoResolution;
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
        private System.Windows.Forms.Button btnGeneralGenerate;
        private System.Windows.Forms.ComboBox cmbVideoFramerate;
        private System.Windows.Forms.TextBox txtVideoAR;
        private System.Windows.Forms.Label lblVideoAR;
    }
}

