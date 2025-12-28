namespace MooVC.Syntax.CSharp
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    internal static partial class SnippetExtensions
    {
        public static IEnumerable<XAttribute> ToXmlAttribute(this Snippet value, string name)
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