namespace MooVC.Syntax.CSharp.Elements
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    internal static partial class QualifierExtensions
    {
        public static IEnumerable<XAttribute> ToXmlAttribute(this Qualifier value, string name)
        {
            if (value.IsUnqualified)
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