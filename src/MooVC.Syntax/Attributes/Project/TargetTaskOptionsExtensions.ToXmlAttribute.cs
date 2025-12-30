namespace MooVC.Syntax.Attributes.Project
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    internal static class TargetTaskOptionsExtensions
    {
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