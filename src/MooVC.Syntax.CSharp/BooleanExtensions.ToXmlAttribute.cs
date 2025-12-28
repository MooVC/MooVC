namespace MooVC.Syntax.CSharp
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    internal static class BooleanExtensions
    {
        internal static IEnumerable<object> ToXmlAttribute(this bool value, string name)
        {
            if (!value)
            {
                return Enumerable.Empty<object>();
            }

            return new object[] { new XAttribute(name, value.ToString().ToLowerInvariant()) };
        }
    }
}