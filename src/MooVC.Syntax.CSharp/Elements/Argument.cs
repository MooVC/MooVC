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
    /// Represents a c# syntax element argument.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Argument
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the Argument.
        /// </summary>
        public static readonly Argument Undefined = new Argument();

        /// <summary>
        /// Initializes a new instance of the Argument class.
        /// </summary>
        internal Argument()
        {
        }

        /// <summary>
        /// Gets a value indicating whether the Argument is undefined.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the modifier on the Argument.
        /// </summary>
        public Mode Modifier { get; internal set; } = Mode.None;

        /// <summary>
        /// Gets or sets the name on the Argument.
        /// </summary>
        [Descriptor("Named")]
        public Variable Name { get; internal set; } = Variable.Unnamed;

        /// <summary>
        /// Gets or sets the value on the Argument.
        /// </summary>
        public Snippet Value { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Defines the string operator for the Argument.
        /// </summary>
        public static implicit operator string(Argument argument)
        {
            Guard.Against.Conversion<Argument, string>(argument);

            return argument.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Argument.
        /// </summary>
        public static implicit operator Snippet(Argument argument)
        {
            Guard.Against.Conversion<Argument, Snippet>(argument);

            return argument.ToSnippet(Options.Call);
        }

        /// <summary>
        /// Returns the string representation of the Argument.
        /// </summary>
        public override string ToString()
        {
            return ToSnippet(Options.Call);
        }

        /// <summary>
        /// Creates a code snippet representation of the c# syntax element.
        /// </summary>
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
        /// Validates the Argument and returns validation results.
        /// </summary>
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