namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Symbol_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Symbol
        : IValidatableObject
    {
        public static readonly Symbol Unspecified = new Symbol();
        private const string Separator = ", ";

        public ImmutableArray<Symbol> Arguments { get; set; } = ImmutableArray<Symbol>.Empty;

        [Ignore]
        public bool IsUnspecified => this == Unspecified;

        public Identifier Name { get; set; } = Identifier.Unnamed;

        public override string ToString()
        {
            if (IsUnspecified)
            {
                return string.Empty;
            }

            string signature = Name;

            if (!Arguments.IsDefaultOrEmpty)
            {
                string arguments = GetArgumentDeclarations();

                signature = $"{signature}<{arguments}>";
            }

            return signature;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnspecified)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (Name.IsUnnamed)
            {
                results = results.Append(new ValidationResult(ValidateNameRequired.Format(nameof(Name), nameof(Symbol)), new[] { nameof(Name) }));
            }

            if (!Arguments.IsDefaultOrEmpty && Arguments.Any(argument => argument.IsUnspecified))
            {
                results = results.Append(new ValidationResult(ValidateArgumentsInvalid.Format(nameof(Symbol), nameof(Arguments)), new[] { nameof(Arguments) }));
            }

            return validationContext
                .IncludeIf(!Arguments.IsDefaultOrEmpty, nameof(Arguments), results, Arguments)
                .And(nameof(Name), Name)
                .Results;
        }

        private string GetArgumentDeclarations()
        {
            string[] arguments = Arguments
                .Select(argument => argument.ToString())
                .ToArray();

            return Separator.Combine(arguments);
        }
    }
}