namespace MooVC.Syntax.Elements
{
    using System;

    /// <summary>
    /// Represents a syntax element identifier extensions.
    /// </summary>
    internal static partial class IdentifierExtensions
    {
        /// <summary>
        /// Creates an XML element name for the syntax element.
        /// </summary>
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