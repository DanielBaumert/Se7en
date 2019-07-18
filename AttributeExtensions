using System;
using System.Linq;

namespace Se7en {
    public static class AttributeExtensions {
        public static bool GetAttribute<TAttribute>(this Type type, out TAttribute attribut) where TAttribute : Attribute {
            attribut = type.GetCustomAttributes(typeof(TAttribute), true ).FirstOrDefault() as TAttribute;
            return attribut != null;
        }
    }
}
