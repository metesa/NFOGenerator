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
using System.Text;
using NFOGenerator.Util;
using NFOGenerator.Model.FileInfo;
using MediaInfoLib;

namespace NFOGenerator.Model.FileInfo
{
    public class ReleaseInfo
    {
        public int[] audioIndex;
        public int[] subtitleIndex;
        
        public MediaInfo MI = new MediaInfo();
        public GeneralInfo GI = new GeneralInfo();
        public VideoInfo VI = new VideoInfo();
        public AudioInfo[] AI;
        public SubtitleInfo[] SI;
        public MenuInfo MNI;

        public ReleaseInfo()
        {
        }

        public void ReadMediaInfo(string inputFile)
        {
            MI.Open(inputFile);

            this.GI.fileSize = this.MI.Get(StreamKind.General, 0, "FileSize/String4");
            this.GI.duration = this.MI.Get(StreamKind.General, 0, "Duration/String1");

            // Get video info.
            this.VI.width = this.MI.Get(StreamKind.Video, 0, "Width");
            this.VI.height = this.MI.Get(StreamKind.Video, 0, "Height");
            this.VI.displayAR = this.MI.Get(StreamKind.Video, 0, "DisplayAspectRatio/String");
            this.VI.framerate = this.MI.Get(StreamKind.Video, 0, "FrameRate/String");
            this.VI.bitrate = this.MI.Get(StreamKind.Video, 0, "BitRate/String");

            // Switch among video codecs.
            string videoFormat = this.MI.Get(StreamKind.Video, 0, "Format");
            switch (videoFormat)
            {
                case "AVC":
                    //if (this.MI.Inform().Contains("x264"))
                    if (this.MI.Get(StreamKind.Video, 0, "Encoded_Library").Contains("x264"))
                    {
                        this.VI.codec = "x264";
                    }
                    else
                    {
                        this.VI.codec = "H.264";
                    }
                    break;
                case "HEVC":
                    this.VI.codec = "HEVC";
                    break;
                case "MPEG Video":
                    this.VI.codec = "MPEG-2";
                    break;
                case "VC-1":
                    this.VI.codec = "VC-1";
                    break;
                case "MPEG-4 Visual":
                    this.VI.codec = "XviD";
                    break;
                default:
                    this.VI.codec = "UNKNOWN";
                    break;
            }

            this.AI = new AudioInfo[this.MI.Count_Get(StreamKind.Audio)];
            this.audioIndex = new int[this.MI.Count_Get(StreamKind.Audio)];

            for (int i = 0; i < this.MI.Count_Get(StreamKind.Audio); i++)
            {
                string language;
                if (this.MI.Get(StreamKind.Audio, i, "Language/String") == "")
                {
                    language = "Unknown";
                }
                else
                {
                    language = this.MI.Get(StreamKind.Audio, i, "Language/String");
                }
                this.AI[i] = new AudioInfo(
                    language,
                    this.MI.Get(StreamKind.Audio, i, "Format"),
                    this.GetChannels(
                        this.MI.Get(StreamKind.Audio, i, "ChannelPositions/String2"),
                        this.MI.Get(StreamKind.Audio, i, "Channel(s)")
                    ),
                    this.MI.Get(StreamKind.Audio, i, "BitRate/String"),
                    this.isSomething(this.MI.Get(StreamKind.Audio, i, "Title").ToLower(), "comm"),
                    this.MI.Get(StreamKind.Audio, i, "Title")
                );
                audioIndex[i] = i;
            }

            this.SI = new SubtitleInfo[this.MI.Count_Get(StreamKind.Text)];
            this.subtitleIndex = new int[this.MI.Count_Get(StreamKind.Text)];

            for (int i = 0; i < this.MI.Count_Get(StreamKind.Text); i++)
            {
                string language;
                if (this.MI.Get(StreamKind.Text, i, "Language/String") == "")
                {
                    language = "Unknown";
                }
                else
                {
                    language = this.MI.Get(StreamKind.Text, i, "Language/String");
                }
                this.SI[i] = new SubtitleInfo(
                    language,
                    this.MI.Get(StreamKind.Text, i, "Format"),
                    this.MI.Get(StreamKind.Text, 0, "Title"),
                    (this.isYesOrNo(this.MI.Get(StreamKind.Text, i, "Forced")) || this.isSomething(this.MI.Get(StreamKind.Text, i, "Title"), "Forced")),
                    this.isSomething(this.MI.Get(StreamKind.Text, i, "Title"), "SDH")
                );
                this.subtitleIndex[i] = i;
            }

            this.MNI = new MenuInfo();
            if (this.MI.Count_Get(StreamKind.Menu) > 0)
            {
                this.MNI.Included = true;
                this.MNI.Update(this.MI.Get(StreamKind.Menu, 0, "Inform"));
            }
            else
            {
                this.MNI.Included = false;
                this.MNI.Named = false;
            }
        }

        public void SwapIndex(StreamKind kind, int index1, int index2)
        {
            if (index1 != index2)
            {
                if (kind == StreamKind.Audio)
                {
                    if (index1 < this.AI.Length && index2 < this.AI.Length)
                    {
                        int temp = audioIndex[index1];
                        audioIndex[index1] = audioIndex[index2];
                        audioIndex[index2] = temp;
                    }
                }
                else if (kind == StreamKind.Text)
                {
                    if (index1 < this.SI.Length && index2 < this.SI.Length)
                    {
                        int temp = subtitleIndex[index1];
                        subtitleIndex[index1] = subtitleIndex[index2];
                        subtitleIndex[index2] = temp;
                    }
                }
            }
        }

        public string GetAllInfo(StreamKind kind)
        {
            string parameter = "";//存放所有参数
            string tempstr;
            int i = 0;
            while (true)
            {
                tempstr = MI.Get(kind, 0, i++, InfoKind.Name);
                if (tempstr == "")
                {
                    break;
                }
                parameter += "\r\n" + tempstr + "   : " + MI.Get(kind, 0, tempstr);
            }
            return parameter;
        }
        /*-------------------------------------------------------------------------
         * Protected custom methods down below
         * ------------------------------------------------------------------------*/

        protected string GetChannels(string paraChanPos, string paraChanCount)
        {
            string result;
            string firstPart = "";
            string secondPart = "";
            if (paraChanPos.Contains("."))
            {
                string[] chanStr = paraChanPos.Split(new char[]{'.'}, StringSplitOptions.RemoveEmptyEntries);
                if (chanStr.Length < 2)
                {
                    firstPart = paraChanPos;
                    secondPart = "0";
                }
                else
                {
                    firstPart = chanStr[0];
                    secondPart = chanStr[1];
                }
            }
            else
            {
                firstPart = paraChanPos;
                secondPart = "0";
            }

            firstPart = GetSumOfDigitalString(firstPart, "/").ToString();

            if (firstPart == "-1")
            {
                throw new Exception("Unrecognized channel positions: " + paraChanPos);
            }

            result = firstPart + "." + secondPart;
            if (GetSumOfDigitalString(result, ".").ToString() == paraChanCount)
            {
                return result;
            }
            else
            {
                return "Unknown";
            }
        }

        protected int GetSumOfDigitalString(string digitalString, string splitTag)
        {
            string[] strings = digitalString.Split(new string[]{splitTag}, StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;
            int digital = 0;
            foreach (string item in strings)
            {
                if (Int32.TryParse(item, out digital))
                {
                    sum += digital;
                }
                else
                {
                    return -1;
                }
            }
            return sum;
        }

        /// <summary>
        /// Determine if something is something, by checking if the full string contains a sub string.
        /// </summary>
        /// <param name="strFull">Full string.</param>
        /// <param name="strSub">Sub string.</param>
        /// <returns>True or False.</returns>
        protected bool isSomething(string strFull, string strSub)
        {
            if (strFull.Contains(strSub))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool isYesOrNo(string paraYesOrNo)
        {
            if (paraYesOrNo.Contains("Yes"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*-------------------------------------------------------------------------
         * Protected custom methods up above
         * ------------------------------------------------------------------------*/

        #region Properties
        #region AllInfo Properties
        public string AudioInfo
        {
            get
            {
                if (this.AI == null)
                {
                    return "";
                }
                string audioCombined = ""; ;
                int audioCount = this.AI.Length;
                for (int i = 0; i < audioCount; i++)
                {
                    audioCombined += this.AI[audioIndex[i]].ToString() + Environment.NewLine;
                }
                return audioCombined;
            }
        }

        public string SubtitleInfo
        {
            get
            {
                if (this.SI == null)
                {
                    return "";
                }
                string subCombined = "";
                int subtitleCount = this.SI.Length;
                if (subtitleCount == 0)
                {
                    return "";
                }
                subCombined = this.SI[subtitleIndex[0]].ToString();
                if (subtitleCount == 1)
                {
                    return subCombined;
                }
                for (int i = 1; i < subtitleCount; i++)
                {
                    subCombined += ", " + this.SI[subtitleIndex[i]].ToString();
                }
                return subCombined;
            }
        }

        public string ChapterInfo
        {
            get
            {
                if (this.MNI == null)
                {
                    return "";
                }
                return this.MNI.ToString();
            }
        }
        #endregion

        #region Audio Properties
        public int AudioCount
        {
            get
            {
                if (this.AI == null)
                {
                    return 0;
                }
                else
                {
                    return this.AI.Length;
                }
            }
        }

        public bool AudioContainsUnknownItem
        {
            get
            {
                if (this.AI == null)
                {
                    return false;
                }
                else
                {
                    bool containsUnknownItem = false;
                    for (int i = 0; i < this.MI.Count_Get(StreamKind.Audio); i++)
                    {
                        if (this.AI[i].ContainsUnknowItem)
                        {
                            containsUnknownItem = true;
                            break;
                        }
                    }
                    return containsUnknownItem;
                }
            }
            
        }
        #endregion

        #region Subtitle Properties
        public int SubtitleCount
        {
            get
            {
                if (this.SI == null)
                {
                    return 0;
                }
                else
                {
                    return this.SI.Length;
                }
            }
        }

        public bool SubtitleContainsUnknownItem
        {
            get
            {
                if (this.SI == null)
                {
                    return false;
                }
                else
                {
                    bool containsUnknownItem = false;
                    for (int i = 0; i < this.MI.Count_Get(StreamKind.Text); i++)
                    {
                        if (this.SI[i].ContainsUnknowItem)
                        {
                            containsUnknownItem = true;
                            break;
                        }
                    }
                    return containsUnknownItem;
                }
            }
        }
        #endregion

        #region Chapter Properties
        public bool ChapterIncluded
        {
            get
            {
                return this.MNI.Included;
            }
            set
            {
                this.MNI.Included = value;
            }
        }

        public bool ChapterNamed
        {
            get
            {
                return this.MNI.Named;
            }
            set
            {
                this.MNI.Named = value;
            }
        }
        #endregion
        #endregion
    }
}
