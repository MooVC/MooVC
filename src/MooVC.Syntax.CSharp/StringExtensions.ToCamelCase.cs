namespace MooVC.Syntax.CSharp
{
    using System.Globalization;
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.CSharp.StringExtensions_Resources;

    internal static partial class StringExtensions
    {
        public static string ToCamelCase(this string value)
        {
            _ = Guard.Against.NullOrWhiteSpace(value, message: ToCamelCaseValueRequired);

            return ToCased(value, character => char.ToLower(character, CultureInfo.InvariantCulture));
        }
    }
}