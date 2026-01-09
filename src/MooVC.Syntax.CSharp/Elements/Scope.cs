namespace MooVC.Syntax.CSharp.Elements
{
    using System;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.CSharp.Elements.Scope_Resources;

    /// <summary>
    /// Represents a C# accessibility scope used to qualify type and member declarations.
    /// </summary>
    [Monify(Type = typeof(string))]
    [SkipAutoInitialization]
    public sealed partial class Scope
        : IComparable<Scope>
    {
        /// <summary>
        /// Gets the file-scoped accessibility modifier.
        /// </summary>
        public static readonly Scope File = "file";

        /// <summary>
        /// Gets the internal accessibility modifier.
        /// </summary>
        public static readonly Scope Internal = "internal";

        /// <summary>
        /// Gets the public accessibility modifier.
        /// </summary>
        public static readonly Scope Public = "public";

        /// <summary>
        /// Gets the private accessibility modifier.
        /// </summary>
        public static readonly Scope Private = "private";

        /// <summary>
        /// Gets the protected accessibility modifier.
        /// </summary>
        public static readonly Scope Protected = "protected";

        /// <summary>
        /// Gets an unspecified accessibility that renders as empty.
        /// </summary>
        public static readonly Scope Unspecified = string.Empty;

        private Scope(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Converts the accessibility scope to its C# source representation.
        /// </summary>
        /// <param name="scope">The scope to render.</param>
        /// <returns>The accessibility modifier text.</returns>
        public static implicit operator string(Scope scope)
        {
            Guard.Against.Conversion<Scope, string>(scope);

            return scope.ToString();
        }

        /// <summary>
        /// Converts the accessibility scope to a snippet.
        /// </summary>
        /// <param name="scope">The scope to convert.</param>
        /// <returns>The snippet containing the accessibility modifier.</returns>
        public static implicit operator Snippet(Scope scope)
        {
            Guard.Against.Conversion<Scope, Snippet>(scope);

            return Snippet.From(scope);
        }

        /// <summary>
        /// Combines compatible accessibility modifiers (for example, private protected).
        /// </summary>
        /// <param name="left">The left-hand modifier.</param>
        /// <param name="right">The right-hand modifier.</param>
        /// <returns>The combined accessibility modifier.</returns>
        public static Scope operator +(Scope left, Scope right)
        {
            _ = Guard.Against.Null(left, message: PlusOperatorLeftRequired.Format(nameof(Scope), right));
            _ = Guard.Against.Null(right, message: PlusOperatorRightRequired.Format(nameof(Scope), left));

            if (IsPrivateProtected(left, right) || IsProtectedInternal(left, right))
            {
                return new Scope($"{left} {right}");
            }

            throw new InvalidOperationException(PlusOperatorNotSupported);
        }

        /// <summary>
        /// Determines whether the left-hand scope sorts before the right-hand scope.
        /// </summary>
        /// <param name="left">The left-hand scope.</param>
        /// <param name="right">The right-hand scope.</param>
        /// <returns>True if the left-hand scope sorts before the right-hand scope.</returns>
        public static bool operator <(Scope left, Scope right)
        {
            if (left is null)
            {
                return right is object;
            }

            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Determines whether the left-hand scope sorts after the right-hand scope.
        /// </summary>
        /// <param name="left">The left-hand scope.</param>
        /// <param name="right">The right-hand scope.</param>
        /// <returns>True if the left-hand scope sorts after the right-hand scope.</returns>
        public static bool operator >(Scope left, Scope right)
        {
            if (left is null)
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Determines whether the left-hand scope sorts before or equal to the right-hand scope.
        /// </summary>
        /// <param name="left">The left-hand scope.</param>
        /// <param name="right">The right-hand scope.</param>
        /// <returns>True if the left-hand scope sorts before or equal to the right-hand scope.</returns>
        public static bool operator <=(Scope left, Scope right)
        {
            return !(left > right);
        }

        /// <summary>
        /// Determines whether the left-hand scope sorts after or equal to the right-hand scope.
        /// </summary>
        /// <param name="left">The left-hand scope.</param>
        /// <param name="right">The right-hand scope.</param>
        /// <returns>True if the left-hand scope sorts after or equal to the right-hand scope.</returns>
        public static bool operator >=(Scope left, Scope right)
        {
            return !(left < right);
        }

        /// <summary>
        /// Compares this Scope to another instance.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>A signed integer indicating relative order.</returns>
        public int CompareTo(Scope other)
        {
            if (other is null)
            {
                return 1;
            }

            int left = GetAccessibilityRank(_value);
            int right = GetAccessibilityRank(other._value);

            return left.CompareTo(right);
        }

        /// <summary>
        /// Returns the string representation of the Scope.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return _value;
        }

        private static int GetAccessibilityRank(string value)
        {
            switch (value)
            {
                case "public":
                    return 7;

                case "internal":
                    return 6;

                case "protected internal":
                    return 5;

                case "protected":
                    return 4;

                case "file":
                    return 3;

                case "private protected":
                    return 2;

                case "private":
                    return 1;

                default:
                    return 0;
            }
        }

        private static bool IsPrivateProtected(Scope left, Scope right)
        {
            return left._value == Private._value && right._value == Protected._value;
        }

        private static bool IsProtectedInternal(Scope left, Scope right)
        {
            return left._value == Protected._value && right._value == Internal._value;
        }
    }
}