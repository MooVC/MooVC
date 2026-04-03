namespace MooVC.Syntax
{
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents a syntax element identifier.
    /// </summary>
    public partial class Identifier
    {
        /// <summary>
        /// Represents a syntax element casing.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInitialization]
        public sealed partial class Casing
        {
            /// <summary>
            /// Represents the camel for the Casing.
            /// </summary>
            public static readonly Casing Camel = "Camel";

            /// <summary>
            /// Represents the kebab for the Casing.
            /// </summary>
            public static readonly Casing Kebab = "Kebab";

            /// <summary>
            /// Represents the pascal for the Casing.
            /// </summary>
            public static readonly Casing Pascal = "Pascal";

            /// <summary>
            /// Represents the snake for the Casing.
            /// </summary>
            public static readonly Casing Snake = "Snake";

            private Casing(string value)
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
                return _value;
            }
        }
    }
}