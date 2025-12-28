namespace MooVC.Syntax.CSharp.Elements
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    internal static class QualifierExtensions
    {
        internal static IEnumerable<object> ToXmlAttribute(this Qualifier value, string name)
        {
            if (value.IsUnqualified)
            {
                return Enumerable.Empty<object>();
            }

            return new object[] { new XAttribute(name, value.ToString()) };
        }
    }
}