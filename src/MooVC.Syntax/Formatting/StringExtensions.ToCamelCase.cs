namespace MooVC.Syntax
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
        /// Performs the To Camel Case operation for the formatting helper.
        /// </summary>
        public static string ToCamelCase(this string value)
        {
            _ = Guard.Against.NullOrWhiteSpace(value, message: ToCamelCaseValueRequired);

            return ToCased(value, character => char.ToLower(character, CultureInfo.InvariantCulture));
        }
    }
}