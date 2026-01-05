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
        /// Represents the async/sync modality applied to a member signature.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInstantiation]
        public sealed partial class Modality
        {
            /// <summary>
            /// Gets the async modifier for an asynchronous member signature.
            /// </summary>
            public static readonly Modality Asynchronous = "async";

            /// <summary>
            /// Gets the absence of async for a synchronous member signature.
            /// </summary>
            public static readonly Modality Synchronous = string.Empty;

            private Modality(string value)
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