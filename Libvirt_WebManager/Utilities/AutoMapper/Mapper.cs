using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Libvirt_WebManager.Utilities.AutoMapper
{
    public static class Mapper<TO_TYPE> where TO_TYPE : new()
    {
        public static TO_TYPE Map<FROM_TYPE>(FROM_TYPE obj)
        {
            var to_obj = new TO_TYPE();
            var src_props = typeof(FROM_TYPE).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).ToArray();
            var dst_props = typeof(TO_TYPE).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).ToArray();

            foreach (var src_prop in src_props)
            {
                var dst_prop = dst_props.FirstOrDefault(a => a.Name.ToLower() == src_prop.Name.ToLower());
                if (dst_prop != null)
                {
                    try
                    {
                        SetFieldValue(dst_prop, to_obj, src_prop.GetValue(obj));
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                    }

                }
            }
            return to_obj;
        }
        private static void SetFieldValue(System.Reflection.PropertyInfo field, object targetObj, object value)
        {
            object valueToSet;

            if (value == null || value == DBNull.Value)
            {
                valueToSet = null;
            }
            else
            {
                Type fieldType = field.PropertyType;
                //assign enum
                if (fieldType.IsEnum)
                    valueToSet = Enum.ToObject(fieldType, value);
                //support for nullable enum types
                else if (fieldType.IsValueType && IsNullableType(fieldType))
                {
                    Type underlyingType = Nullable.GetUnderlyingType(fieldType);
                    valueToSet = underlyingType.IsEnum ? Enum.ToObject(underlyingType, value) : value;
                }
                else
                {
                    valueToSet = Convert.ChangeType(value, fieldType);
                }
            }
            field.SetValue(targetObj, valueToSet);
        }
        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}