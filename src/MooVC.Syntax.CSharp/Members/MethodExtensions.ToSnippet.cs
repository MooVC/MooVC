namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a C# member syntax method extensions.
    /// </summary>
    public static partial class MethodExtensions
    {
        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="methods">The methods.</param>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        internal static Snippet ToSnippet(this ImmutableArray<Method> methods, Method.Options options)
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

            return Snippet.Blank.Combine(options.Snippets, content);
        }
    }
}