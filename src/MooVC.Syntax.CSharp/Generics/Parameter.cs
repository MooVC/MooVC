namespace MooVC.Syntax.CSharp.Generics
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Generics.Constraints;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# generic syntax parameter.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Parameter
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Parameter Undefined = new Parameter();
        /// <summary>
        /// Gets the names on the Parameter.
        /// </summary>
        /// <value>The names.</value>
        public static readonly Func<Parameter, string> Names = parameter => parameter.Name;

        /// <summary>
        /// Initializes a new instance of the Parameter class.
        /// </summary>
        internal Parameter()
        {
        }

        /// <summary>
        /// Gets or sets the name on the Parameter.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        /// <summary>
        /// Gets or sets the constraints on the Parameter.
        /// </summary>
        /// <value>The constraints.</value>
        public ImmutableArray<Constraint> Constraints { get; internal set; } = ImmutableArray<Constraint>.Empty;

        /// <summary>
        /// Gets a value indicating whether the Parameter is undefined.
        /// </summary>
        /// <value>A value indicating whether the Parameter is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Defines the string operator for the Parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Parameter parameter)
        {
            Guard.Against.Conversion<Parameter, string>(parameter);

            return parameter.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Parameter parameter)
        {
            Guard.Against.Conversion<Parameter, Snippet>(parameter);

            return Snippet.From(parameter);
        }

        /// <summary>
        /// Returns the string representation of the Parameter.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Validates the Parameter.
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