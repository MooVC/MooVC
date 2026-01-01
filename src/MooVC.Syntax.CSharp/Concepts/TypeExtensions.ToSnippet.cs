namespace MooVC.Syntax.CSharp.Generics
{
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Concepts;
    using MooVC.Syntax.Elements;

    public static partial class TypeExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Type> types, Snippet.Options options)
        {
            if (types.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            Snippet[] content = types
                .OrderBy(type => type.Name)
                .Select(type => type.ToSnippet(options))
                .ToArray();

            return Snippet.Blank.Combine(options, content);
        }
    }
}