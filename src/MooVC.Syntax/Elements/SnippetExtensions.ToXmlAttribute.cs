namespace MooVC.Syntax.Elements
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    public static partial class SnippetExtensions
    {
        internal static IEnumerable<XAttribute> ToXmlAttribute(this Snippet value, string name)
        {
            if (value.IsEmpty)
            {
                return XAttribute.EmptySequence;
            }

            return new XAttribute[]
            {
                new XAttribute(name, value.ToString()),
            };
        }
    }
}