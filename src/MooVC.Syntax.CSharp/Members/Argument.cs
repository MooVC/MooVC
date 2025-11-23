namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;
    using static MooVC.Syntax.CSharp.Members.Argument_Resources;
    using Microsoft.Extensions.Options;

    [Fluentify]
    [Valuify]
    public sealed partial class Argument
        : IValidatableObject
    {
        public static readonly Argument Undefined = new Argument();

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Identifier Name { get; set; } = Identifier.Unnamed;

        public Snippet Value { get; set; } = Snippet.Empty;

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

            return string.Format(options.Formatter, name, Value);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new System.NotImplementedException();
        }
    }
}