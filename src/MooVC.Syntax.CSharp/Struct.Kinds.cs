namespace MooVC.Syntax.CSharp
{
    using System;
    using Ardalis.GuardClauses;
    using Monify;
    using static MooVC.Syntax.CSharp.Struct_Resources;

    /// <summary>
    /// Represents a C# type syntax struct.
    /// </summary>
    public partial class Struct
    {
        /// <summary>
        /// Represents a C# type syntax kind.
        /// </summary>
        [Monify(Type = typeof(string))]
        public sealed partial class Kinds
        {
            /// <summary>
            /// Gets the default instance.
            /// </summary>
            public static readonly Kinds Default = string.Empty;

            /// <summary>
            /// Represents the read only for the Kind.
            /// </summary>
            public static readonly Kinds ReadOnly = "readonly";

            /// <summary>
            /// Represents the record for the Kind.
            /// </summary>
            public static readonly Kinds Record = "record";

            /// <summary>
            /// Represents the ref for the Kind.
            /// </summary>
            public static readonly Kinds Ref = "ref";

            private Kinds(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Defines the + operator for the Kind.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>The .</returns>
            public static Kinds operator +(Kinds left, Kinds right)
            {
                _ = Guard.Against.Null(left, message: KindPlusOperatorLeftRequired.Format(nameof(Kinds), right));
                _ = Guard.Against.Null(right, message: KindPlusOperatorRightRequired.Format(nameof(Kinds), left));

                if (left == ReadOnly && right == Record)
                {
                    return new Kinds($"{left} {right}");
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