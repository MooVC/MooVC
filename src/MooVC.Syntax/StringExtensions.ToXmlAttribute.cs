namespace MooVC.Syntax
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// Represents a syntax element snippet extensions.
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        /// Creates XML attributes for the syntax element.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        /// <returns>The XML attributes.</returns>
        internal static IEnumerable<XAttribute> ToXmlAttribute(this string value, string name)
        {
            if (string.IsNullOrEmpty(value))
            {
                return XAttribute.EmptySequence;
            }

            return new XAttribute[]
            {
                new XAttribute(name, value),
            };
        }
    }
}