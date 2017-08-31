using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Rksoftware.PropertyCopy
{
    public static class PropertyCopier
    {
        public static T CopyTo<T>(object src, T dest)
        {
            if (src == null || dest == null) return dest;

            var srcProperties = GetCanReadPublicProperties(src);
            var destProperties = GetCanWritePublicProperties(dest);
            var properties = srcProperties.Join(destProperties, p => p.Name, p => p.Name, (p1, p2) => new { p1, p2 });
            foreach (var property in properties)
            {
                var srcValue = property.p1.GetValue(src);
                if(srcValue == null)
                {
                    property.p2.SetValue(dest, null);
                    continue;
                }
                if (property.p1.PropertyType == property.p2.PropertyType)
                {
                    property.p2.SetValue(dest, srcValue);
                    continue;
                }
                CopyUnmatchValue(property.p2, dest, srcValue);
            }
            return dest;
        }

        private static void CopyUnmatchValue(PropertyInfo property, object dest, object srcValue)
        {
            try { property.SetValue(dest, ConvertUnmatchTypeValue(property.PropertyType, srcValue)); } catch { property.SetValue(dest, null); }
        }

        private static object ConvertUnmatchTypeValue(Type destType, object srcValue)
        {
            if (destType == typeof(string)) return Convert.ToString(srcValue);
            if (destType == typeof(bool) || destType == typeof(bool?)) return Convert.ToBoolean(srcValue);
            if (destType == typeof(short) || destType == typeof(short?)) return Convert.ToInt16(srcValue);
            if (destType == typeof(int) || destType == typeof(int?)) return Convert.ToInt32(srcValue);
            if (destType == typeof(long) || destType == typeof(long?)) return Convert.ToInt64(srcValue);
            if (destType == typeof(double) || destType == typeof(double?)) return Convert.ToDouble(srcValue);
            if (destType == typeof(decimal) || destType == typeof(decimal?)) return Convert.ToDecimal(srcValue);
            if (destType == typeof(DateTime) || destType == typeof(DateTime?)) return Convert.ToDateTime(srcValue);
            if (destType == typeof(byte) || destType == typeof(byte?)) return Convert.ToByte(srcValue);
            if (destType == typeof(char) || destType == typeof(char?)) return Convert.ToChar(srcValue);
            if (destType == typeof(sbyte) || destType == typeof(sbyte?)) return Convert.ToSByte(srcValue);
            if (destType == typeof(byte) || destType == typeof(byte?)) return Convert.ToSingle(srcValue);

            return srcValue;
        }

        private static IEnumerable<PropertyInfo> GetPublicProperties(object obj)
        {
            if (obj == null) return Enumerable.Empty<PropertyInfo>();
            return obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        private static IEnumerable<PropertyInfo> GetCanReadPublicProperties(object obj)
        {
            return GetPublicProperties(obj).Where(p => p.CanRead);
        }

        private static IEnumerable<PropertyInfo> GetCanWritePublicProperties(object obj)
        {
            return GetPublicProperties(obj).Where(p => p.CanWrite);
        }
    }
}
