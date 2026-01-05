namespace MooVC.Syntax.CSharp.Elements
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;

    /// <summary>
    /// Represents a C# syntax element argument.
    /// </summary>
    public partial class Argument
    {
        /// <summary>
        /// Represents a C# syntax element mode.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInstantiation]
        public sealed partial class Mode
        {
            /// <summary>
            /// Represents the in for the Mode.
            /// </summary>
            public static readonly Mode In = "in";

            /// <summary>
            /// Represents the out for the Mode.
            /// </summary>
            public static readonly Mode Out = "out";

            /// <summary>
            /// Gets the absence of a value.
            /// </summary>
            public static readonly Mode None = string.Empty;

            /// <summary>
            /// Represents the params for the Mode.
            /// </summary>
            public static readonly Mode Params = "params";

            /// <summary>
            /// Represents the ref for the Mode.
            /// </summary>
            public static readonly Mode Ref = "ref";

            private Mode(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Mode is in.
            /// </summary>
            /// <value>A value indicating whether the Mode is in.</value>
            public bool IsIn => this == In;

            /// <summary>
            /// Gets a value indicating whether the Mode is out.
            /// </summary>
            /// <value>A value indicating whether the Mode is out.</value>
            public bool IsOut => this == Out;

            /// <summary>
            /// Gets a value indicating whether the Mode is none.
            /// </summary>
            /// <value>A value indicating whether the Mode is none.</value>
            public bool IsNone => this == None;

            /// <summary>
            /// Gets a value indicating whether the Mode is ref.
            /// </summary>
            /// <value>A value indicating whether the Mode is ref.</value>
            public bool IsRef => this == Ref;

            /// <summary>
            /// Defines the string operator for the Mode.
            /// </summary>
            /// <param name="mode">The mode.</param>
            /// <returns>The string.</returns>
            public static implicit operator string(Mode mode)
            {
                Guard.Against.Conversion<Mode, string>(mode);

                return mode.ToString();
            }

            /// <summary>
            /// Defines the Snippet operator for the Mode.
            /// </summary>
            /// <param name="mode">The mode.</param>
            /// <returns>The snippet.</returns>
            public static implicit operator Snippet(Mode mode)
            {
                Guard.Against.Conversion<Mode, Snippet>(mode);

                return Snippet.From(mode);
            }

            /// <summary>
            /// Returns the string representation of the Mode.
            /// </summary>
            /// <returns>The string representation.</returns>
            public override string ToString()
            {
                return _value;
            }
        }
    }
}