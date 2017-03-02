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
using NFOGenerator.Util;

namespace NFOGenerator.Model.NFO
{
    /// <summary>
    /// NFOStyle is a class which store all immutable info and all style info for mutable and dictionary-like info of a NFO file.
    /// 
    ///   A mutable line is like    : "║  Godspeed.2016.1080p.WEB-DL.DD5.1.H.264-TAiCHi                              ║"
    ///       A mutable line contains one variable string.
    ///   An immutable line is like : "║                                                                             ║"
    ///       An immutable line is uneditable.
    ///   A dictionary line is like : "║  iMDB............: http://www.imdb.com/title/tt5952306/                     ║"
    ///       A dictionary line contains a pair of key and value.
    ///     
    ///   1."NFOContent" describes the structure of a NFO file.
    ///     Format:
    ///       Key (string)   : [KeySource]_[KeyType]
    ///                            - KeySource = [DataSource]    (e.g. NFOStyle / NFOInfo)
    ///                            - KeyType   = [PropertyType]  (e.g. Start / End / Title / Release / 
    ///                                                              1 / 2 / 3 / ...)
    ///       Value (string) : [Value]
    ///                            - Value     = [DataType]      (e.g. Mutable / Immutable / Dictionary)
    ///     Here we have a NFOContent as below:
    ///         "Style_Start" , "Immutable"
    ///         "Info_Title"  , "Mutable"
    ///         "Style_1"     , "Immutable"
    ///         "Info_Release", "Dictionary"
    ///         "Style_End"   , "Immutable"
    ///     That means the nfo contains the following things:
    ///         (1). An "Immutable"  text from "NFOStyle" named "ContentStart"
    ///         (2). A  "Mutable"    text from "NFOInfo"  named "Title"
    ///         (3). An "Immutable"  text from "NFOStyle" named "ContentLine[1]"
    ///         (4). A  "Dictionary" text from "NFOInfo"  named "Release"
    ///         (5). An "Immutable"  text from "NFOStyle" named "ContentEnd"
    /// 
    ///   2."ContentStart", "ContentLines" and "ContentEnd" describe immutable lines of the nfo
    ///     ContentStart stores all text before the first editable line.
    ///     ContentEnd stores all text after the last editable line.
    ///     ContentLines stores all other uneditable text line.
    ///     
    ///   3."Prefix1", "Suffix" describe the uneditable part in an editable line;
    ///     Prefix1 is the prefix of a mutable line or a dictionary like line.
    ///     Suffix is the suffix of a mutable line or a dictionary like line.
    ///     
    ///   4."Prefix2", "ConcatString", "KeyPaddingChar", "KeyLength", "LinePaddingChar" and "LineLength" describe the additional info of a dictionary line
    ///     Prefix2 is the prefix of all dictionary lines except for the first line.(It has more indent)
    ///     ConcatString is the string between the key info and the value info.
    ///     KeyPaddingChar is the padding char for the key info.
    ///     KeyLength is the total length of the key info.
    ///     LinePaddingChar is the padding char for the value info.
    ///     LineLength is the total length of the value info.
    ///   
    ///   5."ContentAlignment" and "LengthLimit" describe the additional info of a mutable line
    ///     ContentAlignment is the alignment of the variable in a mutable line.
    ///     LengthLimit is the total length of the variable in a mutable line.
    /// </summary>
    [Serializable]
    public class NFOStyle
    {
        #region Private Fields
        private List<byte> generalStart;
        private List<byte[]> generalLine;
        private List<byte> generalEnd;
        
        private List<byte> dictPrefix1;
        private List<byte> dictPrefix2;
        private List<byte> dictConcat;
        private List<byte> dictSuffix;
        private char dictKeyPaddingChar;
        private char dictLinePaddingChar;
        private int dictKeyLength;
        private int dictLineLength;
        private Alignment mutContentAlignment;
        private int mutLengthLimit;

        private Dictionary<string, string> nfoContent;
        #endregion

        #region Constructors
        /// <summary>
        /// Private constructor used for generating style template.
        ///   1. Change it to "public"
        ///   2. NFOStyle.ExportTemplate("the filename", new NFOStyle());
        /// </summary>
        private NFOStyle()
        {
            this.generalStart = new List<byte>();
            this.generalLine = new List<byte[]>();
            this.generalEnd = new List<byte>();

            this.generalStart.AddRange(IOUtil.BinaryRead(@"H:\C#Project\template_v1_1.nfo", false));
            this.generalLine.Add(IOUtil.BinaryRead(@"H:\C#Project\template_v1_2.nfo", false));
            this.generalEnd.AddRange(IOUtil.BinaryRead(@"H:\C#Project\template_v1_3.nfo", false));

            this.dictPrefix1 = new List<byte>() {
                (byte)0xba, (byte)0x20, (byte)0x20 
            };
            this.dictPrefix2 = new List<byte>() {
                (byte)0xba, (byte)0x20, (byte)0x20, (byte)0x20,
                (byte)0x20, (byte)0x20, (byte)0x20, (byte)0x20,
                (byte)0x20, (byte)0x20, (byte)0x20, (byte)0x20,
                (byte)0x20, (byte)0x20, (byte)0x20, (byte)0x20,
                (byte)0x20, (byte)0x20, (byte)0x20, (byte)0x20,
                (byte)0x20 
            };
            this.dictConcat = new List<byte>() {
                (byte)0x3a, (byte)0x20 
            };
            this.dictSuffix = new List<byte>() {
                (byte)0x20, (byte)0x20, (byte)0xba, (byte)0x0d,
                (byte)0x0a
            };
            this.dictKeyPaddingChar = '.';
            this.dictLinePaddingChar = ' ';
            this.dictKeyLength = 16;
            this.dictLineLength = 55;
            this.mutContentAlignment = 0;
            this.mutLengthLimit = 73;

            this.nfoContent = new Dictionary<string, string>();
            this.nfoContent.Add("Style_Start", "Immutable");
            this.nfoContent.Add("Info_Title", "Mutable");
            this.nfoContent.Add("Style_0", "Immutable");
            this.nfoContent.Add("Info_Release", "Dictionary");
            this.nfoContent.Add("Style_End", "Immutable");
        }
        #endregion

        #region Class Members
        /// <summary>
        /// Load a template from a file
        /// </summary>
        /// <param name="filename">the name of the template file</param>
        /// <returns>loaded instance</returns>
        public static NFOStyle ImportTemplate(string filename)
        {
            NFOStyle ns = null;
            try
            {
                ns = (NFOStyle)SerializationUtil.BinaryDerialize(filename);
                return ns;
            }
            catch (Exception e)
            {
                throw new Exception("[Import Template Error]: Error when loading template ' " + filename + " '", e);
            }
        }
        /// <summary>
        /// Save a template to a file
        /// </summary>
        /// <param name="filename">the name of the template file</param>
        /// <param name="style">the instance to be saved</param>
        public static void ExportTemplate(string filename, NFOStyle style)
        {
            try
            {
                SerializationUtil.BinarySerialize(filename, style);
            }
            catch (Exception e)
            {
                throw new Exception("[Export Template Error]: Error when saving template ' " + filename + " '", e);
            }
            
        }
        #endregion

        #region Properties
        public Dictionary<string, string> NFOContent
        {
            get
            {
                return nfoContent;
            }
            set
            {
                nfoContent = value;
            }
        }

        public List<byte> ContentStart
        {
            get
            {
                return generalStart;
            }
            set
            {
                generalStart = value;
            }
        }

        public List<byte[]> ContentLines
        {
            get
            {
                return generalLine;
            }
            set
            {
                generalLine = value;
            }
        }

        public List<byte> ContentEnd
        {
            get
            {
                return generalEnd;
            }
            set
            {
                generalEnd = value;
            }
        }

        public List<byte> Prefix1
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

        public List<byte> Prefix2
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

        public List<byte> ConcatString
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

        public List<byte> Suffix
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
        #endregion
    }
}
