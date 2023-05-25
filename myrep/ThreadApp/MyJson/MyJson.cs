﻿using System.Text;

namespace MyJson
{
    public static class MyJson
    {
        static MyJson() { }

        public static string SerializeObject<T>(T obj)
        {
            var type = typeof(T);

            var properties = type.GetProperties();
            var jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");
            var idx = 0;
            foreach (var propertyInfo in properties)
            {
                var isArray = IsArrayOrList(propertyInfo.PropertyType);
                var propName = propertyInfo.Name;
                var propValue = propertyInfo.GetValue(obj);

                if (isArray)
                {
                    if (propertyInfo != null)
                    {
                        jsonBuilder.AppendFormat("\"{0}\":[", propertyInfo.Name);
                        var val = propertyInfo.GetValue(obj);
                        if (val is Array list)
                        {
                            for (int i = 0; i < list.Length; i++)
                            {
                                var elememt = list.GetValue(i);
                                jsonBuilder.AppendFormat("\"{0}\"", elememt);
                                if (i < list.Length - 1)
                                    jsonBuilder.Append(";");
                            }
                        }
                        jsonBuilder.Append("]");
                    }
                    else jsonBuilder.AppendFormat("\"{0}\":[\"{1}\"]", propName, propValue);
                }
                else
                {
                    jsonBuilder.AppendFormat("\"{0}\":\"{1}\"", propName, propValue);
                }
                if (idx < properties.Length - 1)
                {
                    jsonBuilder.Append(",");
                    idx++;
                }
            }

            jsonBuilder.Append("}");

            return jsonBuilder.ToString();
        }

        public static T DeserializeObject<T>(string path)
            where T : new()
        {
            var json = File.ReadAllText(path);
            var obj = new T();
            var properties = json.Trim(new Char[] {'{', '}'}).Split(',');

            foreach (var property in properties)
            {
                var subs = property.Trim().Split(':');
                var propName = subs[0].Trim('"');
                var propValue = subs[1].Trim('"');

                var propInfo = obj.GetType().GetProperty(propName);
                if (propInfo != null)
                {
                    if (IsArrayOrList(propInfo.PropertyType))
                    {
                        var values = propValue.Trim('[', ']').Trim('"').Split(';');
                        var elementType = propInfo.PropertyType.GetElementType() ?? propInfo.PropertyType.GetGenericArguments()[0];
                        var array = Array.CreateInstance(elementType, values.Length);

                        for (int i = 0; i < values.Length; i++)
                        {
                            var target = values[i].Trim(new char[] { '}', ']', '"' });
                            var val = Convert.ChangeType(target, elementType);
                            array.SetValue(val, i);
                        }

                        propInfo.SetValue(obj, array);
                    }
                    else
                    {
                        var val = Convert.ChangeType(propValue, propInfo.PropertyType);
                        propInfo.SetValue(obj, val);
                    }
                }
            }

            return obj;
        }

        public static async Task WriteJsonInFile(string json, string path)
        {
            using (var file = new StreamWriter(path, false))
                await file.WriteLineAsync(json);
        }
        private static bool IsArrayOrList(Type type)
        {
            return type.IsArray || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>));
        }
    }
}
