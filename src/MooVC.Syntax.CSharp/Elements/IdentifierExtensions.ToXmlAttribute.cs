namespace MooVC.Syntax.CSharp.Elements
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    internal static partial class IdentifierExtensions
    {
        internal static IEnumerable<object> ToXmlAttribute(this Identifier value, string name)
        {
            if (value.IsUnnamed)
            {
                return Enumerable.Empty<object>();
            }

            return new object[] { new XAttribute(name, value.ToSnippet(Identifier.Options.Pascal).ToString()) };
        }
    }
}