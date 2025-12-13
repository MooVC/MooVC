namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Argument_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Argument
        : IValidatableObject
    {
        public static readonly Argument Undefined = new Argument();

        internal Argument()
        {
        }

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Mode Modifier { get; internal set; } = Mode.None;

        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        public Snippet Value { get; internal set; } = Snippet.Empty;

        public static implicit operator string(Argument argument)
        {
            Guard.Against.Conversion<Argument, string>(argument);

            return argument.ToString();
        }

        public static implicit operator Snippet(Argument argument)
        {
            Guard.Against.Conversion<Argument, Snippet>(argument);

            return Snippet.From(argument);
        }

        public override string ToString()
        {
            return ToString(Options.Call);
        }

        public string ToString(Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Options), nameof(Argument), nameof(Name), Name));

            if (IsUndefined)
            {
                return string.Empty;
            }

            if (Name.IsUnnamed)
            {
                return $"{Value}";
            }

            string name = Name.ToString(options.Naming);
            string value = Value.ToString();

            if (!Modifier.IsNone)
            {
                value = $"{Modifier} {value}";
            }

            return string.Format(options.Formatter, name, value);
        }

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