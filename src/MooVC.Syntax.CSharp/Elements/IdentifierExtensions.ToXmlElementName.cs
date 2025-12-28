namespace MooVC.Syntax.CSharp.Elements
{

    internal static partial class IdentifierExtensions
    {
        internal static string ToXmlElementName(this Identifier value, string fallback)
        {
            if (value.IsUnnamed)
            {
                return fallback;
            }

            return value.ToSnippet(Identifier.Options.Pascal).ToString();
        }
    }
}