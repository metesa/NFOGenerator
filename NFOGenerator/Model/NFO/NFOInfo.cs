/// Copyright 2017 Troy Lewis. All Rights Reserved
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

using System.Collections.Generic;
using System.ComponentModel;

using NFOGenerator.Model.General;
using NFOGenerator.Util;

namespace NFOGenerator.Model.NFO
{
    /// <summary>
    /// NFOInfo is a class which stores all mutable or dictionary like info of a NFO file.
    /// NFOInfo contains all info about the movie itself for a NFO.
    /// 
    ///     Each property contains a description which indicates the way how this description 
    ///         is formed in NFO file.
    ///     Here are the explaination of those descriptions:
    ///         "Title"   : movie title
    ///             ReleaseName
    ///         "Release" : release info section
    ///             iMDB
    ///             SOURCE
    ///             SiZE
    ///             DURATiON
    ///             ViDEO BiTRATE
    ///             RESOLUTiON
    ///             FRAMERATE
    ///             AUDIO
    ///             SUBTiTLES
    ///             CHAPTERS
    ///             NOTES
    /// </summary>
    public class NFOInfo
    {
        #region Private Fields
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
        #endregion

        #region Constructors
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
        #endregion

        #region Public Methods
        /// <summary>
        /// Map dictionary-like properties that contains certain keyword in its description to a dictionary
        /// </summary>
        /// <param name="keyWord">certain description</param>
        /// <returns>properties info</returns>
        public Dictionary<string, string> MapDictionaryPropertiesWithKeyword(string keyWord)
        {
            return ClassUtil.ToStringMap(this, keyWord);
        }
        /// <summary>
        /// Map mutable properties that contains certain keyword in its description to a dictionary
        /// </summary>
        /// <param name="keyWord">certain description</param>
        /// <returns>properties info</returns>
        public Dictionary<string, Alignment> MapMutablePropertiesWithKeyword(string keyWord)
        {
            Dictionary<string, string> properties = ClassUtil.ToStringMap(this, keyWord);
            Dictionary<string, Alignment> mutableValue = new Dictionary<string, Alignment>();
            if (properties.Count > 0)
            {
                foreach (KeyValuePair<string, string> item in properties)
                {
                    mutableValue.Add(item.Value, titleAlignment);
                }
            }
            return mutableValue;
        }
        #endregion

        #region Properties
        [Description("Title")]
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

        [Description("Release")]
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

        [Description("Release")]
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

        [Description("Release")]
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

        [Description("Release")]
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

        [Description("Release")]
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

        [Description("Release")]
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

        [Description("Release")]
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

        [Description("Release")]
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

        [Description("Release")]
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

        [Description("Release")]
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

        [Description("Release")]
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
        #endregion
    }
}
