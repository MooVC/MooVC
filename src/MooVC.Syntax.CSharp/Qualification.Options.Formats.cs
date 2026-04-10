namespace MooVC.Syntax.CSharp
{
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents a C# syntax element symbol.
    /// </summary>
    public partial class Qualification
    {
        /// <summary>
        /// Defines options for the Symbol C# syntax element.
        /// </summary>
        public partial class Options
        {
            /// <summary>
            /// Represents a C# syntax element qualification.
            /// </summary>
            [Monify(Type = typeof(string))]
            [SkipAutoInitialization]
            public sealed partial class Formats
            {
                /// <summary>
                /// Represents the full for the Format.
                /// </summary>
                public static readonly Formats Full = "Full";

                /// <summary>
                /// Represents the minimum for the Format.
                /// </summary>
                public static readonly Formats Minimum = "Minimum";

                /// <summary>
                /// Represents the global for the Format.
                /// </summary>
                public static readonly Formats Global = "Global";

                private Formats(string value)
                {
                    _value = value;
                }

                /// <summary>
                /// Gets a value indicating whether the Format is full.
                /// </summary>
                /// <value>A value indicating whether the Format is full.</value>
                public bool IsFull => this == Full;

                /// <summary>
                /// Gets a value indicating whether the Format is minimum.
                /// </summary>
                /// <value>A value indicating whether the Format is minimum.</value>
                public bool IsMinimum => this == Minimum;

                /// <summary>
                /// Gets a value indicating whether the Format is global.
                /// </summary>
                /// <value>A value indicating whether the Format is global.</value>
                public bool IsGlobal => this == Global;

                /// <summary>
                /// Returns a string that represents the current object.
                /// </summary>
                /// <returns>A string representation of the current object.</returns>
                public override string ToString()
                {
                    return _value;
                }
            }
        }
    }
}