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
    /// Represents a c# syntax element scope.
    /// </summary>
    [Monify(Type = typeof(string))]
    [SkipAutoInstantiation]
    public sealed partial class Scope
        : IComparable<Scope>
    {
        /// <summary>
        /// Gets the file on the Scope.
        /// </summary>
        public static readonly Scope File = "file";
        /// <summary>
        /// Gets the internal on the Scope.
        /// </summary>
        public static readonly Scope Internal = "internal";
        /// <summary>
        /// Gets the public on the Scope.
        /// </summary>
        public static readonly Scope Public = "public";
        /// <summary>
        /// Gets the private on the Scope.
        /// </summary>
        public static readonly Scope Private = "private";
        /// <summary>
        /// Gets the protected on the Scope.
        /// </summary>
        public static readonly Scope Protected = "protected";
        /// <summary>
        /// Gets the unspecified on the Scope.
        /// </summary>
        public static readonly Scope Unspecified = string.Empty;

        private Scope(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Defines the string operator for the Scope.
        /// </summary>
        public static implicit operator string(Scope scope)
        {
            Guard.Against.Conversion<Scope, string>(scope);

            return scope.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Scope.
        /// </summary>
        public static implicit operator Snippet(Scope scope)
        {
            Guard.Against.Conversion<Scope, Snippet>(scope);

            return Snippet.From(scope);
        }

        /// <summary>
        /// Defines the + operator for the Scope.
        /// </summary>
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
        /// Defines the < operator for the Scope.
        /// </summary>
        public static bool operator <(Scope left, Scope right)
        {
            if (left is null)
            {
                return right is object;
            }

            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Defines the > operator for the Scope.
        /// </summary>
        public static bool operator >(Scope left, Scope right)
        {
            if (left is null)
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Defines the <= operator for the Scope.
        /// </summary>
        public static bool operator <=(Scope left, Scope right)
        {
            return !(left > right);
        }

        /// <summary>
        /// Defines the >= operator for the Scope.
        /// </summary>
        public static bool operator >=(Scope left, Scope right)
        {
            return !(left < right);
        }

        /// <summary>
        /// Compares this Scope to another instance.
        /// </summary>
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