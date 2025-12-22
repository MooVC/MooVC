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

            Snippet[] content = methods
                .OrderByDescending(property => property.Extensibility == Extensibility.Static)
                .ThenByDescending(method => method.Scope)
                .ThenByDescending(method => method.Extensibility)
                .ThenBy(method => method.Name)
                .Select(method => method.ToSnippet(options))
                .ToArray();

            return Snippet.Blank.Combine(options, content);
        }
    }
}