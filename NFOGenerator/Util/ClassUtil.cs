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
using System.ComponentModel;
using System.Reflection;

namespace NFOGenerator.Util
{
    /// <summary>
    /// Utilities about Class
    /// Reference: http://javaextjs.iteye.com/blog/364624
    /// </summary>
    public class ClassUtil
    {
        #region Class Members
        #region Private
        /// <summary>
        /// Get properties by reflection
        /// </summary>
        /// <param name="o">Object class</param>
        /// <returns>properties</returns>
        private static PropertyInfo[] GetProperties(object o)
        {
            return o.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
        /// <summary>
        /// Get description by reflection
        /// </summary>
        /// <param name="a">member info</param>
        /// <returns>description of member</returns>
        private static string GetDescription(MemberInfo a)
        {
            DescriptionAttribute attr = Attribute.GetCustomAttribute(a,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
            return (attr == null) ? "Unknown" : attr.Description;
        }
        #endregion

        #region Public
        /// <summary>
        /// Map properties which have specific description to a dictionary
        /// </summary>
        /// <param name="o">Object class</param>
        /// <param name="description">specific description</param>
        /// <returns>properties info</returns>
        public static Dictionary<string, string> ToStringMap(Object o, string description)
        {
            PropertyInfo[] pi = GetProperties(o);
            Dictionary<string, string> map = new Dictionary<string, string>();
            MethodInfo mi;

            foreach (PropertyInfo p in pi)
            {
                mi = p.GetGetMethod();
                if (mi != null && mi.IsPublic && GetDescription(p) == description)
                {
                    map.Add(p.Name.Replace('_', ' '), mi.Invoke(o, new Object[] { }).ToString());
                }
            }

            return map;
        }
        #endregion
        #endregion
    }
}
