namespace MooVC.Syntax.CSharp
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Indexer_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents an indexer declaration model.
    /// </summary>
    public partial class Indexer
    {
        /// <summary>
        /// Defines rendering options for indexer declarations.
        /// </summary>
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
            /// Gets the implicit scope for the Indexer.
            /// </summary>
            /// <value>The implicit scope.</value>
            /// <remarks>If the Indexer is configured to have the same scope as the implicit scope, the keyword will not be rendered.</remarks>
            [Required(ErrorMessageResourceName = nameof(OptionsImpliedRequired), ErrorMessageResourceType = typeof(Indexer_Resources))]
            public Scopes Implied { get; internal set; } = Scopes.Unspecified;

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
            /// Gets the options for the Snippets.
            /// </summary>
            /// <value>The behaviour.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsSnippetsRequired), ErrorMessageResourceType = typeof(Indexer_Resources))]
            public Snippet.Options Snippets { get; internal set; } = Snippet.Options.Default
                .WithBlock(blocks => blocks
                    .WithInline(Snippet.Options.Blocks.Styles.Lambda));

            /// <summary>
            /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Scopes" />.
            /// </summary>
            /// <param name="options">The <see cref="Options" /> value to convert.</param>
            /// <returns>The converted <see cref="Scopes" /> value.</returns>
            public static implicit operator Scopes(Options options)
            {
                Guard.Against.Conversion<Options, Scopes>(options);

                return options.Implied;
            }

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
        }
    }
}