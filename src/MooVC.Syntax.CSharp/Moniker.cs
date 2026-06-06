namespace MooVC.Syntax.CSharp
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.CSharp.Moniker_Resources;
    using CType = System.Type;

    /// <summary>
    /// Represents one segment in a qualified identifier.
    /// </summary>
    [Monify(Type = typeof(string))]
    [SkipAutoInitialization]
    public sealed partial class Moniker
        : IValidatableObject
    {
        /// <summary>
        /// Gets the empty instance.
        /// </summary>
        public static readonly Moniker Unnamed = string.Empty;
        private static readonly Regex _rule = new Regex(@"^@?[A-Za-z][A-Za-z0-9_]*$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

        internal Moniker(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets a value indicating whether the Segment is empty.
        /// </summary>
        /// <value>A value indicating whether the Segment is empty.</value>
        public bool IsUnnamed => this == Unnamed;

        /// <summary>
        /// Defines an implicit conversion from <see cref="Moniker" /> to <see cref="string" />.
        /// </summary>
        /// <param name="moniker">The <see cref="Moniker" /> value to convert.</param>
        /// <returns>The converted <see cref="string" /> value.</returns>
        public static implicit operator string(Moniker moniker)
        {
            Guard.Against.Conversion<Moniker, string>(moniker);

            return moniker.ToString();
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Moniker" /> to <see cref="Snippet" />.
        /// </summary>
        /// <param name="moniker">The <see cref="Moniker" /> value to convert.</param>
        /// <returns>The converted <see cref="Snippet" /> value.</returns>
        public static implicit operator Snippet(Moniker moniker)
        {
            Guard.Against.Conversion<Moniker, Snippet>(moniker);

            return Snippet.From(moniker);
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Name" /> to <see cref="Moniker" />.
        /// </summary>
        /// <param name="name">The <see cref="Name" /> value to convert.</param>
        /// <returns>The converted <see cref="Moniker" /> value.</returns>
        public static implicit operator Moniker(Name name)
        {
            Guard.Against.Conversion<Name, Moniker>(name);

            return new Moniker(name);
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="CType" /> to <see cref="Moniker" />.
        /// </summary>
        /// <param name="type">The <see cref="CType" /> value to convert.</param>
        /// <returns>The converted <see cref="Moniker" /> value.</returns>
        public static implicit operator Moniker(CType type)
        {
            Guard.Against.Conversion<CType, Moniker>(type);

            if (Aliases.TryGet(type, out string alias))
            {
                return alias;
            }

            if (type.IsArray)
            {
                type = type.GetElementType();
            }

            string name = type.Name;

            if (type.IsGenericType)
            {
                const char marker = '`';

                int index = name.IndexOf(marker);

                return index > 0
                    ? name.Substring(0, index)
                    : name;
            }

            return name;
        }

        /// <summary>
        /// Validates the Segment.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnnamed)
            {
                yield break;
            }

            const int Unspecified = 0;

            if (_value is null || _value.Length == Unspecified || !_rule.IsMatch(_value))
            {
                yield return new ValidationResult(
                    MonikerValidateValueRequired.Format(_value, nameof(Moniker)),
                    new[] { nameof(Moniker) });
            }
        }
    }
}