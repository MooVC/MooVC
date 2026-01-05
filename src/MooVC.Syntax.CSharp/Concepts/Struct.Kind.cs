namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using Ardalis.GuardClauses;
    using Monify;
    using static MooVC.Syntax.CSharp.Concepts.Struct_Resources;

    /// <summary>
    /// Represents a C# type syntax struct.
    /// </summary>
    public partial class Struct
    {
        /// <summary>
        /// Represents a C# type syntax kind.
        /// </summary>
        [Monify(Type = typeof(string))]
        public sealed partial class Kind
        {
            /// <summary>
            /// Gets the default instance.
            /// </summary>
            public static readonly Kind Default = string.Empty;

            /// <summary>
            /// Represents the read only for the Kind.
            /// </summary>
            public static readonly Kind ReadOnly = "readonly";

            /// <summary>
            /// Represents the record for the Kind.
            /// </summary>
            public static readonly Kind Record = "record";

            /// <summary>
            /// Represents the ref for the Kind.
            /// </summary>
            public static readonly Kind Ref = "ref";

            private Kind(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Defines the + operator for the Kind.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>The .</returns>
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
            /// <returns>The string representation.</returns>
            public override string ToString()
            {
                return _value;
            }
        }
    }
}