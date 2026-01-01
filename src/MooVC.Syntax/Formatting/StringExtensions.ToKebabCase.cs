namespace MooVC.Syntax
{
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.Formatting.StringExtensions_Resources;

    public static partial class StringExtensions
    {
        public static string ToKebabCase(this string value)
        {
            _ = Guard.Against.NullOrWhiteSpace(value, message: ToKebabCaseValueRequired);

            return ToSeparatedCase(value, Hyphen);
        }
    }
}