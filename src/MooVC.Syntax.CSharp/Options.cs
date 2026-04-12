namespace MooVC.Syntax.CSharp
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Chaining;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents top-level rendering options for type declarations.
    /// </summary>
    /// <remarks>
    /// This type provides implicit conversions to common option subsets so APIs can accept either
    /// aggregate or specialized options.
    /// </remarks>
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
        /// Gets the namespace options.
        /// </summary>
        /// <value>The namespace rendering options.</value>
        public Qualifier.Options Namespace { get; internal set; } = Qualifier.Options.File;

        /// <summary>
        /// Gets the snippet options.
        /// </summary>
        /// <value>The snippet formatting options used during rendering.</value>
        public Snippet.Options Snippets { get; internal set; } = Snippet.Options.Default.WithChaining(new[]
        {
            OneDotPerLine.Instance,
            Parentheses.Instance,
        });

        /// <summary>
        /// Gets the type options.
        /// </summary>
        /// <value>The type rendering options.</value>
        public Type.Options Types { get; internal set; } = Type.Options.Default;

        /// <summary>
        /// Converts the current options to namespace options.
        /// </summary>
        /// <param name="options">The source options.</param>
        /// <returns>The namespace options.</returns>
        /// <remarks>
        /// Conversion fails when <paramref name="options"/> is null.
        /// </remarks>
        public static implicit operator Qualifier.Options(Options options)
        {
            Guard.Against.Conversion<Options, Qualifier.Options>(options);

            return options.Namespace;
        }

        /// <summary>
        /// Converts type options into snippet options.
        /// </summary>
        /// <param name="options">The source options.</param>
        /// <returns>The snippet options.</returns>
        /// <remarks>
        /// Conversion fails when <paramref name="options"/> is null.
        /// </remarks>
        public static implicit operator Snippet.Options(Options options)
        {
            Guard.Against.Conversion<Options, Snippet.Options>(options);

            return options.Snippets;
        }

        /// <summary>
        /// Converts the current options to type options.
        /// </summary>
        /// <param name="options">The source options.</param>
        /// <returns>The type options.</returns>
        /// <remarks>
        /// Conversion fails when <paramref name="options"/> is null. Missing snippet options in
        /// <see cref="Types"/> are automatically populated from <see cref="Snippets"/>.
        /// </remarks>
        public static implicit operator Type.Options(Options options)
        {
            Guard.Against.Conversion<Options, Type.Options>(options);

            return options.Types.ForkOn(types => types.Snippets.IsUnspecified, types => types.WithSnippets(options.Snippets), _ => _);
        }
    }
}