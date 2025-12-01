namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Immutable;
    using System.Text;

    internal static class Keywords
    {
        public static readonly ImmutableHashSet<string> Reserved =
            ImmutableHashSet.Create(
                StringComparer.Ordinal,
                "abstract",
                "as",
                "base",
                "break",
                "case",
                "catch",
                "checked",
                "class",
                "const",
                "continue",
                "default",
                "delegate",
                "do",
                "else",
                "enum",
                "event",
                "explicit",
                "extern",
                "false",
                "finally",
                "fixed",
                "for",
                "foreach",
                "goto",
                "if",
                "implicit",
                "in",
                "interface",
                "internal",
                "is",
                "lock",
                "namespace",
                "new",
                "null",
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
                "sizeof",
                "stackalloc",
                "static",
                "struct",
                "switch",
                "this",
                "throw",
                "true",
                "try",
                "typeof",
                "unchecked",
                "unsafe",
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