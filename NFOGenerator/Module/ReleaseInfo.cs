using System;
using System.Collections.Generic;
using System.Text;

namespace NFOGenerator
{
    class ReleaseInfo
    {
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

        // Constructors        
        public ReleaseInfo(string paraTitle, string paraYear, string paraEdition, string paraHybrid,
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
        // End of constructors

        // Generate a complete release name.
        public string generateRLZName()
        {
            this.releaseName = this.nameTitle + "." + this.nameYear + this.removeDotIfEmpty(this.nameEdition) + 
                this.removeDotIfEmpty(this.nameHybrid) + this.removeDotIfEmpty(this.nameProper) + "." + 
                this.nameResolution + "." + this.nameSource + "." + this.nameAudio + "." + this.nameVideo + "-TAiCHi";
            return this.releaseName;
        }

        // See if the encode is a hybrid.
        public string getHybrid()
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

        // Remove the leading dot if an option is empty, such as Edition, PROPER, etc.
        private string removeDotIfEmpty(string paraStr)
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
