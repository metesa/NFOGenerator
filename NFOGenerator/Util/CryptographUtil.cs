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
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace NFOGenerator.Util
{
    /// <summary>
    /// Utilities about encrypt and decrypt
    /// Reference: http://stackoverflow.com/questions/1905246/how-to-encrypt-decrypt-an-xml-file
    /// </summary>
    class CryptographUtil
    {
        #region Private Const Fields
        private const string InitVector = "T=A4rAzu94ez-dra";
        private const int KeySize = 256;
        private const int PasswordIterations = 1000; //2;
        private const string SaltValue = "d=?ustAF=UstenAr3B@pRu8=ner5sW&h59_Xe9P2za-eFr2fa&ePHE@ras!a+uc@";
        #endregion

        #region Class Members
        /// <summary>
        /// Decrypt a string
        /// </summary>
        /// <param name="encryptedText">encrypted string</param>
        /// <param name="passPhrase">password</param>
        /// <returns>plain string</returns>
        public static string Decrypt(string encryptedText, string passPhrase)
        {
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(InitVector);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(passPhrase);
            string plainText;
            byte[] saltValueBytes = Encoding.UTF8.GetBytes(SaltValue);

            Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passwordBytes, saltValueBytes, PasswordIterations);
            byte[] keyBytes = password.GetBytes(KeySize / 8);

            RijndaelManaged rijndaelManaged = new RijndaelManaged { Mode = CipherMode.CBC };

            try
            {
                using (ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(keyBytes, initVectorBytes))
                {
                    using (MemoryStream memoryStream = new MemoryStream(encryptedTextBytes))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            //TODO: Need to look into this more. Assuming encrypted text is longer than plain but there is probably a better way
                            byte[] plainTextBytes = new byte[encryptedTextBytes.Length];

                            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                            plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                        }
                    }
                }
            }
            catch (CryptographicException)
            {
                plainText = string.Empty; // Assume the error is caused by an invalid password
            }

            return plainText;
        }
        /// <summary>
        /// Encrypt a string
        /// </summary>
        /// <param name="plainText">plain string</param>
        /// <param name="passPhrase">password</param>
        /// <returns>encrypted string</returns>
        public static string Encrypt(string plainText, string passPhrase)
        {
            string encryptedText;
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(InitVector);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(passPhrase);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] saltValueBytes = Encoding.UTF8.GetBytes(SaltValue);

            Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passwordBytes, saltValueBytes, PasswordIterations);
            byte[] keyBytes = password.GetBytes(KeySize / 8);

            RijndaelManaged rijndaelManaged = new RijndaelManaged { Mode = CipherMode.CBC };

            using (ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(keyBytes, initVectorBytes))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cryptoStream.FlushFinalBlock();

                        byte[] cipherTextBytes = memoryStream.ToArray();
                        encryptedText = Convert.ToBase64String(cipherTextBytes);
                    }
                }
            }

            return encryptedText;
        }
        #endregion
    }
}
