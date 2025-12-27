namespace MooVC.Syntax.CSharp.Generics
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Concepts;

    public static partial class ConstructExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Construct> constructs, Snippet.Options options)
        {
            if (constructs.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            Snippet[] content = constructs
                .OrderBy(construct => construct.Name)
                .Select(construct => construct.ToSnippet(options))
                .ToArray();

            return Snippet.Blank.Combine(options, content);
        }
    }
}