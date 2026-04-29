namespace MooVC.Syntax.CSharp
{
    using System.Diagnostics;
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents method return signature settings.
    /// </summary>
    public partial class Result
    {
        /// <summary>
        /// Represents return modifiers that precede the return type in a C# signature.
        /// </summary>
        [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
        [Monify(Type = typeof(string))]
        [SkipAutoInitialization]
        public sealed partial class Modifiers
        {
            /// <summary>
            /// Gets the absence of a return modifier.
            /// </summary>
            public static readonly Modifiers None = string.Empty;

            /// <summary>
            /// Gets the ref return modifier.
            /// </summary>
            public static readonly Modifiers Ref = "ref";

            /// <summary>
            /// Gets the ref readonly return modifier.
            /// </summary>
            public static readonly Modifiers RefReadOnly = "ref readonly";

            /// <summary>
            /// Gets the unsafe return modifier.
            /// </summary>
            public static readonly Modifiers Unsafe = "unsafe";

            private Modifiers(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Returns the C# return modifier text.
            /// </summary>
            /// <returns>The return modifier text.</returns>
            public override string ToString()
            {
                return _value;
            }

            private string GetDebuggerDisplay()
            {
                return $"{nameof(Modifiers)} {{ {_value} }}";
            }
        }
    }
}