namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Diagnostics;
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents a user-defined conversion operator declaration model.
    /// </summary>
    public partial class Conversion
    {
        /// <summary>
        /// Represents whether a conversion operator is implicit or explicit.
        /// </summary>
        [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
        [Monify(Type = typeof(string))]
        [SkipAutoInitialization]
        public sealed partial class Intents
            : IComparable<Intents>
        {
            /// <summary>
            /// Represents the from for the Intent.
            /// </summary>
            public static readonly Intents From = "From";

            /// <summary>
            /// Represents the to for the Intent.
            /// </summary>
            public static readonly Intents To = "To";

            private Intents(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Intent is from.
            /// </summary>
            /// <value>A value indicating whether the Intent is from.</value>
            public bool IsFrom => this == From;

            /// <summary>
            /// Gets a value indicating whether the Intent is to.
            /// </summary>
            /// <value>A value indicating whether the Intent is to.</value>
            public bool IsTo => this == To;

            /// <summary>
            /// Defines the less than operator for the Intent.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>
            /// <see langword="true" /> when <paramref name="left" /> is less than <paramref name="right" />;
            /// otherwise, <see langword="false" />.
            /// </returns>
            public static bool operator <(Intents left, Intents right)
            {
                if (left is null)
                {
                    return right is object;
                }

                return left.CompareTo(right) < 0;
            }

            /// <summary>
            /// Defines the greater than operator for the Intent.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>
            /// <see langword="true" /> when <paramref name="left" /> is greater than <paramref name="right" />;
            /// otherwise, <see langword="false" />.
            /// </returns>
            public static bool operator >(Intents left, Intents right)
            {
                if (left is null)
                {
                    return false;
                }

                return left.CompareTo(right) > 0;
            }

            /// <summary>
            /// Defines the less than or equal to operator for the Intent.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>
            /// <see langword="true" /> when <paramref name="left" /> is less than or equal to <paramref name="right" />;
            /// otherwise, <see langword="false" />.
            /// </returns>
            public static bool operator <=(Intents left, Intents right)
            {
                return !(left > right);
            }

            /// <summary>
            /// Defines the greater than or equal to operator for the Intent.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>
            /// <see langword="true" /> when <paramref name="left" /> is greater than or equal to <paramref name="right" />;
            /// otherwise, <see langword="false" />.
            /// </returns>
            public static bool operator >=(Intents left, Intents right)
            {
                return !(left < right);
            }

            /// <summary>
            /// Compares this Intent to another instance.
            /// </summary>
            /// <param name="other">The other.</param>
            /// <returns>A signed integer indicating relative order.</returns>
            public int CompareTo(Intents other)
            {
                if (this == To && other == From)
                {
                    return 1;
                }

                if (this == From && other == To)
                {
                    return -1;
                }

                return 0;
            }

            /// <summary>
            /// Returns the string representation of the Intent.
            /// </summary>
            /// <returns>The string representation.</returns>
            public override string ToString()
            {
                return _value;
            }

            private string GetDebuggerDisplay()
            {
                return $"{nameof(Intents)} {{ {_value} }}";
            }
        }
    }
}