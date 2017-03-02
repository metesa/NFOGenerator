using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NFOGenerator.Model.FileInfo
{
    public class AudioInfo
    {
        public string audioLang;
        public string audioCodec;
        public string audioChan;
        public string audioBitr;
        public bool audioComm;
        public string audioCommentator;
        public string audioInfoFull;

        public AudioInfo(bool isCommentary)
        {
            this.audioComm = isCommentary;
        }

        public AudioInfo()
        {
            this.audioComm = false;
        }

        public void UpdateAudioInfo()
        {
            if (this.audioComm)
            {
                this.audioInfoFull = this.audioLang + ", " + this.audioCodec + ", " + this.audioChan + 
                    ", " + this.audioBitr + ", " + this.audioCommentator;
            }
            else
            {
                this.audioInfoFull = this.audioLang + ", " + this.audioCodec + ", " + this.audioChan + 
                    ", " + this.audioBitr;
            }
        }
    }

    /*
    public enum AudioCodec
    {
        [Description("DTS-HD MA")]
        DTS_HD_MA = 0,
        [Description("TrueHD")]
        TrueHD,
        [Description("LPCM")]
        LPCM,
        [Description("FLAC")]
        FLAC,
        [Description("AURO")]
        AURO,
        [Description("DTS-HD HR")]
        DTS_HD_HR = 0,
        [Description("DTS")]
        DTS,
        [Description("DTS-ES")]
        DTS_ES,
        [Description("DD")]
        AC3,
        [Description("DD-EX")]
        AC3_EX,
        [Description("DD+")]
        EAC3,
        [Description("AAC")]
        AAC,
        [Description("")]
        Unknown
    }

    public enum AudioChannel
    {
        [Description("1.0")]
        C10,
        [Description("2.0")]
        C20,
        [Description("2.1")]
        C21,
        [Description("3.0")]
        C30,
        [Description("3.1")]
        C31,
        [Description("4.0")]
        C40,
        [Description("4.1")]
        C41,
        [Description("5.0")]
        C50,
        [Description("5.1")]
        C51,
        [Description("6.1")]
        C61,
        [Description("7.1")]
        C71,
        [Description("8.0")]
        C80,
        [Description("9.0")]
        C90,
        [Description("9.1")]
        C91,
        [Description("10.0")]
        C100,
        [Description("10.1")]
        C101,
        [Description("11.1")]
        C111,
        [Description("13.1")]
        C131,
        [Description("")]
        Unknown
    }
    */
}
