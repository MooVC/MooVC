namespace MooVC.Syntax.CSharp.Operators
{
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Syntax.CSharp.Concepts;
    using MooVC.Syntax.Elements;

    public static partial class BinaryExtensions
    {
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