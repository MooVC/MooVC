namespace MooVC.Syntax.CSharp.Elements
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Formatting;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.CSharp.Elements.Symbol_Resources;

    public partial class Symbol
    {
        /// <summary>
        /// Represents a syntax element segment.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInitialization]
        public sealed partial class Moniker
            : IComparable<Moniker>,
              IValidatableObject
        {
            /// <summary>
            /// Gets the empty instance.
            /// </summary>
            public static readonly Moniker Unnamed = string.Empty;
            private static readonly Regex rule = new Regex(@"^@?[A-Za-z][A-Za-z0-9_]*$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

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
            /// Defines the string operator for the Moniker.
            /// </summary>
            /// <param name="moniker">The moniker.</param>
            /// <returns>The string.</returns>
            public static implicit operator string(Moniker moniker)
            {
                Guard.Against.Conversion<Moniker, string>(moniker);

                return moniker.ToString();
            }

            /// <summary>
            /// Defines the Snippet operator for the Moniker.
            /// </summary>
            /// <param name="moniker">The moniker.</param>
            /// <returns>The snippet.</returns>
            public static implicit operator Snippet(Moniker moniker)
            {
                Guard.Against.Conversion<Moniker, Snippet>(moniker);

                return Snippet.From(moniker);
            }

            /// <summary>
            /// Defines the Type operator for the Moniker.
            /// </summary>
            /// <param name="type">The type.</param>
            /// <returns>The moniker.</returns>
            public static implicit operator Moniker(Type type)
            {
                Guard.Against.Conversion<Type, Moniker>(type);

                if (Aliases.TryGet(type, out string alias))
                {
                    return alias;
                }

                string name = type.Name;

                if (type.IsGenericType)
                {
                    int index = name.IndexOf(Separator);

                    return index > 0
                        ? name.Substring(0, index)
                        : name;
                }

                return name;
            }

            /// <summary>
            /// Defines the less than operator for the Moniker.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>The .</returns>
            public static bool operator <(Moniker left, Moniker right)
            {
                if (left is null)
                {
                    return right is object;
                }

                return left.CompareTo(right) < 0;
            }

            /// <summary>
            /// Defines the greater than operator for the Segment.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>The .</returns>
            public static bool operator >(Moniker left, Moniker right)
            {
                if (left is null)
                {
                    return false;
                }

                return left.CompareTo(right) > 0;
            }

            /// <summary>
            /// Defines the less than or equal to operator for the Segment.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>The .</returns>
            public static bool operator <=(Moniker left, Moniker right)
            {
                return !(left > right);
            }

            /// <summary>
            /// Defines the greater than or equal to operator for the Segment.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>The .</returns>
            public static bool operator >=(Moniker left, Moniker right)
            {
                return !(left < right);
            }

            /// <summary>
            /// Compares this Segment to another instance.
            /// </summary>
            /// <param name="other">The other.</param>
            /// <returns>A signed integer indicating relative order.</returns>
            public int CompareTo(Moniker other)
            {
                return other is null
                    ? 1
                    : string.CompareOrdinal(_value, other._value);
            }

            /// <summary>
            /// Returns the string representation of the Segment.
            /// </summary>
            /// <returns>The string representation.</returns>
            public override string ToString()
            {
                return _value;
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

                if (_value is null || _value.Length == Unspecified || !rule.IsMatch(_value))
                {
                    yield return new ValidationResult(
                        MonikerValidateValueRequired.Format(_value, nameof(Moniker)),
                        new[] { nameof(Moniker) });
                }
            }
        }
    }
}