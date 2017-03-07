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
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace NFOGenerator.Main.IMDb
{
    class IMDbReader
    {
        public string result;
        public string[] poster { get; set; }
        public string[] title { get; set; }
        public string[] year { get; set; }
        public string[] IMDbID { get; set; }
        public bool isResponding;
        public int resultCount { get; set; }
        private WebClient IMDbInfo;
        private XmlDocument IMDbParser;

        public IMDbReader()
        {
            this.IMDbInfo = new WebClient();
            this.IMDbParser = new XmlDocument();
        }

        /// <summary>
        /// Search IMDb for movie title and release year.
        /// </summary>
        /// <param name="paraTitle">Movie title (mandatory).</param>
        /// <param name="paraYear">Release year (optional).</param>
        public void SearchIMDb(string paraTitle, string paraYear)
        {
            Stream IMDbStream = this.IMDbInfo.OpenRead("http://www.omdbapi.com/?s=" + paraTitle + 
                "&y=" + paraYear + "&type=movie&r=xml");
            StreamReader IMDbRes = new StreamReader(IMDbStream);

            this.result = IMDbRes.ReadToEnd();

            this.IMDbParser.LoadXml(this.result);
            this.IsResponding();
            this.GetResultCount();

            if (this.isResponding)
            {
                this.title = new string[this.resultCount];
                this.IMDbID = new string[this.resultCount];
                this.year = new string[this.resultCount];
                this.poster = new string[this.resultCount];
                XmlNodeList nodes = IMDbParser.SelectNodes("/root/result");

                for (int i = 0; i < this.resultCount; i++)
                {
                    this.title[i] = nodes[i].Attributes["title"].Value;
                    this.IMDbID[i] = nodes[i].Attributes["imdbID"].Value;
                    this.year[i] = nodes[i].Attributes["year"].Value;
                    if (nodes[i].Attributes["poster"] != null)
                    {
                        this.poster[i] = nodes[i].Attributes["poster"].Value;
                    }
                    else
                    {
                        this.poster[i] = "";
                    }
                }
            }
            else
            {
                this.title = new string[1];
                this.IMDbID = new string[1];
                this.year = new string[1];
                this.poster = new string[1];
                this.title[0] = "Movie not found";
                this.IMDbID[0] = "";
                this.year[0] = "";
                this.poster[0] = "";
            }

            IMDbRes.Close();
            IMDbStream.Close();
        }

        private void IsResponding()
        {
            if (this.IMDbParser.SelectSingleNode("/root").Attributes[0].LocalName == "totalResults" &&
                this.IMDbParser.SelectSingleNode("/root").Attributes[1].Value == "True")
            {
                this.isResponding = true;
            }
            else
            {
                this.isResponding = false;
            }
        }

        private void GetResultCount()
        {
            if (this.isResponding)
            {
                int count = Convert.ToInt16(this.IMDbParser.SelectSingleNode("/root/@totalResults").Value);
                if ( count > 10)
                {
                    this.resultCount = 10;
                }
                else
                {
                    this.resultCount = count;
                }
            }
            else
            {
                this.resultCount = 1;
            }
        }
    }
}
