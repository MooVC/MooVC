namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using MooVC.Syntax.CSharp.Attributes.Project;

    internal static class TargetTaskOptionsExtensions
    {
        internal static IEnumerable<object> ToXmlAttribute(this TargetTask.Options value, string name)
        {
            if (value == TargetTask.Options.ErrorAndStop)
            {
                return Array.Empty<object>();
            }

            return new object[] { new XAttribute(name, value.ToString()) };
        }
    }
}