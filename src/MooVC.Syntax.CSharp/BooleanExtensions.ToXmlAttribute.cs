namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    internal static class BooleanExtensions
    {
        internal static IEnumerable<object> ToXmlAttribute(this bool value, string name)
        {
            if (!value)
            {
                return Array.Empty<object>();
            }

            return new object[] { new XAttribute(name, value.ToString().ToLowerInvariant()) };
        }
    }
}