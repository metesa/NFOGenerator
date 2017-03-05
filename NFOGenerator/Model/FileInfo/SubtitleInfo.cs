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

namespace NFOGenerator.Model.FileInfo
{
    public class SubtitleInfo
    {
        private string subLang;
        private string subFormat;
        private string subComment;
        private bool subForced;
        private bool subSDH;
        private string subInfoFull;

        private bool containsUnknownItem;

        public SubtitleInfo(bool isForced, bool isSDH)
       {
            this.subForced = isForced;
            this.subSDH = isSDH;
        }

        public SubtitleInfo()
        {
            this.subForced = false;
            this.subSDH = false;
        }

        public SubtitleInfo(string language, string format, string comment, bool forced, bool sdh)
        {
            UpdateSubtitleInfo(language, format, comment, forced, sdh);
        }

        public void UpdateSubtitleInfo(string language, string format, string comment, bool forced, bool sdh)
        {
            this.subLang = language;
            this.subFormat = format;
            this.subComment = comment;
            this.subForced = forced;
            this.subSDH = sdh;
            if (language == "Unknown")
            {
                containsUnknownItem = true;
            }
            else
            {
                containsUnknownItem = false;
            }
            UpdateSubtitleText();
        }

        private void UpdateSubtitleText()
        {
            if (this.subSDH)
            {
                if (this.subForced)
                {
                    this.subInfoFull = this.subLang + " (" + this.subFormat + ", SDH, Forced)";
                }
                else
                {
                    this.subInfoFull = this.subLang + " (" + this.subFormat + ", SDH)";
                }
            }
            else
            {
                if (this.subForced)
                {
                    this.subInfoFull = this.subLang + " (" + this.subFormat + ", Forced)";
                }
                else
                {
                    this.subInfoFull = this.subLang + " (" + this.subFormat + ")";
                }
            }
        }

        public string SubtitleLanguage
        {
            get
            {
                return subLang;
            }
            set
            {
                subLang = value;
            }
        }

        public string SubtitleFormat
        {
            get
            {
                return subFormat;
            }
            set
            {
                subFormat = value;
            }
        }

        public string SubtitleComment
        {
            get
            {
                return subComment;
            }
            set
            {
                subComment = value;
            }
        }

        public bool SubtitleForced
        {
            get
            {
                return subForced;
            }
            set
            {
                subForced = value;
            }
        }

        public bool SubtitleSDH
        {
            get
            {
                return subSDH;
            }
            set
            {
                subSDH = value;
            }
        }

        public override string ToString()
        {
            return this.subInfoFull;
        }

        public bool ContainsUnknowItem
        {
            get
            {
                return containsUnknownItem;
            }
        }
    }
}
