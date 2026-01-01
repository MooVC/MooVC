namespace MooVC.Syntax.Elements
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// Represents a syntax element snippet extensions.
    /// </summary>
    public static partial class SnippetExtensions
    {
        /// <summary>
        /// Creates XML attributes for the syntax element.
        /// </summary>
        internal static IEnumerable<XAttribute> ToXmlAttribute(this Snippet value, string name)
        {
            if (value.IsEmpty)
            {
                return XAttribute.EmptySequence;
            }

            return new XAttribute[]
            {
                new XAttribute(name, value.ToString()),
            };
        }
    }
}