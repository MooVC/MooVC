namespace MooVC.Syntax.CSharp.Members
{
    using Monify;

    public partial class Symbol
    {
        [Monify(Type = typeof(byte))]
        public sealed partial class Qualification
        {
            public static readonly Qualification Full = 1;
            public static readonly Qualification Minimum = 0;
            public static readonly Qualification Global = 2;

            private Qualification(byte value)
            {
                _value = value;
            }

            public bool IsFull => this == Full;

            public bool IsMinimum => this == Minimum;

            public bool IsGlobal => this == Global;
        }
    }
}