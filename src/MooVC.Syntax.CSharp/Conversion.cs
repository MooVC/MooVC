namespace MooVC.Syntax.CSharp
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Conversion_Resources;
    using Concept = MooVC.Syntax.CSharp.Type;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a user-defined conversion operator declaration model.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Conversion
        : IEnumerable<Qualifier>,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Conversion Undefined = new Conversion();

        /// <summary>
        /// Initializes a new instance of the Conversion class.
        /// </summary>
        internal Conversion()
        {
        }

        /// <summary>
        /// Gets the body on the Conversion.
        /// </summary>
        /// <value>The body.</value>
        public Snippet Body { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the direction on the Conversion.
        /// </summary>
        /// <value>The direction.</value>
        public Intents Direction { get; internal set; } = Intents.To;

        /// <summary>
        /// Gets a value indicating whether the Conversion is undefined.
        /// </summary>
        /// <value>A value indicating whether the Conversion is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the mode on the Conversion.
        /// </summary>
        /// <value>The mode.</value>
        public Types Mode { get; internal set; } = Types.Implicit;

        /// <summary>
        /// Gets the scope on the Conversion.
        /// </summary>
        /// <value>The scope.</value>
        public Scopes Scope { get; internal set; } = Scopes.Public;

        /// <summary>
        /// Gets the target for the Conversion.
        /// </summary>
        /// <value>The target for conversion.</value>
        [Descriptor("ForType")]
        public Symbol Target { get; internal set; } = Symbol.Undefined;

        /// <summary>
        /// Returns an enumerator that iterates through the collection of symbols.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection of symbols.</returns>
        public IEnumerator<Qualifier> GetEnumerator()
        {
            return Target.GetEnumerator();
        }

        /// <summary>
        /// Returns the string representation of the Conversion.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Declaration.Unspecified, Snippet.Options.Default);
        }

        /// <summary>
        /// Returns the string representation of the Conversion.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="type">The type.</param>
        /// <returns>The string representation.</returns>
        public string ToString(Snippet.Options options, Concept type)
        {
            return ToSnippet(options, type);
        }

        /// <summary>
        /// Creates a snippet representation of the C# operator syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="type">The type.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Snippet.Options options, Concept type)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Body), nameof(Conversion)));
            _ = Guard.Against.Null(type, message: ToSnippetTypeRequired.Format(nameof(Types), nameof(Conversion)));

            return ToSnippet(type.Declaration, options);
        }

        /// <summary>
        /// Validates the Conversion.
        /// </summary>
        /// <remarks>Required members include: Body, Subject.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (Body.IsEmpty)
            {
                results = results.Append(new ValidationResult(ValidateBodyRequired.Format(nameof(Body), nameof(Conversion)), new[] { nameof(Body) }));
            }

            if (Target.IsUndefined)
            {
                results = results.Append(new ValidationResult(
                    ValidateSubjectRequired.Format(nameof(Target), nameof(Conversion)),
                    new[] { nameof(Target) }));
            }

            return validationContext
                .Include(nameof(Target), results, Target)
                .Results;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <remarks>This method is an explicit interface implementation for <see
        /// cref="IEnumerable.GetEnumerator"/>. Use the generic <see cref="GetEnumerator"/> method for type-safe
        /// enumeration.</remarks>
        /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void GetInputAndResult(Declaration declaration, out string input, out string result)
        {
            if (Direction == Intents.To)
            {
                input = declaration;
                result = Target;
            }
            else
            {
                input = Target;
                result = declaration;
            }
        }

        private Snippet ToSnippet(Declaration declaration, Snippet.Options options)
        {
            if (IsUndefined || declaration.IsUnspecified)
            {
                return Snippet.Empty;
            }

            GetInputAndResult(declaration, out string input, out string result);

            string mode = Mode;
            string scope = Scope;
            var signature = Snippet.From($"{scope} static {mode} operator {result}({input} subject)");

            return Body.Block(options, signature);
        }
    }
}