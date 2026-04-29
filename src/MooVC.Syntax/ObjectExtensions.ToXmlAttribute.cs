namespace MooVC.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Xml.Linq;

    /// <summary>
    /// Represents a syntax element snippet extensions.
    /// </summary>
    internal static partial class ObjectExtensions
    {
        /// <summary>
        /// Creates XML attributes for the syntax element.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        /// <param name="include">An optional predicate that determines if the attrbibute should be added.</param>
        /// <param name="toLower">Denotes whether or not the attribute name should be in lower case.</param>
        /// <returns>The XML attributes.</returns>
        [SuppressMessage("Style", "IDE0041:Use 'is null' check", Justification = "False Positive")]
        public static IEnumerable<XAttribute> ToXmlAttribute<T>(this T value, string name, Predicate<T> include = default, bool toLower = false)
        {
            if (ReferenceEquals(value, null) || !(include is null || include(value)))
            {
                return XAttribute.EmptySequence;
            }

            return value
                .ToString()
                .ToXmlAttribute(name, toLower: toLower);
        }
    }
}