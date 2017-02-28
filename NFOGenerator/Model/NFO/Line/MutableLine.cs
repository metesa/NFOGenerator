using System;
using System.Collections.Generic;
using System.Text;

namespace NFOGenerator.Model.NFO.Line
{
    class MutableLine : Line
    {
        public MutableLine(string content, NFOStyle style)
        {
            List<string> lines = SplitByLength(content, style.LengthLimit);
            int count = lines.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    base.line += GenerateMutableLine(style, lines[i]);
                }
            }
        }
        /// <summary>
        /// Generate nfo line with proper indent and alignment
        /// </summary>
        /// <param name="style">NFO style parameter</param>
        /// <param name="content">the mutable part in this line</param>
        /// <returns>a well-formed nfo line</returns>
        private string GenerateMutableLine(NFOStyle style, string content)
        {
            int remainingSpace = style.LengthLimit - content.Length;
            int leftRemainingSpace = remainingSpace / 2;
            int rightRemainingSpace = remainingSpace - leftRemainingSpace;
            return style.Prefix1.PadRight(leftRemainingSpace, style.LinePaddingChar) + content + style.Suffix.PadLeft(rightRemainingSpace, style.LinePaddingChar);
        }
    }
}
