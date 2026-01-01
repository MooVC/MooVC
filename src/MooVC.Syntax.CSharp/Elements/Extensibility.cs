namespace MooVC.Syntax.CSharp.Elements
{
    using System;
    using Ardalis.GuardClauses;
    using Monify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.CSharp.Elements.Extensibility_Resources;

    [Monify(Type = typeof(string))]
    public sealed partial class Extensibility
        : IComparable<Extensibility>
    {
        public static readonly Extensibility Abstract = "abstract";
        public static readonly Extensibility Implicit = string.Empty;
        public static readonly Extensibility Override = "override";
        public static readonly Extensibility Static = "static";
        public static readonly Extensibility Sealed = "sealed";
        public static readonly Extensibility Virtual = "virtual";

        private Extensibility(string value)
        {
            _value = value;
        }

        public static implicit operator string(Extensibility extensibility)
        {
            Guard.Against.Conversion<Extensibility, string>(extensibility);

            return extensibility.ToString();
        }

        public static implicit operator Snippet(Extensibility extensibility)
        {
            Guard.Against.Conversion<Extensibility, Snippet>(extensibility);

            return Snippet.From(extensibility);
        }

        public static bool operator <(Extensibility left, Extensibility right)
        {
            if (left is null)
            {
                return right is object;
            }

            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Extensibility left, Extensibility right)
        {
            if (left is null)
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Extensibility left, Extensibility right)
        {
            return !(left > right);
        }

        public static bool operator >=(Extensibility left, Extensibility right)
        {
            return !(left < right);
        }

        public static Extensibility operator +(Extensibility left, Extensibility right)
        {
            _ = Guard.Against.Null(left, message: PlusOperatorLeftRequired.Format(nameof(Extensibility), right));
            _ = Guard.Against.Null(right, message: PlusOperatorRightRequired.Format(nameof(Extensibility), left));

            if (IsStatic(left, right) || IsOverride(left, right))
            {
                return new Extensibility($"{left} {right}");
            }

            throw new InvalidOperationException(PlusOperatorNotSupported.Format(left, right));
        }

        public int CompareTo(Extensibility other)
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

        public bool IsPermitted(params Extensibility[] permissable)
        {
            return Array.Exists(permissable, extensibility => extensibility == this);
        }

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

        private static bool IsStatic(Extensibility left, Extensibility right)
        {
            return left == Static && right == Abstract;
        }

        private static bool IsOverride(Extensibility left, Extensibility right)
        {
            return (left == Sealed || left == Abstract) && right == Override;
        }
    }
}