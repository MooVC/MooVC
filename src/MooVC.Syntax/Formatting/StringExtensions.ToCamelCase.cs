namespace MooVC.Syntax.Formatting
{
    using System.Globalization;
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.Formatting.StringExtensions_Resources;

    /// <summary>
    /// Represents a formatting helper string extensions.
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        /// Performs the to camel case operation for the formatting helper.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The string.</returns>
        public static string ToCamelCase(this string value)
        {
            _ = Guard.Against.NullOrWhiteSpace(value, message: ToCamelCaseValueRequired);

            return ToCased(value, character => char.ToLower(character, CultureInfo.InvariantCulture));
        }
    }
}