namespace MooVC.Syntax.Concepts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Xml.Linq;
    using Fluentify;
    using MooVC.Syntax.Attributes.Solution;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;
    using ProjectReference = MooVC.Syntax.Attributes.Solution.Project;

    [Fluentify]
    [Valuify]
    public sealed partial class Solution
        : Construct
    {
        public static readonly Solution Undefined = new Solution();

        public ImmutableArray<Configuration> Configurations { get; internal set; } = ImmutableArray<Configuration>.Empty;

        public ImmutableArray<File> Files { get; internal set; } = ImmutableArray<File>.Empty;

        public ImmutableArray<Folder> Folders { get; internal set; } = ImmutableArray<Folder>.Empty;

        public ImmutableArray<Item> Items { get; internal set; } = ImmutableArray<Item>.Empty;

        public ImmutableArray<ProjectReference> Projects { get; internal set; } = ImmutableArray<ProjectReference>.Empty;

        public ImmutableArray<Property> Properties { get; internal set; } = ImmutableArray<Property>.Empty;

        [Ignore]
        public override bool IsUndefined => this == Undefined;

        public XDocument ToDocument()
        {
            if (IsUndefined)
            {
                return new XDocument();
            }

            var elements = new List<XElement>();

            AppendConfiguration(elements);
            AppendItems(elements);
            AppendProjects(elements);
            AppendProperties(elements);

            var declaration = new XDeclaration("1.0", "utf-8", "yes");
            var solution = new XElement(nameof(Solution), elements);

            return new XDocument(declaration, solution);
        }

        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToDocument().ToString();
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Array.Empty<ValidationResult>();
            }

            return validationContext
                .IncludeIf(!Configurations.IsDefaultOrEmpty, nameof(Configurations), configuration => !configuration.IsUndefined, Configurations)
                .AndIf(!Files.IsDefaultOrEmpty, nameof(Files), file => !file.IsUndefined, Files)
                .AndIf(!Folders.IsDefaultOrEmpty, nameof(Folders), folder => !folder.IsUndefined, Folders)
                .AndIf(!Items.IsDefaultOrEmpty, nameof(Items), item => !item.IsUndefined, Items)
                .AndIf(!Projects.IsDefaultOrEmpty, nameof(Projects), project => !project.IsUndefined, Projects)
                .AndIf(!Properties.IsDefaultOrEmpty, nameof(Properties), property => !property.IsUndefined, Properties)
                .Results;
        }

        private static ImmutableArray<XElement> Get<T>(
            Func<T, ImmutableArray<XElement>> fragments,
            Predicate<T> isDefined,
            ImmutableArray<T> subjects)
            where T : class
        {
            if (subjects.IsDefaultOrEmpty)
            {
                return ImmutableArray<XElement>.Empty;
            }

            return subjects
                .Where(item => isDefined(item))
                .SelectMany(item => fragments(item))
                .ToImmutableArray();
        }

        private void AppendConfiguration(List<XElement> elements)
        {
            ImmutableArray<XElement> configurations = Get(
                configuration => configuration.ToFragments(),
                configuration => !configuration.IsUndefined,
                Configurations);

            if (!configurations.IsDefaultOrEmpty)
            {
                elements.Add(new XElement("Configurations", configurations));
            }
        }

        private void AppendItems(List<XElement> elements)
        {
            ImmutableArray<XElement> files = Get(file => file.ToFragments(), file => !file.IsUndefined, Files);
            ImmutableArray<XElement> folders = Get(folder => folder.ToFragments(), folder => !folder.IsUndefined, Folders);
            ImmutableArray<XElement> items = Get(item => item.ToFragments(), item => !item.IsUndefined, Items);

            if (!(files.IsDefaultOrEmpty && folders.IsEmpty && items.IsDefaultOrEmpty))
            {
                elements.Add(new XElement("Items", files, folders, items));
            }
        }

        private void AppendProperties(List<XElement> elements)
        {
            ImmutableArray<XElement> properties = Get(property => property.ToFragments(), property => !property.IsUndefined, Properties);

            if (!properties.IsDefaultOrEmpty)
            {
                elements.Add(new XElement("Properties", properties));
            }
        }

        private void AppendProjects(List<XElement> elements)
        {
            ImmutableArray<XElement> projects = Get(project => project.ToFragments(), project => !project.IsUndefined, Projects);

            if (!projects.IsDefaultOrEmpty)
            {
                elements.Add(new XElement("Projects", projects));
            }
        }
    }
}