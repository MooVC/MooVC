namespace MooVC.Syntax.Attributes.Solution
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Xml.Linq;
    using Fluentify;
    using MooVC.Syntax;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a MSBuild solution attribute file.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class File
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly File Undefined = new File();

        /// <summary>
        /// Initializes a new instance of the File class.
        /// </summary>
        internal File()
        {
        }

        /// <summary>
        /// Gets or sets the id on the File.
        /// </summary>
        /// <value>The id.</value>
        public Snippet Id { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the File is undefined.
        /// </summary>
        /// <value>A value indicating whether the File is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the name on the File.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Snippet Name { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the path on the File.
        /// </summary>
        /// <value>The path.</value>
        [Descriptor("At")]
        public Snippet Path { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Performs the to fragments operation for the MSBuild solution attribute.
        /// </summary>
        /// <returns>The immutable array x element.</returns>
        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            ImmutableArray<XElement>.Builder builder = ImmutableArray.CreateBuilder<XElement>(1);

            builder.Add(new XElement(
                nameof(File),
                Id.ToXmlAttribute(nameof(Id)),
                Name.ToXmlAttribute(nameof(Name)),
                Path.ToXmlAttribute(nameof(Path))));

            return builder.ToImmutable();
        }

        /// <summary>
        /// Returns the string representation of the File.
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
        /// Validates the File.
        /// </summary>
        /// <remarks>Required members include: Id, Name, Path.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Id), _ => !Id.IsMultiLine, Id)
                .And(nameof(Name), _ => !Name.IsMultiLine, Name)
                .And(nameof(Path), _ => Path.IsSingleLine, Path)
                .Results;
        }
    }
}