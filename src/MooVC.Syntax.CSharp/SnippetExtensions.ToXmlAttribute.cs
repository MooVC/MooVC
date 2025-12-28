namespace MooVC.Syntax.CSharp
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    internal static class SnippetExtensions
    {
        internal static IEnumerable<object> ToXmlAttribute(this Snippet value, string name)
        {
            if (value.IsEmpty)
            {
                return Enumerable.Empty<object>();
            }

            return new object[] { new XAttribute(name, value.ToString()) };
        }
    }
}