namespace MooVC.Syntax.CSharp
{
    using System.Diagnostics;
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents a symbol reference, including qualification and generic arguments.
    /// </summary>
    public partial class Qualification
    {
        /// <summary>
        /// Defines rendering options used when composing symbol references.
        /// </summary>
        public partial class Options
        {
            /// <summary>
            /// Represents formatting options for qualified symbol names.
            /// </summary>
            [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
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

                private string GetDebuggerDisplay()
                {
                    return $"{nameof(Formats)} {{ {nameof(IsFull)} = {DebuggerDisplayFormatter.Format(IsFull)}, {nameof(IsGlobal)} = {DebuggerDisplayFormatter.Format(IsGlobal)}, {nameof(IsMinimum)} = {DebuggerDisplayFormatter.Format(IsMinimum)} }}";
                }
            }
        }
    }
}