namespace MooVC.Syntax.CSharp
{
    using System.Xml.Linq;
    using MooVC.Syntax.CSharp.Attributes.Project;
    using MooVC.Syntax.CSharp.Elements;

    internal static class XmlExtensions
    {
        private static readonly Identifier.Options IdentifierOptions = Identifier.Options.Pascal;

        internal static XAttribute ToXmlAttribute(this Snippet value, string name)
        {
            if (value.IsEmpty)
            {
                return null;
            }

            return new XAttribute(name, value.ToString());
        }

        internal static XAttribute ToXmlAttribute(this Identifier value, string name)
        {
            if (value.IsUnnamed)
            {
                return null;
            }

            return new XAttribute(name, value.ToSnippet(IdentifierOptions).ToString());
        }

        internal static XAttribute ToXmlAttribute(this Qualifier value, string name)
        {
            if (value.IsUnqualified)
            {
                return null;
            }

            return new XAttribute(name, value.ToString());
        }

        internal static XAttribute ToXmlAttribute(this bool value, string name)
        {
            if (!value)
            {
                return null;
            }

            return new XAttribute(name, value.ToString().ToLowerInvariant());
        }

        internal static XAttribute ToXmlAttribute(this TargetTask.Options value, string name)
        {
            if (value == TargetTask.Options.ErrorAndStop)
            {
                return null;
            }

            return new XAttribute(name, value.ToString());
        }

        internal static string ToXmlElementName(this Identifier value, string fallback)
        {
            if (value.IsUnnamed)
            {
                return fallback;
            }

            return value.ToSnippet(IdentifierOptions).ToString();
        }
    }
}