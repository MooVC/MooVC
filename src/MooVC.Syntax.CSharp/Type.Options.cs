namespace MooVC.Syntax.CSharp
{
    using System.ComponentModel.DataAnnotations;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Type_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# type symbol.
    /// </summary>
    public partial class Type
    {
        /// <summary>
        /// Represents top-level rendering options for type declarations.
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
            [Required(ErrorMessageResourceName = nameof(OptionsAttributesRequired), ErrorMessageResourceType = typeof(Type_Resources))]
            public Attribute.Options Attributes { get; internal set; } = Attribute.Options.Unspecified;

            /// <summary>
            /// Gets the Event options.
            /// </summary>
            /// <value>The Event options.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsEventsRequired), ErrorMessageResourceType = typeof(Type_Resources))]
            public Event.Options Events { get; internal set; } = Event.Options.Default;

            /// <summary>
            /// Gets the Indexer options.
            /// </summary>
            /// <value>The Indexer options.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsIndexersRequired), ErrorMessageResourceType = typeof(Type_Resources))]
            public Indexer.Options Indexers { get; internal set; } = Indexer.Options.Default;

            /// <summary>
            /// Gets the Method options.
            /// </summary>
            /// <value>The Method options.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsMethodsRequired), ErrorMessageResourceType = typeof(Type_Resources))]
            public Method.Options Methods { get; internal set; } = Method.Options.Default;

            /// <summary>
            /// Gets the Property options.
            /// </summary>
            /// <value>The Property options.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsPropertiesRequired), ErrorMessageResourceType = typeof(Type_Resources))]
            public Property.Options Properties { get; internal set; } = Property.Options.Default;

            /// <summary>
            /// Gets the Symbol options.
            /// </summary>
            /// <value>The Symbol options.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsQualificationsRequired), ErrorMessageResourceType = typeof(Type_Resources))]
            public Qualification.Options Qualifications { get; internal set; } = Qualification.Options.Unspecified;

            /// <summary>
            /// Gets the Snippets options.
            /// </summary>
            /// <value>The Snippets options.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsSnippetsRequired), ErrorMessageResourceType = typeof(Type_Resources))]
            public Snippet.Options Snippets { get; internal set; } = Snippet.Options.Unspecified;

            /// <summary>
            /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Attribute.Options" />.
            /// </summary>
            /// <param name="options">The <see cref="Options" /> value to convert.</param>
            /// <returns>The converted <see cref="Attribute.Options" /> value.</returns>
            public static implicit operator Attribute.Options(Options options)
            {
                Guard.Against.Conversion<Options, Attribute.Options>(options);

                return options.Attributes
                    .ForkOn(
                        attributes => attributes.Qualifications.IsUnspecified,
                        attributes => attributes.WithQualifications(options.Qualifications),
                        _ => _)
                    .ForkOn(
                        attributes => attributes.Snippets.IsUnspecified,
                        attributes => attributes.WithSnippets(options.Snippets),
                        _ => _);
            }

            /// <summary>
            /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Event.Options" />.
            /// </summary>
            /// <param name="options">The <see cref="Options" /> value to convert.</param>
            /// <returns>The converted <see cref="Event.Options" /> value.</returns>
            public static implicit operator Event.Options(Options options)
            {
                Guard.Against.Conversion<Options, Event.Options>(options);

                return options.Events.ForkOn(events => events.Snippets.IsUnspecified, events => events.WithSnippets(options.Snippets), _ => _);
            }

            /// <summary>
            /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Indexer.Options" />.
            /// </summary>
            /// <param name="options">The <see cref="Options" /> value to convert.</param>
            /// <returns>The converted <see cref="Indexer.Options" /> value.</returns>
            public static implicit operator Indexer.Options(Options options)
            {
                Guard.Against.Conversion<Options, Indexer.Options>(options);

                return options.Indexers.ForkOn(
                    indexers => indexers.Snippets.IsUnspecified,
                    indexers => indexers.WithSnippets(options.Snippets),
                    _ => _);
            }

            /// <summary>
            /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Method.Options" />.
            /// </summary>
            /// <param name="options">The <see cref="Options" /> value to convert.</param>
            /// <returns>The converted <see cref="Method.Options" /> value.</returns>
            public static implicit operator Method.Options(Options options)
            {
                Guard.Against.Conversion<Options, Method.Options>(options);

                return options.Methods
                    .ForkOn(methods => methods.Qualifications.IsUnspecified, methods => methods.WithQualifications(options.Qualifications), _ => _)
                    .ForkOn(methods => methods.Snippets.IsUnspecified, methods => methods.WithSnippets(options.Snippets), _ => _);
            }

            /// <summary>
            /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Property.Options" />.
            /// </summary>
            /// <param name="options">The <see cref="Options" /> value to convert.</param>
            /// <returns>The converted <see cref="Property.Options" /> value.</returns>
            public static implicit operator Property.Options(Options options)
            {
                Guard.Against.Conversion<Options, Property.Options>(options);

                return options.Properties
                    .ForkOn(
                        properties => properties.Qualifications.IsUnspecified,
                        properties => properties.WithQualifications(options.Qualifications),
                        _ => _)
                    .ForkOn(
                        properties => properties.Snippets.IsUnspecified,
                        properties => properties.WithSnippets(options.Snippets),
                        _ => _);
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