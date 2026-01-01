namespace MooVC.Syntax
{
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.Formatting.StringExtensions_Resources;

    public static partial class StringExtensions
    {
        public static string ToSnakeCase(this string value)
        {
            _ = Guard.Against.NullOrWhiteSpace(value, message: ToSnakeCaseValueRequired);

            return ToSeparatedCase(value, Underscore);
        }
    }
}