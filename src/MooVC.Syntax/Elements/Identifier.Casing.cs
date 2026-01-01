namespace MooVC.Syntax.Elements
{
    using Fluentify;
    using Monify;

    partial class Identifier
    {
        /// <summary>
        /// Represents a syntax element casing.
        /// </summary>
        [Monify(Type = typeof(int))]
        [SkipAutoInstantiation]
        public sealed partial class Casing
        {
            /// <summary>
            /// Gets the camel on the Casing.
            /// </summary>
            public static readonly Casing Camel = 1;
            /// <summary>
            /// Gets the kebab on the Casing.
            /// </summary>
            public static readonly Casing Kebab = 2;
            /// <summary>
            /// Gets the pascal on the Casing.
            /// </summary>
            public static readonly Casing Pascal = 0;
            /// <summary>
            /// Gets the snake on the Casing.
            /// </summary>
            public static readonly Casing Snake = 3;

            private Casing(int value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Casing is camel.
            /// </summary>
            public bool IsCamel => this == Camel;

            /// <summary>
            /// Gets a value indicating whether the Casing is kebab.
            /// </summary>
            public bool IsKebab => this == Kebab;

            /// <summary>
            /// Gets a value indicating whether the Casing is pascal.
            /// </summary>
            public bool IsPascal => this == Pascal;

            /// <summary>
            /// Gets a value indicating whether the Casing is snake.
            /// </summary>
            public bool IsSnake => this == Snake;

            /// <summary>
            /// Returns the string representation of the Casing.
            /// </summary>
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