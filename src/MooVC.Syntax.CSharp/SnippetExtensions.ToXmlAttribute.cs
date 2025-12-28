namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    internal static class SnippetExtensions
    {
        internal static IEnumerable<object> ToXmlAttribute(this Snippet value, string name)
        {
            if (value.IsEmpty)
            {
                return Array.Empty<object>();
            }

            return new object[] { new XAttribute(name, value.ToString()) };
        }
    }
}