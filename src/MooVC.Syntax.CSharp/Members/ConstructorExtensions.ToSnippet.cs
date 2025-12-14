namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Concepts;

    public static partial class ConstructorExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Constructor> constructors, Construct construct, Snippet.Options options)
        {
            if (constructors.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            string[] content = constructors
                .OrderBy(constructor => constructor)
                .Select(method => method.ToString(construct, options))
                .ToArray();

            return options.BlankSpace.Combine(options, content);
        }
    }
}