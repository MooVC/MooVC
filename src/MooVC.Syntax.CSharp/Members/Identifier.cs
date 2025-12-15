namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Text.RegularExpressions;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.CSharp;
    using static MooVC.Syntax.CSharp.Members.Identifier_Resources;

    [Monify(Type = typeof(string))]
    [SkipAutoInstantiation]
    public sealed partial class Identifier
        : IComparable<Identifier>,
          IValidatableObject
    {
        public static readonly Identifier Unnamed = string.Empty;

        private static readonly Regex rule = new Regex(@"^(?!\d)(?!.*[^A-Za-z0-9])(?:[A-Z][a-zA-Z0-9]*)$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

        private static readonly Dictionary<Casing, Func<string, string>> casingStrategies = new Dictionary<Casing, Func<string, string>>
        {
            { Casing.Pascal, StringExtensions.ToPascalCase },
            { Casing.Camel, StringExtensions.ToCamelCase },
            { Casing.Snake, StringExtensions.ToSnakeCase },
            { Casing.Kebab, StringExtensions.ToKebabCase },
        };

        public Identifier(string value)
        {
            _value = value ?? string.Empty;
        }

        [Ignore]
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

        public static implicit operator Identifier(Type type)
        {
            Guard.Against.Conversion<Type, Identifier>(type);

            return type.GetIdentifier();
        }

        public static bool operator <(Identifier left, Identifier right)
        {
            if (left is null)
            {
                return right is object;
            }

            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Identifier left, Identifier right)
        {
            if (left is null)
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Identifier left, Identifier right)
        {
            return !(left > right);
        }

        public static bool operator >=(Identifier left, Identifier right)
        {
            return !(left < right);
        }

        public int CompareTo(Identifier other)
        {
            return other is null
                ? 1
                : string.CompareOrdinal(_value, other._value);
        }

        public override string ToString()
        {
            return ToString(Options.Camel);
        }

        public string ToString(Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Identifier)));

            if (IsUnnamed)
            {
                return string.Empty;
            }

            if (Aliases.IsSystem(_value))
            {
                return _value.ToCamelCase();
            }

            const char ReservationPrefix = '@';
            const char UnderscorePrefix = '_';

            if (!casingStrategies.TryGetValue(options.Casing, out Func<string, string> transform))
            {
                throw new NotSupportedException(ToStringCasingNotSupported.Format(options.Casing, nameof(Identifier)));
            }

            var identifier = new StringBuilder(transform(_value));

            if (options.UseUnderscores)
            {
                identifier = identifier.Prepend(UnderscorePrefix);
            }
            else if (options.Casing != Casing.Pascal && identifier.IsReserved())
            {
                identifier = identifier.Prepend(ReservationPrefix);
            }

            return identifier.ToString();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnnamed)
            {
                yield break;
            }

            const int Unspecified = 0;

            if (_value is null || _value.Length == Unspecified || !(rule.IsMatch(_value) || Aliases.IsSystem(_value)))
            {
                yield return new ValidationResult(
                    ValidateValueRequired.Format(_value, nameof(Identifier)),
                    new[] { nameof(Identifier) });
            }
        }
    }
}