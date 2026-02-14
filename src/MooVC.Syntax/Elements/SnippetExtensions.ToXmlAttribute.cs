namespace MooVC.Syntax.Elements
{
    using System;
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
        /// <param name="include">An optional predicate that determines if the attrbibute should be added.</param>
        /// <param name="toLower">Denotes whether or not the attribute name should be in lower case.</param>
        /// <returns>The XML attributes.</returns>
        /// <remarks>
        /// It only every returns at most one element, but an <see cref="IEnumerable{XAttribute}"/> is returned for convenience of consumption.
        /// </remarks>
        internal static IEnumerable<XAttribute> ToXmlAttribute(
            this Snippet value,
            string name,
            Predicate<Snippet> include = default,
            bool toLower = false)
        {
            if (value.IsEmpty || !(include is null || include(value)))
            {
                return XAttribute.EmptySequence;
            }

            return value.ToString().ToXmlAttribute(name, toLower: toLower);
        }
    }
}