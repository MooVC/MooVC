namespace MooVC.Syntax.CSharp.Generics
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using static MooVC.Syntax.CSharp.Generics.Identifier_Resources;

    [Monify(Type = typeof(string))]
    [SkipAutoInstantiation]
    public sealed partial class Identifier
        : IValidatableObject
    {
        public static readonly Identifier Unnamed = string.Empty;
        private static readonly Regex rule = new Regex(@"^T(?:[A-Z][A-Za-z0-9]*)?$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public bool IsUnnamed => this == Unnamed;

        public static implicit operator string(Identifier identifier)
        {
            Guard.Against.Conversion<Identifier, string>(identifier);

            return identifier.ToString();
        }

        public static implicit operator Snippet(Identifier identifier)
        {
            Guard.Against.Conversion<Identifier, Snippet>(identifier);

            return Snippet.From(identifier);
        }

        public override string ToString()
        {
            return _value;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnnamed)
            {
                yield break;
            }

            const int Unspecified = 0;

            if (_value is null || _value.Length == Unspecified || !rule.IsMatch(_value))
            {
                yield return new ValidationResult(ValidateValueRequired.Format(_value, nameof(Identifier)), new[] { nameof(Identifier) });
            }
        }
    }
}