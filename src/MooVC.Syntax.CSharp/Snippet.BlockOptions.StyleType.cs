namespace MooVC.Syntax.CSharp
{
    using System;
    using Monify;

    public partial class Snippet
    {
        public partial class BlockOptions
        {
            [Monify(Type = typeof(int))]
            public sealed partial class StyleType
            {
                public static readonly StyleType Allman = 0;
                public static readonly StyleType KAndR = 1;

                private StyleType(int value)
                {
                    _value = value;
                }

                public bool IsAllman => this == Allman;

                public bool IsKAndR => this == KAndR;
            }
        }
    }
}