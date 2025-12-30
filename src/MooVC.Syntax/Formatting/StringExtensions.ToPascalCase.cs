namespace MooVC.Syntax
{
    using System.Globalization;
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.Formatting.StringExtensions_Resources;

    public static partial class StringExtensions
    {
        public static string ToPascalCase(this string value)
        {
            _ = Guard.Against.NullOrWhiteSpace(value, message: ToPascalCaseValueRequired);

            return ToCased(value, character => char.ToUpper(character, CultureInfo.InvariantCulture));
        }
    }
}