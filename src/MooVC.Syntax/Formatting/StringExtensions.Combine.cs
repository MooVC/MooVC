namespace MooVC.Syntax.Formatting
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Text;
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.Formatting.StringExtensions_Resources;

    /// <summary>
    /// Represents a formatting helper string extensions.
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        /// Performs the combine operation for the formatting helper.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <param name="values">The values.</param>
        /// <returns>The string.</returns>
        public static string Combine(this string separator, params string[] values)
        {
            _ = Guard.Against.NullOrEmpty(separator, message: CombineSeparatorRequired);
            _ = Guard.Against.Null(values, message: CombineValuesRequired.Format(separator));

            var builder = new StringBuilder();

            values = values
                .Where(value => !string.IsNullOrWhiteSpace(value))
                .ToArray();

            int lastIndex = values.Length - 1;

            for (int index = 0; index < values.Length; index++)
            {
                string value = values[index];
                builder = builder.Append(value);

                if (index < lastIndex && !string.IsNullOrEmpty(value))
                {
                    builder = builder.Append(separator);
                }
            }

            return builder
                .ToString()
                .Trim();
        }

        /// <summary>
        /// Performs the combine t operation for the formatting helper.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <param name="elements">The elements.</param>
        /// <param name="formatter">The formatter.</param>
        /// <typeparam name="T">The type of the element to which the formatting is to be applied.</typeparam>
        /// <returns>The string.</returns>
        public static string Combine<T>(this string separator, ImmutableArray<T> elements, Func<T, string> formatter)
        {
            _ = Guard.Against.Null(formatter, message: CombineFormatterRequired);

            if (elements.IsDefaultOrEmpty)
            {
                return string.Empty;
            }

            string[] values = new string[elements.Length];

            for (int index = 0; index < elements.Length; index++)
            {
                values[index] = formatter(elements[index]);
            }

            return separator.Combine(values);
        }
    }
}