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
    /// Represents the return signature of a C# member, including modifiers, modality, and return type.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Result
        : IValidatableObject
    {
        /// <summary>
        /// Gets the default asynchronous result (Task).
        /// </summary>
        public static readonly Result Task = new Result { Type = typeof(Task) };
        /// <summary>
        /// Gets the undefined return signature.
        /// </summary>
        public static readonly Result Undefined = new Result();
        /// <summary>
        /// Gets the synchronous void return signature.
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
        /// Gets a value indicating whether the return type is Task.
        /// </summary>
        [Ignore]
        public bool IsTask => this == Task;

        /// <summary>
        /// Gets a value indicating whether the return signature is unspecified.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets a value indicating whether the return signature is void.
        /// </summary>
        [Ignore]
        public bool IsVoid => this == Void;

        /// <summary>
        /// Gets or sets the return modifier (for example, ref or ref readonly).
        /// </summary>
        public Kind Modifier { get; internal set; } = Kind.None;

        /// <summary>
        /// Gets or sets the modality of the return (synchronous, Task, or ValueTask).
        /// </summary>
        public Modality Mode { get; internal set; } = Modality.Asynchronous;

        /// <summary>
        /// Gets or sets the return type symbol.
        /// </summary>
        [Descriptor("OfType")]
        public Symbol Type { get; internal set; } = Symbol.Undefined;

        /// <summary>
        /// Converts a runtime type into a result signature.
        /// </summary>
        public static implicit operator Result(Type type)
        {
            Guard.Against.Conversion<Type, Result>(type);

            return new Result { Type = type };
        }

        /// <summary>
        /// Converts the result signature into its C# source representation.
        /// </summary>
        public static implicit operator string(Result result)
        {
            Guard.Against.Conversion<Result, string>(result);

            return result.ToString();
        }

        /// <summary>
        /// Converts the result signature into a snippet.
        /// </summary>
        public static implicit operator Snippet(Result result)
        {
            Guard.Against.Conversion<Result, Snippet>(result);

            return Snippet.From(result);
        }

        /// <summary>
        /// Returns the string representation of the Result.
        /// </summary>
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
        /// Creates a snippet representing the return type portion of a member signature.
        /// </summary>
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
        /// Validates the Result and returns validation results.
        /// </summary>
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
