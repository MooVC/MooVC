namespace MooVC.Syntax.CSharp.Elements
{
    using Monify;

    /// <summary>
    /// Represents a c# syntax element symbol.
    /// </summary>
    public partial class Symbol
    {
        /// <summary>
        /// Represents a c# syntax element qualification.
        /// </summary>
        [Monify(Type = typeof(byte))]
        public sealed partial class Qualification
        {
            /// <summary>
            /// Gets the full on the Qualification.
            /// </summary>
            public static readonly Qualification Full = 1;
            /// <summary>
            /// Gets the minimum on the Qualification.
            /// </summary>
            public static readonly Qualification Minimum = 0;
            /// <summary>
            /// Gets the global on the Qualification.
            /// </summary>
            public static readonly Qualification Global = 2;

            private Qualification(byte value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Qualification is full.
            /// </summary>
            public bool IsFull => this == Full;

            /// <summary>
            /// Gets a value indicating whether the Qualification is minimum.
            /// </summary>
            public bool IsMinimum => this == Minimum;

            /// <summary>
            /// Gets a value indicating whether the Qualification is global.
            /// </summary>
            public bool IsGlobal => this == Global;
        }
    }
}