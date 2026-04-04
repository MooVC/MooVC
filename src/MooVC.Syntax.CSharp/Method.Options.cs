namespace MooVC.Syntax.CSharp
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Method_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# member syntax method.
    /// </summary>
    public partial class Method
    {
        /// <summary>
        /// Represents the rendering options for a method.
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
            /// Gets the Attribute options.
            /// </summary>
            /// <value>The Attribute options.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsAttributesRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
            public Attribute.Options Attributes { get; internal set; } = Attribute.Options.Inline;

            /// <summary>
            /// Gets the implicit scope for the Method.
            /// </summary>
            /// <value>The implicit scope.</value>
            /// <remarks>If the Method is configured to have the same scope as the implicit scope, the keyword will not be rendered.</remarks>
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
            /// <value>The snippets.</value>
            public Snippet.Options Snippets { get; internal set; } = Snippet.Options.Unspecified;

            /// <summary>
            /// Gets the options for the Types.
            /// </summary>
            /// <value>The types.</value>
            public Symbol.Options Types { get; internal set; } = Symbol.Options.Default;

            /// <summary>
            /// Converts Method options into Attribute options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The Attribute options.</returns>
            public static implicit operator Attribute.Options(Options options)
            {
                Guard.Against.Conversion<Options, Attribute.Options>(options);

                return options.Attributes
                    .ForkOn(attributes => attributes.Snippets.IsUnspecified, attributes => attributes.WithSnippets(options.Snippets), _ => _)
                    .ForkOn(attributes => attributes.Symbols.IsUnspecified, attributes => attributes.WithSymbols(options.Types), _ => _);
            }

            public static implicit operator Parameter.Options(Options options)
            {
                Guard.Against.Conversion<Options, Parameter.Options>(options);

                return Parameter.Options.Camel
                    .WithSnippets(options.Snippets)
                    .WithTypes(options.Types);
            }

            /// <summary>
            /// Converts method options into scope options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The implied scope.</returns>
            public static implicit operator Scope(Options options)
            {
                Guard.Against.Conversion<Options, Scope>(options);

                return options.Implied;
            }

            /// <summary>
            /// Converts method options into snippet options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The snippet options.</returns>
            public static implicit operator Snippet.Options(Options options)
            {
                Guard.Against.Conversion<Options, Snippet.Options>(options);

                return options.Snippets;
            }

            /// <summary>
            /// Converts method options into type options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The type options.</returns>
            public static implicit operator Symbol.Options(Options options)
            {
                Guard.Against.Conversion<Options, Symbol.Options>(options);

                return options.Types;
            }
        }
    }
}