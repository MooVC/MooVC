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
        /// <param name="value">The attribute value.</param>
        /// <param name="name">The attribute name.</param>
        /// <param name="toLower">Denotes whether or not the attribute name should be in lower case.</param>
        /// <returns>The XML attributes.</returns>
        /// <remarks>
        /// It only every returns at most one element, but an <see cref="IEnumerable{XAttribute}"/> is returned for convenience of consumption.
        /// </remarks>
        internal static IEnumerable<XAttribute> ToXmlAttribute(this Snippet value, string name, bool toLower = false)
        {
            if (value.IsEmpty)
            {
                return XAttribute.EmptySequence;
            }

            if (toLower)
            {
                name = name.ToLowerInvariant();
            }

            return new XAttribute[]
            {
                new XAttribute(name, value.ToString()),
            };
        }
    }
}