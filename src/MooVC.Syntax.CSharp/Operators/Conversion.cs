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
    /// Represents a c# operator syntax conversion.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Conversion
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the Conversion.
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
        public Snippet Body { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the direction on the Conversion.
        /// </summary>
        public Intent Direction { get; internal set; } = Intent.To;

        /// <summary>
        /// Gets a value indicating whether the Conversion is undefined.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the mode on the Conversion.
        /// </summary>
        public Type Mode { get; internal set; } = Type.Implicit;

        /// <summary>
        /// Gets or sets the scope on the Conversion.
        /// </summary>
        public Scope Scope { get; internal set; } = Scope.Public;

        /// <summary>
        /// Gets or sets the subject on the Conversion.
        /// </summary>
        [Descriptor("ForType")]
        public Symbol Subject { get; internal set; } = Symbol.Undefined;

        /// <summary>
        /// Returns the string representation of the Conversion.
        /// </summary>
        public override string ToString()
        {
            return ToSnippet(Declaration.Unspecified, Snippet.Options.Default);
        }

        /// <summary>
        /// Returns the string representation of the Conversion.
        /// </summary>
        public string ToString(Snippet.Options options, Concept type)
        {
            return ToSnippet(options, type);
        }

        /// <summary>
        /// Creates a code snippet representation of the c# operator syntax.
        /// </summary>
        public Snippet ToSnippet(Snippet.Options options, Concept type)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Body), nameof(Conversion)));
            _ = Guard.Against.Null(type, message: ToSnippetTypeRequired.Format(nameof(Type), nameof(Conversion)));

            return ToSnippet(type.Name, options);
        }

        /// <summary>
        /// Validates the Conversion and returns validation results.
        /// </summary>
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