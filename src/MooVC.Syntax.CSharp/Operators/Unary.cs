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
    using static MooVC.Syntax.CSharp.Operators.Unary_Resources;
    using Concept = MooVC.Syntax.CSharp.Concepts.Type;
    using Identifier = MooVC.Syntax.Elements.Identifier;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# operator syntax unary.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Unary
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Unary Undefined = new Unary();

        /// <summary>
        /// Initializes a new instance of the Unary class.
        /// </summary>
        internal Unary()
        {
        }

        /// <summary>
        /// Gets or sets the body on the Unary.
        /// </summary>
        /// <value>The body.</value>
        public Snippet Body { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the Unary is undefined.
        /// </summary>
        /// <value>A value indicating whether the Unary is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the operator on the Unary.
        /// </summary>
        /// <value>The operator.</value>
        public Type Operator { get; internal set; } = Type.Unspecified;

        /// <summary>
        /// Gets or sets the scope on the Unary.
        /// </summary>
        /// <value>The scope.</value>
        public Scope Scope { get; internal set; } = Scope.Public;

        /// <summary>
        /// Returns the string representation of the Unary.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Declaration.Unspecified, Snippet.Options.Default);
        }

        /// <summary>
        /// Returns the string representation of the Unary.
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
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Body), nameof(Unary)));
            _ = Guard.Against.Null(type, message: ToSnippetTypeRequired.Format(nameof(Type), nameof(Unary)));

            return ToSnippet(type.Name, options);
        }

        /// <summary>
        /// Validates the Unary.
        /// </summary>
        /// <remarks>Required members include: Body.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Body.IsEmpty)
            {
                yield return new ValidationResult(ValidateBodyRequired.Format(nameof(Body), nameof(Unary)), new[] { nameof(Body) });
            }
        }

        private Snippet ToSnippet(Declaration declaration, Snippet.Options options)
        {
            if (IsUndefined || declaration.IsUnspecified)
            {
                return Snippet.Empty;
            }

            string @operator = Operator;
            var name = declaration.Name.ToSnippet(Identifier.Options.Camel);
            string scope = Scope;
            var type = declaration.Name.ToSnippet(Identifier.Options.Pascal);
            var signature = Snippet.From(options, $"{scope} static {type} operator {@operator}({type} {name})");

            return Body.Block(options, signature);
        }
    }
}