using System;
using System.Collections.Generic;
using System.Text;

using NFOGenerator.Model.General;

namespace NFOGenerator.Model.NFO.Line
{
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
                    base.line += GenerateMutableLine(style, lines[i], align);
                }
            }
        }
        /// <summary>
        /// Generate nfo line with proper indent and alignment
        /// </summary>
        /// <param name="style">NFO style parameter</param>
        /// <param name="content">the mutable part in this line</param>
        /// <returns>a well-formed nfo line</returns>
        private string GenerateMutableLine(NFOStyle style, string content, Alignment align)
        {
            switch (align)
            {
                case Alignment.Left:
                    return style.Prefix1 + content.PadRight(style.LengthLimit, style.LinePaddingChar) + style.Suffix;
                case Alignment.Middle:
                    int remainingSpace = style.LengthLimit - content.Length;
                    int leftRemainingSpace = remainingSpace / 2;
                    int rightRemainingSpace = remainingSpace - leftRemainingSpace;            
                    return style.Prefix1.PadRight(leftRemainingSpace, style.LinePaddingChar) + content + style.Suffix.PadLeft(rightRemainingSpace, style.LinePaddingChar);
                case Alignment.Right:
                    return style.Prefix1 + content.PadLeft(style.LengthLimit, style.LinePaddingChar) + style.Suffix;
                default:
                    return style.Prefix1 + content.PadRight(style.LengthLimit, style.LinePaddingChar) + style.Suffix;
            }
        }
    }
}
