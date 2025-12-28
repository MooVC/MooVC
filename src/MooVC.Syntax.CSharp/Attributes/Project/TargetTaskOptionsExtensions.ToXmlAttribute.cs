namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    internal static class TargetTaskOptionsExtensions
    {
        internal static IEnumerable<object> ToXmlAttribute(this TargetTask.Options value, string name)
        {
            if (value == TargetTask.Options.ErrorAndStop)
            {
                return Enumerable.Empty<object>();
            }

            return new object[] { new XAttribute(name, value.ToString()) };
        }
    }
}