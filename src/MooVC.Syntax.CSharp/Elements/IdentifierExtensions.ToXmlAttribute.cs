namespace MooVC.Syntax.CSharp.Elements
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    internal static partial class IdentifierExtensions
    {
        public static IEnumerable<XAttribute> ToXmlAttribute(this Identifier value, string name)
        {
            if (value.IsUnnamed)
            {
                return XAttribute.EmptySequence;
            }

            return new XAttribute[]
            {
                new XAttribute(name, value.ToSnippet(Identifier.Options.Pascal).ToString()),
            };
        }
    }
}