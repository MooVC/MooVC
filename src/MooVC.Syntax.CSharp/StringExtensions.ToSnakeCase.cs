namespace MooVC.Syntax.CSharp
{
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.CSharp.StringExtensions_Resources;

    internal static partial class StringExtensions
    {
        public static string ToSnakeCase(this string value)
        {
            _ = Guard.Against.NullOrWhiteSpace(value, message: ToSnakeCaseValueRequired);

            return ToSeparatedCase(value, Underscore);
        }
    }
}