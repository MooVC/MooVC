namespace MooVC.Syntax.CSharp.Concepts
{
    using Fluentify;
    using MooVC.Syntax.Elements;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# type syntax options.
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
        /// Gets a value indicating whether the Options is default.
        /// </summary>
        /// <value>A value indicating whether the Options is default.</value>
        [Ignore]
        public bool IsDefault => this == Default;

        /// <summary>
        /// Gets or sets the namespace on the Options.
        /// </summary>
        /// <value>The namespace.</value>
        public Qualifier.Options Namespace { get; internal set; } = Qualifier.Options.File;

        /// <summary>
        /// Gets or sets the snippets on the Options.
        /// </summary>
        /// <value>The snippets.</value>
        public Snippet.Options Snippets { get; internal set; } = Snippet.Options.Default;
    }
}