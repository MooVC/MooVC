namespace MooVC.Syntax.CSharp
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Validation;

    /// <summary>
    /// Represents an argument expression used in generated C# member invocations.
    /// </summary>
    public partial class Argument
    {
        /// <summary>
        /// Represents the pass-by modifier applied to an argument expression.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInitialization]
        public sealed partial class Modes
        {
            /// <summary>
            /// Represents the in for the Mode.
            /// </summary>
            public static readonly Modes In = "in";

            /// <summary>
            /// Represents the out for the Mode.
            /// </summary>
            public static readonly Modes Out = "out";

            /// <summary>
            /// Gets the absence of a value.
            /// </summary>
            public static readonly Modes None = string.Empty;

            /// <summary>
            /// Represents the params for the Mode.
            /// </summary>
            public static readonly Modes Params = "params";

            /// <summary>
            /// Represents the ref for the Mode.
            /// </summary>
            public static readonly Modes Ref = "ref";

            private Modes(string value)
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
            /// Defines an implicit conversion from <see cref="Modes" /> to <see cref="string" />.
            /// </summary>
            /// <param name="mode">The <see cref="Modes" /> value to convert.</param>
            /// <returns>The converted <see cref="string" /> value.</returns>
            public static implicit operator string(Modes mode)
            {
                Guard.Against.Conversion<Modes, string>(mode);

                return mode.ToString();
            }

            /// <summary>
            /// Defines an implicit conversion from <see cref="Modes" /> to <see cref="Snippet" />.
            /// </summary>
            /// <param name="mode">The <see cref="Modes" /> value to convert.</param>
            /// <returns>The converted <see cref="Snippet" /> value.</returns>
            public static implicit operator Snippet(Modes mode)
            {
                Guard.Against.Conversion<Modes, Snippet>(mode);

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