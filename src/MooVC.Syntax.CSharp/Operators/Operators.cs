namespace MooVC.Syntax.CSharp.Operators
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Concepts;
    using MooVC.Syntax.CSharp.Concepts;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Operators.Operators_Resources;

    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# operator syntax operators.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Operators
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Operators Undefined = new Operators();

        /// <summary>
        /// Initializes a new instance of the Operators class.
        /// </summary>
        internal Operators()
        {
        }

        /// <summary>
        /// Gets the binaries on the Operators.
        /// </summary>
        /// <value>The binaries.</value>
        public ImmutableArray<Binary> Binaries { get; internal set; } = ImmutableArray<Binary>.Empty;

        /// <summary>
        /// Gets the comparisons on the Operators.
        /// </summary>
        /// <value>The comparisons.</value>
        public ImmutableArray<Comparison> Comparisons { get; internal set; } = ImmutableArray<Comparison>.Empty;

        /// <summary>
        /// Gets the conversions on the Operators.
        /// </summary>
        /// <value>The conversions.</value>
        public ImmutableArray<Conversion> Conversions { get; internal set; } = ImmutableArray<Conversion>.Empty;

        /// <summary>
        /// Gets a value indicating whether the Operators is undefined.
        /// </summary>
        /// <value>A value indicating whether the Operators is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the unaries on the Operators.
        /// </summary>
        /// <value>The unaries.</value>
        public ImmutableArray<Unary> Unaries { get; internal set; } = ImmutableArray<Unary>.Empty;

        /// <summary>
        /// Returns the string representation of the Operators.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Snippet.Options.Default, Class.Undefined);
        }

        /// <summary>
        /// Creates a snippet representation of the C# operator syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="type">The type.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Snippet.Options options, Type type)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Operators)));
            _ = Guard.Against.Null(type, message: ToStringTypeRequired.Format(nameof(Construct), nameof(Binary)));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            var binaries = Binaries.ToSnippet(options, type);
            var comparisons = Comparisons.ToSnippet(options, type);
            var conversions = Conversions.ToSnippet(options, type);
            var unaries = Unaries.ToSnippet(options, type);

            return Snippet.Blank.Combine(options, binaries, comparisons, conversions, unaries);
        }

        /// <summary>
        /// Validates the Operators.
        /// </summary>
        /// <remarks>Required members include: Binaries, Comparisons, Conversions, Unaries.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .IncludeIf(!Binaries.IsDefaultOrEmpty, nameof(Binaries), Binaries)
                .AndIf(!Comparisons.IsDefaultOrEmpty, nameof(Comparisons), Comparisons)
                .AndIf(!Conversions.IsDefaultOrEmpty, nameof(Conversions), Conversions)
                .AndIf(!Unaries.IsDefaultOrEmpty, nameof(Unaries), Unaries)
                .Results;
        }
    }
}