namespace MooVC.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// Represents a syntax helper boolean extensions.
    /// </summary>
    internal static partial class BooleanExtensions
    {
        /// <summary>
        /// Creates XML attributes for the syntax helper.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        /// <param name="include">An optional predicate that determines if the attrbibute should be added.</param>
        /// <param name="toLower">Denotes whether or not the attribute name should be in lower case.</param>
        /// <returns>The XML attributes.</returns>
        public static IEnumerable<XAttribute> ToXmlAttribute(this bool value, string name, Predicate<bool> include = default, bool toLower = false)
        {
            if (!value || !(include is null || include(value)))
            {
                return XAttribute.EmptySequence;
            }

            return value.ToString().ToLowerInvariant().ToXmlAttribute(name, toLower: toLower);
        }
    }
}