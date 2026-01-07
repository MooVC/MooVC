namespace MooVC.Syntax.CSharp.Operators
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.CSharp.Members;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Operators.Conversion_Resources;
    using Concept = MooVC.Syntax.CSharp.Concepts.Type;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# operator syntax conversion.
    /// </summary>
    [AutoInitiateWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Conversion
        : IValidatableObject
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
        /// Gets or sets the body on the Conversion.
        /// </summary>
        /// <value>The body.</value>
        public Snippet Body { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the direction on the Conversion.
        /// </summary>
        /// <value>The direction.</value>
        public Intent Direction { get; internal set; } = Intent.To;

        /// <summary>
        /// Gets a value indicating whether the Conversion is undefined.
        /// </summary>
        /// <value>A value indicating whether the Conversion is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the mode on the Conversion.
        /// </summary>
        /// <value>The mode.</value>
        public Type Mode { get; internal set; } = Type.Implicit;

        /// <summary>
        /// Gets or sets the scope on the Conversion.
        /// </summary>
        /// <value>The scope.</value>
        public Scope Scope { get; internal set; } = Scope.Public;

        /// <summary>
        /// Gets or sets the subject on the Conversion.
        /// </summary>
        /// <value>The subject.</value>
        [Descriptor("ForType")]
        public Symbol Subject { get; internal set; } = Symbol.Undefined;

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
            _ = Guard.Against.Null(type, message: ToSnippetTypeRequired.Format(nameof(Type), nameof(Conversion)));

            return ToSnippet(type.Name, options);
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

            if (Subject.IsUndefined)
            {
                results = results.Append(new ValidationResult(ValidateSubjectRequired.Format(nameof(Subject), nameof(Conversion)), new[] { nameof(Subject) }));
            }

            return validationContext
                .Include(nameof(Subject), results, Subject)
                .Results;
        }

        private void GetInputAndResult(Declaration declaration, out string input, out string result)
        {
            if (Direction == Intent.To)
            {
                input = declaration;
                result = Subject;
            }
            else
            {
                input = Subject;
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