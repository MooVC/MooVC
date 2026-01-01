namespace MooVC.Syntax.Concepts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Fluentify;
    using MooVC.Syntax.Attributes.Project;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Project
        : Construct
    {
        private const string AutoGenValue = "True";
        private const string DesignTimeValue = "True";
        private const string InternalGeneratorValue = "ResXFileCodeGenerator";
        private const string PublicGeneratorValue = "PublicResXFileCodeGenerator";

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
                .Select(resource => CreateResourceItemGroup(resource))
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

        private static XElement CreateResourceItemGroup(ResourceFile resource)
        {
            var resourcePath = resource.ResourcePath.ToString();
            var designerPath = resource.DesignerPath.ToString();

            var compile = new XElement(
                "Compile",
                new XAttribute("Update", designerPath),
                new XElement("DesignTime", DesignTimeValue),
                new XElement("AutoGen", AutoGenValue),
                new XElement("DependentUpon", Path.GetFileName(resourcePath)));

            var embeddedResource = new XElement(
                "EmbeddedResource",
                new XAttribute("Update", resourcePath),
                new XElement("Generator", resource.Scope == ResourceScope.Public ? PublicGeneratorValue : InternalGeneratorValue),
                new XElement("LastGenOutput", Path.GetFileName(designerPath)));

            if (!resource.CustomToolNamespace.IsEmpty)
            {
                embeddedResource.Add(new XElement("CustomToolNamespace", resource.CustomToolNamespace.ToString()));
            }

            return new XElement(nameof(ItemGroup), compile, embeddedResource);
        }

        [Fluentify]
        [Valuify]
        public sealed partial class ResourceFile
            : Construct
        {
            public static readonly ResourceFile Undefined = new ResourceFile();

            public Snippet CustomToolNamespace { get; internal set; } = Snippet.Empty;

            public Snippet DesignerPath { get; internal set; } = Snippet.Empty;

            public Resource Resource { get; internal set; } = Resource.Undefined;

            public Snippet ResourcePath { get; internal set; } = Snippet.Empty;

            public ResourceScope Scope { get; internal set; } = ResourceScope.Internal;

            [Ignore]
            public override bool IsUndefined => this == Undefined;

            public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (IsUndefined)
                {
                    return Array.Empty<ValidationResult>();
                }

                return validationContext
                    .Include(nameof(CustomToolNamespace), _ => !CustomToolNamespace.IsMultiLine, CustomToolNamespace)
                    .And(nameof(DesignerPath), _ => DesignerPath.IsSingleLine, DesignerPath)
                    .And(nameof(Resource), resource => !resource.IsUndefined, Resource)
                    .And(nameof(ResourcePath), _ => ResourcePath.IsSingleLine, ResourcePath)
                    .Results;
            }
        }

        public enum ResourceScope
        {
            Internal,
            Public,
        }
    }
}
