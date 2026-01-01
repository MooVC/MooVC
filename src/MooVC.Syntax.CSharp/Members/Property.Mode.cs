namespace MooVC.Syntax.CSharp.Members
{
    using Monify;

    public partial class Property
    {
        [Monify(Type = typeof(int))]
        public sealed partial class Mode
        {
            public static readonly Mode Init = 2;
            public static readonly Mode ReadOnly = 1;
            public static readonly Mode Set = 0;

            private Mode(int value)
            {
                _value = value;
            }

            public bool IsInit => this == Init;

            public bool IsReadOnly => this == ReadOnly;

            public bool IsSet => this == Set;

            public override string ToString()
            {
                if (IsInit)
                {
                    return "init";
                }

                if (IsSet)
                {
                    return "set";
                }

                return string.Empty;
            }
        }
    }
}