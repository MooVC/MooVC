namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using MooVC.Syntax.CSharp.Elements;

    internal static partial class IdentifierExtensions
    {
        internal static IEnumerable<object> ToXmlAttribute(this Identifier value, string name)
        {
            if (value.IsUnnamed)
            {
                return Array.Empty<object>();
            }

            return new object[] { new XAttribute(name, value.ToSnippet(Identifier.Options.Pascal).ToString()) };
        }
    }
}