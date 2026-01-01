namespace MooVC.Syntax
{
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.Formatting.StringExtensions_Resources;

    /// <summary>
    /// Represents a formatting helper string extensions.
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        /// Performs the To Kebab Case operation for the formatting helper.
        /// </summary>
        public static string ToKebabCase(this string value)
        {
            _ = Guard.Against.NullOrWhiteSpace(value, message: ToKebabCaseValueRequired);

            return ToSeparatedCase(value, Hyphen);
        }
    }
}