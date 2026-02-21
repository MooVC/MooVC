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
        /// <param name="value">The value.</param>
        /// <returns>The XML element name.</returns>
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