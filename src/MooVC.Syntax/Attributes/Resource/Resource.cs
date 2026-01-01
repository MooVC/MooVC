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

    /// <summary>
    /// Represents a resource file attribute resource.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Resource
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the Resource.
        /// </summary>
        public static readonly Resource Undefined = new Resource();

        private const string AutoGenValue = "True";
        private const string DesignTimeValue = "True";
        private const string InternalGeneratorValue = "ResXFileCodeGenerator";
        private const string PublicGeneratorValue = "PublicResXFileCodeGenerator";

        /// <summary>
        /// Initializes a new instance of the Resource class.
        /// </summary>
        internal Resource()
        {
        }

        /// <summary>
        /// Gets or sets the custom tool namespace on the Resource.
        /// </summary>
        public Snippet CustomToolNamespace { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the designer on the Resource.
        /// </summary>
        public Path Designer { get; internal set; } = Path.Empty;

        /// <summary>
        /// Gets or sets the location on the Resource.
        /// </summary>
        public Path Location { get; internal set; } = Path.Empty;

        /// <summary>
        /// Gets or sets the visibility on the Resource.
        /// </summary>
        public Scope Visibility { get; internal set; } = Scope.Internal;

        /// <summary>
        /// Gets a value indicating whether the Resource is undefined.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Performs the To Fragments operation for the resource file attribute.
        /// </summary>
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

        /// <summary>
        /// Returns the string representation of the Resource.
        /// </summary>
        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToFragments().Merge();
        }

        /// <summary>
        /// Validates the Resource and returns validation results.
        /// </summary>
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