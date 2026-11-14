namespace MooVC.Syntax.CSharp
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Formatting;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Unary_Resources;
    using Concept = MooVC.Syntax.CSharp.Type;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a unary operator declaration model.
    /// </summary>
    /// <remarks>
    /// Implicit conversions create an instance from a <c>(Snippet Body, Types Type)</c> tuple. The body supplies the
    /// operator implementation, and the type selects the C# unary operator token to declare.
    /// </remarks>
    [AutoInitializeWith(nameof(Undefined))]
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
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
        /// Gets the body on the Unary.
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
        /// Gets the operand, which defaults to the containing type with a camel-cased name.
        /// </summary>
        public Parameter Operand { get; internal set; } = Parameter.Undefined;

        /// <summary>
        /// Gets the operator on the Unary.
        /// </summary>
        /// <value>The operator.</value>
        public Types Operator { get; internal set; } = Types.Unspecified;

        /// <summary>
        /// Gets the result type, which defaults to the containing type.
        /// </summary>
        public Symbol Result { get; internal set; } = Symbol.Undefined;

        /// <summary>
        /// Gets the scope on the Unary.
        /// </summary>
        /// <value>The scope.</value>
        public Scopes Scope { get; internal set; } = Scopes.Public;

        public static implicit operator Unary((Snippet Body, Types Type) unary)
        {
            Guard.Against.Conversion<(Snippet Body, Types Type), Unary>(unary);

            return new Unary()
                .WithBody(unary.Body)
                .WithOperator(unary.Type);
        }

        /// <summary>
        /// Returns the string representation of the Unary.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Options.Default);
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
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(typeof(Unary)));
            _ = Guard.Against.Null(type, message: ToSnippetTypeRequired.Format(typeof(Types), typeof(Unary)));

            return Render(type.Declaration, Type.Options.Default.WithSnippets(options));
        }

        /// <summary>
        /// Renders an operator whose operand and result types are specified explicitly.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet, or an empty snippet when a type is missing.</returns>
        public Snippet ToSnippet(Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(typeof(Unary)));

            return Render(Declaration.Unspecified, options);
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
                yield return new ValidationResult(ValidateBodyRequired.Format(nameof(Body), typeof(Unary)), new[] { nameof(Body) });
            }
        }

        internal Snippet ToSnippet(Type.Options options, Concept type)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(typeof(Unary)));
            _ = Guard.Against.Null(type, message: ToSnippetTypeRequired.Format(typeof(Types), typeof(Unary)));

            return Render(type.Declaration, options);
        }

        private Snippet Render(Declaration declaration, Type.Options options)
        {
            if (IsUndefined || (declaration.IsUnspecified && (Operand.Type.IsUndefined || Result.IsUndefined)))
            {
                return Snippet.Empty;
            }

            string @operator = Operator;
            var name = declaration.IsUnspecified ? "value" : declaration.Name.ToString().ToCamelCase();
            string scope = Scope;
            Snippet type = declaration.ToSnippet(options);
            Snippet operand = Operand.ToSnippet((Method.Options)options, type, name);
            Snippet result = Result.IsUndefined ? type : Result.ToSnippet(options);
            var signature = Snippet.From(options, $"{scope} static {result} operator {@operator}({operand})");

            return Body.Block(options, signature);
        }

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Unary)} {{ " +
                $"{nameof(Body)} = `{DebuggerDisplayFormatter.Format(Body)}`, " +
                $"{nameof(IsUndefined)} = `{DebuggerDisplayFormatter.Format(IsUndefined)}`, " +
                $"{nameof(Operand)} = `{DebuggerDisplayFormatter.Format(Operand)}`, " +
                $"{nameof(Operator)} = `{DebuggerDisplayFormatter.Format(Operator)}`, " +
                $"{nameof(Result)} = `{DebuggerDisplayFormatter.Format(Result)}`, " +
                $"{nameof(Scope)} = `{DebuggerDisplayFormatter.Format(Scope)}` }}";
        }
    }
}