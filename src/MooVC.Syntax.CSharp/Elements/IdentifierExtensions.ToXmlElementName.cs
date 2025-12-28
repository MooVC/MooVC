namespace MooVC.Syntax.CSharp.Elements
{
    using System;

    internal static partial class IdentifierExtensions
    {
        public static string ToXmlElementName(this Identifier value)
        {
            if (value.IsUnnamed)
            {
                throw new NotSupportedException();
            }

            return value.ToSnippet(Identifier.Options.Pascal).ToString();
        }
    }
}