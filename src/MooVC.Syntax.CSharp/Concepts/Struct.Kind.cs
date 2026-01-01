namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using Ardalis.GuardClauses;
    using Monify;
    using static MooVC.Syntax.CSharp.Concepts.Struct_Resources;

    /// <summary>
    /// Represents a c# type syntax struct.
    /// </summary>
    public partial class Struct
    {
        /// <summary>
        /// Represents a c# type syntax kind.
        /// </summary>
        [Monify(Type = typeof(string))]
        public sealed partial class Kind
        {
            /// <summary>
            /// Gets the default on the Kind.
            /// </summary>
            public static readonly Kind Default = string.Empty;
            /// <summary>
            /// Gets the read only on the Kind.
            /// </summary>
            public static readonly Kind ReadOnly = "readonly";
            /// <summary>
            /// Gets the record on the Kind.
            /// </summary>
            public static readonly Kind Record = "record";
            /// <summary>
            /// Gets the ref on the Kind.
            /// </summary>
            public static readonly Kind Ref = "ref";

            private Kind(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Defines the + operator for the Kind.
            /// </summary>
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

            /// <summary>
            /// Returns the string representation of the Kind.
            /// </summary>
            public override string ToString()
            {
                return _value;
            }
        }
    }
}