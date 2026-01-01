namespace MooVC.Syntax.Formatting
{
    using System;
    using System.Collections.Immutable;
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.Formatting.StringExtensions_Resources;

    /// <summary>
    /// Represents a formatting helper char extensions.
    /// </summary>
    public static partial class CharExtensions
    {
        /// <summary>
        /// Performs the Combine operation for the formatting helper.
        /// </summary>
        public static string Combine(this char separator, params string[] values)
        {
            _ = Guard.Against.Null(separator, message: CombineSeparatorRequired);

            return separator.ToString().Combine(values);
        }

        /// <summary>
        /// Performs the Combine T operation for the formatting helper.
        /// </summary>
        public static string Combine<T>(this char separator, ImmutableArray<T> elements, Func<T, string> formatter)
        {
            _ = Guard.Against.Null(separator, message: CombineSeparatorRequired);

            return separator.ToString().Combine(elements, formatter);
        }
    }
}