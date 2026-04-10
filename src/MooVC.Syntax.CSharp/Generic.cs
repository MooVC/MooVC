namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections;
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
    /// Represents a C# generic syntax generic.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Generic
        : IEnumerable<Qualifier>,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Generic Undefined = new Generic();

        /// <summary>
        /// Gets the names on the Generic.
        /// </summary>
        /// <value>The names.</value>
        public static readonly Func<Generic, string> Names = generic => generic.Name;

        /// <summary>
        /// Initializes a new instance of the Generic class.
        /// </summary>
        internal Generic()
        {
        }

        /// <summary>
        /// Gets the name on the Generic.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Name Name { get; internal set; } = Name.Unnamed;

        /// <summary>
        /// Gets the constraints on the Generic.
        /// </summary>
        /// <value>The constraints.</value>
        public ImmutableArray<Constraint> Constraints { get; internal set; } = ImmutableArray<Constraint>.Empty;

        /// <summary>
        /// Gets a value indicating whether the Generic is undefined.
        /// </summary>
        /// <value>A value indicating whether the Generic is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Defines the string operator for the Generic.
        /// </summary>
        /// <param name="generic">The generic.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Generic generic)
        {
            Guard.Against.Conversion<Generic, string>(generic);

            return generic.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Generic.
        /// </summary>
        /// <param name="generic">The generic.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Generic generic)
        {
            Guard.Against.Conversion<Generic, Snippet>(generic);

            return Snippet.From(generic);
        }

        public static implicit operator Generic(Name name)
        {
            Guard.Against.Conversion<Name, Generic>(name);

            return new Generic()
                .Named(name);
        }

        /// <summary>
        /// Returns an enumerator that iterates through all symbols contained in the constraints.
        /// </summary>
        /// <remarks>
        /// The enumerator iterates over all symbols from each constraint in the order they appear.
        /// The collection should not be modified during enumeration.
        /// </remarks>
        /// <returns>An enumerator that can be used to iterate through the collection of symbols.</returns>
        public IEnumerator<Qualifier> GetEnumerator()
        {
            foreach (Qualifier qualifier in Constraints.SelectMany(constraint => constraint))
            {
                yield return qualifier;
            }
        }

        /// <summary>
        /// Returns the string representation of the Generic.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Validates the Generic.
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

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}