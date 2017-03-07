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

namespace NFOGenerator.Model.FileInfo
{
    /// <summary>
    /// Define properties of chapters
    /// </summary>
    public class MenuInfo
    {
        #region Private Fields
        private bool included;
        private bool named;
        #endregion

        #region Constructor
        public MenuInfo()
        {
            included = false;
            named = false;
        }
        #endregion

        #region Properties
        public bool Included
        {
            get
            {
                return included;
            }
            set
            {
                included = value;
            }
        }

        public bool Named
        {
            get
            {
                return named;
            }
            set
            {
                named = value;
            }
        }
        #endregion
    }
}
