namespace MooVC.Syntax.Elements
{
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents a syntax element identifier.
    /// </summary>
    partial class Identifier
    {
        /// <summary>
        /// Represents a syntax element casing.
        /// </summary>
        [Monify(Type = typeof(int))]
        [SkipAutoInitialization]
        public sealed partial class Casing
        {
            /// <summary>
            /// Represents the camel for the Casing.
            /// </summary>
            public static readonly Casing Camel = 1;

            /// <summary>
            /// Represents the kebab for the Casing.
            /// </summary>
            public static readonly Casing Kebab = 2;

            /// <summary>
            /// Represents the pascal for the Casing.
            /// </summary>
            public static readonly Casing Pascal = 0;

            /// <summary>
            /// Represents the snake for the Casing.
            /// </summary>
            public static readonly Casing Snake = 3;

            private Casing(int value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Casing is camel.
            /// </summary>
            /// <value>A value indicating whether the Casing is camel.</value>
            public bool IsCamel => this == Camel;

            /// <summary>
            /// Gets a value indicating whether the Casing is kebab.
            /// </summary>
            /// <value>A value indicating whether the Casing is kebab.</value>
            public bool IsKebab => this == Kebab;

            /// <summary>
            /// Gets a value indicating whether the Casing is pascal.
            /// </summary>
            /// <value>A value indicating whether the Casing is pascal.</value>
            public bool IsPascal => this == Pascal;

            /// <summary>
            /// Gets a value indicating whether the Casing is snake.
            /// </summary>
            /// <value>A value indicating whether the Casing is snake.</value>
            public bool IsSnake => this == Snake;

            /// <summary>
            /// Returns the string representation of the Casing.
            /// </summary>
            /// <returns>The string representation.</returns>
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