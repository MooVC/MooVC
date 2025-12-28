namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Xml.Linq;
    using MooVC.Syntax.CSharp.Elements;

    internal static class ProjectXml
    {
        private static readonly Identifier.Options IdentifierOptions = Identifier.Options.Pascal;

        internal static XAttribute Attribute(string name, Snippet value)
        {
            if (value.IsEmpty)
            {
                return null;
            }

            return new XAttribute(name, value.ToString());
        }

        internal static XAttribute Attribute(string name, Identifier value)
        {
            if (value.IsUnnamed)
            {
                return null;
            }

            return new XAttribute(name, value.ToSnippet(IdentifierOptions).ToString());
        }

        internal static XAttribute Attribute(string name, Qualifier value)
        {
            if (value.IsUnqualified)
            {
                return null;
            }

            return new XAttribute(name, value.ToString());
        }

        internal static XAttribute Attribute(string name, bool value)
        {
            if (!value)
            {
                return null;
            }

            return new XAttribute(name, value.ToString().ToLowerInvariant());
        }

        internal static XAttribute Attribute(string name, TargetTask.Options value)
        {
            if (value == TargetTask.Options.ErrorAndStop)
            {
                return null;
            }

            return new XAttribute(name, value.ToString());
        }

        internal static string ElementName(Identifier value, string fallback)
        {
            if (value.IsUnnamed)
            {
                return fallback;
            }

            return value.ToSnippet(IdentifierOptions).ToString();
        }
    }
}