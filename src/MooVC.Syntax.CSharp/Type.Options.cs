namespace MooVC.Syntax.CSharp
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Chaining;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# type symbol.
    /// </summary>
    public partial class Type
    {
        /// <summary>
        /// Represents a C# type syntax options.
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
            /// Gets a value indicating whether the Options is default.
            /// </summary>
            /// <value>A value indicating whether the Options is default.</value>
            [Ignore]
            public bool IsDefault => this == Default;

            /// <summary>
            /// Gets the Attribute options.
            /// </summary>
            /// <value>The Attribute options.</value>
            public Attribute.Options Attributes { get; internal set; } = Attribute.Options.Unspecified;

            /// <summary>
            /// Gets the Event options.
            /// </summary>
            /// <value>The Event options.</value>
            public Event.Options Events { get; internal set; } = Event.Options.Default;

            /// <summary>
            /// Gets the Indexer options.
            /// </summary>
            /// <value>The Indexer options.</value>
            public Indexer.Options Indexers { get; internal set; } = Indexer.Options.Default;

            /// <summary>
            /// Gets the Method options.
            /// </summary>
            /// <value>The Method options.</value>
            public Method.Options Methods { get; internal set; } = Method.Options.Default;

            /// <summary>
            /// Gets the Property options.
            /// </summary>
            /// <value>The Property options.</value>
            public Property.Options Properties { get; internal set; } = Property.Options.Default;

            /// <summary>
            /// Gets the Snippets options.
            /// </summary>
            /// <value>The Snippets options.</value>
            public Snippet.Options Snippets { get; internal set; } = Snippet.Options.Unspecified;

            /// <summary>
            /// Gets the Symbol options.
            /// </summary>
            /// <value>The Symbol options.</value>
            public Symbol.Options Symbols { get; internal set; } = Symbol.Options.Unspecified;

            /// <summary>
            /// Converts type options into Attribute options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The Attribute options.</returns>
            public static implicit operator Attribute.Options(Options options)
            {
                Guard.Against.Conversion<Options, Attribute.Options>(options);

                return options.Attributes
                    .ForkOn(attributes => attributes.Snippets.IsUnspecified, attributes => attributes.WithSnippets(options.Snippets), _ => _)
                    .ForkOn(attributes => attributes.Symbols.IsUnspecified, attributes => attributes.WithSymbols(options.Symbols), _ => _);
            }

            /// <summary>
            /// Converts type options into Event options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The Event options.</returns>
            public static implicit operator Event.Options(Options options)
            {
                Guard.Against.Conversion<Options, Event.Options>(options);

                return options.Events.ForkOn(events => events.Snippets.IsUnspecified, events => events.WithSnippets(options.Snippets), _ => _);
            }

            /// <summary>
            /// Converts type options into Indexer options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The Indexer options.</returns>
            public static implicit operator Indexer.Options(Options options)
            {
                Guard.Against.Conversion<Options, Indexer.Options>(options);

                return options.Indexers.ForkOn(
                    indexers => indexers.Snippets.IsUnspecified,
                    indexers => indexers.WithSnippets(options.Snippets),
                    _ => _);
            }

            /// <summary>
            /// Converts type options into Method options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The Method options.</returns>
            public static implicit operator Method.Options(Options options)
            {
                Guard.Against.Conversion<Options, Method.Options>(options);

                return options.Methods
                    .ForkOn(methods => methods.Snippets.IsUnspecified, methods => methods.WithSnippets(options.Snippets), _ => _)
                    .ForkOn(methods => methods.Symbols.IsUnspecified, methods => methods.WithSymbols(options.Symbols), _ => _);
            }

            /// <summary>
            /// Converts type options into Property options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The Property options.</returns>
            public static implicit operator Property.Options(Options options)
            {
                Guard.Against.Conversion<Options, Property.Options>(options);

                return options.Properties
                    .ForkOn(properties => properties.Snippets.IsUnspecified, properties => properties.WithSnippets(options.Snippets), _ => _)
                    .ForkOn(properties => properties.Symbols.IsUnspecified, properties => properties.WithSymbols(options.Symbols), _ => _);
            }

            /// <summary>
            /// Converts type options into snippet options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The snippet options.</returns>
            public static implicit operator Snippet.Options(Options options)
            {
                Guard.Against.Conversion<Options, Snippet.Options>(options);

                return options.Snippets;
            }

            /// <summary>
            /// Converts type options into symbol options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The symbol options.</returns>
            public static implicit operator Symbol.Options(Options options)
            {
                Guard.Against.Conversion<Options, Symbol.Options>(options);

                return options.Symbols;
            }
        }
    }
}