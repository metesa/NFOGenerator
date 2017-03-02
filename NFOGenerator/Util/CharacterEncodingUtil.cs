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
using System.Globalization;
using System.Text;

namespace NFOGenerator.Util
{
    /// <summary>
    /// Utilities about character encoding
    /// </summary>
    public class CharacterEncodingUtil
    {
        #region Class Members
        /// <summary>
        /// Convert byte array to formatted string
        ///   byte array ==> formatted string
        /// [0x2e, 0x16]     "2e-16"
        /// </summary>
        /// <param name="bytes">byte array</param>
        /// <returns>converted string</returns>
        public static string Bytes2FormattedString(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            return BitConverter.ToString(bytes);
        }
        /// <summary>
        /// Convert formatted string to byte array
        /// formatted string ==> byte array
        ///          "2e-16"     [0x2e, 0x16]     
        /// </summary>
        /// <param name="bitStr">formatted string</param>
        /// <returns>converted byte array</returns>
        public static byte[] FormattedString2Bytes(string bitStr)
        {
            if (bitStr == null)
            {
                return null;
            }

            string[] sInput = bitStr.Split("-".ToCharArray());
            byte[] data = new byte[sInput.Length];
            for (int i = 0; i < sInput.Length; i++)
            {
                data[i] = byte.Parse(sInput[i], NumberStyles.HexNumber);
            }

            return data;
        }
        /// <summary>
        /// Convert a char to byte
        /// </summary>
        /// <param name="ch">char</param>
        /// <returns>converted byte</returns>
        public static byte CharToByte(char ch)
        {
            return Encoding.Default.GetBytes(new char[] { ch })[0];
        }
        /// <summary>
        /// Convert a string to byte array
        /// </summary>
        /// <param name="text">string</param>
        /// <returns>converted byte array</returns>
        public static byte[] StringToBytes(string text)
        {
            return Encoding.Default.GetBytes(text);
        }
        /// <summary>
        /// Convert byte array to byte list
        /// </summary>
        /// <param name="bytes">byte array</param>
        /// <returns>converted byte list</returns>
        public static List<byte> BytesToByteList(byte[] bytes)
        {
            List<byte> list = new List<byte>();
            list.AddRange(bytes);
            return list;
        }
        #endregion
    }
}
