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
    /// Represents a c# generic syntax parameter.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Parameter
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the Parameter.
        /// </summary>
        public static readonly Parameter Undefined = new Parameter();
        /// <summary>
        /// Gets the names on the Parameter.
        /// </summary>
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
        [Descriptor("Named")]
        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        /// <summary>
        /// Gets or sets the constraints on the Parameter.
        /// </summary>
        public ImmutableArray<Constraint> Constraints { get; internal set; } = ImmutableArray<Constraint>.Empty;

        /// <summary>
        /// Gets a value indicating whether the Parameter is undefined.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Defines the string operator for the Parameter.
        /// </summary>
        public static implicit operator string(Parameter parameter)
        {
            Guard.Against.Conversion<Parameter, string>(parameter);

            return parameter.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Parameter.
        /// </summary>
        public static implicit operator Snippet(Parameter parameter)
        {
            Guard.Against.Conversion<Parameter, Snippet>(parameter);

            return Snippet.From(parameter);
        }

        /// <summary>
        /// Returns the string representation of the Parameter.
        /// </summary>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Validates the Parameter and returns validation results.
        /// </summary>
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