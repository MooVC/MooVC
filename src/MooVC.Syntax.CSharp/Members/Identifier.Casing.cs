namespace MooVC.Syntax.CSharp.Members
{
    using Fluentify;
    using Monify;

    partial class Identifier
    {
        [Monify(Type = typeof(int))]
        [SkipAutoInstantiation]
        public sealed partial class Casing
        {
            public static readonly Casing Camel = 1;
            public static readonly Casing Kebab = 2;
            public static readonly Casing Pascal = 0;
            public static readonly Casing Snake = 3;

            private Casing(int value)
            {
                _value = value;
            }

            public bool IsCamel => this == Camel;

            public bool IsKebab => this == Kebab;

            public bool IsPascal => this == Pascal;

            public bool IsSnake => this == Snake;

            public override string ToString()
            {
                switch (_value)
                {
                    case 1:
                        return nameof(Camel);

                    case 2:
                        return nameof(Kebab);

                    case 3:
                        return nameof(Snake);

                    default:
                        return nameof(Pascal);
                }
            }
        }
    }
}