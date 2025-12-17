namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;

    internal static partial class StringExtensions
    {
        public static Snippet ToSnippet(this IEnumerable<string> values)
        {
            return values
                .Where(value => !string.IsNullOrEmpty(value))
                .ToImmutableArray();
        }
    }
}