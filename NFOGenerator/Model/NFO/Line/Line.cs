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

namespace NFOGenerator.Model.NFO.Line
{
    /// <summary>
    /// The basic class that defines a line of nfo text.
    /// </summary>
    public abstract class Line
    {
        #region Protected Fields
        protected string line = "";
        protected byte[] bytes = null;
        protected List<byte> byteList = new List<byte>();
        #endregion

        #region Protected Methods
        /// <summary>
        /// Split text to multiple lines if it is too long
        /// </summary>
        /// <param name="text">text content</param>
        /// <param name="length">length limit</param>
        /// <returns>splitted lines</returns>
        protected List<string> SplitByLength(string text, int length)
        {
            List<string> lines = new List<string>();
            string[] convertedText = text.Replace("\r", "").Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

            string tempText;
            int indexOfSplit;
            foreach (string item in convertedText)
            {
                tempText = item;
                indexOfSplit = 0;
                while (tempText.Length > length)
                {
                    for (int i = length - 1; i > -1; i--)
                    {
                        if (tempText[i] == ' ')
                        {
                            indexOfSplit = i;
                            break;
                        }
                    }
                    lines.Add(tempText.Substring(0, indexOfSplit).Trim());
                    tempText = tempText.Substring(indexOfSplit + 1);
                }
                lines.Add(tempText);
            }
            return lines;
        }
        #endregion

        #region Object Member
        public override string ToString()
        {
            return line;
        }
        #endregion

        #region Public Methods
        public List<byte> ToByteList()
        {
            return byteList;
        }
        #endregion
    }
}
