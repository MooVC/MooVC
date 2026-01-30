namespace MooVC.Syntax.CSharp.Operators
{
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Syntax.CSharp.Concepts;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a C# operator syntax binary extensions.
    /// </summary>
    public static partial class BinaryExtensions
    {
        /// <summary>
        /// Creates a snippet representation of the C# operator syntax.
        /// </summary>
        /// <param name="binaries">The binaries.</param>
        /// <param name="options">The options.</param>
        /// <param name="type">The type.</param>
        /// <returns>The generated snippet.</returns>
        internal static Snippet ToSnippet(this ImmutableArray<Binary> binaries, Snippet.Options options, Type type)
        {
            if (binaries.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            Snippet[] content = binaries
                .OrderByDescending(binary => binary.Scope)
                .ThenBy(binary => binary.Operator)
                .Select(binary => binary.ToSnippet(options, type))
                .ToArray();

            return Snippet.Blank.Combine(options, content);
        }
    }
}