namespace MooVC.Syntax.CSharp.Elements
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;

    /// <summary>
    /// Represents a C# parameter syntax element, including its name, type, and modifiers.
    /// </summary>
    public partial class Parameter
    {
        /// <summary>
        /// Represents the modifier applied to a C# parameter that changes passing semantics.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInitialization]
        public sealed partial class Mode
        {
            /// <summary>
            /// Gets the in modifier, indicating a readonly by-ref parameter.
            /// </summary>
            public static readonly Mode In = "in";

            /// <summary>
            /// Gets the out modifier, indicating assignment by the callee.
            /// </summary>
            public static readonly Mode Out = "out";

            /// <summary>
            /// Gets the absence of a parameter modifier.
            /// </summary>
            public static readonly Mode None = string.Empty;

            /// <summary>
            /// Gets the params modifier, indicating a parameter array.
            /// </summary>
            public static readonly Mode Params = "params";

            /// <summary>
            /// Gets the ref modifier, indicating a by-ref parameter.
            /// </summary>
            public static readonly Mode Ref = "ref";

            /// <summary>
            /// Gets the ref readonly modifier, indicating a readonly by-ref parameter.
            /// </summary>
            public static readonly Mode RefReadonly = "ref readonly";

            /// <summary>
            /// Gets the scoped modifier, constraining the lifetime of a by-ref parameter.
            /// </summary>
            public static readonly Mode Scoped = "scoped";

            /// <summary>
            /// Gets the this modifier, marking the receiver parameter of an extension method.
            /// </summary>
            public static readonly Mode This = "this";

            private Mode(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the parameter is passed with the in modifier.
            /// </summary>
            /// <value>A value indicating whether the parameter is passed with the in modifier.</value>
            public bool IsIn => this == In;

            /// <summary>
            /// Gets a value indicating whether the parameter is passed with the out modifier.
            /// </summary>
            /// <value>A value indicating whether the parameter is passed with the out modifier.</value>
            public bool IsOut => this == Out;

            /// <summary>
            /// Gets a value indicating whether the parameter has no modifier.
            /// </summary>
            /// <value>A value indicating whether the parameter has no modifier.</value>
            public bool IsNone => this == None;

            /// <summary>
            /// Gets a value indicating whether the parameter is a params array.
            /// </summary>
            /// <value>A value indicating whether the parameter is a params array.</value>
            public bool IsParams => this == Params;

            /// <summary>
            /// Gets a value indicating whether the parameter is passed by ref.
            /// </summary>
            /// <value>A value indicating whether the parameter is passed by ref.</value>
            public bool IsRef => this == Ref;

            /// <summary>
            /// Gets a value indicating whether the parameter is passed by ref readonly.
            /// </summary>
            /// <value>A value indicating whether the parameter is passed by ref readonly.</value>
            public bool IsRefReadonly => this == RefReadonly;

            /// <summary>
            /// Gets a value indicating whether the parameter is scoped.
            /// </summary>
            /// <value>A value indicating whether the parameter is scoped.</value>
            public bool IsScoped => this == Scoped;

            /// <summary>
            /// Gets a value indicating whether the parameter is an extension method receiver.
            /// </summary>
            /// <value>A value indicating whether the parameter is an extension method receiver.</value>
            public bool IsThis => this == This;

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