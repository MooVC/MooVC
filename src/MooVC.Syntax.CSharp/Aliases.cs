namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provides mappings between CLR primitive types and their C# keyword aliases.
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
        /// Attempts to get the C# keyword alias for a CLR type.
        /// </summary>
        /// <param name="type">The CLR type to resolve.</param>
        /// <param name="alias">When this method returns, contains the C# alias if found.</param>
        /// <returns><see langword="true"/> if an alias exists; otherwise, <see langword="false"/>.</returns>
        public static bool TryGet(Type type, out string alias)
        {
            return aliases.TryGetValue(type, out alias);
        }

        /// <summary>
        /// Determines whether a type name is a C# keyword alias for a system type.
        /// </summary>
        /// <param name="type">The type name to check.</param>
        /// <returns><see langword="true"/> if the name is a C# alias; otherwise, <see langword="false"/>.</returns>
        public static bool IsSystem(string type)
        {
            return aliases.Values.Contains(type, StringComparer.OrdinalIgnoreCase);
        }
    }
}
