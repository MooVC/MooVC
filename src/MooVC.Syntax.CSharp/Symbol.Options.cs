namespace MooVC.Syntax.CSharp
{
    using System.Diagnostics.CodeAnalysis;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

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
            /// Represents an options instance with unspecified or default values.
            /// </summary>
            /// <remarks>
            /// Use this field to indicate that no specific options have been set. This can
            /// be useful as a sentinel value or when an explicit 'unspecified' state is required.
            /// </remarks>
            public static readonly Options Unspecified = new Options(true);

            [SuppressMessage("Style", "IDE0032:Use auto property", Justification = "Fields are not set by Fluentify")]
            private readonly bool _isUnspecified;

            /// <summary>
            /// Initializes a new instance of the Options class.
            /// </summary>
            public Options()
            {
            }

            private Options(bool isUnspecified)
            {
                _isUnspecified = isUnspecified;
            }

            /// <summary>
            /// Gets a value indicating whether the Setter is default.
            /// </summary>
            /// <value>A value indicating whether the Setter is default.</value>
            [Ignore]
            public bool IsDefault => this == Default;

            /// <summary>
            /// Gets a value indicating whether the current instance is unspecified.
            /// </summary>
            /// <value>
            /// A value indicating whether the current instance is unspecified.
            /// </value>
            [Ignore]
            public bool IsUnspecified => _isUnspecified;

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