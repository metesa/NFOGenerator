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
        public string GenerateRLZName()
        {
            this.releaseName = this.nameTitle + "." + this.nameYear + this.RemoveDotIfEmpty(this.nameEdition) + 
                this.RemoveDotIfEmpty(this.nameHybrid) + this.RemoveDotIfEmpty(this.nameProper) + "." + 
                this.nameResolution + "." + this.nameSource + "." + this.nameAudio + "." + this.nameVideo + "-TAiCHi";
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
        protected string RemoveDotIfEmpty(string paraStr)
        {
            string result;
            if (paraStr == "")
            {
                result = "";
            }
            else
            {
                result = "." + paraStr;
            }
            return result;
        }
    }
}
