namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;

    public static partial class MethodExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Method> methods, Snippet.Options options)
        {
            if (methods.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            string[] content = methods
                .Select(method => method.ToString(options))
                .ToArray();

            return options.BlankSpace.Combine(options, content);
        }
    }
}