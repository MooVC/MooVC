namespace MooVC.Syntax.Attributes.Project
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// Represents a msbuild project attribute target task options extensions.
    /// </summary>
    internal static class TargetTaskOptionsExtensions
    {
        /// <summary>
        /// Creates XML attributes for the msbuild project attribute.
        /// </summary>
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