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
    using static MooVC.Syntax.CSharp.Operators.Comparison_Resources;
    using Concept = MooVC.Syntax.CSharp.Concepts.Type;
    using Identifier = MooVC.Syntax.Elements.Identifier;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# operator syntax comparison.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Comparison
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Comparison Undefined = new Comparison();

        /// <summary>
        /// Initializes a new instance of the Comparison class.
        /// </summary>
        internal Comparison()
        {
        }

        /// <summary>
        /// Gets or sets the body on the Comparison.
        /// </summary>
        /// <value>The body.</value>
        public Snippet Body { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the Comparison is undefined.
        /// </summary>
        /// <value>A value indicating whether the Comparison is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the operator on the Comparison.
        /// </summary>
        /// <value>The operator.</value>
        public Type Operator { get; internal set; } = Type.Unspecified;

        /// <summary>
        /// Gets or sets the scope on the Comparison.
        /// </summary>
        /// <value>The scope.</value>
        public Scope Scope { get; internal set; } = Scope.Public;

        /// <summary>
        /// Returns the string representation of the Comparison.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Declaration.Unspecified, Snippet.Options.Default);
        }

        /// <summary>
        /// Returns the string representation of the Comparison.
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
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Body), nameof(Comparison)));
            _ = Guard.Against.Null(type, message: ToSnippetTypeRequired.Format(nameof(Type), nameof(Comparison)));

            return ToSnippet(type.Name, options);
        }

        /// <summary>
        /// Validates the Comparison.
        /// </summary>
        /// <remarks>Required members include: Body.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Body.IsEmpty)
            {
                yield return new ValidationResult(ValidateBodyRequired.Format(nameof(Body), nameof(Comparison)), new[] { nameof(Body) });
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
            var type = declaration.Name.ToSnippet(Identifier.Options.Pascal);
            var signature = Snippet.From(options, $"{scope} static bool operator {@operator}({type} left, {type} right)");

            return Body.Block(options, signature);
        }
    }
}