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
    public class GeneralInfo
    {
        public string imdbLink;
        public string fileSize;
        public string duration;
        public string nameTitle;
        public string nameYear;
        public string nameEdition;
        public string nameHybrid;
        public string nameProper;
        public string nameResolution;
        public string nameSource;
        public string nameAudio;
        public string nameVideo;
        public string releaseName;
        public string releaseNameSrc;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="paraTitle">Movie title.</param>
        /// <param name="paraYear">Cinema year.</param>
        /// <param name="paraEdition">Edition.</param>
        /// <param name="paraHybrid">Hybrid encode or not.</param>
        /// <param name="paraProper">PROPER, REPACK, etc.</param>
        /// <param name="paraResolution">Resolution standard.</param>
        /// <param name="paraSource">Source type.</param>
        /// <param name="paraAudio">Main audio format.</param>
        /// <param name="paraVideo">Video codec.</param>
       
        public GeneralInfo(string paraTitle, string paraYear, string paraEdition, string paraHybrid,
            string paraProper, string paraResolution, string paraSource, string paraAudio, string paraVideo)
        {
            this.nameTitle = paraTitle;
            this.nameYear = paraYear;
            this.nameEdition = paraEdition;
            this.nameHybrid = paraHybrid;
            this.nameProper = paraProper;
            this.nameResolution = paraResolution;
            this.nameSource = paraSource;
            this.nameAudio = paraAudio;
            this.nameVideo = paraVideo;
        }

        public GeneralInfo()
        {
        }
        // End of constructors

        /// <summary>
        /// Generate a complete release name.
        /// </summary>
        /// <returns>release name</returns>
        public string GenerateRLZName(string separate, string groupName)
        {
            this.releaseName = this.nameTitle + separate + this.nameYear + this.RemoveSepIfEmpty(this.nameEdition, separate) +
                this.RemoveSepIfEmpty(this.nameHybrid, separate) + this.RemoveSepIfEmpty(this.nameProper, separate) + separate +
                this.nameResolution + separate + this.nameSource + separate + this.nameAudio + separate + this.nameVideo + "-" + groupName;
            return this.releaseName;
        }
        
        /// <summary>
        /// See if the encode is a hybrid.
        /// </summary>
        /// <returns>"Hybrid" if yes, otherwise blank.</returns>
        public string GetHybrid()
        {
            if (this.nameHybrid == "Yes")
            {
                return "Hybrid";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Remove the leading dot if an option is empty, such as Edition, PROPER, etc.
        /// </summary>
        /// <param name="paraStr"></param>
        /// <returns>".OPTION" if option is filled, otherwise blank.</returns>
        protected string RemoveSepIfEmpty(string paraStr, string separate)
        {
            string result;
            if (paraStr == "")
            {
                result = "";
            }
            else
            {
                result = separate + paraStr;
            }
            return result;
        }
    }
}
