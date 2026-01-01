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

    [Fluentify]
    [Valuify]
    public sealed partial class Project
        : Construct
    {
        public static readonly Project Undefined = new Project();

        public ImmutableArray<Import> Imports { get; internal set; } = ImmutableArray<Import>.Empty;

        public ImmutableArray<ItemGroup> ItemGroups { get; internal set; } = ImmutableArray<ItemGroup>.Empty;

        public ImmutableArray<PropertyGroup> PropertyGroups { get; internal set; } = ImmutableArray<PropertyGroup>.Empty;

        public ImmutableArray<ResourceFile> Resources { get; internal set; } = ImmutableArray<ResourceFile>.Empty;

        public ImmutableArray<Sdk> Sdks { get; internal set; } = ImmutableArray<Sdk>.Empty;

        public ImmutableArray<Target> Targets { get; internal set; } = ImmutableArray<Target>.Empty;

        [Ignore]
        public override bool IsUndefined => this == Undefined;

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