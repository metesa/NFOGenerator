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

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace NFOGenerator.Util
{
    /// <summary>
    /// Utilities about serialization
    /// </summary>
    public class SerializationUtil
    {
        #region Class Member
        /// <summary>
        /// Serialize and encrypt a class as binary stream and save to a file
        /// </summary>
        /// <param name="filename">name of the file</param>
        /// <param name="obj">the instance to be serialized and encrypted</param>
        public static void BinarySerialize(string filename, object obj)
        {
            IFormatter formatter = new BinaryFormatter();
            using (MemoryStream mstream = new MemoryStream())
            {
                formatter.Serialize(mstream, obj);
                byte[] unencryptBytes = mstream.ToArray();
                mstream.Close();
                mstream.Dispose();
                string encryptedText = CryptographUtil.Encrypt(CharacterEncodingUtil.Bytes2FormattedString(unencryptBytes), "TAiCHi");
                IOUtil.StringWrite(filename, encryptedText, false, false, Encoding.UTF8);
            }
            
        }
        /// <summary>
        /// Decrypt and deserialize a string to a class
        /// </summary>
        /// <param name="filename">name of the file</param>
        /// <returns>the instance of the class</returns>
        public static object BinaryDerialize(string filename)
        {
            IFormatter formatter = new BinaryFormatter();
            object obj = null;
            string encryptedText = IOUtil.StringRead(filename, false, Encoding.UTF8, false);
            byte[] unencryptBytes = CharacterEncodingUtil.FormattedString2Bytes(CryptographUtil.Decrypt(encryptedText, "TAiCHi"));
            using (MemoryStream ms = new MemoryStream(unencryptBytes))
            {
                obj = formatter.Deserialize(ms);
                ms.Close();
                ms.Dispose();
            }
            return obj;
        }
        #endregion
    }
}
