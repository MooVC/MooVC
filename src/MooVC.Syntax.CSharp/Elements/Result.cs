namespace MooVC.Syntax.CSharp.Elements
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Elements.Result_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# member return signature, including modality, modifiers, and return type.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Result
        : IValidatableObject
    {
        /// <summary>
        /// Gets a default Task-based return signature.
        /// </summary>
        public static readonly Result Task = new Result { Type = typeof(Task) };
        /// <summary>
        /// Gets an unspecified return signature.
        /// </summary>
        public static readonly Result Undefined = new Result();
        /// <summary>
        /// Gets a synchronous void return signature.
        /// </summary>
        public static readonly Result Void = new Result { Mode = Modality.Synchronous };

        private const string Separator = " ";

        /// <summary>
        /// Initializes a new instance of the Result class.
        /// </summary>
        internal Result()
        {
        }

        /// <summary>
        /// Gets a value indicating whether the return signature is Task-based.
        /// </summary>
        /// <value>A value indicating whether the return signature is Task-based.</value>
        [Ignore]
        public bool IsTask => this == Task;

        /// <summary>
        /// Gets a value indicating whether the return signature is unspecified.
        /// </summary>
        /// <value>A value indicating whether the return signature is unspecified.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets a value indicating whether the return signature is void.
        /// </summary>
        /// <value>A value indicating whether the return signature is void.</value>
        [Ignore]
        public bool IsVoid => this == Void;

        /// <summary>
        /// Gets or sets the return modifier (for example, ref or ref readonly).
        /// </summary>
        /// <value>The return modifier.</value>
        public Kind Modifier { get; internal set; } = Kind.None;

        /// <summary>
        /// Gets or sets the async modality for the return signature.
        /// </summary>
        /// <value>The async modality.</value>
        public Modality Mode { get; internal set; } = Modality.Asynchronous;

        /// <summary>
        /// Gets or sets the return type symbol.
        /// </summary>
        /// <value>The return type symbol.</value>
        [Descriptor("OfType")]
        public Symbol Type { get; internal set; } = Symbol.Undefined;

        /// <summary>
        /// Creates a return signature from the specified runtime type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The return signature.</returns>
        public static implicit operator Result(Type type)
        {
            Guard.Against.Conversion<Type, Result>(type);

            return new Result { Type = type };
        }

        /// <summary>
        /// Converts the return signature to its C# source representation.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>The C# return signature text.</returns>
        public static implicit operator string(Result result)
        {
            Guard.Against.Conversion<Result, string>(result);

            return result.ToString();
        }

        /// <summary>
        /// Converts the return signature to a snippet.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>The return signature snippet.</returns>
        public static implicit operator Snippet(Result result)
        {
            Guard.Against.Conversion<Result, Snippet>(result);

            return Snippet.From(result);
        }

        /// <summary>
        /// Returns the C# return signature text.
        /// </summary>
        /// <returns>The return signature text.</returns>
        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            string modifier = Modifier;
            string mode = Mode;
            string type = Type;

            return Separator.Combine(mode, modifier, type);
        }

        /// <summary>
        /// Creates a snippet representing the return type portion of a signature.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The return signature snippet.</returns>
        public Snippet ToSnippet(Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Result)));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            return Snippet.From(options, ToString());
        }

        /// <summary>
        /// Validates the Result.
        /// </summary>
        /// <remarks>Required members include: Type.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Modifier == Kind.None && Type == Symbol.Undefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Type), _ => !Type.IsUndefined, Type)
                .Results;
        }
    }
}
