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
using System.Text;

namespace NFOGenerator.Util
{
    /// <summary>
    /// Utilities about Exception
    /// </summary>
    public class ExceptionUtil
    {
        /// <summary>
        /// Combine messages of all inner exceptions
        /// </summary>
        /// <param name="e">the initial exception</param>
        /// <returns>all messages</returns>
        public static string FullMessage(Exception e)
        {
            Exception tempE = e;
            StringBuilder fullMessage = new StringBuilder("Message: " + Environment.NewLine);
            while (tempE != null)
            {
                fullMessage.AppendLine(tempE.Message);
                tempE = tempE.InnerException;
            }
            return fullMessage.ToString();
        }
    }
}
