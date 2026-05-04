namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Diagnostics;
    using Ardalis.GuardClauses;
    using Monify;
    using static MooVC.Syntax.CSharp.Struct_Resources;

    /// <summary>
    /// Represents a C# struct declaration model.
    /// </summary>
    public partial class Struct
    {
        /// <summary>
        /// Represents the struct shape keyword (`struct`, `readonly struct`, or `ref struct`).
        /// </summary>
        [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
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
            /// Gets a value indicating whether or not this is a compound instance.
            /// </summary>
            public bool IsCompound => _value.Contains(" ");

            /// <summary>
            /// Gets a value indicating whether or not this is the default instance.
            /// </summary>
            public bool IsDefault => this == Default;

            /// <summary>
            /// Gets a value indicating whether or not this is a read only instance.
            /// </summary>
            public bool IsReadOnly => _value.StartsWith("readonly", StringComparison.Ordinal);

            /// <summary>
            /// Gets a value indicating whether or not this is a record instance.
            /// </summary>
            public bool IsRecord => _value.EndsWith("record", StringComparison.Ordinal);

            /// <summary>
            /// Gets a value indicating whether or not this is a ref instance.
            /// </summary>
            public bool IsRef => _value.EndsWith("ref", StringComparison.Ordinal);

            /// <summary>
            /// Defines the + operator for the Kind.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>A value that combines <paramref name="left" /> and <paramref name="right" />.</returns>
            public static Kinds operator +(Kinds left, Kinds right)
            {
                _ = Guard.Against.Null(left, message: KindPlusOperatorLeftRequired.Format(nameof(Kinds), right));
                _ = Guard.Against.Null(right, message: KindPlusOperatorRightRequired.Format(nameof(Kinds), left));

                if (left == ReadOnly && (right == Record || right == Ref))
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

            /// <summary>
            /// Returns the string representation of the Kind.
            /// </summary>
            /// <param name="left">The left part of the Kind.</param>
            /// <param name="right">The right part of the Kind.</param>
            public void ToString(out string left, out string right)
            {
                left = _value;
                right = string.Empty;

                if (IsCompound && IsRecord)
                {
                    string[] parts = _value.Split(' ');

                    left = parts[0];
                    right = parts[1];
                }
            }

            private string GetDebuggerDisplay()
            {
                return $"{nameof(Kinds)} {{ {_value} }}";
            }
        }
    }
}