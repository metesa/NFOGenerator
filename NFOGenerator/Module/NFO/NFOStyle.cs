using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

using NFOGenerator.Module.General;

namespace NFOGenerator.Module.NFO
{
    [Serializable]
    public class NFOStyle
    {
        private string dictPrefix1 = "║  ";
        private string dictPrefix2 = "║                    ";
        private string dictConcat = ": ";
        private string dictSuffix = "  ║\r\n";
        private char dictKeyPaddingChar = '.';
        private char dictLinePaddingChar = ' ';
        private int dictKeyLength = 16;
        private int dictLineLength = 55;
        private Alignment mutContentAlignment = 0;
        private int mutLengthLimit = 73;

        public NFOStyle(string dictPrefix1, string dictPrefix2, string dictConcat, string dictSuffix, 
            char dictKeyPaddingChar, char dictLinePaddingChar, int dictKeyLength, int dictLineLength,
            Alignment mutContentAlignment, int mutLengthLimit)
        {
            this.dictPrefix1 = dictPrefix1;
            this.dictPrefix2 = dictPrefix2;
            this.dictConcat = dictConcat;
            this.dictSuffix = dictSuffix;
            this.dictKeyPaddingChar = dictKeyPaddingChar;
            this.dictLinePaddingChar = dictLinePaddingChar;
            this.dictKeyLength = dictKeyLength;
            this.dictLineLength = dictLineLength;
            this.mutContentAlignment = mutContentAlignment;
            this.mutLengthLimit = mutLengthLimit;
        }

        public string Prefix1
        {
            get
            {
                return dictPrefix1;
            }
            set
            {
                dictPrefix1 = value;
            }
        }

        public string Prefix2
        {
            get
            {
                return dictPrefix2;
            }
            set
            {
                dictPrefix2 = value;
            }
        }

        public string ConcatString
        {
            get
            {
                return dictConcat;
            }
            set
            {
                dictConcat = value;
            }
        }

        public string Suffix
        {
            get
            {
                return dictSuffix;
            }
            set
            {
                dictSuffix = value;
            }
        }

        public char KeyPaddingChar
        {
            get
            {
                return dictKeyPaddingChar;
            }
            set
            {
                dictKeyPaddingChar = value;
            }
        }

        public char LinePaddingChar
        {
            get
            {
                return dictLinePaddingChar;
            }
            set
            {
                dictLinePaddingChar = value;
            }
        }

        public int KeyLength
        {
            get
            {
                return dictKeyLength;
            }
            set
            {
                dictKeyLength = value;
            }
        }

        public int LineLength
        {
            get
            {
                return dictLineLength;
            }
            set
            {
                dictLineLength = value;
            }
        }

        public Alignment ContentAlignment
        {
            get
            {
                return mutContentAlignment;
            }
            set
            {
                mutContentAlignment = value;
            }
        }

        public int LengthLimit
        {
            get
            {
                return mutLengthLimit;
            }
            set
            {
                mutLengthLimit = value;
            }
        }
    }
}
