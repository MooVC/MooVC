namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class Aliases
    {
        private static readonly HashSet<string> aliases = new HashSet<string>
        {
            "bool",
            "byte",
            "char",
            "decimal",
            "double",
            "dynamic",
            "float",
            "int",
            "long",
            "nint",
            "nuint",
            "object",
            "sbyte",
            "short",
            "string",
            "uint",
            "ulong",
            "ushort",
        };

        public static bool IsSystem(string type)
        {
            return aliases.Contains(type, StringComparer.OrdinalIgnoreCase);
        }
    }
}