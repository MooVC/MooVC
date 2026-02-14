namespace MooVC.Syntax.Attributes.Solution
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Xml.Linq;
    using Fluentify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Platform
        : IProduceXml,
          IValidatableObject
    {
        /// <summary>
        /// Represents an undefined <see cref="Platform"/>.
        /// </summary>
        public static readonly Platform Undefined = new Platform();

        internal Platform()
        {
        }

        /// <summary>
        /// Gets a value indicating whether the current instance represents an undefined value.
        /// </summary>
        /// <value>
        /// A value indicating whether the current instance represents an undefined value.
        /// </value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the project configuration mapper (see <see cref="Configurations"/>).
        /// </summary>
        /// <value>
        /// The project configuration mapper (see <see cref="Configurations"/>).
        /// </value>
        [Descriptor("ForProject")]
        public Snippet Project { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the solution configuration mapper (see <see cref="Configurations"/>).
        /// </summary>
        /// <value>
        /// The solution configuration mapper (see <see cref="Configurations"/>).
        /// </value>
        [Descriptor("ForSolution")]
        public Snippet Solution { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Performs the to fragments operation for the MSBuild build attribute.
        /// </summary>
        /// <returns>The immutable array x element.</returns>
        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            return ImmutableArray.Create(new XElement(
                nameof(Platform),
                Project.ToXmlAttribute(nameof(Project), include: _ => Project.IsSingleLine),
                Solution.ToXmlAttribute(nameof(Solution), include: _ => Solution.IsSingleLine)));
        }

        /// <summary>
        /// Returns the string representation of the Build.
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
        /// Validates the current object and returns a collection of validation results that describe any validation errors.
        /// </summary>
        /// <param name="validationContext">
        /// The context information about the object being validated. Provides services and information used during validation.
        /// </param>
        /// <returns>
        /// A collection of <see cref="ValidationResult"/> objects that describe any validation errors.
        /// The collection is empty if the object is valid or undefined.
        /// </returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Project), _ => !Project.IsMultiLine, Project)
                .And(nameof(Solution), _ => !Solution.IsMultiLine, Solution)
                .Results;
        }
    }
}