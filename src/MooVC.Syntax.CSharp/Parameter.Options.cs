namespace MooVC.Syntax.CSharp
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Parameter_Resources;

    /// <summary>
    /// Represents a parameter signature component used by members and delegates.
    /// </summary>
    public partial class Parameter
    {
        /// <summary>
        /// Defines formatting and naming options used when rendering parameters.
        /// </summary>
        [AutoInitializeWith(nameof(Camel))]
        [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            /// <summary>
            /// Represents the camel for the Options.
            /// </summary>
            public static readonly Options Camel = new Options();

            /// <summary>
            /// Represents the pascal for the Options.
            /// </summary>
            public static readonly Options Pascal = new Options
            {
                Naming = Variable.Options.Pascal,
            };

            /// <summary>
            /// Gets the Attribute options.
            /// </summary>
            /// <value>The Attribute options.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsAttributesRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
            public Attribute.Options Attributes { get; internal set; } = Attribute.Options.Inline;

            /// <summary>
            /// Gets the naming on the Options.
            /// </summary>
            /// <value>The naming.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsNamingRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
            public Variable.Options Naming { get; internal set; } = Variable.Options.Camel;

            /// <summary>
            /// Gets the types on the Options.
            /// </summary>
            /// <value>The types.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsTypesRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
            public Qualification.Options Qualifications { get; internal set; } = Qualification.Options.Unspecified;

            /// <summary>
            /// Gets the options for the Snippets.
            /// </summary>
            /// <value>The behaviour.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsSnippetsRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
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

            /// <summary>
            /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Variable.Options" />.
            /// </summary>
            /// <param name="options">The <see cref="Options" /> value to convert.</param>
            /// <returns>The converted <see cref="Variable.Options" /> value.</returns>
            public static implicit operator Variable.Options(Options options)
            {
                Guard.Against.Conversion<Options, Variable.Options>(options);

                return options.Naming;
            }

            private string GetDebuggerDisplay()
            {
                return $"{nameof(Options)} {{ " +
                    $"{nameof(Attributes)} = {DebuggerDisplayFormatter.Format(Attributes)}, " +
                    $"{nameof(Naming)} = {DebuggerDisplayFormatter.Format(Naming)}, " +
                    $"{nameof(Qualifications)} = {DebuggerDisplayFormatter.Format(Qualifications)}, " +
                    $"{nameof(Snippets)} = {DebuggerDisplayFormatter.Format(Snippets)} }}";
            }
        }
    }
}