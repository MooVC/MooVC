namespace MooVC.Syntax.CSharp
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Attribute_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# syntax element parameter.
    /// </summary>
    public partial class Attribute
    {
        /// <summary>
        /// Defines options for the Attribute C# syntax element.
        /// </summary>
        [AutoInitializeWith(nameof(Separate))]
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            /// <summary>
            /// Represents the camel for the Options.
            /// </summary>
            public static readonly Options Separate = new Options();

            /// <summary>
            /// Represents the pascal for the Options.
            /// </summary>
            public static readonly Options Inline = new Options
            {
                Format = Styles.Inline,
            };

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
            /// Gets the naming on the Options.
            /// </summary>
            /// <value>The naming.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsStyleRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
            public Styles Format { get; internal set; } = Styles.Separate;

            /// <summary>
            /// Gets a value indicating whether the format style is set to separate.
            /// </summary>
            /// <value>
            /// A value indicating whether the format style is set to separate.
            /// </value>
            [Ignore]
            public bool IsSeparate => Format == Styles.Separate;

            /// <summary>
            /// Gets a value indicating whether the format is inline.
            /// </summary>
            /// <value>
            /// A value indicating whether the format is inline.
            /// </value>
            [Ignore]
            public bool IsInline => Format == Styles.Inline;

            /// <summary>
            /// Gets a value indicating whether the current instance is unspecified.
            /// </summary>
            /// <value>
            /// A value indicating whether the current instance is unspecified.
            /// </value>
            [Ignore]
            public bool IsUnspecified => _isUnspecified;

            /// <summary>
            /// Gets the types on the Options.
            /// </summary>
            /// <value>The types.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsQualificationsRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
            public Qualification.Options Qualifications { get; internal set; } = Qualification.Options.Unspecified;

            /// <summary>
            /// Gets the options for the Snippets.
            /// </summary>
            /// <value>The behaviour.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsSnippetsRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
            public Snippet.Options Snippets { get; internal set; } = Snippet.Options.Unspecified;

            /// <summary>
            /// Converts parameter options into snippet options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The snippet options.</returns>
            public static implicit operator Snippet.Options(Options options)
            {
                Guard.Against.Conversion<Options, Snippet.Options>(options);

                return options.Snippets;
            }

            /// <summary>
            /// Converts parameter options into symbol options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The symbol options.</returns>
            public static implicit operator Qualification.Options(Options options)
            {
                Guard.Against.Conversion<Options, Qualification.Options>(options);

                return options.Qualifications;
            }

            /// <summary>
            /// Defines an implicit conversion from an Options instance to a Style instance.
            /// </summary>
            /// <param name="options">The Options instance to convert to a Style.</param>
            /// <remarks>
            /// This operator enables seamless assignment of an Options object where a Style
            /// is expected, by extracting the Format property from the Options instance.
            /// </remarks>
            public static implicit operator Styles(Options options)
            {
                Guard.Against.Conversion<Options, Styles>(options);

                return options.Format;
            }
        }
    }
}