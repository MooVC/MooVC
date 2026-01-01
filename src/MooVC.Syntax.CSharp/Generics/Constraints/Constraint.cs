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
    /// Represents a c# generic syntax constraint.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Constraint
        : IValidatableObject
    {
        /// <summary>
        /// Gets the unspecified on the Constraint.
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
        public Base Base { get; internal set; } = Base.Unspecified;

        /// <summary>
        /// Gets or sets the interfaces on the Constraint.
        /// </summary>
        public ImmutableArray<Interface> Interfaces { get; internal set; } = ImmutableArray<Interface>.Empty;

        /// <summary>
        /// Gets a value indicating whether the Constraint is unspecified.
        /// </summary>
        [Ignore]
        public bool IsUnspecified => this == Unspecified;

        /// <summary>
        /// Gets or sets the nature on the Constraint.
        /// </summary>
        public Nature Nature { get; internal set; } = Nature.Unspecified;

        /// <summary>
        /// Gets or sets the new on the Constraint.
        /// </summary>
        public New New { get; internal set; } = New.NotRequired;

        /// <summary>
        /// Defines the string operator for the Constraint.
        /// </summary>
        public static implicit operator string(Constraint constraint)
        {
            Guard.Against.Conversion<Constraint, string>(constraint);

            return constraint.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Constraint.
        /// </summary>
        public static implicit operator Snippet(Constraint constraint)
        {
            Guard.Against.Conversion<Constraint, Snippet>(constraint);

            return Snippet.From(constraint);
        }

        /// <summary>
        /// Returns the string representation of the Constraint.
        /// </summary>
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
        /// Validates the Constraint and returns validation results.
        /// </summary>
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