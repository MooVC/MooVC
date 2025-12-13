namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;

    public static partial class FieldExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Field> fields, Snippet.Options options)
        {
            if (fields.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            string[] content = fields
                .Select(field => field.ToString())
                .ToArray();

            string snippet = options.NewLine.Combine(content);

            return Snippet.From(options, snippet);
        }
    }
}