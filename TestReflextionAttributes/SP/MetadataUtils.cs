using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestReflextionAttributes.SP
{
    public static class MetadataUtils
    {
        public static MetadataObject CreateMetadataObject(Type t)
        {
            var result = new MetadataObject();
            result.Name = t.Name;
            Attribute[] attrs = Attribute.GetCustomAttributes(t);

            foreach (var attr in attrs)
            {
                if (attr is ListAttrib)
                {
                    var spList = (ListAttrib)attr;
                    if (!string.IsNullOrEmpty(spList.Name))
                    {
                        result.SPName = spList.Name;
                        break;
                    }
                }
            }

            // Load metadata properties
            result.Properties = CreateMetadataProperties(t);

            return result;
        }

        public static List<MetadataProperty> CreateMetadataProperties(Type t)
        {
            var properties = new List<MetadataProperty>();

            PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var p in propInfos)
            {
                var mprop = new MetadataProperty();
                mprop.Name = p.Name;

                foreach (var attr in Attribute.GetCustomAttributes(p))
                {
                    if (attr is ListItemAttrib)
                    {
                        var a = (ListItemAttrib)attr;
                        mprop.SPName = a.Name;
                        mprop.SPDisplayName = a.DisplayName;
                        break;
                    }
                }
                properties.Add(mprop);
            }
            return properties;
        }


        public static Object GetPropValue(this Object obj, String name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) return null;

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) return null;

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        public static T GetPropValue<T>(this Object obj, String name)
        {
            Object retval = GetPropValue(obj, name);
            if (retval == null) { return default(T); }

            return (T)retval;
        }

        public static bool SetPropValue<T>(this Object obj, String name, T value)
        {
            bool result = false;
            var names = name.Split('.');
            PropertyInfo info = null;
            for (int i = 0; i < names.Length; i++)
            {
                info = obj.GetType()?.GetProperty(names[i]);

                if (info is null) break;

                if (i == names.Length - 1)
                {
                    info.SetValue(obj, value, null);
                    result = true;
                }
                else
                {
                    obj = info.GetValue(obj, null);
                }
            }
            return result;
        }
    }
}
