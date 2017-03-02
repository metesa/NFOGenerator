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
using System.ComponentModel;
using System.Reflection;

namespace NFOGenerator.Util
{
    /// <summary>
    /// Utilities about Enum
    /// Reference: http://stackoverflow.com/a/4367868
    /// </summary>
    public class EnumUtil
    {
        #region Class Member
        #region Private
        /// <summary>
        /// Get description of a Enum member
        /// </summary>
        /// <param name="a">enum member</param>
        /// <returns>description</returns>
        private static string GetDescription(MemberInfo a)
        {
            DescriptionAttribute attr = Attribute.GetCustomAttribute(a,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
            return (attr == null) ? "Unknown" : attr.Description;
        }
        #endregion

        #region Public
        /// <summary>
        /// Get enum member value from description
        /// </summary>
        /// <typeparam name="T">type of enum</typeparam>
        /// <param name="description">specific description</param>
        /// <returns>enum member</returns>
        public static T GetEnumValueFromDescription<T>(string description)
        {
            Type type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            FieldInfo[] fi = type.GetFields();
            foreach (FieldInfo field in fi)
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
        }
        /// <summary>
        /// Get description from enum member value
        /// </summary>
        /// <typeparam name="T">type of enum</typeparam>
        /// <param name="enumValue">enum member value</param>
        /// <returns>description</returns>
        public static string GetDescriptionFromEnumValue<T>(T enumValue)
        {
            Type type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();

            FieldInfo field = enumValue.GetType().GetField(enumValue.ToString());

            return GetDescription(field);
        }
        #endregion
        #endregion
    }
}
