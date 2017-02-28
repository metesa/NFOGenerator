using System;
using System.Collections.Generic;
using System.Text;

namespace NFOGenerator.Model.NFO.Line
{
    public abstract class Line
    {
        protected string line = "";

        /// <summary>
        /// Split text to multiple lines if it is too long
        /// </summary>
        /// <param name="text">text content</param>
        /// <param name="length">length limit</param>
        /// <returns>splitted lines</returns>
        protected List<string> SplitByLength(string text, int length)
        {
            List<string> lines = new List<string>();
            string tempText = text;
            int indexOfSplit = 0;
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
            return lines;
        }

        public override string ToString()
        {
            return line;
        }
    }
}
