namespace MooVC.Syntax.Elements
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;

    /// <summary>
    /// Represents a syntax element qualifier extensions.
    /// </summary>
    internal static partial class QualifierExtensions
    {
        /// <summary>
        /// Creates a code snippet representation of the syntax element.
        /// </summary>
        public static Snippet ToSnippet(this ImmutableArray<Qualifier> usings, Snippet.Options options)
        {
            if (usings.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            return usings
                .OrderBy(@using => @using)
                .Select(@using => @using.ToSnippet(options))
                .ToImmutableArray()
                .Stack(options);
        }
    }
}