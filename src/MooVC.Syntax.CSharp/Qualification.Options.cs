namespace MooVC.Syntax.CSharp
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Qualification_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a symbol reference, including qualification and generic arguments.
    /// </summary>
    public partial class Qualification
    {
        /// <summary>
        /// Defines rendering options used when composing symbol references.
        /// </summary>
        [AutoInitializeWith(nameof(Default))]
        [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
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
            /// Gets the Format on the Options.
            /// </summary>
            /// <value>The Format.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsFormatRequired), ErrorMessageResourceType = typeof(Qualification_Resources))]
            public Formats Format { get; internal set; } = Formats.Minimum;

            public static implicit operator Formats(Options options)
            {
                Guard.Against.Conversion<Options, Formats>(options);

                return options.Format;
            }

            private string GetDebuggerDisplay()
            {
                return $"{nameof(Options)} {{ {nameof(Format)} = {DebuggerDisplayFormatter.Format(Format)}, {nameof(IsDefault)} = {DebuggerDisplayFormatter.Format(IsDefault)}, {nameof(IsUnspecified)} = {DebuggerDisplayFormatter.Format(IsUnspecified)} }}";
            }
        }
    }
}