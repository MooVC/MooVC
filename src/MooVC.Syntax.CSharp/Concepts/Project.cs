namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
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
    }
}