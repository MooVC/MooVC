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
        /// Performs the combine operation for the formatting helper.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <param name="values">The values.</param>
        /// <returns>The string.</returns>
        public static string Combine(this char separator, params string[] values)
        {
            _ = Guard.Against.Null(separator, message: CombineSeparatorRequired);

            return separator.ToString().Combine(values);
        }

        /// <summary>
        /// Performs the combine t operation for the formatting helper.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <param name="elements">The elements.</param>
        /// <param name="formatter">The formatter.</param>
        /// <returns>The string.</returns>
        public static string Combine<T>(this char separator, ImmutableArray<T> elements, Func<T, string> formatter)
        {
            _ = Guard.Against.Null(separator, message: CombineSeparatorRequired);

            return separator.ToString().Combine(elements, formatter);
        }
    }
}