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

using NFOGenerator.Util;

namespace NFOGenerator.Model.NFO.Line
{
    /// <summary>
    /// Define the nfo text which doen't contains uneditable info.
    /// </summary>
    public class ImmutableLine : Line
    {
        #region Constructors
        public ImmutableLine(string line)
        {
            base.bytes = CharacterEncodingUtil.StringToBytes(line);
            base.byteList = CharacterEncodingUtil.BytesToByteList(bytes);
            base.line = line;
        }
        #endregion
    }
}
