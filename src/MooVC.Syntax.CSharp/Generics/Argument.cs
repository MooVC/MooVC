namespace MooVC.Syntax.CSharp.Generics
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# generic syntax argument.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Argument
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Argument Undefined = new Argument();

        /// <summary>
        /// Gets the names on the Argument.
        /// </summary>
        /// <value>The names.</value>
        public static readonly Func<Argument, string> Names = argument => argument.Name;

        /// <summary>
        /// Initializes a new instance of the Argument class.
        /// </summary>
        internal Argument()
        {
        }

        /// <summary>
        /// Gets the name on the Argument.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Name Name { get; internal set; } = Name.Unnamed;

        /// <summary>
        /// Gets the constraints on the Argument.
        /// </summary>
        /// <value>The constraints.</value>
        public ImmutableArray<Constraint> Constraints { get; internal set; } = ImmutableArray<Constraint>.Empty;

        /// <summary>
        /// Gets a value indicating whether the Argument is undefined.
        /// </summary>
        /// <value>A value indicating whether the Argument is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Defines the string operator for the Argument.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Argument argument)
        {
            Guard.Against.Conversion<Argument, string>(argument);

            return argument.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Argument.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Argument argument)
        {
            Guard.Against.Conversion<Argument, Snippet>(argument);

            return Snippet.From(argument);
        }

        /// <summary>
        /// Returns the string representation of the Argument.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Validates the Argument.
        /// </summary>
        /// <remarks>Required members include: Constraints, Name.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .IncludeIf(!Constraints.IsDefaultOrEmpty, nameof(Constraints), constraint => !constraint.IsUnspecified, Constraints)
                .And(nameof(Name), _ => !Name.IsUnnamed, Name)
                .Results;
        }
    }
}