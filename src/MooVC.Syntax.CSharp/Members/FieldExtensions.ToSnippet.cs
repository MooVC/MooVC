namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a c# member syntax field extensions.
    /// </summary>
    public static partial class FieldExtensions
    {
        /// <summary>
        /// Creates a code snippet representation of the c# member syntax.
        /// </summary>
        internal static Snippet ToSnippet(this ImmutableArray<Field> fields, Snippet.Options options)
        {
            if (fields.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            return fields
                .OrderByDescending(field => field.IsStatic)
                .ThenByDescending(field => field.IsReadOnly)
                .ThenByDescending(field => field.Scope)
                .ThenBy(field => field.Name)
                .Select(field => field.ToSnippet(options))
                .ToImmutableArray()
                .Stack(options);
        }
    }
}