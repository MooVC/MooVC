namespace MooVC.Syntax.CSharp.Elements
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;

    /// <summary>
    /// Represents a c# syntax element argument.
    /// </summary>
    public partial class Argument
    {
        /// <summary>
        /// Represents a c# syntax element mode.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInstantiation]
        public sealed partial class Mode
        {
            /// <summary>
            /// Gets the in on the Mode.
            /// </summary>
            public static readonly Mode In = "in";
            /// <summary>
            /// Gets the out on the Mode.
            /// </summary>
            public static readonly Mode Out = "out";
            /// <summary>
            /// Gets the none on the Mode.
            /// </summary>
            public static readonly Mode None = string.Empty;
            /// <summary>
            /// Gets the params on the Mode.
            /// </summary>
            public static readonly Mode Params = "params";
            /// <summary>
            /// Gets the ref on the Mode.
            /// </summary>
            public static readonly Mode Ref = "ref";

            private Mode(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Mode is in.
            /// </summary>
            public bool IsIn => this == In;

            /// <summary>
            /// Gets a value indicating whether the Mode is out.
            /// </summary>
            public bool IsOut => this == Out;

            /// <summary>
            /// Gets a value indicating whether the Mode is none.
            /// </summary>
            public bool IsNone => this == None;

            /// <summary>
            /// Gets a value indicating whether the Mode is ref.
            /// </summary>
            public bool IsRef => this == Ref;

            /// <summary>
            /// Defines the string operator for the Mode.
            /// </summary>
            public static implicit operator string(Mode mode)
            {
                Guard.Against.Conversion<Mode, string>(mode);

                return mode.ToString();
            }

            /// <summary>
            /// Defines the Snippet operator for the Mode.
            /// </summary>
            public static implicit operator Snippet(Mode mode)
            {
                Guard.Against.Conversion<Mode, Snippet>(mode);

                return Snippet.From(mode);
            }

            /// <summary>
            /// Returns the string representation of the Mode.
            /// </summary>
            public override string ToString()
            {
                return _value;
            }
        }
    }
}