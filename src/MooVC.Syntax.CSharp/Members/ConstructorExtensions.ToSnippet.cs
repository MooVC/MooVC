namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Concepts;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a c# member syntax constructor extensions.
    /// </summary>
    public static partial class ConstructorExtensions
    {
        /// <summary>
        /// Creates a code snippet representation of the c# member syntax.
        /// </summary>
        internal static Snippet ToSnippet(this ImmutableArray<Constructor> constructors, Snippet.Options options, Type type)
        {
            if (constructors.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            Snippet[] content = constructors
                .OrderByDescending(scope => scope.Scope)
                .ThenBy(constructor => constructor.Parameters.Length)
                .Select(method => method.ToSnippet(options, type))
                .ToArray();

            return Snippet.Blank.Combine(options, content);
        }
    }
}