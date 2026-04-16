namespace MooVC.Syntax.CSharp
{
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents method return signature settings.
    /// </summary>
    public partial class Result
    {
        /// <summary>
        /// Represents the async/sync modality applied to a member signature.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInitialization]
        public sealed partial class Modes
        {
            /// <summary>
            /// Gets the async modifier for an asynchronous member signature.
            /// </summary>
            public static readonly Modes Asynchronous = "async";

            /// <summary>
            /// Gets the absence of async for a synchronous member signature.
            /// </summary>
            public static readonly Modes Synchronous = string.Empty;

            private Modes(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Returns the C# async modifier text.
            /// </summary>
            /// <returns>The async modifier text.</returns>
            public override string ToString()
            {
                return _value;
            }
        }
    }
}