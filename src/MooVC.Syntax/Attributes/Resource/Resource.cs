namespace MooVC.Syntax.Attributes.Resource
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Linq;
    using Fluentify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;
    using Path = MooVC.Syntax.Elements.Path;

    [Fluentify]
    [Valuify]
    public sealed partial class Resource
        : IValidatableObject
    {
        public static readonly Resource Undefined = new Resource();

        private const string AutoGenValue = "True";
        private const string DesignTimeValue = "True";
        private const string InternalGeneratorValue = "ResXFileCodeGenerator";
        private const string PublicGeneratorValue = "PublicResXFileCodeGenerator";

        internal Resource()
        {
        }

        public Snippet CustomToolNamespace { get; internal set; } = Snippet.Empty;

        public Path Designer { get; internal set; } = Path.Empty;

        public Path Location { get; internal set; } = Path.Empty;

        public Scope Visibility { get; internal set; } = Scope.Internal;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            Path designer = Designer.IsEmpty
                ? Location.ChangeExtension("Designer.cs")
                : Designer;

            string locationPath = Location;
            string designerPath = designer;

            ImmutableArray<XElement>.Builder builder = ImmutableArray.CreateBuilder<XElement>(2);

            builder.Add(new XElement(
                "Compile",
                new XAttribute("Update", designerPath),
                new XElement("DesignTime", DesignTimeValue),
                new XElement("AutoGen", AutoGenValue),
                new XElement("DependentUpon", Location.FileName)));

            builder.Add(new XElement(
                "EmbeddedResource",
                new XAttribute("Update", locationPath),
                new XElement("Generator", Visibility == Scope.Public ? PublicGeneratorValue : InternalGeneratorValue),
                new XElement("LastGenOutput", designer.FileName)));

            if (!CustomToolNamespace.IsEmpty)
            {
                builder[1].Add(new XElement("CustomToolNamespace", CustomToolNamespace.ToString()));
            }

            return builder.ToImmutable();
        }

        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToFragments().Merge();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Array.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(CustomToolNamespace), _ => !CustomToolNamespace.IsMultiLine, CustomToolNamespace)
                .AndIf(!Designer.IsEmpty, nameof(Designer), path => !path.IsEmpty, Designer)
                .And(nameof(Location), path => !path.IsEmpty, Location)
                .Results;
        }
    }
}