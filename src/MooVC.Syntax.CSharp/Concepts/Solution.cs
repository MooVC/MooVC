namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Xml.Linq;
    using Fluentify;
    using MooVC.Syntax.CSharp.Attributes.Solution;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Solution
        : Construct
    {
        public static readonly Solution Undefined = new Solution();

        internal Solution()
        {
        }

        public ImmutableArray<Configuration> Configurations { get; internal set; } = ImmutableArray<Configuration>.Empty;

        public ImmutableArray<File> Files { get; internal set; } = ImmutableArray<File>.Empty;

        public ImmutableArray<Folder> Folders { get; internal set; } = ImmutableArray<Folder>.Empty;

        public ImmutableArray<Item> Items { get; internal set; } = ImmutableArray<Item>.Empty;

        public ImmutableArray<Project> Projects { get; internal set; } = ImmutableArray<Project>.Empty;

        public ImmutableArray<Property> Properties { get; internal set; } = ImmutableArray<Property>.Empty;

        [Ignore]
        public override bool IsUndefined => this == Undefined;

        public XDocument ToDocument()
        {
            if (IsUndefined)
            {
                return new XDocument();
            }

            var declaration = new XDeclaration("1.0", "utf-8", "yes");

            return new XDocument(declaration, ToFragments());
        }

        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            XElement[] configurations = Configurations
                .Where(configuration => !configuration.IsUndefined)
                .SelectMany(configuration => configuration.ToFragments())
                .ToArray();

            XElement[] files = Files
                .Where(file => !file.IsUndefined)
                .SelectMany(file => file.ToFragments())
                .ToArray();

            XElement[] folders = Folders
                .Where(folder => !folder.IsUndefined)
                .SelectMany(folder => folder.ToFragments())
                .ToArray();

            XElement[] items = Items
                .Where(item => !item.IsUndefined)
                .SelectMany(item => item.ToFragments())
                .ToArray();

            XElement[] projects = Projects
                .Where(project => !project.IsUndefined)
                .SelectMany(project => project.ToFragments())
                .ToArray();

            XElement[] properties = Properties
                .Where(property => !property.IsUndefined)
                .SelectMany(property => property.ToFragments())
                .ToArray();

            var configurationsElement = configurations.Length == 0
                ? null
                : new XElement("Configurations", configurations);

            var itemsElement = files.Length == 0 && folders.Length == 0 && items.Length == 0
                ? null
                : new XElement("Items", files, folders, items);

            var projectsElement = projects.Length == 0
                ? null
                : new XElement("Projects", projects);

            var propertiesElement = properties.Length == 0
                ? null
                : new XElement("Properties", properties);

            var solution = new XElement(
                nameof(Solution),
                configurationsElement,
                itemsElement,
                projectsElement,
                propertiesElement);

            return ImmutableArray.Create(solution);
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
    }
}