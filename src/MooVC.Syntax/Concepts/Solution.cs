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

    /// <summary>
    /// Represents a syntax construct solution.
    /// </summary>
    [AutoInitiateWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Solution
        : Construct
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Solution Undefined = new Solution();

        /// <summary>
        /// Gets or sets the configurations on the Solution.
        /// </summary>
        /// <value>The configurations.</value>
        public ImmutableArray<Configuration> Configurations { get; internal set; } = ImmutableArray<Configuration>.Empty;

        /// <summary>
        /// Gets or sets the files on the Solution.
        /// </summary>
        /// <value>The files.</value>
        public ImmutableArray<File> Files { get; internal set; } = ImmutableArray<File>.Empty;

        /// <summary>
        /// Gets or sets the folders on the Solution.
        /// </summary>
        /// <value>The folders.</value>
        public ImmutableArray<Folder> Folders { get; internal set; } = ImmutableArray<Folder>.Empty;

        /// <summary>
        /// Gets or sets the items on the Solution.
        /// </summary>
        /// <value>The items.</value>
        public ImmutableArray<Item> Items { get; internal set; } = ImmutableArray<Item>.Empty;

        /// <summary>
        /// Gets or sets the projects on the Solution.
        /// </summary>
        /// <value>The projects.</value>
        public ImmutableArray<ProjectReference> Projects { get; internal set; } = ImmutableArray<ProjectReference>.Empty;

        /// <summary>
        /// Gets or sets the properties on the Solution.
        /// </summary>
        /// <value>The properties.</value>
        public ImmutableArray<Property> Properties { get; internal set; } = ImmutableArray<Property>.Empty;

        /// <summary>
        /// Gets a value indicating whether the Solution is undefined.
        /// </summary>
        /// <value>A value indicating whether the Solution is undefined.</value>
        [Ignore]
        public override bool IsUndefined => this == Undefined;

        /// <summary>
        /// Creates an XML document for the Solution.
        /// </summary>
        /// <returns>The generated XML document.</returns>
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

        /// <summary>
        /// Returns the string representation of the Solution.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToDocument().ToString();
        }

        /// <summary>
        /// Validates the Solution.
        /// </summary>
        /// <remarks>Required members include: Configurations, Files, Folders, Items, Projects, Properties.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
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