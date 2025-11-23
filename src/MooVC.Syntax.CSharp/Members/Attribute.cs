namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Fluentify;
    using MooVC.Linq;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Attribute_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Attribute
        : IValidatableObject
    {
        public static readonly Attribute Unspecified = new Attribute();

        private const string Separator = ", ";

        public ImmutableArray<Argument> Arguments { get; set; } = ImmutableArray<Argument>.Empty;

        [Ignore]
        public bool IsUnspecified => this == Unspecified;

        public Symbol Name { get; set; } = Symbol.Unspecified;

        public Specifier Target { get; set; } = Specifier.None;

        public override string ToString()
        {
            if (Name.IsUnspecified)
            {
                return string.Empty;
            }

            var value = new StringBuilder();

            if (Target != Specifier.None)
            {
                value = value.Append($"{Target}:");
            }

            value = value.Append(Name);

            string arguments = string.Empty;

            if (!Arguments.IsDefaultOrEmpty)
            {
                arguments = Separator.Combine(Arguments, argument => argument.ToString(Argument.Options.Declaration));

                value = value.Append($"({arguments})");
            }

            return $"[{value}]";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnspecified)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (Name.IsUnspecified)
            {
                results = results.Append(new ValidationResult(ValidateNameRequired.Format(nameof(Name), nameof(Attribute)), new[] { nameof(Name) }));
            }

            return validationContext
                .IncludeIf(!Arguments.IsDefaultOrEmpty, nameof(Arguments), results, Arguments)
                .And(nameof(Name), Name)
                .Results;
        }
    }
}