namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using Ardalis.GuardClauses;
    using Monify;
    using static MooVC.Syntax.CSharp.Concepts.Struct_Resources;

    public partial class Struct
    {
        [Monify(Type = typeof(string))]
        public sealed partial class Kind
        {
            public static readonly Kind Default = string.Empty;
            public static readonly Kind ReadOnly = "readonly";
            public static readonly Kind Record = "record";
            public static readonly Kind Ref = "ref";

            internal Kind(string value)
            {
                _value = value;
            }

            public static Kind operator +(Kind left, Kind right)
            {
                _ = Guard.Against.Null(left, message: KindPlusOperatorLeftRequired.Format(nameof(Kind), right));
                _ = Guard.Against.Null(right, message: KindPlusOperatorRightRequired.Format(nameof(Kind), left));

                if (left == ReadOnly && right == Record)
                {
                    return new Kind($"{left} {right}");
                }

                throw new InvalidOperationException(KindPlusOperatorNotSupported);
            }

            public override string ToString()
            {
                return _value;
            }
        }
    }
}