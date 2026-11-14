namespace MooVC.Syntax.CSharp
{
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents a generic type-parameter declaration.
    /// </summary>
    public partial class Generic
    {
        /// <summary>
        /// Represents the variance modifier on a generic interface type parameter.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInitialization]
        public sealed partial class Variances
        {
            /// <summary>
            /// Gets the <c>in</c> modifier for a contravariant type parameter.
            /// </summary>
            public static readonly Variances In = "in";

            /// <summary>
            /// Gets the absence of a variance modifier for an invariant type parameter.
            /// </summary>
            public static readonly Variances None = string.Empty;

            /// <summary>
            /// Gets the <c>out</c> modifier for a covariant type parameter.
            /// </summary>
            public static readonly Variances Out = "out";

            private Variances(string value)
            {
                _value = value;
            }
        }
    }
}