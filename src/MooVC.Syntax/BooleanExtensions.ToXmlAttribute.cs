namespace MooVC.Syntax
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// Represents a syntax helper boolean extensions.
    /// </summary>
    internal static class BooleanExtensions
    {
        /// <summary>
        /// Creates XML attributes for the syntax helper.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        /// <returns>The XML attributes.</returns>
        public static IEnumerable<XAttribute> ToXmlAttribute(this bool value, string name)
        {
            if (!value)
            {
                return XAttribute.EmptySequence;
            }

            return new XAttribute[]
            {
                new XAttribute(name, value.ToString().ToLowerInvariant()),
            };
        }
    }
}