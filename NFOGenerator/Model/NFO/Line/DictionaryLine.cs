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
using System.Linq;
using System.Text;

using NFOGenerator.Util;

namespace NFOGenerator.Model.NFO.Line
{
    /// <summary>
    /// Define the nfo text which contains a pair of key and value.
    /// Format:
    ///     "║  NOTE............: This is a multi-line note. This is a multi-line note. This   ║"
    ///     "║                    is a multi-line note. This is a multi-line note.             ║"
    ///     
    ///     Line 1:
    ///     [Prefix1] + [Key] + [KeyPaddingChar] + [ConcatString] + [Value]                                                    + [ValuePaddingChar] + [Suffix]
    ///     "║  "      "NOTE"  "............"     ": "             "This is a multi-line note. This is a multi-line note. This" " "                  "  ║"
    ///     
    ///     Line 2:
    ///     [Prefix2]              + [Value]                                           + [ValuePaddingChar] + [Suffix]
    ///     "║                    " "is a multi-line note. This is a multi-line note."  "          "          "  ║"
    /// </summary>
    class DictionaryLine : Line
    {
        #region Private Fileds
        private string key;
        private string value;
        #endregion

        #region Constructors
        public DictionaryLine(KeyValuePair<string, string> dataPair, NFOStyle style)
        {
            this.key = dataPair.Key;
            this.value = dataPair.Value;

            List<string> lines = SplitByLength(value, style.LineLength);
            int count = lines.Count;
            if (count > 0)
            {
                base.byteList.AddRange(GenerateDictionaryLine(style, key, lines[0], true));
                if (count > 1)
                {
                    for (int i = 1; i < count; i++)
                    {
                        base.byteList.AddRange(GenerateDictionaryLine(style, key, lines[i], false));
                    }
                }
                base.bytes = byteList.ToArray();
                base.line = Encoding.Default.GetString(bytes);
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Generate nfo line with proper indent and alignment
        /// </summary>
        /// <param name="nfoStyle">NFO style parameter</param>
        /// <param name="key">key for dictionary</param>
        /// <param name="line">a line from value for dictionary under length limit</param>
        /// <param name="containsKey">contains key when generate nfo line. Yes for the first line and No for others</param>
        /// <returns>a well-formed nfo line</returns>
        private List<byte> GenerateDictionaryLine(NFOStyle nfoStyle, string key, string line, bool containsKey)
        {
            List<byte> list = new List<byte>();
            if (containsKey)
            {
                list.AddRange(nfoStyle.Prefix1);
                list.AddRange(CharacterEncodingUtil.StringToBytes(key));
                list.AddRange(Enumerable.Repeat(CharacterEncodingUtil.CharToByte(nfoStyle.KeyPaddingChar), nfoStyle.KeyLength - key.Length).ToArray());
                list.AddRange(nfoStyle.ConcatString);
                list.AddRange(CharacterEncodingUtil.StringToBytes(line));
                list.AddRange(Enumerable.Repeat(CharacterEncodingUtil.CharToByte(nfoStyle.LinePaddingChar), nfoStyle.LineLength - line.Length).ToArray());
                list.AddRange(nfoStyle.Suffix);
            }
            else
            {
                list.AddRange(nfoStyle.Prefix2);
                list.AddRange(CharacterEncodingUtil.StringToBytes(line));
                list.AddRange(Enumerable.Repeat(CharacterEncodingUtil.CharToByte(nfoStyle.LinePaddingChar), nfoStyle.LineLength - line.Length).ToArray());
                list.AddRange(nfoStyle.Suffix);
            }
            return list;
        }
        #endregion
    }
}
