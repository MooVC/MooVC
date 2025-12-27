namespace MooVC.Syntax.CSharp.Operators
{
    using System;
    using Monify;

    public partial class Conversion
    {
        [Monify(Type = typeof(int))]
        public sealed partial class Intent
            : IComparable<Intent>
        {
            public static readonly Intent From = 1;
            public static readonly Intent To = 0;

            private Intent(int value)
            {
                _value = value;
            }

            public bool IsFrom => this == From;

            public bool IsTo => this == To;

            public static bool operator <(Intent left, Intent right)
            {
                if (left is null)
                {
                    return right is object;
                }

                return left.CompareTo(right) < 0;
            }

            public static bool operator >(Intent left, Intent right)
            {
                if (left is null)
                {
                    return false;
                }

                return left.CompareTo(right) > 0;
            }

            public static bool operator <=(Intent left, Intent right)
            {
                return !(left > right);
            }

            public static bool operator >=(Intent left, Intent right)
            {
                return !(left < right);
            }

            public int CompareTo(Intent other)
            {
                return other is null
                    ? 1
                    : _value.CompareTo(other._value);
            }

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