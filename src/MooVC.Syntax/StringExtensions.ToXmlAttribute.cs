namespace MooVC.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// Represents a syntax element snippet extensions.
    /// </summary>
    internal static partial class StringExtensions
    {
        /// <summary>
        /// Creates XML attributes for the syntax element.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        /// <param name="include">An optional predicate that determines if the attrbibute should be added.</param>
        /// <param name="toLower">Denotes whether or not the attribute name should be in lower case.</param>
        /// <returns>The XML attributes.</returns>
        public static IEnumerable<XAttribute> ToXmlAttribute(this string value, string name, Predicate<string> include = default, bool toLower = false)
        {
            if (string.IsNullOrEmpty(value) || !(include is null || include(value)))
            {
                return XAttribute.EmptySequence;
            }

            if (toLower)
            {
                name = name.ToLowerInvariant();
            }

            return new XAttribute[]
            {
                new XAttribute(name, value),
            };
        }
    }
}