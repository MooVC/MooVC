namespace MooVC.Syntax.CSharp
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Chaining;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Options_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents top-level rendering options for type declarations.
    /// </summary>
    /// <remarks>
    /// This type provides implicit conversions to nested settings so APIs can accept either aggregate or specialized options.
    /// Shared attribute and qualification settings are taken from the type-level options.
    /// </remarks>
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
        /// Gets a value indicating whether the Options is default.
        /// </summary>
        /// <value>A value indicating whether the Options is default.</value>
        [Ignore]
        public bool IsDefault => this == Default;

        /// <summary>
        /// Gets the namespace options.
        /// </summary>
        /// <value>The namespace rendering options.</value>
        [Required(ErrorMessageResourceName = nameof(OptionsNamespaceRequired), ErrorMessageResourceType = typeof(Options_Resources))]
        public Qualifier.Options Namespace { get; internal set; } = Qualifier.Options.File;

        /// <summary>
        /// Gets the snippet options.
        /// </summary>
        /// <value>The snippet formatting options used during rendering.</value>
        [Required(ErrorMessageResourceName = nameof(OptionsSnippetsRequired), ErrorMessageResourceType = typeof(Options_Resources))]
        public Snippet.Options Snippets { get; internal set; } = Snippet.Options.Default.WithChaining(new[]
        {
            OneDotPerLine.Instance,
            Parentheses.Instance,
        });

        /// <summary>
        /// Gets the type options.
        /// </summary>
        /// <value>The type rendering options.</value>
        [Required(ErrorMessageResourceName = nameof(OptionsTypesRequired), ErrorMessageResourceType = typeof(Options_Resources))]
        public Type.Options Types { get; internal set; } = Type.Options.Default;

        /// <summary>
        /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Attribute.Options" />.
        /// </summary>
        /// <param name="options">The <see cref="Options" /> value to convert.</param>
        /// <returns>The type-level attribute options.</returns>
        public static implicit operator Attribute.Options(Options options)
        {
            Guard.Against.Conversion<Options, Attribute.Options>(options);

            return (Type.Options)options;
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Attribute.Options.Styles" />.
        /// </summary>
        /// <param name="options">The <see cref="Options" /> value to convert.</param>
        /// <returns>The type-level attribute formatting style.</returns>
        public static implicit operator Attribute.Options.Styles(Options options)
        {
            Guard.Against.Conversion<Options, Attribute.Options.Styles>(options);

            return options.Types.Attributes.Format;
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Event.Options" />.
        /// </summary>
        /// <param name="options">The <see cref="Options" /> value to convert.</param>
        /// <returns>The converted <see cref="Event.Options" /> value.</returns>
        public static implicit operator Event.Options(Options options)
        {
            Guard.Against.Conversion<Options, Event.Options>(options);

            return (Type.Options)options;
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Identifier.Casing" />.
        /// </summary>
        /// <param name="options">The <see cref="Options" /> value to convert.</param>
        /// <returns>The converted <see cref="Identifier.Casing" /> value.</returns>
        public static implicit operator Identifier.Casing(Options options)
        {
            Guard.Against.Conversion<Options, Identifier.Casing>(options);

            return (Variable.Options)options;
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Identifier.Options" />.
        /// </summary>
        /// <param name="options">The <see cref="Options" /> value to convert.</param>
        /// <returns>The converted <see cref="Identifier.Options" /> value.</returns>
        public static implicit operator Identifier.Options(Options options)
        {
            Guard.Against.Conversion<Options, Identifier.Options>(options);

            return (Variable.Options)options;
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Indexer.Options" />.
        /// </summary>
        /// <param name="options">The <see cref="Options" /> value to convert.</param>
        /// <returns>The converted <see cref="Indexer.Options" /> value.</returns>
        public static implicit operator Indexer.Options(Options options)
        {
            Guard.Against.Conversion<Options, Indexer.Options>(options);

            return (Type.Options)options;
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Method.Options" />.
        /// </summary>
        /// <param name="options">The <see cref="Options" /> value to convert.</param>
        /// <returns>The converted <see cref="Method.Options" /> value.</returns>
        public static implicit operator Method.Options(Options options)
        {
            Guard.Against.Conversion<Options, Method.Options>(options);

            return (Type.Options)options;
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Parameter.Options" />.
        /// </summary>
        /// <param name="options">The <see cref="Options" /> value to convert.</param>
        /// <returns>The converted <see cref="Parameter.Options" /> value.</returns>
        public static implicit operator Parameter.Options(Options options)
        {
            Guard.Against.Conversion<Options, Parameter.Options>(options);

            return (Method.Options)options;
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Property.Options" />.
        /// </summary>
        /// <param name="options">The <see cref="Options" /> value to convert.</param>
        /// <returns>The converted <see cref="Property.Options" /> value.</returns>
        public static implicit operator Property.Options(Options options)
        {
            Guard.Against.Conversion<Options, Property.Options>(options);

            return (Type.Options)options;
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Qualification.Options" />.
        /// </summary>
        /// <param name="options">The <see cref="Options" /> value to convert.</param>
        /// <returns>The type-level qualification options.</returns>
        public static implicit operator Qualification.Options(Options options)
        {
            Guard.Against.Conversion<Options, Qualification.Options>(options);

            return options.Types.Qualifications;
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Qualification.Options.Formats" />.
        /// </summary>
        /// <param name="options">The <see cref="Options" /> value to convert.</param>
        /// <returns>The type-level qualification format.</returns>
        public static implicit operator Qualification.Options.Formats(Options options)
        {
            Guard.Against.Conversion<Options, Qualification.Options.Formats>(options);

            return options.Types.Qualifications.Format;
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Qualifier.Options" />.
        /// </summary>
        /// <param name="options">The <see cref="Options" /> value to convert.</param>
        /// <returns>The converted <see cref="Qualifier.Options" /> value.</returns>
        public static implicit operator Qualifier.Options(Options options)
        {
            Guard.Against.Conversion<Options, Qualifier.Options>(options);

            return options.Namespace;
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
        /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Type.Options" />.
        /// </summary>
        /// <param name="options">The <see cref="Options" /> value to convert.</param>
        /// <returns>The converted <see cref="Type.Options" /> value.</returns>
        public static implicit operator Type.Options(Options options)
        {
            Guard.Against.Conversion<Options, Type.Options>(options);

            return options.Types.ForkOn(types => types.Snippets.IsUnspecified, types => types.WithSnippets(options.Snippets), _ => _);
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Variable.Options" />.
        /// </summary>
        /// <param name="options">The <see cref="Options" /> value to convert.</param>
        /// <returns>The converted <see cref="Variable.Options" /> value.</returns>
        public static implicit operator Variable.Options(Options options)
        {
            Guard.Against.Conversion<Options, Variable.Options>(options);

            return (Parameter.Options)options;
        }

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Options)} {{ " +
                $"{nameof(IsDefault)} = `{DebuggerDisplayFormatter.Format(IsDefault)}`, " +
                $"{nameof(Namespace)} = `{DebuggerDisplayFormatter.Format(Namespace)}`, " +
                $"{nameof(Snippets)} = `{DebuggerDisplayFormatter.Format(Snippets)}`, " +
                $"{nameof(Types)} = `{DebuggerDisplayFormatter.Format(Types)}` }}";
        }
    }
}