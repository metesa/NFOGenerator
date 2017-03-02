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

using System;
using System.Collections.Generic;

using NFOGenerator.Model.General;
using NFOGenerator.Model.NFO.Line;
using NFOGenerator.Util;

namespace NFOGenerator.Model.NFO
{
    /// <summary>
    /// NFODocument defines a nfo text with certain NFOInfo and certain NFOStyle 
    /// </summary>
    public class NFODocument
    {
        #region Private Fields
        private NFOInfo nfoInfo;
        private NFOStyle nfoStyle;
        #endregion

        #region Constructor
        public NFODocument(NFOInfo nfoInfo, NFOStyle nfoStyle)
        {
            this.nfoInfo = nfoInfo;
            this.nfoStyle = nfoStyle;
        }
        #endregion
        
        #region Private Methods
        /// <summary>
        /// Generate nfo text base on NFOInfo and NFOStyle
        /// </summary>
        /// <returns>bytes array of nfo</returns>
        private byte[] GenerateNfoBytes()
        {
            List<byte> fullBytes = new List<byte>();

            Dictionary<string, string> nfoContent = nfoStyle.NFOContent;
            string keySource = "";
            string keyType = "";
            string[] keyParts;
            
            foreach (KeyValuePair<string, string> item in nfoContent)
            {
                if (item.Key.Contains("_"))
                {
                    keyParts = item.Key.Split('_');
                    keySource = keyParts[0];
                    keyType = keyParts[1];
                }
                else
                {
                    keySource = "Style";
                    keyType = item.Key;
                }

                if (keySource == "Style")
                {
                    fullBytes.AddRange(GetBytesFromNfoStyle(keyType));
                }
                else if (keySource == "Info")
                {
                    fullBytes.AddRange(GetBytesFromNfoInfo(keyType, item.Value));
                }
            }
            return fullBytes.ToArray();
        }
        /// <summary>
        /// Generate nfo text that is from NFOStyle
        /// </summary>
        /// <param name="propertyType">string that describe property type(Start / End / Title / Release). see decription of NFOStyle</param>
        /// <returns>bytes array of nfo</returns>
        private List<byte> GetBytesFromNfoStyle(string propertyType)
        {
            switch (propertyType)
            {
                case "Start":
                    return nfoStyle.ContentStart;
                case "End":
                    return nfoStyle.ContentEnd;
                default:
                    int lineIndex;
                    if (Int32.TryParse(propertyType, out lineIndex) && lineIndex < nfoStyle.ContentLines.Count)
                    {
                        return new List<byte>(nfoStyle.ContentLines[lineIndex]);
                    }
                    else
                    {
                        return new List<byte>();
                    }
            }
        }
        /// <summary>
        /// Generate nfo text that is from NFOInfo
        /// </summary>
        /// <param name="propertyType">string that describe property type(Start / End / Title / Release). see decription of NFOStyle</param>
        /// <param name="dataType">string that describe data type(Mutable / Immutable / Dictionary). see decription of NFOStyle</param>
        /// <returns>bytes array of nfo</returns>
        private List<byte> GetBytesFromNfoInfo(string propertyType, string dataType)
        {
            List<byte> byteList = new List<byte>();
            switch (dataType)
            {
                case "Mutable":
                    Dictionary<string, Alignment> nfoMutContent = nfoInfo.MapMutablePropertiesWithKeyword(propertyType);
                    if (nfoMutContent != null && nfoMutContent.Count > 0)
                    {
                        foreach (KeyValuePair<string, Alignment> dataPair in nfoMutContent)
                        {
                            byteList.AddRange(new MutableLine(dataPair, nfoStyle).ToByteList());
                        }
                    }
                    break;
                case "Dictionary":
                    Dictionary<string, string> nfoDictContent = nfoInfo.MapDictionaryPropertiesWithKeyword(propertyType);
                    if (nfoDictContent != null && nfoDictContent.Count > 0)
                    {
                        foreach (KeyValuePair<string, string> dataPair in nfoDictContent)
                        {
                            byteList.AddRange(new DictionaryLine(dataPair, nfoStyle).ToByteList());
                        }
                    }
                    break;
                default:
                    break;
            }
            return byteList;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Write NFO text to a file
        /// </summary>
        /// <param name="filename">the full path of the file</param>
        public void WriteNfoFile(string filename)
        {
            try
            {
                IOUtil.BinaryWrite(filename, GenerateNfoBytes(), false, false);
            }
            catch (Exception ex)
            {
                throw new Exception("[Write NFO Error]: An error occurred when writing the NFO to a file", ex);
            }
        }
        #endregion
    }
}
