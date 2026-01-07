namespace MooVC.Syntax.CSharp.Elements
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Elements.Argument_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# argument expression, including optional name and modifier.
    /// </summary>
    [AutoInitiateWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Argument
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined argument instance used as a placeholder.
        /// </summary>
        public static readonly Argument Undefined = new Argument();

        /// <summary>
        /// Initializes a new instance of the Argument class.
        /// </summary>
        internal Argument()
        {
        }

        /// <summary>
        /// Gets a value indicating whether this argument is the undefined sentinel.
        /// </summary>
        /// <value>A value indicating whether this instance is the undefined sentinel.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the argument modifier (in, ref, out, or none).
        /// </summary>
        /// <value>The modifier that affects how the argument is passed.</value>
        public Mode Modifier { get; internal set; } = Mode.None;

        /// <summary>
        /// Gets the argument name used for named arguments.
        /// </summary>
        /// <value>The argument name.</value>
        [Descriptor("Named")]
        public Variable Name { get; internal set; } = Variable.Unnamed;

        /// <summary>
        /// Gets the argument expression value.
        /// </summary>
        /// <value>The expression snippet supplied for the argument.</value>
        public Snippet Value { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Converts the argument expression to its C# source representation.
        /// </summary>
        /// <param name="argument">The argument to render.</param>
        /// <returns>The rendered argument text.</returns>
        public static implicit operator string(Argument argument)
        {
            Guard.Against.Conversion<Argument, string>(argument);

            return argument.ToString();
        }

        /// <summary>
        /// Converts the argument expression to a snippet for composition.
        /// </summary>
        /// <param name="argument">The argument to convert.</param>
        /// <returns>The snippet representing the argument.</returns>
        public static implicit operator Snippet(Argument argument)
        {
            Guard.Against.Conversion<Argument, Snippet>(argument);

            return argument.ToSnippet(Options.Call);
        }

        /// <summary>
        /// Returns the C# source representation of the argument expression.
        /// </summary>
        /// <returns>The rendered argument text.</returns>
        public override string ToString()
        {
            return ToSnippet(Options.Call);
        }

        /// <summary>
        /// Creates a snippet representation of the argument expression.
        /// </summary>
        /// <param name="options">The formatting options for the argument.</param>
        /// <returns>The argument snippet.</returns>
        public Snippet ToSnippet(Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Options), nameof(Argument), nameof(Name), Name));

            if (IsUndefined)
            {
                return string.Empty;
            }

            if (Name.IsUnnamed)
            {
                return $"{Value}";
            }

            var name = Name.ToSnippet(options.Naming);
            string value = Value.ToString();

            if (!Modifier.IsNone)
            {
                value = $"{Modifier} {value}";
            }

            return Snippet.From(options.Snippet, string.Format(options.Formatter, name, value));
        }

        /// <summary>
        /// Validates the argument expression before rendering.
        /// </summary>
        /// <remarks>
        /// Ensures a value is present and is a single-line expression, and validates named arguments when a name is supplied.
        /// </remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (!Value.IsSingleLine)
            {
                string message = Value.IsEmpty
                    ? ValidateValueRequired
                    : ValidateValueInvalid;

                results = results.Append(new ValidationResult(
                    message.Format(nameof(Value), nameof(Argument)),
                    new[] { nameof(Value) }));
            }

            return validationContext
                .Include(nameof(Name), _ => !Name.IsUnnamed, results, Name)
                .Results;
        }
    }
}