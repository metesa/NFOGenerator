/// Copyright 2017 Jevenski C. Woodsmann. All Rights Reserved
/// 
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
/// 
///     http://www.apache.org/licenses/LICENSE-2.0
/// 
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NFOGenerator.Model.FileInfo
{
    public class AudioInfo
    {
        #region Private Fields
        private string audioLang;
        private string audioCodec;
        private string audioChan;
        private string audioBitr;
        private bool audioComm;
        private string audioCommentator;
        private string audioInfoFull;

        private bool containsUnknownItem;
        #endregion

        #region Constructors
        public AudioInfo(bool isCommentary)
        {
            this.audioComm = isCommentary;
        }

        public AudioInfo()
        {
            this.audioComm = false;
        }

        public AudioInfo(string language, string codec, string channel, string bitrate, bool commentary, string commentator)
        {
            UpdateAudioInfo(language, codec, channel, bitrate, commentary, commentator);
        }
        #endregion

        #region Public Methods
        public void UpdateAudioInfo(string language, string codec, string channel, string bitrate, bool commentary, string commentator)
        {
            this.audioLang = language;
            this.audioCodec = parseCodec(codec);
            this.audioChan = channel;
            this.audioBitr = bitrate;
            this.audioComm = commentary;
            this.audioCommentator = commentator;
            if (language == "Unknown" || audioChan == "Unknown" || audioBitr == "")
            {
                containsUnknownItem = true;
            }
            else
            {
                containsUnknownItem = false;
            }
            UpdateAudioText();
        }
        #endregion

        #region Private Methods
        private void UpdateAudioText()
        {
            if (this.audioComm)
            {
                this.audioInfoFull = this.audioLang + ", " + this.audioCodec + ", " + AudioChannel +
                    ", " + this.audioBitr + Environment.NewLine + "  (" + this.audioCommentator + ")";
            }
            else
            {
                this.audioInfoFull = this.audioLang + ", " + this.audioCodec + ", " + AudioChannel +
                    ", " + this.audioBitr;
            }
        }
        
        private string parseCodec(string text)
        {
            switch (text)
            {
                case "AC-3":
                    return "DD";
                default:
                    return text;
            }
        }
        #endregion

        #region Properties
        public string AudioLanguage
        {
            get
            {
                return audioLang;
            }
            set
            {
                audioLang = value;
                UpdateAudioText();
            }
        }

        public string AudioCodec
        {
            get
            {
                return audioCodec;
            }
            set
            {
                audioCodec = parseCodec(value);
                UpdateAudioText();
            }
        }

        public string AudioChannel
        {
            get
            {
                if (audioChan == "1.0")
                {
                    return audioChan + " channel";
                }
                else if (audioChan.EndsWith(" channels"))
                {
                    return audioChan;
                }
                else
                {
                    return audioChan + " channels";
                }
            }
            set
            {
                audioChan = value;
                UpdateAudioText();
            }
        }

        public string AudioBitrate
        {
            get
            {
                return audioBitr;
            }
            set
            {
                audioBitr = value;
                UpdateAudioText();
            }
        }

        public bool AudioCommentary
        {
            get
            {
                return audioComm;
            }
            set
            {
                audioComm = value;
                UpdateAudioText();
            }
        }

        public string AudioCommentator
        {
            get
            {
                return audioCommentator;
            }
            set
            {
                audioCommentator = value;
                UpdateAudioText();
            }
        }

        public string AudioTitleInfo
        {
            get
            {
                switch (audioCodec)
                {
                    case "DTS-ES":
                        return AudioCodec;
                    case "DD-EX":
                        return AudioCodec;
                    case "DTS":
                        return AudioCodec;
                    default:
                        return AudioCodec + audioChan;
                }
            }
        }

        public bool ContainsUnknowItem
        {
            get
            {
                return containsUnknownItem;
            }
        }
        #endregion

        #region Object Members
        public override string ToString()
        {
            return audioInfoFull;
        }
        #endregion
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
