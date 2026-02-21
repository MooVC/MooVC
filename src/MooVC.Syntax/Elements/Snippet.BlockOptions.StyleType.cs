namespace MooVC.Syntax.Elements
{
    using Monify;

    /// <summary>
    /// Represents a syntax element snippet.
    /// </summary>
    public partial class Snippet
    {
        /// <summary>
        /// Represents a syntax element block options.
        /// </summary>
        public partial class BlockOptions
        {
            /// <summary>
            /// Represents a syntax element style type.
            /// </summary>
            [Monify(Type = typeof(int))]
            public sealed partial class StyleType
            {
                /// <summary>
                /// Represents the allman for the StyleType.
                /// </summary>
                public static readonly StyleType Allman = 0;

                /// <summary>
                /// Represents the k and r for the StyleType.
                /// </summary>
                public static readonly StyleType KAndR = 1;

                private StyleType(int value)
                {
                    _value = value;
                }

                /// <summary>
                /// Gets a value indicating whether the StyleType is allman.
                /// </summary>
                /// <value>A value indicating whether the StyleType is allman.</value>
                public bool IsAllman => this == Allman;

                /// <summary>
                /// Gets a value indicating whether the StyleType is k and r.
                /// </summary>
                /// <value>A value indicating whether the StyleType is k and r.</value>
                public bool IsKAndR => this == KAndR;
            }
        }
    }
}