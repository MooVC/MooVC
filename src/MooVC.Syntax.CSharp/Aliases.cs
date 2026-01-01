namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class Aliases
    {
        private static readonly Dictionary<Type, string> aliases = new Dictionary<Type, string>
        {
            { typeof(bool), "bool" },
            { typeof(byte), "byte" },
            { typeof(char), "char" },
            { typeof(decimal), "decimal" },
            { typeof(double), "double" },
            { typeof(float), "float" },
            { typeof(int), "int" },
            { typeof(long), "long" },
            { typeof(object), "object" },
            { typeof(sbyte), "sbyte" },
            { typeof(short), "short" },
            { typeof(string), "string" },
            { typeof(uint), "uint" },
            { typeof(ulong), "ulong" },
            { typeof(ushort), "ushort" },
        };

        public static bool TryGet(Type type, out string alias)
        {
            return aliases.TryGetValue(type, out alias);
        }

        public static bool IsSystem(string type)
        {
            return aliases.Values.Contains(type, StringComparer.OrdinalIgnoreCase);
        }
    }
}