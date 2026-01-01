namespace MooVC.Syntax.CSharp.Elements
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;

    /// <summary>
    /// Represents a C# parameter syntax element.
    /// </summary>
    public partial class Parameter
    {
        /// <summary>
        /// Represents the modifier applied to a C# parameter.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInstantiation]
        public sealed partial class Mode
        {
            /// <summary>
            /// Gets the in modifier, indicating a readonly by-ref parameter.
            /// </summary>
            public static readonly Mode In = "in";
            /// <summary>
            /// Gets the out modifier, indicating the parameter is assigned by the callee.
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
            /// Gets the this modifier, marking the receiver of an extension method.
            /// </summary>
            public static readonly Mode This = "this";

            private Mode(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the parameter is passed as in.
            /// </summary>
            public bool IsIn => this == In;

            /// <summary>
            /// Gets a value indicating whether the parameter is passed as out.
            /// </summary>
            public bool IsOut => this == Out;

            /// <summary>
            /// Gets a value indicating whether the parameter has no modifier.
            /// </summary>
            public bool IsNone => this == None;

            /// <summary>
            /// Gets a value indicating whether the parameter is a params array.
            /// </summary>
            public bool IsParams => this == Params;

            /// <summary>
            /// Gets a value indicating whether the parameter is passed by ref.
            /// </summary>
            public bool IsRef => this == Ref;

            /// <summary>
            /// Gets a value indicating whether the parameter is passed by ref readonly.
            /// </summary>
            public bool IsRefReadonly => this == RefReadonly;

            /// <summary>
            /// Gets a value indicating whether the parameter is scoped.
            /// </summary>
            public bool IsScoped => this == Scoped;

            /// <summary>
            /// Gets a value indicating whether the parameter is an extension method receiver.
            /// </summary>
            public bool IsThis => this == This;

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
