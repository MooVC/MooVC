namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Xml.Linq;
    using Fluentify;
    using MooVC.Syntax.CSharp.Attributes.Project;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Project
        : Construct
    {
        public static readonly Project Undefined = new Project();

        internal Project()
        {
        }

        public ImmutableArray<Import> Imports { get; internal set; } = ImmutableArray<Import>.Empty;

        public ImmutableArray<ItemGroup> ItemGroups { get; internal set; } = ImmutableArray<ItemGroup>.Empty;

        public ImmutableArray<PropertyGroup> PropertyGroups { get; internal set; } = ImmutableArray<PropertyGroup>.Empty;

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