namespace MooVC.Syntax.CSharp
{
    using System;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.CSharp.Modifiers_Resources;

    /// <summary>
    /// Represents C# extensibility modifiers that describe inheritance and override behavior.
    /// </summary>
    [Monify(Type = typeof(string))]
    [SkipAutoInitialization]
    public sealed partial class Modifiers
        : IComparable<Modifiers>
    {
        /// <summary>
        /// Gets the abstract modifier for abstract members and types.
        /// </summary>
        public static readonly Modifiers Abstract = "abstract";

        /// <summary>
        /// Gets the absence of an extensibility modifier.
        /// </summary>
        public static readonly Modifiers Implicit = string.Empty;

        /// <summary>
        /// Gets the override modifier for overridden members.
        /// </summary>
        public static readonly Modifiers Override = "override";

        /// <summary>
        /// Gets the static modifier for static members.
        /// </summary>
        public static readonly Modifiers Static = "static";

        /// <summary>
        /// Gets the sealed modifier for sealed members or types.
        /// </summary>
        public static readonly Modifiers Sealed = "sealed";

        /// <summary>
        /// Gets the virtual modifier for virtual members.
        /// </summary>
        public static readonly Modifiers Virtual = "virtual";

        private Modifiers(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Converts the extensibility modifier to its C# source representation.
        /// </summary>
        /// <param name="modifiers">The extensibility modifier to render.</param>
        /// <returns>The modifier text.</returns>
        public static implicit operator string(Modifiers modifiers)
        {
            Guard.Against.Conversion<Modifiers, string>(modifiers);

            return modifiers.ToString();
        }

        /// <summary>
        /// Converts the extensibility modifier to a snippet.
        /// </summary>
        /// <param name="modifiers">The extensibility modifier to convert.</param>
        /// <returns>The snippet containing the modifier.</returns>
        public static implicit operator Snippet(Modifiers modifiers)
        {
            Guard.Against.Conversion<Modifiers, Snippet>(modifiers);

            return Snippet.From(modifiers.ToString());
        }

        /// <summary>
        /// Determines whether the left-hand modifier sorts before the right-hand modifier.
        /// </summary>
        /// <param name="left">The left-hand modifier.</param>
        /// <param name="right">The right-hand modifier.</param>
        /// <returns>True if the left-hand modifier sorts before the right-hand modifier.</returns>
        public static bool operator <(Modifiers left, Modifiers right)
        {
            if (left is null)
            {
                return right is object;
            }

            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Determines whether the left-hand modifier sorts after the right-hand modifier.
        /// </summary>
        /// <param name="left">The left-hand modifier.</param>
        /// <param name="right">The right-hand modifier.</param>
        /// <returns>True if the left-hand modifier sorts after the right-hand modifier.</returns>
        public static bool operator >(Modifiers left, Modifiers right)
        {
            if (left is null)
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Determines whether the left-hand modifier sorts before or equal to the right-hand modifier.
        /// </summary>
        /// <param name="left">The left-hand modifier.</param>
        /// <param name="right">The right-hand modifier.</param>
        /// <returns>True if the left-hand modifier sorts before or equal to the right-hand modifier.</returns>
        public static bool operator <=(Modifiers left, Modifiers right)
        {
            return !(left > right);
        }

        /// <summary>
        /// Determines whether the left-hand modifier sorts after or equal to the right-hand modifier.
        /// </summary>
        /// <param name="left">The left-hand modifier.</param>
        /// <param name="right">The right-hand modifier.</param>
        /// <returns>True if the left-hand modifier sorts after or equal to the right-hand modifier.</returns>
        public static bool operator >=(Modifiers left, Modifiers right)
        {
            return !(left < right);
        }

        /// <summary>
        /// Defines the + operator for the Extensibility.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>A value that combines <paramref name="left" /> and <paramref name="right" />.</returns>
        public static Modifiers operator +(Modifiers left, Modifiers right)
        {
            _ = Guard.Against.Null(left, message: PlusOperatorLeftRequired.Format(nameof(Modifiers), right));
            _ = Guard.Against.Null(right, message: PlusOperatorRightRequired.Format(nameof(Modifiers), left));

            if (IsStatic(left, right) || IsOverride(left, right))
            {
                return new Modifiers($"{left} {right}");
            }

            throw new InvalidOperationException(PlusOperatorNotSupported.Format(left, right));
        }

        /// <summary>
        /// Compares this Extensibility to another instance.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>A signed integer indicating relative order.</returns>
        public int CompareTo(Modifiers other)
        {
            if (other is null)
            {
                return 1;
            }

            int left = GetRank(_value);
            int right = GetRank(other._value);

            int rank = left.CompareTo(right);

            return rank != 0
                ? rank
                : string.CompareOrdinal(_value, other._value);
        }

        /// <summary>
        /// Performs the is permitted operation for the C# syntax element.
        /// </summary>
        /// <param name="permissable">The permissable.</param>
        /// <returns>The bool.</returns>
        public bool IsPermitted(params Modifiers[] permissable)
        {
            return Array.Exists(permissable, extensibility => extensibility == this);
        }

        /// <summary>
        /// Returns the string representation of the Extensibility.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return _value;
        }

        private static int GetRank(string value)
        {
            if (value == Static._value)
            {
                return 6;
            }

            if (value == Abstract._value)
            {
                return 5;
            }

            if (value == Sealed._value)
            {
                return 4;
            }

            if (value == Override._value)
            {
                return 3;
            }

            if (value == Virtual._value)
            {
                return 2;
            }

            return 1;
        }

        private static bool IsStatic(Modifiers left, Modifiers right)
        {
            return left == Static && right == Abstract;
        }

        private static bool IsOverride(Modifiers left, Modifiers right)
        {
            return (left == Sealed || left == Abstract) && right == Override;
        }
    }
}