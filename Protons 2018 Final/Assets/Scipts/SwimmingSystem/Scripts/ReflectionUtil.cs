using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Assets.SwimmingSystem.Scripts
{
    internal class ReflectionUtil
    {
        private static FieldInfo GetFieldInfo(Type type, string fieldName)
        {
            FieldInfo fieldInfo;
            do
            {
                fieldInfo = type.GetField(fieldName,
                       BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                type = type.BaseType;
            }
            while (fieldInfo == null && type != null);
            return fieldInfo;
        }

        public static object GetFieldValue(object obj, string fieldName)
        {
            Type objType = obj.GetType();
            FieldInfo fieldInfo = GetFieldInfo(objType, fieldName);
            if (fieldInfo == null)
                return null;

            return fieldInfo.GetValue(obj);
        }

        public static void SetFieldValue(object obj, string fieldName, object val)
        {
            Type objType = obj.GetType();
            FieldInfo fieldInfo = GetFieldInfo(objType, fieldName);
            if (fieldInfo == null)
                throw new ArgumentOutOfRangeException("fieldName",
                  string.Format("No field {0} of {1}", fieldName, objType.FullName));
            fieldInfo.SetValue(obj, val);
        }
    }
}
