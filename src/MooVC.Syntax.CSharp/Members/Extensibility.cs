namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using Ardalis.GuardClauses;
    using Monify;
    using static MooVC.Syntax.CSharp.Members.Extensibility_Resources;

    [Monify(Type = typeof(string))]
    public sealed partial class Extensibility
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

        public static Extensibility operator +(Extensibility left, Extensibility right)
        {
            _ = Guard.Against.Null(left, message: PlusOperatorLeftRequired.Format(nameof(Extensibility), right));
            _ = Guard.Against.Null(right, message: PlusOperatorRightRequired.Format(nameof(Extensibility), left));

            if (IsStatic(left, right) || IsOverride(left, right))
            {
                return new Extensibility($"{left} {right}");
            }

            throw new InvalidOperationException(PlusOperatorNotSupported);
        }

        public override string ToString()
        {
            return _value;
        }

        private static bool IsStatic(Extensibility left, Extensibility right)
        {
            return left == Static && right == Abstract;
        }

        private static bool IsOverride(Extensibility left, Extensibility right)
        {
            return left == Override && (right == Sealed || right == Abstract);
        }
    }
}