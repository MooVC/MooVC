namespace MooVC.Syntax.CSharp.Elements
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;

    /// <summary>
    /// Represents a C# syntax element symbol.
    /// </summary>
    public partial class Symbol
    {
        /// <summary>
        /// Defines options for the Symbol C# syntax element.
        /// </summary>
        [AutoInitializeWith(nameof(Default))]
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            /// <summary>
            /// Gets the default instance.
            /// </summary>
            public static readonly Options Default = new Options();

            /// <summary>
            /// Gets the qualification on the Options.
            /// </summary>
            /// <value>The qualification.</value>
            public Qualification Qualification { get; internal set; } = Qualification.Minimum;

            public static implicit operator Qualification(Options options)
            {
                Guard.Against.Conversion<Options, Qualification>(options);

                return options.Qualification;
            }
        }
    }
}