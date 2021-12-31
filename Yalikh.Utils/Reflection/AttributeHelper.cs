using System;
using System.Linq;
using System.Reflection;

namespace Yalikh.Utils.Reflection
{
    public static class AttributeHelper
    {
        public static bool TryGetAttrValue<T>(this Type self, Type attributeType, string getterName, out T result)
        {
#pragma warning disable CS8601

            var attr = self.GetCustomAttribute(attributeType);
            if (attr == null)
            {
                result = default;
                return false;
            }

            return attr.TryGetValue<T>(attributeType, getterName, out result);

#pragma warning restore  CS8601
        }

        public static bool TryGetAttrValue<T>(this PropertyInfo self, Type attributeType, string getterName, out T result)
        {
#pragma warning disable CS8601
            
            var attr = self.GetCustomAttribute(attributeType);
            if (attr == null)
            {
                result = default;
                return false;
            }

            return attr.TryGetValue<T>(attributeType, getterName, out result);

#pragma warning restore CS8601
        }

        private static bool TryGetValue<T>(this Attribute self, Type attributeType, string getterName, out T result)
        {
#pragma warning disable CS8601

            result = default;
            var valueType = typeof(T);

            var propInfo = attributeType.GetProperties()
                .Where(x => x.Name == getterName)
                .OrderBy(x => x.PropertyType == valueType ? 0 : 1)
                .FirstOrDefault();
            if (propInfo != null)
            {
                result = (T)propInfo.GetValue(self);
                return true;
            }

            var fieldInfo = attributeType.GetFields()
                .Where(x => x.Name == getterName)
                .OrderBy(x => x.FieldType == valueType ? 0 : 1)
                .FirstOrDefault();
            if (fieldInfo != null)
            {
                result = (T)fieldInfo.GetValue(self);
                return true;
            }

            var methodInfo = attributeType.GetMethods()
                .Where(x => x.Name == getterName)
                .OrderBy(x => x.ReturnType == valueType ? 0 : 1)
                .FirstOrDefault();
            if (methodInfo != null)
            {
                result = (T)methodInfo.Invoke(self, new object[0]);
                return true;
            }

            return false;
#pragma warning restore  CS8601
        }


        public static TAttribute GetAttribute<TAttribute>(this Enum enumeration)
            where TAttribute : Attribute
        {
            var type = enumeration.GetType();
            var member = type
                .GetMember(enumeration.ToString())
                .FirstOrDefault(x => x.MemberType == MemberTypes.Field)
                ?? throw new Exception($"Member \"{enumeration}\" is not found in the type \"{type.FullName}\".");

            TAttribute attribute = member
                .GetCustomAttributes<TAttribute>(inherit: false)
                .SingleOrDefault();

            return attribute;
        }

        public static TResult GetAttributeValue<TAttribute, TResult>(this Enum enumeration, Func<TAttribute, TResult> expression)
            where TAttribute : Attribute
        {
#pragma warning disable CS8603

            TAttribute attribute = enumeration.GetAttribute<TAttribute>();

            if (attribute == null)
                return default;

            return expression(attribute);

#pragma warning restore CS8603
        }
    }
}
