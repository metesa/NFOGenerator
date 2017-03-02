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
using System.Security;
using System.Text;

namespace NFOGenerator.Util
{
    /// <summary>
    /// Utilities about I/O
    /// </summary>
    public class IOUtil
    {
        #region Class Methods
        /// <summary>
        /// read file as binary
        /// </summary>
        /// <param name="filename">name of the file</param>
        /// <param name="silent">whether to keep silent when exception is catched</param>
        /// <returns>bytes obtained</returns>
        public static byte[] BinaryRead(string filename, bool silent)
        {
            if (!File.Exists(filename))
            {
                return null;
            }
            try
            {
                using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    byte[] bytes = SafeBinaryRead(stream);
                    stream.Close();
                    stream.Dispose();
                    return bytes;
                }
            }
            catch (ArgumentNullException ane)
            {
                throw new Exception("[File Binary Read Error]: At least one parameter of the Stream is null", ane);
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                throw new Exception("[File Binary Read Error]: At least one parameter of the Stream is out of range", aoore);
            }
            catch (ArgumentException ae)
            {
                throw new Exception("[File Binary Read Error]: At least one parameter of the Stream is invalid", ae);
            }
            catch (NotSupportedException nse)
            {
                throw new Exception("[File Binary Read Error]: Stream doesn't support to be read", nse);
            }
            catch (FileNotFoundException fnfe)
            {
                throw new Exception("[File Binary Read Error]: File is not found when attemping to read", fnfe);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                throw new Exception("[File Binary Read Error]: Directory is not found when attemping to read", dnfe);
            }
            catch (PathTooLongException ptle)
            {
                throw new Exception("[File Binary Read Error]: Path is too long to read", ptle);
            }
            catch (IOException ie)
            {
                throw new Exception("[File Binary Read Error]: IO error when read", ie);
            }
            catch (SecurityException se)
            {
                throw new Exception("[File Binary Read Error]: Security error when read", se);
            }
            catch (UnauthorizedAccessException uae)
            {
                throw new Exception("[File Binary Read Error]: Doesn't have enough authority when read", uae);
            }
            catch (Exception e)
            {
                throw new Exception("[File Binary Read Error]: other exception", e);
            }
        }
        /// <summary>
        /// write file as binary
        /// </summary>
        /// <param name="filename">name of the file</param>
        /// <param name="bytes">bytes to be written</param>
        /// <param name="silent">whether to keep silent when exception is catched</param>
        /// <param name="append">whether to append or write from the beginning</param>
        public static void BinaryWrite(string filename, byte[] bytes, bool silent, bool append)
        {
            if (bytes == null || bytes.Length < 1)
            {
                return;
            }
            FileMode fm = FileMode.OpenOrCreate;
            if (append && File.Exists(filename))
            {
                fm = FileMode.Append;
            }
            try
            {
                using (Stream stream = new FileStream(filename, fm, FileAccess.Write, FileShare.None))
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                    stream.Close();
                    stream.Dispose();
                }
            }
            catch (ArgumentNullException ane)
            {
                throw new Exception("[File Binary Write Error]: At least one parameter of the Stream is null", ane);
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                throw new Exception("[File Binary Write Error]: At least one parameter of the Stream is out of range", aoore);
            }
            catch (ArgumentException ae)
            {
                throw new Exception("[File Binary Write Error]: At least one parameter of the Stream is invalid", ae);
            }
            catch (NotSupportedException nse)
            {
                throw new Exception("[File Binary Write Error]: Stream doesn't support to be write", nse);
            }
            catch (FileNotFoundException fnfe)
            {
                throw new Exception("[File Binary Write Error]: File is not found when attemping to write", fnfe);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                throw new Exception("[File Binary Write Error]: Directory is not found when attemping to write", dnfe);
            }
            catch (ObjectDisposedException ode)
            {
                throw new Exception("[File Binary Write Error]: Stream was disposed before write", ode);
            }
            catch (PathTooLongException ptle)
            {
                throw new Exception("[File Binary Write Error]: Path is too long to write", ptle);
            }
            catch (IOException ie)
            {
                throw new Exception("[File Binary Write Error]: IO error when write", ie);
            }
            catch (SecurityException se)
            {
                throw new Exception("[File Binary Write Error]: Security error when write", se);
            }
            catch (UnauthorizedAccessException uae)
            {
                throw new Exception("[File Binary Write Error]: Doesn't have enough authority when write", uae);
            }
            catch (Exception e)
            {
                throw new Exception("[File Binary Write Error]: other exception", e);
            }
        }
        /// <summary>
        /// read file as chars
        /// </summary>
        /// <param name="filename">name of the file</param>
        /// <param name="silent">whether to keep silent when exception is catched</param>
        /// <param name="encoding">encoding of the file</param>
        /// <param name="detectEncodingFromBOM">whether to check BOM when detecting encoding</param>
        /// <returns>string obtained</returns>
        public static string StringRead(string filename, bool silent, Encoding encoding, bool detectEncodingFromBOM)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filename, encoding, detectEncodingFromBOM))
                {
                    string content = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                    return content;
                }
            }
            catch (ArgumentNullException ane)
            {
                if (!silent)
                {
                    throw new Exception("[File Stream Read Error]: At least one parameter of the Stream is null", ane);
                }
            }
            catch (ArgumentException ae)
            {
                if (!silent)
                {
                    throw new Exception("[File Stream Read Error]: At least one parameter of the Stream is invalid", ae);
                }
            }
            catch (NotSupportedException nse)
            {
                if (!silent)
                {
                    throw new Exception("[File Stream Read Error]: Stream doesn't support to be read", nse);
                }
            }
            catch (FileNotFoundException fnfe)
            {
                if (!silent)
                {
                    throw new Exception("[File Stream Read Error]: File is not found when attemping to read", fnfe);
                }
            }
            catch (DirectoryNotFoundException dnfe)
            {
                if (!silent)
                {
                    throw new Exception("[File Stream Read Error]: Directory is not found when attemping to read", dnfe);
                }
            }
            catch (IOException ie)
            {
                if (!silent)
                {
                    throw new Exception("[File Stream Read Error]: IO error when read", ie);
                }
            }
            catch (OutOfMemoryException oome)
            {
                if (!silent)
                {
                    throw new Exception("[File Stream Read Error]: Run out of memory when read", oome);
                }
            }
            catch (Exception e)
            {
                if (!silent)
                {
                    throw new Exception("[File Stream Read Error]: other exception", e);
                }
            }
            return "";
        }
        /// <summary>
        /// write file as chars
        /// </summary>
        /// <param name="filename">name of the file</param>
        /// <param name="content">string to be written</param>
        /// <param name="silent">whether to keep silent when exception is catched</param>
        /// <param name="append">whether to append or write from the beginning</param>
        /// <param name="encoding">encoding of the file</param>
        public static void StringWrite(string filename, string content, bool silent, bool append, Encoding encoding)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filename, append, encoding))
                {
                    sw.Write(content);
                    sw.Close();
                    sw.Dispose();
                }
            }
            catch (UnauthorizedAccessException uae)
            {
                if (!silent)
                {
                    throw new Exception("[File Stream Write Error]: Doesn't have enough authority when write", uae);
                }
            }
            catch (ArgumentNullException ane)
            {
                if (!silent)
                {
                    throw new Exception("[File Stream Write Error]: At least one parameter of the Stream is null", ane);
                }
            }
            catch (ArgumentException ae)
            {
                if (!silent)
                {
                    throw new Exception("[File Stream Write Error]: At least one parameter of the Stream is invalid", ae);
                }
            }
            catch (PathTooLongException ptle)
            {
                if (!silent)
                {
                    throw new Exception("[File Stream Write Error]: Path is too long to write", ptle);
                }
            }
            catch (DirectoryNotFoundException dnfe)
            {
                if (!silent)
                {
                    throw new Exception("[File Stream Write Error]: Directory is not found when attemping to write", dnfe);
                }
            }
            catch (IOException ie)
            {
                if (!silent)
                {
                    throw new Exception("[File Stream Write Error]: IO error when write", ie);
                }
            }
            catch (ObjectDisposedException ode)
            {
                if (!silent)
                {
                    throw new Exception("[File Stream Write Error]: Stream was disposed before write", ode);
                }
            }
            catch (NotSupportedException nse)
            {
                if (!silent)
                {
                    throw new Exception("[File Stream Write Error]: Stream doesn't support to be write", nse);
                }
            }
            catch (SecurityException se)
            {
                if (!silent)
                {
                    throw new Exception("[File Stream Write Error]: Security error when write", se);
                }
            }
            catch (Exception e)
            {
                if (!silent)
                {
                    throw new Exception("[File Stream Write Error]: other exception", e);
                }
            }
        }
        /// <summary>
        /// read byte safely
        /// </summary>
        /// <param name="stream">source stream</param>
        /// <returns>bytes obtained</returns>
        private static byte[] SafeBinaryRead(Stream stream)
        {
            int offset = 0;
            int remaining;
            byte[] data;

            try
            {
                remaining = (int)stream.Length;
                data = new byte[remaining];
            }
            catch (NotSupportedException nse)
            {
                throw new Exception("[Stream Reading Error]: Stream doesn't support 'Length' query", nse);
            }
            catch (ObjectDisposedException ode)
            {
                throw new Exception("[Stream Reading Error]: Stream was disposed before 'Length' query", ode);
            }

            try
            {
                while (remaining > 0)
                {
                    int read = stream.Read(data, offset, remaining);
                    if (read <= 0)
                        throw new EndOfStreamException("[Stream Reading Error]: Error code " + read.ToString() + " when reading buffer");
                    remaining -= read;
                    offset += read;
                }
            }
            catch (ArgumentNullException ane)
            {
                throw new Exception("[Stream Reading Error]: At least one parameter of the Stream is null", ane);
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                throw new Exception("[Stream Reading Error]: At least one parameter of the Stream is out of range", aoore);
            }
            catch (ArgumentException ae)
            {
                throw new Exception("[Stream Reading Error]: At least one parameter of the Stream is invalid", ae);
            }
            catch (IOException ie)
            {
                throw new Exception("[Stream Reading Error]: Stream encouters IO error when read", ie);
            }
            catch (NotSupportedException nse)
            {
                throw new Exception("[Stream Reading Error]: Stream doesn't support to be read", nse);
            }
            catch (ObjectDisposedException ode)
            {
                throw new Exception("[Stream Reading Error]: Stream was disposed before read", ode);
            }
            
            return data;
        }
        #endregion
    }
}
