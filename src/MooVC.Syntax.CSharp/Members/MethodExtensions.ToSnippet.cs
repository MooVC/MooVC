namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a c# member syntax method extensions.
    /// </summary>
    public static partial class MethodExtensions
    {
        /// <summary>
        /// Creates a code snippet representation of the c# member syntax.
        /// </summary>
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