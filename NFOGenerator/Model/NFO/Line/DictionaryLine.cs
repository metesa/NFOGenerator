using System;
using System.Collections.Generic;
using System.Text;

namespace NFOGenerator.Model.NFO.Line
{
    class DictionaryLine : Line
    {
        private string key;
        private string value;

        public DictionaryLine(KeyValuePair<string, string> dataPair, NFOStyle style)
        {
            this.key = dataPair.Key;
            this.value = dataPair.Value;

            List<string> lines = SplitByLength(value, style.LineLength);
            int count = lines.Count;
            if (count < 1)
            {
                line = "";
            }
            else
            {
                line = GenerateDictionaryLine(style, key, lines[0], true);
                if (count > 1)
                {
                    for (int i = 1; i < count; i++)
                    {
                        line += GenerateDictionaryLine(style, key, lines[i], false);
                    }
                }
            }
        }
        
        /// <summary>
        /// Generate nfo line with proper indent and alignment
        /// </summary>
        /// <param name="nfoStyle">NFO style parameter</param>
        /// <param name="key">key for dictionary</param>
        /// <param name="line">a line from value for dictionary under length limit</param>
        /// <param name="containsKey">contains key when generate nfo line. Yes for the first line and No for others</param>
        /// <returns>a well-formed nfo line</returns>
        private string GenerateDictionaryLine(NFOStyle nfoStyle, string key, string line, bool containsKey)
        {
            if (containsKey)
            {
                return nfoStyle.Prefix1 + key.PadRight(nfoStyle.KeyLength, nfoStyle.KeyPaddingChar) + nfoStyle.ConcatString + line.PadRight(nfoStyle.LineLength, nfoStyle.LinePaddingChar) + nfoStyle.Suffix;
            }
            else
            {
                return nfoStyle.Prefix2 + line.PadRight(nfoStyle.LineLength, nfoStyle.LinePaddingChar) + nfoStyle.Suffix;
            }
        }
    }
}
