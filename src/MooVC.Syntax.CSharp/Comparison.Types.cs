namespace MooVC.Syntax.CSharp
{
    using System.Diagnostics;
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents a comparison operator declaration model.
    /// </summary>
    public partial class Comparison
    {
        /// <summary>
        /// Represents an operator token category used by operator declarations.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInitialization]
        public sealed partial class Types
        {
            /// <summary>
            /// Represents the equality for the Type.
            /// </summary>
            public static readonly Types Equality = "==";

            /// <summary>
            /// Represents the greater than for the Type.
            /// </summary>
            public static readonly Types GreaterThan = ">";

            /// <summary>
            /// Represents the greater than or equal for the Type.
            /// </summary>
            public static readonly Types GreaterThanOrEqual = ">=";

            /// <summary>
            /// Represents the inequality for the Type.
            /// </summary>
            public static readonly Types Inequality = "!=";

            /// <summary>
            /// Represents the less than for the Type.
            /// </summary>
            public static readonly Types LessThan = "<";

            /// <summary>
            /// Represents the less than or equal for the Type.
            /// </summary>
            public static readonly Types LessThanOrEqual = "<=";

            /// <summary>
            /// Gets the unspecified instance.
            /// </summary>
            public static readonly Types Unspecified = string.Empty;

            private Types(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Type is equality.
            /// </summary>
            /// <value>A value indicating whether the Type is equality.</value>
            public bool IsEquality => this == Equality;

            /// <summary>
            /// Gets a value indicating whether the Type is greater than.
            /// </summary>
            /// <value>A value indicating whether the Type is greater than.</value>
            public bool IsGreaterThan => this == GreaterThan;

            /// <summary>
            /// Gets a value indicating whether the Type is greater than or equal.
            /// </summary>
            /// <value>A value indicating whether the Type is greater than or equal.</value>
            public bool IsGreaterThanOrEqual => this == GreaterThanOrEqual;

            /// <summary>
            /// Gets a value indicating whether the Type is inequality.
            /// </summary>
            /// <value>A value indicating whether the Type is inequality.</value>
            public bool IsInequality => this == Inequality;

            /// <summary>
            /// Gets a value indicating whether the Type is less than.
            /// </summary>
            /// <value>A value indicating whether the Type is less than.</value>
            public bool IsLessThan => this == LessThan;

            /// <summary>
            /// Gets a value indicating whether the Type is less than or equal.
            /// </summary>
            /// <value>A value indicating whether the Type is less than or equal.</value>
            public bool IsLessThanOrEqual => this == LessThanOrEqual;

            /// <summary>
            /// Gets a value indicating whether the Type is unspecified.
            /// </summary>
            /// <value>A value indicating whether the Type is unspecified.</value>
            public bool IsUnspecified => this == Unspecified;
        }
    }
}