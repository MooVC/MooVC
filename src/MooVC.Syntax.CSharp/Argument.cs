namespace MooVC.Syntax.CSharp
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Argument_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# argument expression, including optional name and modifier.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
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
        public Modes Modifier { get; internal set; } = Modes.None;

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
        /// Defines an implicit conversion from <see cref="Argument" /> to <see cref="string" />.
        /// </summary>
        /// <param name="argument">The <see cref="Argument" /> value to convert.</param>
        /// <returns>The converted <see cref="string" /> value.</returns>
        public static implicit operator string(Argument argument)
        {
            Guard.Against.Conversion<Argument, string>(argument);

            return argument.ToString();
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Argument" /> to <see cref="Snippet" />.
        /// </summary>
        /// <param name="argument">The <see cref="Argument" /> value to convert.</param>
        /// <returns>The converted <see cref="Snippet" /> value.</returns>
        public static implicit operator Snippet(Argument argument)
        {
            Guard.Against.Conversion<Argument, Snippet>(argument);

            return argument.ToSnippet(Options.Call);
        }

        /// <summary>
        /// Defines an implicit conversion to <see cref="Argument" />.
        /// </summary>
        /// <param name="argument">The value to convert.</param>
        /// <returns>The converted <see cref="Argument" /> value.</returns>
        public static implicit operator Argument((Name Name, Snippet Value) argument)
        {
            Guard.Against.Conversion<(Name Name, Snippet Value), Argument>(argument);

            return new Argument()
                .Named(argument.Name)
                .WithValue(argument.Value);
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

            var name = Name.ToSnippet(options);
            string value = Value.ToString();

            if (!Modifier.IsNone)
            {
                value = $"{Modifier} {value}";
            }

            return Snippet.From(options, string.Format(options.Formatter, name, value));
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

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Argument)} {{ " +
                $"{nameof(IsUndefined)} = `{DebuggerDisplayFormatter.Format(IsUndefined)}`, " +
                $"{nameof(Modifier)} = `{DebuggerDisplayFormatter.Format(Modifier)}`, " +
                $"{nameof(Name)} = `{DebuggerDisplayFormatter.Format(Name)}`, " +
                $"{nameof(Value)} = `{DebuggerDisplayFormatter.Format(Value)}` }}";
        }
    }
}