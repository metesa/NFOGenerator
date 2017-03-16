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
using System.Linq;
using System.IO;
using System.Net;
using System.Text;

using Newtonsoft.Json;

namespace NFOGenerator.Model.SomeDb
{
    class TVDbReader
    {
        private TVDbToken token;
        public TVDbSearchResults results;

        /// <summary>
        /// Sends a request to TheTVDb, using POST method for login and GET method for other requests.
        /// </summary>
        /// <param name="route">Request route.</param>
        /// <param name="login">Is login or not.</param>
        /// <returns>Response JSON string.</returns>
        private string SendRequest(string route, bool login)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://api.thetvdb.com/" + route);
            req.ContentType = "application/json";
            if (!login)
            {
                req.Method = "GET";
                req.Headers["Authorization"] = "Bearer " + this.token.token;
            }
            else
            {
                req.Method = "POST";
                TVDbLogin loginObject = new TVDbLogin("1DABEEE170FC6AB5");
                string loginJSON = JsonConvert.SerializeObject(loginObject);

                StreamWriter TVDbReqSW = new StreamWriter(req.GetRequestStream());
                TVDbReqSW.Write(loginJSON);
                TVDbReqSW.Flush();
                TVDbReqSW.Close();
            }

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            StreamReader ResSR = new StreamReader(res.GetResponseStream());
            string result = ResSR.ReadToEnd();
            ResSR.Close();

            return result;
        }

        /// <summary>
        /// Sends a request to TheTVDb, using GET method as default request is non-login.
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        private string SendRequest(string route)
        {
            return this.SendRequest(route, false);
        }

        /// <summary>
        /// Gets and stores the JWT token.
        /// </summary>
        public void Login()
        {
            this.token = JsonConvert.DeserializeObject<TVDbToken>(this.SendRequest("login", true));
        }

        /// <summary>
        /// Refreshes the JWT token.
        /// </summary>
        public void RefreshToken()
        {
            this.token = JsonConvert.DeserializeObject<TVDbToken>(this.SendRequest("refresh_token"));
        }

        /// <summary>
        /// Searches TVDb by the given keyword.
        /// </summary>
        /// <param name="keyword">Search keyword.</param>
        public void Search(string keyword)
        {
            string searchResult = this.SendRequest("search/series?name=" + keyword);
            this.results = JsonConvert.DeserializeObject<TVDbSearchResults>(searchResult);
        }

        public string FindPoster(int id)
        {
            TVDbPosters posters = JsonConvert.DeserializeObject<TVDbPosters>(
                this.SendRequest("series/" + id.ToString() + "/images/query?keyType=poster"));
            int posterCount = posters.poster.Length;
            string posterAddr = "";
            if (posterCount > 0)
            {
                posterAddr = "http://www.thetvdb.com/banners/" + posters.poster[posterCount - 1].filename;
            }
            return posterAddr;
        }
    }

    /// <summary>
    /// Sends authentication info to TVDb.
    /// </summary>
    public class TVDbLogin
    {
        public string apikey;

        public TVDbLogin(string apikey)
        {
            this.apikey = apikey;
        }
    }

    /// <summary>
    /// Stores the authentication token returned from TVDb.
    /// </summary>
    public class TVDbToken
    {
        [JsonProperty("token")]
        public string token;
    }

    /// <summary>
    /// Stores a single search match.
    /// </summary>
    public class TVDbSearchData
    {
        [JsonProperty("aliases")]
        public string[] aliases;

        [JsonProperty("banner")]
        public string banner;

        [JsonProperty("firstAired")]
        public string firstAired;

        [JsonProperty("id")]
        public int ID;

        [JsonProperty("network")]
        public string network;

        [JsonProperty("overview")]
        public string overview;

        [JsonProperty("seriesName")]
        public string seriesName;

        [JsonProperty("status")]
        public string status;
    }

    public class TVDbSearchResults
    {
        [JsonProperty("data")]
        public TVDbSearchData[] match;
    }

    public class TVDbPosters
    {
        [JsonProperty("data")]
        public TVDbSinglePoster[] poster;
    }

    public class TVDbSinglePoster
    {
        [JsonProperty("id")]
        public int id;

        [JsonProperty("keyType")]
        public string keytype;

        [JsonProperty("subKey")]
        public string subkey;

        [JsonProperty("fileName")]
        public string filename;

        [JsonProperty("resolution")]
        public string resolution;

        [JsonProperty("thumbnail")]
        public string thumbnail;
    }
}
