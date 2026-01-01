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
                /// Gets the allman on the StyleType.
                /// </summary>
                public static readonly StyleType Allman = 0;
                /// <summary>
                /// Gets the k and r on the StyleType.
                /// </summary>
                public static readonly StyleType KAndR = 1;

                private StyleType(int value)
                {
                    _value = value;
                }

                /// <summary>
                /// Gets a value indicating whether the StyleType is allman.
                /// </summary>
                public bool IsAllman => this == Allman;

                /// <summary>
                /// Gets a value indicating whether the StyleType is k and r.
                /// </summary>
                public bool IsKAndR => this == KAndR;
            }
        }
    }
}