namespace MooVC.Syntax.CSharp.Constructs
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Text;

    public static class Keywords
    {
        public static readonly ImmutableHashSet<string> Reserved =
            ImmutableHashSet.Create(
                StringComparer.Ordinal,
                "abstract",
                "as",
                "base",
                "bool",
                "break",
                "byte",
                "case",
                "catch",
                "char",
                "checked",
                "class",
                "const",
                "continue",
                "decimal",
                "default",
                "delegate",
                "do",
                "double",
                "else",
                "enum",
                "event",
                "explicit",
                "extern",
                "false",
                "finally",
                "fixed",
                "float",
                "for",
                "foreach",
                "goto",
                "if",
                "implicit",
                "in",
                "int",
                "interface",
                "internal",
                "is",
                "lock",
                "long",
                "namespace",
                "new",
                "null",
                "object",
                "operator",
                "out",
                "override",
                "params",
                "private",
                "protected",
                "public",
                "readonly",
                "ref",
                "return",
                "sbyte",
                "sealed",
                "short",
                "sizeof",
                "stackalloc",
                "static",
                "string",
                "struct",
                "switch",
                "this",
                "throw",
                "true",
                "try",
                "typeof",
                "uint",
                "ulong",
                "unchecked",
                "unsafe",
                "ushort",
                "using",
                "virtual",
                "void",
                "volatile",
                "while",
                "file",
                "global",
                "required",
                "scoped");

        public static bool IsReserved(this string value)
        {
            return !string.IsNullOrWhiteSpace(value) && Reserved.Contains(value);
        }

        public static bool IsReserved(this StringBuilder value)
        {
            if (value is null)
            {
                return false;
            }

            return value
                .ToString()
                .IsReserved();
        }
    }
}