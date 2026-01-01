namespace MooVC.Syntax.CSharp.Elements
{
    using Monify;

    /// <summary>
    /// Represents a C# syntax element symbol.
    /// </summary>
    public partial class Symbol
    {
        /// <summary>
        /// Represents a C# syntax element qualification.
        /// </summary>
        [Monify(Type = typeof(byte))]
        public sealed partial class Qualification
        {
            /// <summary>
            /// Represents the full for the Qualification.
            /// </summary>
            public static readonly Qualification Full = 1;
            /// <summary>
            /// Represents the minimum for the Qualification.
            /// </summary>
            public static readonly Qualification Minimum = 0;
            /// <summary>
            /// Represents the global for the Qualification.
            /// </summary>
            public static readonly Qualification Global = 2;

            private Qualification(byte value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Qualification is full.
            /// </summary>
            /// <value>A value indicating whether the Qualification is full.</value>
            public bool IsFull => this == Full;

            /// <summary>
            /// Gets a value indicating whether the Qualification is minimum.
            /// </summary>
            /// <value>A value indicating whether the Qualification is minimum.</value>
            public bool IsMinimum => this == Minimum;

            /// <summary>
            /// Gets a value indicating whether the Qualification is global.
            /// </summary>
            /// <value>A value indicating whether the Qualification is global.</value>
            public bool IsGlobal => this == Global;
        }
    }
}