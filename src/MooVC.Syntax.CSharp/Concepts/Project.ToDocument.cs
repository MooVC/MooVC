namespace MooVC.Syntax.CSharp.Concepts
{
    using System.Linq;
    using System.Xml.Linq;
    using MooVC.Syntax.CSharp.Attributes.Project;

    public sealed partial class Project
    {
        public XDocument ToDocument()
        {
            if (IsUndefined)
            {
                return new XDocument();
            }

            var imports = Imports
                .Where(import => !import.IsUndefined)
                .Select(import => import.ToFragment());

            var itemGroups = ItemGroups
                .Where(group => !group.IsUndefined)
                .Select(group => group.ToFragment());

            var propertyGroups = PropertyGroups
                .Where(group => !group.IsUndefined)
                .Select(group => group.ToFragment());

            var sdks = Sdks
                .Where(sdk => !sdk.IsUnspecified)
                .Select(sdk => sdk.ToFragment());

            var targets = Targets
                .Where(target => !target.IsUndefined)
                .Select(target => target.ToFragment());

            var project = new XElement(
                nameof(Project),
                imports,
                itemGroups,
                propertyGroups,
                sdks,
                targets);

            return new XDocument(project);
        }

        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToDocument().ToString();
        }
    }
}