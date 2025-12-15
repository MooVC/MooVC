namespace MooVC.Syntax.CSharp.Generics
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Concepts;

    public static partial class ConstructExtensions
    {
        private const string Separator = ", ";

        internal static Snippet ToSnippet(this ImmutableArray<Construct> constructs, Snippet.Options options)
        {
            if (constructs.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            string[] content = constructs
                .OrderBy(construct => construct.Name)
                .Select(construct => construct.ToString(options))
                .ToArray();

            string snippet = Separator.Combine(content);

            return Snippet.From(options, snippet);
        }
    }
}