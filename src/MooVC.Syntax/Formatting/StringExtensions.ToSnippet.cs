namespace MooVC.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Syntax.Elements;

    public static partial class StringExtensions
    {
        internal static Snippet ToSnippet(this string value)
        {
            ImmutableArray<string>.Builder builder = ImmutableArray.CreateBuilder<string>(1);

            builder.Add(value);

            return new Snippet(builder.ToImmutable());
        }

        internal static Snippet ToSnippet(this IEnumerable<string> values)
        {
            var lines = values
                .Where(value => !string.IsNullOrEmpty(value))
                .ToImmutableArray();

            return new Snippet(lines);
        }
    }
}