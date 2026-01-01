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
        /// Performs the To Snake Case operation for the formatting helper.
        /// </summary>
        public static string ToSnakeCase(this string value)
        {
            _ = Guard.Against.NullOrWhiteSpace(value, message: ToSnakeCaseValueRequired);

            return ToSeparatedCase(value, Underscore);
        }
    }
}