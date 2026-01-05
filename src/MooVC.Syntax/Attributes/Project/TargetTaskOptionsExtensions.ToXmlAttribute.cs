namespace MooVC.Syntax.Attributes.Project
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// Represents a MSBuild project attribute target task options extensions.
    /// </summary>
    internal static class TargetTaskOptionsExtensions
    {
        /// <summary>
        /// Creates XML attributes for the MSBuild project attribute.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The XML attributes.</returns>
        public static IEnumerable<XAttribute> ToXmlAttribute(this TargetTask.Options value)
        {
            if (value == TargetTask.Options.ErrorAndStop)
            {
                return XAttribute.EmptySequence;
            }

            return new XAttribute[]
            {
                new XAttribute("ContinueOnError", value.ToString()),
            };
        }
    }
}