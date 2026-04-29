namespace MooVC.Syntax.CSharp
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Attribute_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a parameter signature component used by members and delegates.
    /// </summary>
    public partial class Attribute
    {
        /// <summary>
        /// Defines rendering options for attribute declarations.
        /// </summary>
        [AutoInitializeWith(nameof(Separate))]
        [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
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
            /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Snippet.Options" />.
            /// </summary>
            /// <param name="options">The <see cref="Options" /> value to convert.</param>
            /// <returns>The converted <see cref="Snippet.Options" /> value.</returns>
            public static implicit operator Snippet.Options(Options options)
            {
                Guard.Against.Conversion<Options, Snippet.Options>(options);

                return options.Snippets;
            }

            /// <summary>
            /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Qualification.Options" />.
            /// </summary>
            /// <param name="options">The <see cref="Options" /> value to convert.</param>
            /// <returns>The converted <see cref="Qualification.Options" /> value.</returns>
            public static implicit operator Qualification.Options(Options options)
            {
                Guard.Against.Conversion<Options, Qualification.Options>(options);

                return options.Qualifications;
            }

            /// <summary>
            /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Styles" />.
            /// </summary>
            /// <param name="options">The <see cref="Options" /> value to convert.</param>
            /// <returns>The converted <see cref="Styles" /> value.</returns>
            public static implicit operator Styles(Options options)
            {
                Guard.Against.Conversion<Options, Styles>(options);

                return options.Format;
            }

            private string GetDebuggerDisplay()
            {
                return $"{nameof(Options)} {{ " +
                    $"{nameof(Format)} = {DebuggerDisplayFormatter.Format(Format)}, " +
                    $"{nameof(IsInline)} = {DebuggerDisplayFormatter.Format(IsInline)}, " +
                    $"{nameof(IsSeparate)} = {DebuggerDisplayFormatter.Format(IsSeparate)}, " +
                    $"{nameof(IsUnspecified)} = {DebuggerDisplayFormatter.Format(IsUnspecified)}, " +
                    $"{nameof(Qualifications)} = {DebuggerDisplayFormatter.Format(Qualifications)}, " +
                    $"{nameof(Snippets)} = {DebuggerDisplayFormatter.Format(Snippets)} }}";
            }
        }
    }
}