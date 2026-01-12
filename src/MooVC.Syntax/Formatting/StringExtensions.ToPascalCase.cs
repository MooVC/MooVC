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
        /// Performs the to pascal case operation for the formatting helper.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The string.</returns>
        public static string ToPascalCase(this string value)
        {
            _ = Guard.Against.NullOrWhiteSpace(value, message: ToPascalCaseValueRequired);

            return ToCased(value, character => char.ToUpper(character, CultureInfo.InvariantCulture));
        }
    }
}