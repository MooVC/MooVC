namespace MooVC.Syntax.CSharp.Operators
{
    using System;
    using Monify;

    /// <summary>
    /// Represents a c# operator syntax conversion.
    /// </summary>
    public partial class Conversion
    {
        /// <summary>
        /// Represents a c# operator syntax intent.
        /// </summary>
        [Monify(Type = typeof(int))]
        public sealed partial class Intent
            : IComparable<Intent>
        {
            /// <summary>
            /// Gets the from on the Intent.
            /// </summary>
            public static readonly Intent From = 1;
            /// <summary>
            /// Gets the to on the Intent.
            /// </summary>
            public static readonly Intent To = 0;

            private Intent(int value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Intent is from.
            /// </summary>
            public bool IsFrom => this == From;

            /// <summary>
            /// Gets a value indicating whether the Intent is to.
            /// </summary>
            public bool IsTo => this == To;

            /// <summary>
            /// Defines the < operator for the Intent.
            /// </summary>
            public static bool operator <(Intent left, Intent right)
            {
                if (left is null)
                {
                    return right is object;
                }

                return left.CompareTo(right) < 0;
            }

            /// <summary>
            /// Defines the > operator for the Intent.
            /// </summary>
            public static bool operator >(Intent left, Intent right)
            {
                if (left is null)
                {
                    return false;
                }

                return left.CompareTo(right) > 0;
            }

            /// <summary>
            /// Defines the <= operator for the Intent.
            /// </summary>
            public static bool operator <=(Intent left, Intent right)
            {
                return !(left > right);
            }

            /// <summary>
            /// Defines the >= operator for the Intent.
            /// </summary>
            public static bool operator >=(Intent left, Intent right)
            {
                return !(left < right);
            }

            /// <summary>
            /// Compares this Intent to another instance.
            /// </summary>
            public int CompareTo(Intent other)
            {
                return other is null
                    ? 1
                    : _value.CompareTo(other._value);
            }

            /// <summary>
            /// Returns the string representation of the Intent.
            /// </summary>
            public override string ToString()
            {
                if (_value == From._value)
                {
                    return nameof(From);
                }

                return nameof(To);
            }
        }
    }
}