namespace MooVC.Syntax.CSharp.Elements
{
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents a C# result signature for a member.
    /// </summary>
    public partial class Result
    {
        /// <summary>
        /// Represents the async/sync modality for a member signature.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInstantiation]
        public sealed partial class Modality
        {
            /// <summary>
            /// Gets the async modifier for an asynchronous method signature.
            /// </summary>
            public static readonly Modality Asynchronous = "async";
            /// <summary>
            /// Gets the absence of async for a synchronous method signature.
            /// </summary>
            public static readonly Modality Synchronous = string.Empty;

            private Modality(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Returns the string representation of the Modality.
            /// </summary>
            public override string ToString()
            {
                return _value;
            }
        }
    }
}
