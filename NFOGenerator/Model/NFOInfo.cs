using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using NFOGenerator.Model.General;
using NFOGenerator.Util;

namespace NFOGenerator.Model
{
    public class NFOInfo
    {
        private string releaseName;
        private Alignment titleAlignment;
        private string imdb;
        private string source;
        private string size;
        private string duration;
        private string videoBitrate;
        private string resolution;
        private string framerate;
        private string audio;
        private string subtitles;
        private string chapters;
        private string notes;
        
        public NFOInfo(string releaseName, Alignment titleAlignment, string imdb, string source, string size,
            string duration, string videoBitrate, string resolution, string framerate,
            string audio, string subtitles, string chapters, string notes)
        {
            this.releaseName = releaseName;
            this.titleAlignment = titleAlignment;
            this.imdb = imdb;
            this.source = source;
            this.size = size;
            this.duration = duration;
            this.videoBitrate = videoBitrate;
            this.resolution = resolution;
            this.framerate = framerate;
            this.audio = audio;
            this.subtitles = subtitles;
            this.chapters = chapters;
            this.notes = notes;
        }

        public Dictionary<string, string> MapDictionaryValue()
        {
            return ClassUtil.ToStringMap(this, "Dictionary");
        }

        public Dictionary<string, Alignment> MapMutableValue()
        {
            Dictionary<string, string> properties = ClassUtil.ToStringMap(this, "Mutable");
            Dictionary<string, Alignment> mutableValue = new Dictionary<string, Alignment>();
            if (properties.Count > 0)
            {
                foreach (KeyValuePair<string, string> item in properties)
                {
                    mutableValue.Add(item.Key, titleAlignment);
                }
            }
            return mutableValue;
        }

        [Description("Mutable")]
        public string ReleaseName
        {
            get
            {
                return releaseName;
            }
            set
            {
                releaseName = value;
            }
        }
        [Description("Dictionary")]
        public string iMDB
        {
            get
            {
                return imdb;
            }
            set
            {
                imdb = value;
            }
        }
        [Description("Dictionary")]
        public string SOURCE
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
            }
        }
        [Description("Dictionary")]
        public string SiZE
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
        [Description("Dictionary")]
        public string DURATiON
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
            }
        }
        [Description("Dictionary")]
        public string ViDEO_BiTRATE
        {
            get
            {
                return videoBitrate;
            }
            set
            {
                videoBitrate = value;
            }
        }
        [Description("Dictionary")]
        public string RESOLUTiON
        {
            get
            {
                return resolution;
            }
            set
            {
                resolution = value;
            }
        }
        [Description("Dictionary")]
        public string FRAMERATE
        {
            get
            {
                return framerate;
            }
            set
            {
                framerate = value;
            }
        }
        [Description("Dictionary")]
        public string AUDIO
        {
            get
            {
                return audio;
            }
            set
            {
                audio = value;
            }
        }
        [Description("Dictionary")]
        public string SUBTiTLES
        {
            get
            {
                return subtitles;
            }
            set
            {
                subtitles = value;
            }
        }
        [Description("Dictionary")]
        public string CHAPTERS
        {
            get
            {
                return chapters;
            }
            set
            {
                chapters = value;
            }
        }
        [Description("Dictionary")]
        public string NOTES
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }
    }
}
