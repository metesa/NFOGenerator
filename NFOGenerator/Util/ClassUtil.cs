using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace NFOGenerator.Util
{
    /// <summary>
    /// http://javaextjs.iteye.com/blog/364624
    /// </summary>
    public class ClassUtil
    {
        private static PropertyInfo[] GetProperties(object o)
        {
            return o.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        private static string GetDescription(MemberInfo a)
        {
            DescriptionAttribute attr = Attribute.GetCustomAttribute(a,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
            return (attr == null) ? "Unknown" : attr.Description;
        }
        
        public static Dictionary<string, object> ToMap(object o, string description)
        {
            PropertyInfo[] pi = GetProperties(o);
            Dictionary<string, object> map = new Dictionary<string, object>();
            MethodInfo mi;
            
            foreach (PropertyInfo p in pi)
            {
                mi = p.GetGetMethod();
                if (mi != null && mi.IsPublic && GetDescription(p) == description)
                {
                    map.Add(p.Name.Replace('_', ' '), mi.Invoke(o, new Object[] { }));
                }
            }

            return map;
        }

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
    }
}
