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

        public override string ToString()
        {
            return _value;
        }

        private static bool IsPrivateProtected(Scope left, Scope right)
        {
            return left == Private && right == Protected;
        }

        private static bool IsProtectedInternal(Scope left, Scope right)
        {
            return left == Protected && right == Internal;
        }
    }
}