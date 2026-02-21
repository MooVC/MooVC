namespace MooVC.Syntax.CSharp.Operators
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.CSharp.Members;
    using MooVC.Syntax.Elements;
    using Valuify;
    using static MooVC.Syntax.CSharp.Operators.Binary_Resources;
    using Concept = MooVC.Syntax.CSharp.Concepts.Type;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# operator syntax binary.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Binary
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Binary Undefined = new Binary();

        /// <summary>
        /// Initializes a new instance of the Binary class.
        /// </summary>
        internal Binary()
        {
        }

        /// <summary>
        /// Gets the body on the Binary.
        /// </summary>
        /// <value>The body.</value>
        public Snippet Body { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the Binary is undefined.
        /// </summary>
        /// <value>A value indicating whether the Binary is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the operator on the Binary.
        /// </summary>
        /// <value>The operator.</value>
        public Type Operator { get; internal set; } = Type.Unspecified;

        /// <summary>
        /// Gets the scope on the Binary.
        /// </summary>
        /// <value>The scope.</value>
        public Scope Scope { get; internal set; } = Scope.Public;

        /// <summary>
        /// Returns the string representation of the Binary.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Declaration.Unspecified, Snippet.Options.Default);
        }

        /// <summary>
        /// Returns the string representation of the Binary.
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
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Body), nameof(Binary)));
            _ = Guard.Against.Null(type, message: ToSnippetTypeRequired.Format(nameof(Type), nameof(Binary)));

            return ToSnippet(type.Declaration, options);
        }

        /// <summary>
        /// Validates the Binary.
        /// </summary>
        /// <remarks>Required members include: Body.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Body.IsEmpty)
            {
                yield return new ValidationResult(ValidateBodyRequired.Format(nameof(Body), nameof(Binary)), new[] { nameof(Body) });
            }
        }

        private Snippet ToSnippet(Declaration declaration, Snippet.Options options)
        {
            if (IsUndefined || declaration.IsUnspecified)
            {
                return Snippet.Empty;
            }

            string @operator = Operator;
            string scope = Scope;
            var type = declaration.ToSnippet(options);
            var signature = Snippet.From(options, $"{scope} static {type} operator {@operator}({type} left, {type} right)");

            return Body.Block(options, signature);
        }
    }
}