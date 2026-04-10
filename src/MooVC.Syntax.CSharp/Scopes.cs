namespace MooVC.Syntax.CSharp
{
    using System;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.CSharp.Scopes_Resources;

    /// <summary>
    /// Represents a C# accessibility scope used to qualify type and member declarations.
    /// </summary>
    [Monify(Type = typeof(string))]
    [SkipAutoInitialization]
    public sealed partial class Scopes
        : IComparable<Scopes>
    {
        /// <summary>
        /// Gets the file-scoped accessibility modifier.
        /// </summary>
        public static readonly Scopes File = "file";

        /// <summary>
        /// Gets the internal accessibility modifier.
        /// </summary>
        public static readonly Scopes Internal = "internal";

        /// <summary>
        /// Gets the public accessibility modifier.
        /// </summary>
        public static readonly Scopes Public = "public";

        /// <summary>
        /// Gets the private accessibility modifier.
        /// </summary>
        public static readonly Scopes Private = "private";

        /// <summary>
        /// Gets the protected accessibility modifier.
        /// </summary>
        public static readonly Scopes Protected = "protected";

        /// <summary>
        /// Gets an unspecified accessibility that renders as empty.
        /// </summary>
        public static readonly Scopes Unspecified = string.Empty;

        private Scopes(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Converts the accessibility scope to its C# source representation.
        /// </summary>
        /// <param name="scope">The scope to render.</param>
        /// <returns>The accessibility modifier text.</returns>
        public static implicit operator string(Scopes scope)
        {
            Guard.Against.Conversion<Scopes, string>(scope);

            return scope.ToString();
        }

        /// <summary>
        /// Converts the accessibility scope to a snippet.
        /// </summary>
        /// <param name="scope">The scope to convert.</param>
        /// <returns>The snippet containing the accessibility modifier.</returns>
        public static implicit operator Snippet(Scopes scope)
        {
            Guard.Against.Conversion<Scopes, Snippet>(scope);

            return Snippet.From(scope.ToString());
        }

        /// <summary>
        /// Combines compatible accessibility modifiers (for example, private protected).
        /// </summary>
        /// <param name="left">The left-hand modifier.</param>
        /// <param name="right">The right-hand modifier.</param>
        /// <returns>The combined accessibility modifier.</returns>
        public static Scopes operator +(Scopes left, Scopes right)
        {
            _ = Guard.Against.Null(left, message: PlusOperatorLeftRequired.Format(nameof(Scopes), right));
            _ = Guard.Against.Null(right, message: PlusOperatorRightRequired.Format(nameof(Scopes), left));

            if (IsPrivateProtected(left, right) || IsProtectedInternal(left, right))
            {
                return new Scopes($"{left} {right}");
            }

            throw new InvalidOperationException(PlusOperatorNotSupported);
        }

        /// <summary>
        /// Determines whether the left-hand scope sorts before the right-hand scope.
        /// </summary>
        /// <param name="left">The left-hand scope.</param>
        /// <param name="right">The right-hand scope.</param>
        /// <returns>True if the left-hand scope sorts before the right-hand scope.</returns>
        public static bool operator <(Scopes left, Scopes right)
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
        public static bool operator >(Scopes left, Scopes right)
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
        public static bool operator <=(Scopes left, Scopes right)
        {
            return !(left > right);
        }

        /// <summary>
        /// Determines whether the left-hand scope sorts after or equal to the right-hand scope.
        /// </summary>
        /// <param name="left">The left-hand scope.</param>
        /// <param name="right">The right-hand scope.</param>
        /// <returns>True if the left-hand scope sorts after or equal to the right-hand scope.</returns>
        public static bool operator >=(Scopes left, Scopes right)
        {
            return !(left < right);
        }

        /// <summary>
        /// Compares this Scope to another instance.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>A signed integer indicating relative order.</returns>
        public int CompareTo(Scopes other)
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

        /// <summary>
        /// Returns the string representation of the Scope.
        /// </summary>
        /// <param name="implied">The implied scope.</param>
        /// <returns>The string representation of the scope, or string.Empty if the instance matches the implied.</returns>
        public string ToString(Scopes implied)
        {
            if (this == implied)
            {
                return string.Empty;
            }

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

        private static bool IsPrivateProtected(Scopes left, Scopes right)
        {
            return left._value == Private._value && right._value == Protected._value;
        }

        private static bool IsProtectedInternal(Scopes left, Scopes right)
        {
            return left._value == Protected._value && right._value == Internal._value;
        }
    }
}