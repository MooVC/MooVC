namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using static MooVC.Syntax.CSharp.Members.Scope_Resources;

    [Monify(Type = typeof(string))]
    [SkipAutoInstantiation]
    public sealed partial class Scope
        : IComparable<Scope>
    {
        public static readonly Scope File = "file";
        public static readonly Scope Internal = "internal";
        public static readonly Scope Public = "public";
        public static readonly Scope Private = "private";
        public static readonly Scope Protected = "protected";
        public static readonly Scope Unspecified = string.Empty;

        private Scope(string value)
        {
            _value = value;
        }

        public static implicit operator string(Scope scope)
        {
            Guard.Against.Conversion<Scope, string>(scope);

            return scope.ToString();
        }

        public static implicit operator Snippet(Scope scope)
        {
            Guard.Against.Conversion<Scope, Snippet>(scope);

            return Snippet.From(scope);
        }

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

        public static bool operator <(Scope left, Scope right)
        {
            if (left is null)
            {
                return right is object;
            }

            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Scope left, Scope right)
        {
            if (left is null)
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Scope left, Scope right)
        {
            return !(left > right);
        }

        public static bool operator >=(Scope left, Scope right)
        {
            return !(left < right);
        }

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