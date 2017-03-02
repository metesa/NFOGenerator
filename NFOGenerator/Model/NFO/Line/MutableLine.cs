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

using NFOGenerator.Model.General;
using NFOGenerator.Util;

namespace NFOGenerator.Model.NFO.Line
{
    /// <summary>
    /// Define the nfo text which contains a string variable.
    /// Format:
    ///     "║  Godspeed.2016.1080p.WEB-DL.DD5.1.H.264-TAiCHi                              ║"
    ///     
    ///     [Prefix1] + [Mutable Content]                            + [Suffix]
    ///     "║  "     "Godspeed.2016.1080p.WEB-DL.DD5.1.H.264-TAiCHi" "  ║"
    /// </summary>
    class MutableLine : Line
    {
        public MutableLine(KeyValuePair<string, Alignment> dataPair, NFOStyle style)
        {
            Alignment align = dataPair.Value;
            string content = dataPair.Key;
            List<string> lines = SplitByLength(content, style.LengthLimit);
            int count = lines.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    base.byteList.AddRange(GenerateMutableLine(style, lines[i], align));
                    //base.line += GenerateMutableLine(style, lines[i], align);
                }
                base.bytes = byteList.ToArray();
                base.line = Encoding.Default.GetString(base.bytes);
            }
        }
        /// <summary>
        /// Generate nfo line with proper indent and alignment
        /// </summary>
        /// <param name="style">NFO style parameter</param>
        /// <param name="content">the mutable part in this line</param>
        /// <returns>a well-formed nfo line</returns>
        private List<byte> GenerateMutableLine(NFOStyle style, string content, Alignment align)
        {
            List<byte> byteList = new List<byte>();
            byteList.AddRange(style.Prefix1);
            switch (align)
            {
                case Alignment.Left:
                    byteList.AddRange(CharacterEncodingUtil.StringToBytes(content.PadRight(style.LengthLimit, style.LinePaddingChar)));
                    byteList.AddRange(style.Suffix);
                    break;
                case Alignment.Middle:
                    int remainingSpace = style.LengthLimit - content.Length;
                    int leftRemainingSpace = remainingSpace / 2;
                    int rightRemainingSpace = remainingSpace - leftRemainingSpace;
                    byteList.AddRange(Enumerable.Repeat(CharacterEncodingUtil.CharToByte(style.LinePaddingChar), leftRemainingSpace).ToArray());
                    byteList.AddRange(CharacterEncodingUtil.StringToBytes(content));
                    byteList.AddRange(Enumerable.Repeat(CharacterEncodingUtil.CharToByte(style.LinePaddingChar), rightRemainingSpace).ToArray());
                    byteList.AddRange(style.Suffix);
                    break;
                case Alignment.Right:
                    byteList.AddRange(CharacterEncodingUtil.StringToBytes(content.PadLeft(style.LengthLimit, style.LinePaddingChar)));
                    byteList.AddRange(style.Suffix);
                    break;
                default:
                    byteList.AddRange(CharacterEncodingUtil.StringToBytes(content.PadRight(style.LengthLimit, style.LinePaddingChar)));
                    byteList.AddRange(style.Suffix);
                    break;
            }
            return byteList;
        }
    }
}
