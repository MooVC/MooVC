namespace MooVC.Syntax.CSharp.Constructs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Text.RegularExpressions;
    using Ardalis.GuardClauses;
    using Monify;
    using static MooVC.Syntax.CSharp.Constructs.Member_Resources;

    [Monify(Type = typeof(string))]
    public sealed partial class Member
        : IValidatableObject
    {
        private static readonly Regex rule = new Regex(@"^(?!\d)(?!.*[^A-Za-z0-9])(?:[A-Z][a-zA-Z0-9]*)$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

        private static readonly Dictionary<Casing, Func<string, string>> casingStrategies = new Dictionary<Casing, Func<string, string>>
        {
            { Casing.Pascal, StringExtensions.ToPascalCase },
            { Casing.Camel, StringExtensions.ToCamelCase },
            { Casing.Snake, StringExtensions.ToSnakeCase },
            { Casing.Kebab, StringExtensions.ToKebabCase },
        };

        public override string ToString()
        {
            return ToString(Options.Default);
        }

        public string ToString(Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Member)));

            const char UnderscorePrefix = '_';

            if (!casingStrategies.TryGetValue(options.Casing, out Func<string, string> transform))
            {
                throw new NotSupportedException(ToStringCasingNotSupported.Format(options.Casing, nameof(Member)));
            }

            var identifier = new StringBuilder(transform(_value));

            if (options.UseUnderscores)
            {
                identifier = identifier.Prepend(UnderscorePrefix);
            }

            return identifier.ToString();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            const int Empty = 0;

            if (_value is null || _value.Length == Empty || !rule.IsMatch(_value))
            {
                yield return new ValidationResult(ValidateIdentifierRequired.Format(_value, nameof(Member)), new[] { nameof(Member) });
            }
        }
    }
}