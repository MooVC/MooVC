namespace MooVC.Syntax
{
    using System.Diagnostics;
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents a syntax element snippet.
    /// </summary>
    public partial class Snippet
    {
        /// <summary>
        /// Defines options for the Snippet syntax element.
        /// </summary>
        public partial class Options
        {
            /// <summary>
            /// Represents a syntax element block options.
            /// </summary>
            public partial class Blocks
            {
                /// <summary>
                /// Represents a syntax element style type.
                /// </summary>
                [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
                [Monify(Type = typeof(string))]
                [SkipAutoInitialization]
                public sealed partial class Layouts
                {
                    /// <summary>
                    /// Represents the allman for the StyleType.
                    /// </summary>
                    public static readonly Layouts Allman = "Allman";

                    /// <summary>
                    /// Represents the k and r for the StyleType.
                    /// </summary>
                    public static readonly Layouts KAndR = "KAndR";

                    private Layouts(string value)
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

                    /// <summary>
                    /// Returns a string that represents the current object.
                    /// </summary>
                    /// <returns>A string representation of the current object.</returns>
                    public override string ToString()
                    {
                        return _value;
                    }

                    private string GetDebuggerDisplay()
                    {
                        return $"{nameof(Layouts)} {{ {_value} }}";
                    }
                }
            }
        }
    }
}