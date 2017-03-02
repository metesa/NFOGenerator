using System;
using System.Collections.Generic;
using System.Text;

namespace NFOGenerator.Model.FileInfo
{
    public class SubtitleInfo
    {
        public string subLang;
        public string subFormat;
        public string subComment;
        public bool subForced;
        public bool subSDH;
        public string subInfoFull;

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
    }
}
