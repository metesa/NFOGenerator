using System;
using System.ComponentModel;
using System.Reflection;

namespace NFOGenerator.Util
{
    public class EnumUtil
    {
        /// <summary>
        /// http://stackoverflow.com/a/4367868
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <returns></returns>
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

        public static string GetDescriptionFromEnumValue<T>(T enumValue)
        {
            Type type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();

            FieldInfo field = enumValue.GetType().GetField(enumValue.ToString());

            return GetDescription(field);
        }

        private static string GetDescription(MemberInfo a)
        {
            DescriptionAttribute attr = Attribute.GetCustomAttribute(a,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
            return (attr == null) ? "Unknown" : attr.Description;
        }
    }
}
