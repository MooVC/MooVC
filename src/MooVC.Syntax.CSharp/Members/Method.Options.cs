namespace MooVC.Syntax.CSharp.Members
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Concepts;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
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
            /// Gets the mode on the Setter.
            /// </summary>
            /// <value>The mode.</value>
            public Scope Implied { get; internal set; } = Scope.Unspecified;

            /// <summary>
            /// Gets a value indicating whether the Setter is default.
            /// </summary>
            /// <value>A value indicating whether the Setter is default.</value>
            [Ignore]
            public bool IsDefault => this == Default;

            /// <summary>
            /// Gets the options for the Snippets.
            /// </summary>
            /// <value>The snippets.</value>
            public Snippet.Options Snippets { get; internal set; } = Snippet.Options.Default;

            /// <summary>
            /// Gets the options for the Types.
            /// </summary>
            /// <value>The types.</value>
            public Type.Options Types { get; internal set; } = Type.Options.Default;

            public static implicit operator Scope(Options options)
            {
                Guard.Against.Conversion<Options, Scope>(options);

                return options.Implied;
            }

            public static implicit operator Snippet.Options(Options options)
            {
                Guard.Against.Conversion<Options, Snippet.Options>(options);

                return options.Snippets;
            }

            public static implicit operator Type.Options(Options options)
            {
                Guard.Against.Conversion<Options, Type.Options>(options);

                return options.Types;
            }
        }
    }
}