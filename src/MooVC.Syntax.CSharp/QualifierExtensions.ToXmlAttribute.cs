namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using MooVC.Syntax.CSharp.Elements;

    internal static class QualifierExtensions
    {
        internal static IEnumerable<object> ToXmlAttribute(this Qualifier value, string name)
        {
            if (value.IsUnqualified)
            {
                return Array.Empty<object>();
            }

            return new object[] { new XAttribute(name, value.ToString()) };
        }
    }
}