namespace MooVC.Syntax.Concepts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Xml.Linq;
    using Fluentify;
    using MooVC.Syntax.Attributes.Project;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;
    using ResourceReference = MooVC.Syntax.Attributes.Resource.Resource;

    /// <summary>
    /// Represents a syntax construct project.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Project
        : Construct
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Project Undefined = new Project();

        /// <summary>
        /// Gets or sets the imports on the Project.
        /// </summary>
        /// <value>The imports.</value>
        public ImmutableArray<Import> Imports { get; internal set; } = ImmutableArray<Import>.Empty;

        /// <summary>
        /// Gets or sets the item groups on the Project.
        /// </summary>
        /// <value>The item groups.</value>
        public ImmutableArray<ItemGroup> ItemGroups { get; internal set; } = ImmutableArray<ItemGroup>.Empty;

        /// <summary>
        /// Gets or sets the property groups on the Project.
        /// </summary>
        /// <value>The property groups.</value>
        public ImmutableArray<PropertyGroup> PropertyGroups { get; internal set; } = ImmutableArray<PropertyGroup>.Empty;

        /// <summary>
        /// Gets or sets the resources on the Project.
        /// </summary>
        /// <value>The resources.</value>
        public ImmutableArray<ResourceReference> Resources { get; internal set; } = ImmutableArray<ResourceReference>.Empty;

        /// <summary>
        /// Gets or sets the sdks on the Project.
        /// </summary>
        /// <value>The sdks.</value>
        public ImmutableArray<Sdk> Sdks { get; internal set; } = ImmutableArray<Sdk>.Empty;

        /// <summary>
        /// Gets or sets the targets on the Project.
        /// </summary>
        /// <value>The targets.</value>
        public ImmutableArray<Target> Targets { get; internal set; } = ImmutableArray<Target>.Empty;

        /// <summary>
        /// Gets a value indicating whether the Project is undefined.
        /// </summary>
        /// <value>A value indicating whether the Project is undefined.</value>
        [Ignore]
        public override bool IsUndefined => this == Undefined;

        /// <summary>
        /// Validates the Project.
        /// </summary>
        /// <remarks>Required members include: Imports, ItemGroups, PropertyGroups, Resources, Sdks, Targets.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Array.Empty<ValidationResult>();
            }

            return validationContext
                .IncludeIf(!Imports.IsDefaultOrEmpty, nameof(Imports), import => !import.IsUndefined, Imports)
                .AndIf(!ItemGroups.IsDefaultOrEmpty, nameof(ItemGroups), group => !group.IsUndefined, ItemGroups)
                .AndIf(!PropertyGroups.IsDefaultOrEmpty, nameof(PropertyGroups), group => !group.IsUndefined, PropertyGroups)
                .AndIf(!Resources.IsDefaultOrEmpty, nameof(Resources), resource => !resource.IsUndefined, Resources)
                .AndIf(!Sdks.IsDefaultOrEmpty, nameof(Sdks), sdk => !sdk.IsUnspecified, Sdks)
                .AndIf(!Targets.IsDefaultOrEmpty, nameof(Targets), target => !target.IsUndefined, Targets)
                .Results;
        }

        /// <summary>
        /// Creates an XML document for the Project.
        /// </summary>
        /// <returns>The generated XML document.</returns>
        public XDocument ToDocument()
        {
            if (IsUndefined)
            {
                return new XDocument();
            }

            XElement[] imports = Imports
                .Where(import => !import.IsUndefined)
                .SelectMany(import => import.ToFragments())
                .ToArray();

            XElement[] itemGroups = ItemGroups
                .Where(group => !group.IsUndefined)
                .SelectMany(group => group.ToFragments())
                .ToArray();

            XElement[] resourceItemGroups = Resources
                .Where(resource => !resource.IsUndefined)
                .SelectMany(resource => resource.ToFragments())
                .ForkOn(resources => resources.Any(), @true: CreateResourcesGroup, @false: _ => XElement.EmptySequence)
                .ToArray();

            XElement[] propertyGroups = PropertyGroups
                .Where(group => !group.IsUndefined)
                .SelectMany(group => group.ToFragments())
                .ToArray();

            XElement[] sdks = Sdks
                .Where(sdk => !sdk.IsUnspecified)
                .SelectMany(sdk => sdk.ToFragments())
                .ToArray();

            XElement[] targets = Targets
                .Where(target => !target.IsUndefined)
                .SelectMany(target => target.ToFragments())
                .ToArray();

            var declaration = new XDeclaration("1.0", "utf-8", "yes");

            var project = new XElement(
                nameof(Project),
                propertyGroups,
                itemGroups,
                resourceItemGroups,
                imports,
                sdks,
                targets);

            return new XDocument(declaration, project);
        }

        /// <summary>
        /// Returns the string representation of the Project.
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

        private static IEnumerable<XElement> CreateResourcesGroup(IEnumerable<XElement> resources)
        {
            yield return new XElement(nameof(ItemGroup), resources);
        }
    }
}