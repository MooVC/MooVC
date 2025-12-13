namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;

    public static partial class QualifierExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Qualifier> usings, Snippet.Options options)
        {
            if (usings.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            string[] values = usings
                .Select(@using => @using.ToString())
                .ToArray();

            return Snippet.Empty.Append(options, values);
        }
    }
}