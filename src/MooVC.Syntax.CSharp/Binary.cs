namespace MooVC.Syntax.CSharp
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Binary_Resources;
    using Concept = MooVC.Syntax.CSharp.Type;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a binary operator declaration model.
    /// </summary>
    /// <remarks>
    /// Implicit conversions create an instance from a <c>(Snippet Body, Types Type)</c> tuple. The body supplies the
    /// operator implementation, and the type selects the C# binary operator token to declare.
    /// </remarks>
    [AutoInitializeWith(nameof(Undefined))]
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
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
        /// Gets the left operand, which defaults to the containing type and the name <c>left</c>.
        /// </summary>
        public Parameter Left { get; internal set; } = Parameter.Undefined;

        /// <summary>
        /// Gets the operator on the Binary.
        /// </summary>
        /// <value>The operator.</value>
        public Types Operator { get; internal set; } = Types.Unspecified;

        /// <summary>
        /// Gets the result type, which defaults to the containing type.
        /// </summary>
        public Symbol Result { get; internal set; } = Symbol.Undefined;

        /// <summary>
        /// Gets the right operand, which defaults to the containing type and the name <c>right</c>.
        /// </summary>
        public Parameter Right { get; internal set; } = Parameter.Undefined;

        /// <summary>
        /// Gets the scope on the Binary.
        /// </summary>
        /// <value>The scope.</value>
        public Scopes Scope { get; internal set; } = Scopes.Public;

        public static implicit operator Binary((Snippet Body, Types Type) binary)
        {
            Guard.Against.Conversion<(Snippet Body, Types Type), Binary>(binary);

            return new Binary()
                .WithBody(binary.Body)
                .WithOperator(binary.Type);
        }

        /// <summary>
        /// Returns the string representation of the Binary.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Options.Default);
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
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(typeof(Binary)));
            _ = Guard.Against.Null(type, message: ToSnippetTypeRequired.Format(nameof(Types), nameof(Binary)));

            return Render(type.Declaration, Type.Options.Default.WithSnippets(options));
        }

        /// <summary>
        /// Renders an operator whose operand and result types are specified explicitly.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet, or an empty snippet when a type is missing.</returns>
        public Snippet ToSnippet(Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(typeof(Binary)));

            return Render(Declaration.Unspecified, options);
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

        internal Snippet ToSnippet(Type.Options options, Concept type)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(typeof(Binary)));
            _ = Guard.Against.Null(type, message: ToSnippetTypeRequired.Format(nameof(Types), nameof(Binary)));

            return Render(type.Declaration, options);
        }

        private Snippet Render(Declaration declaration, Type.Options options)
        {
            if (IsUndefined || (declaration.IsUnspecified && (Left.Type.IsUndefined || Right.Type.IsUndefined || Result.IsUndefined)))
            {
                return Snippet.Empty;
            }

            Parameter.Options parameters = (Method.Options)options;
            Snippet type = declaration.ToSnippet(options);
            Snippet left = Left.ToSnippet(parameters, type, "left");
            Snippet result = Result.IsUndefined ? type : Result.ToSnippet(options);
            Snippet right = Right.ToSnippet(parameters, type, "right");
            string @operator = Operator;
            string scope = Scope;
            var signature = Snippet.From(options, $"{scope} static {result} operator {@operator}({left}, {right})");

            return Body.Block(options, signature);
        }

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Binary)} {{ " +
                $"{nameof(Body)} = `{DebuggerDisplayFormatter.Format(Body)}`, " +
                $"{nameof(IsUndefined)} = `{DebuggerDisplayFormatter.Format(IsUndefined)}`, " +
                $"{nameof(Left)} = `{DebuggerDisplayFormatter.Format(Left)}`, " +
                $"{nameof(Operator)} = `{DebuggerDisplayFormatter.Format(Operator)}`, " +
                $"{nameof(Result)} = `{DebuggerDisplayFormatter.Format(Result)}`, " +
                $"{nameof(Right)} = `{DebuggerDisplayFormatter.Format(Right)}`, " +
                $"{nameof(Scope)} = `{DebuggerDisplayFormatter.Format(Scope)}` }}";
        }
    }
}