namespace MooVC.Syntax.CSharp
{
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.CSharp.StringExtensions_Resources;

    internal static partial class StringExtensions
    {
        public static string ToKebabCase(this string value)
        {
            _ = Guard.Against.NullOrWhiteSpace(value, message: ToKebabCaseValueRequired);

            return ToSeparatedCase(value, Hyphen);
        }
    }
}