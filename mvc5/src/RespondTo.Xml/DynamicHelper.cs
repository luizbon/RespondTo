using System;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace RespondTo.Xml
{
    internal static class DynamicHelper
    {
        private static readonly Type[] WriteTypes =
        {
            typeof (string),
            typeof (DateTime),
            typeof (Enum),
            typeof (decimal),
            typeof (Guid)
        };

        public static bool IsSimpleType(this Type type)
        {
            return type.IsPrimitive || WriteTypes.Contains(type);
        }

        public static XElement ToXml(this object input)
        {
            return input.ToXml(null);
        }

        public static XElement ToXml(this object input, string element)
        {
            if (input == null)
                return null;
            if (string.IsNullOrEmpty(element))
                element = "object";
            element = XmlConvert.EncodeName(element);
            var ret = new XElement(element);

            var type = input.GetType();
            var props = type.GetProperties();
            var elements = from prop in props
                let name = XmlConvert.EncodeName(prop.Name)
                let val = prop.PropertyType.IsArray ? "array" : prop.GetValue(input, null)
                let value =
                    prop.PropertyType.IsArray
                        ? GetArrayElement(prop, (Array) prop.GetValue(input, null))
                        : (prop.PropertyType.IsSimpleType() ? new XElement(name, val) : val.ToXml(name))
                where value != null
                select value;
            ret.Add(elements);

            return ret;
        }

        private static XElement GetArrayElement(PropertyInfo info, Array input)
        {
            var name = XmlConvert.EncodeName(info.Name);
            var rootElement = new XElement(name);
            var arrayCount = input.GetLength(0);
            for (var i = 0; i < arrayCount; i++)
            {
                var val = input.GetValue(i);
                var childElement = val.GetType().IsSimpleType() ? new XElement(name + "Child", val) : val.ToXml();
                rootElement.Add(childElement);
            }
            return rootElement;
        }
    }
}