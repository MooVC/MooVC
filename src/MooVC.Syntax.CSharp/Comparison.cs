namespace MooVC.Syntax.CSharp
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Comparison_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a comparison operator declaration model.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
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
        /// Gets the body on the Comparison.
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
        /// Gets the operator on the Comparison.
        /// </summary>
        /// <value>The operator.</value>
        public Types Operator { get; internal set; } = Types.Unspecified;

        /// <summary>
        /// Gets the scope on the Comparison.
        /// </summary>
        /// <value>The scope.</value>
        public Scopes Scope { get; internal set; } = Scopes.Public;

        /// <summary>
        /// Gets the subject symbol.
        /// </summary>
        /// <remarks>When set to Symbol.Undefined, the containing type is used.</remarks>
        [Descriptor("To")]
        public Symbol Subject { get; internal set; } = Symbol.Undefined;

        public static implicit operator Comparison((Snippet Body, Types Type) comparison)
        {
            Guard.Against.Conversion<(Snippet Body, Types Type), Comparison>(comparison);

            return new Comparison()
                .WithBody(comparison.Body)
                .WithOperator(comparison.Type);
        }

        /// <summary>
        /// Returns the string representation of the Comparison.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Declaration.Unspecified, Type.Options.Default);
        }

        /// <summary>
        /// Returns the string representation of the Comparison.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="type">The type.</param>
        /// <returns>The string representation.</returns>
        public string ToString(Type.Options options, Type type)
        {
            return ToSnippet(options, type);
        }

        /// <summary>
        /// Creates a snippet representation of the C# operator syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="type">The type.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Type.Options options, Type type)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(typeof(Comparison)));
            _ = Guard.Against.Null(type, message: ToSnippetTypeRequired.Format(nameof(Types), nameof(Comparison)));

            return ToSnippet(type.Declaration, options);
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

        private Snippet ToSnippet(Declaration declaration, Type.Options options)
        {
            if (IsUndefined || declaration.IsUnspecified)
            {
                return Snippet.Empty;
            }

            string @operator = Operator;
            string scope = Scope;
            var left = declaration.ToSnippet(options);
            Snippet right = left;

            if (!Subject.IsUndefined)
            {
                right = Subject.ToSnippet(options);
            }

            var signature = Snippet.From(options, $"{scope} static bool operator {@operator}({left} left, {right} right)");

            return Body.Block(options, signature);
        }

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Comparison)} {{ " +
                $"{nameof(Body)} = `{DebuggerDisplayFormatter.Format(Body)}`, " +
                $"{nameof(IsUndefined)} = `{DebuggerDisplayFormatter.Format(IsUndefined)}`, " +
                $"{nameof(Operator)} = `{DebuggerDisplayFormatter.Format(Operator)}`, " +
                $"{nameof(Scope)} = `{DebuggerDisplayFormatter.Format(Scope)}`, " +
                $"{nameof(Subject)} = `{DebuggerDisplayFormatter.Format(Subject)}` }}";
        }
    }
}