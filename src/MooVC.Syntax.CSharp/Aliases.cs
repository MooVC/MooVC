namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a c# syntax aliases.
    /// </summary>
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

        /// <summary>
        /// Performs the Try Get operation for the c# syntax.
        /// </summary>
        public static bool TryGet(Type type, out string alias)
        {
            return aliases.TryGetValue(type, out alias);
        }

        /// <summary>
        /// Performs the Is System operation for the c# syntax.
        /// </summary>
        public static bool IsSystem(string type)
        {
            return aliases.Values.Contains(type, StringComparer.OrdinalIgnoreCase);
        }
    }
}