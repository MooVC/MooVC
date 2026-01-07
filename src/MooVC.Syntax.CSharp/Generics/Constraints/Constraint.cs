namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# generic syntax constraint.
    /// </summary>
    [AutoInitiateWith(nameof(Unspecified))]
    [Fluentify]
    [Valuify]
    public sealed partial class Constraint
        : IValidatableObject
    {
        /// <summary>
        /// Gets the unspecified instance.
        /// </summary>
        public static readonly Constraint Unspecified = new Constraint();
        private const string Separator = ", ";

        /// <summary>
        /// Initializes a new instance of the Constraint class.
        /// </summary>
        internal Constraint()
        {
        }

        /// <summary>
        /// Gets or sets the base on the Constraint.
        /// </summary>
        /// <value>The base.</value>
        public Base Base { get; internal set; } = Base.Unspecified;

        /// <summary>
        /// Gets or sets the interfaces on the Constraint.
        /// </summary>
        /// <value>The interfaces.</value>
        public ImmutableArray<Interface> Interfaces { get; internal set; } = ImmutableArray<Interface>.Empty;

        /// <summary>
        /// Gets a value indicating whether the Constraint is unspecified.
        /// </summary>
        /// <value>A value indicating whether the Constraint is unspecified.</value>
        [Ignore]
        public bool IsUnspecified => this == Unspecified;

        /// <summary>
        /// Gets or sets the nature on the Constraint.
        /// </summary>
        /// <value>The nature.</value>
        public Nature Nature { get; internal set; } = Nature.Unspecified;

        /// <summary>
        /// Gets or sets the new on the Constraint.
        /// </summary>
        /// <value>The new.</value>
        public New New { get; internal set; } = New.NotRequired;

        /// <summary>
        /// Defines the string operator for the Constraint.
        /// </summary>
        /// <param name="constraint">The constraint.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Constraint constraint)
        {
            Guard.Against.Conversion<Constraint, string>(constraint);

            return constraint.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Constraint.
        /// </summary>
        /// <param name="constraint">The constraint.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Constraint constraint)
        {
            Guard.Against.Conversion<Constraint, Snippet>(constraint);

            return Snippet.From(constraint);
        }

        /// <summary>
        /// Returns the string representation of the Constraint.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            if (IsUnspecified)
            {
                return string.Empty;
            }

            string @base = Base;
            string nature = Nature;
            string @new = New;

            IEnumerable<string> interfaces = Interfaces.IsDefaultOrEmpty
                ? Enumerable.Empty<string>()
                : Interfaces.Select(@interface => @interface.ToString());

            string[] constraints = interfaces
                .Prepend(@base)
                .Prepend(nature)
                .Append(@new)
                .ToArray();

            return $"where {Separator.Combine(constraints)}";
        }

        /// <summary>
        /// Validates the Constraint.
        /// </summary>
        /// <remarks>Required members include: Base, Interfaces.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnspecified)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Base), Base)
                .AndIf(!Interfaces.IsDefaultOrEmpty, nameof(Interfaces), @interface => !@interface.IsUndefined, Interfaces)
                .Results;
        }
    }
}