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
    /// Represents a MSBuild solution attribute project.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Project
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Project Undefined = new Project();

        /// <summary>
        /// Initializes a new instance of the Project class.
        /// </summary>
        internal Project()
        {
        }

        /// <summary>
        /// Gets the id on the Project.
        /// </summary>
        /// <value>The id.</value>
        public Snippet Id { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the Project is undefined.
        /// </summary>
        /// <value>A value indicating whether the Project is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the name on the Project.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Snippet Name { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the path on the Project.
        /// </summary>
        /// <value>The path.</value>
        [Descriptor("At")]
        public Snippet Path { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the type on the Project.
        /// </summary>
        /// <value>The type.</value>
        [Descriptor("OfType")]
        public Snippet Type { get; internal set; } = Snippet.Empty;

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

            return ImmutableArray.Create(new XElement(
                nameof(Project),
                Id.ToXmlAttribute(nameof(Id))
                .And(Name.ToXmlAttribute(nameof(Name)))
                .And(Path.ToXmlAttribute(nameof(Path)))
                .And(Type.ToXmlAttribute(nameof(Type)))));
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

            return ToFragments().Merge();
        }

        /// <summary>
        /// Validates the Project.
        /// </summary>
        /// <remarks>Required members include: Id, Name, Path, Type.</remarks>
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
                .And(nameof(Type), _ => !Type.IsMultiLine, Type)
                .Results;
        }
    }
}