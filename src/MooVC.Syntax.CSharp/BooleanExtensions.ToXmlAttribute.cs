namespace MooVC.Syntax.CSharp
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    internal static class BooleanExtensions
    {
        public static IEnumerable<XAttribute> ToXmlAttribute(this bool value, string name)
        {
            if (!value)
            {
                return XAttribute.EmptySequence;
            }

            return new XAttribute[]
            {
                new XAttribute(name, value.ToString().ToLowerInvariant()),
            };
        }
    }
}