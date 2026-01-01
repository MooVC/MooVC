namespace MooVC.Syntax.Elements
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// Represents a syntax element identifier extensions.
    /// </summary>
    internal static partial class IdentifierExtensions
    {
        /// <summary>
        /// Creates XML attributes for the syntax element.
        /// </summary>
        public static IEnumerable<XAttribute> ToXmlAttribute(this Identifier value, string name)
        {
            if (value.IsUnnamed)
            {
                return XAttribute.EmptySequence;
            }

            return new XAttribute[]
            {
                new XAttribute(name, value.ToSnippet(Identifier.Options.Pascal).ToString()),
            };
        }
    }
}