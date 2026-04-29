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
    /// This type provides implicit conversions to common option subsets so APIs can accept either
    /// aggregate or specialized options.
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

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Options)} {{ " +
                $"{nameof(IsDefault)} = {DebuggerDisplayFormatter.Format(IsDefault)}, " +
                $"{nameof(Namespace)} = {DebuggerDisplayFormatter.Format(Namespace)}, " +
                $"{nameof(Snippets)} = {DebuggerDisplayFormatter.Format(Snippets)}, " +
                $"{nameof(Types)} = {DebuggerDisplayFormatter.Format(Types)} }}";
        }
    }
}