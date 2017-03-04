using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace NFOGenerator.Util
{
    class IMDbReader
    {
        private string IMDbRes;
        public string title { get; set; }
        public string IMDbID { get; set; }
        public WebClient IMDbInfo;
        public XmlDocument IMDbParser;

        public IMDbReader()
        {
            this.IMDbInfo = new WebClient();
            this.IMDbParser = new XmlDocument();
        }

        public void SendIMDbRequest()
        {
            Stream IMDbStream = this.IMDbInfo.OpenRead("http://www.omdbapi.com/?t=" + this.title + "&r=xml");
            StreamReader IMDbSR = new StreamReader(IMDbStream);

            this.IMDbRes = IMDbSR.ReadToEnd();

            IMDbSR.Close();
            IMDbStream.Close();
        }

        public void ReadIMDbID()
        {
            IMDbParser.LoadXml(this.IMDbRes);
            this.IMDbID = this.IMDbParser.SelectSingleNode("/root/movie/@imdbID").Value;
        }
    }
}
