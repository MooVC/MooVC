namespace MooVC.Syntax.CSharp.Elements
{
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents a C# member return signature.
    /// </summary>
    public partial class Result
    {
        /// <summary>
        /// Represents return modifiers that precede the return type in a C# signature.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInstantiation]
        public sealed partial class Kind
        {
            /// <summary>
            /// Gets the absence of a return modifier.
            /// </summary>
            public static readonly Kind None = string.Empty;
            /// <summary>
            /// Gets the ref return modifier.
            /// </summary>
            public static readonly Kind Ref = "ref";
            /// <summary>
            /// Gets the ref readonly return modifier.
            /// </summary>
            public static readonly Kind RefReadOnly = "ref readonly";
            /// <summary>
            /// Gets the unsafe return modifier.
            /// </summary>
            public static readonly Kind Unsafe = "unsafe";

            private Kind(string value)
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
        }
    }
}
