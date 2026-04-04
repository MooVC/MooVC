namespace MooVC.Syntax.CSharp
{
    using System.Diagnostics.CodeAnalysis;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# member syntax event.
    /// </summary>
    public partial class Event
    {
        /// <summary>
        /// Represents the rendering options for a event.
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
            /// Gets the implicit scope for the Event.
            /// </summary>
            /// <value>The implicit scope.</value>
            /// <remarks>If the Event is configured to have the same scope as the implicit scope, the keyword will not be rendered.</remarks>
            public Scope Implied { get; internal set; } = Scope.Unspecified;

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
            public Snippet.Options Snippets { get; internal set; } = Snippet.Options.Default
                .WithBlock(blocks => blocks
                    .WithInline(Snippet.Options.Blocks.Styles.Lambda));

            /// <summary>
            /// Converts event options into a scope value.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The implied scope.</returns>
            public static implicit operator Scope(Options options)
            {
                Guard.Against.Conversion<Options, Scope>(options);

                return options.Implied;
            }

            /// <summary>
            /// Converts event options into snippet options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The snippet options.</returns>
            public static implicit operator Snippet.Options(Options options)
            {
                Guard.Against.Conversion<Options, Snippet.Options>(options);

                return options.Snippets;
            }
        }
    }
}