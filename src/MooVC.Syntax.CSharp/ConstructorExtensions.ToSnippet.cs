namespace MooVC.Syntax.CSharp
{
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;

    /// <summary>
    /// Provides snippet conversion helpers for <see cref="Constructor"/> values.
    /// </summary>
    public static partial class ConstructorExtensions
    {
        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="constructors">The constructors.</param>
        /// <param name="options">The options.</param>
        /// <param name="type">The type.</param>
        /// <returns>The generated snippet.</returns>
        internal static Snippet ToSnippet(this ImmutableArray<Constructor> constructors, Type.Options options, Type type)
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