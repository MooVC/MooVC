namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Concepts;

    public static partial class ConstructorExtensions
    {
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