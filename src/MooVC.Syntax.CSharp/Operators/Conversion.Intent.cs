namespace MooVC.Syntax.CSharp.Operators
{
    using Monify;

    public partial class Conversion
    {
        [Monify(Type = typeof(int))]
        public sealed partial class Intent
        {
            public static readonly Intent From = 1;
            public static readonly Intent To = 0;

            private Intent(int value)
            {
                _value = value;
            }

            public bool IsFrom => this == From;

            public bool IsTo => this == To;
        }
    }
}