namespace MooVC.Syntax.Elements
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// Represents a syntax element qualifier extensions.
    /// </summary>
    internal static partial class QualifierExtensions
    {
        /// <summary>
        /// Creates XML attributes for the syntax element.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        /// <returns>The XML attributes.</returns>
        public static IEnumerable<XAttribute> ToXmlAttribute(this Qualifier value, string name)
        {
            if (value.IsUnqualified)
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