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
        /// Gets the undefined instance.
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
        /// Gets the custom tool namespace on the Resource.
        /// </summary>
        /// <value>The custom tool namespace.</value>
        public Snippet CustomToolNamespace { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the designer on the Resource.
        /// </summary>
        /// <value>The designer.</value>
        public Path Designer { get; internal set; } = Path.Empty;

        /// <summary>
        /// Gets the location on the Resource.
        /// </summary>
        /// <value>The location.</value>
        public Path Location { get; internal set; } = Path.Empty;

        /// <summary>
        /// Gets the visibility on the Resource.
        /// </summary>
        /// <value>The visibility.</value>
        public Scope Visibility { get; internal set; } = Scope.Internal;

        /// <summary>
        /// Gets a value indicating whether the Resource is undefined.
        /// </summary>
        /// <value>A value indicating whether the Resource is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Performs the to fragments operation for the resource file attribute.
        /// </summary>
        /// <returns>The immutable array x element.</returns>
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

            var elements = ImmutableArray.Create(
                new XElement(
                    "Compile",
                    new XAttribute("Update", designerPath),
                    new XElement("DesignTime", DesignTimeValue),
                    new XElement("AutoGen", AutoGenValue),
                    new XElement("DependentUpon", Location.FileName)),
                new XElement(
                    "EmbeddedResource",
                    new XAttribute("Update", locationPath),
                    new XElement("Generator", Visibility == Scope.Public ? PublicGeneratorValue : InternalGeneratorValue),
                    new XElement("LastGenOutput", designer.FileName)));

            if (!CustomToolNamespace.IsEmpty)
            {
                elements[1].Add(new XElement("CustomToolNamespace", CustomToolNamespace.ToString()));
            }

            return elements;
        }

        /// <summary>
        /// Returns the string representation of the Resource.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToFragments().Merge();
        }

        /// <summary>
        /// Validates the Resource.
        /// </summary>
        /// <remarks>Required members include: CustomToolNamespace, Designer, Location.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
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