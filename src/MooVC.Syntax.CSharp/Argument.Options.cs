namespace MooVC.Syntax.CSharp
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Argument_Resources;

    /// <summary>
    /// Represents an argument expression used in generated C# member invocations.
    /// </summary>
    public partial class Argument
    {
        /// <summary>
        /// Defines formatting and naming options used when rendering arguments.
        /// </summary>
        [AutoInitializeWith(nameof(Call))]
        [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            /// <summary>
            /// Represents the call for the Options.
            /// </summary>
            public static readonly Options Call = new Options();

            /// <summary>
            /// Represents the declaration for the Options.
            /// </summary>
            public static readonly Options Declaration = new Options
            {
                Formatter = Formatters.Declaration,
                Naming = Variable.Options.Pascal,
                Snippets = Snippet.Options.Default,
            };

            /// <summary>
            /// Gets the formatter on the Options.
            /// </summary>
            /// <value>The formatter.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsFormatterRequired), ErrorMessageResourceType = typeof(Argument_Resources))]
            public Formatters Formatter { get; internal set; } = Formatters.Call;

            /// <summary>
            /// Gets the naming on the Options.
            /// </summary>
            /// <value>The naming.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsNamingRequired), ErrorMessageResourceType = typeof(Argument_Resources))]
            public Variable.Options Naming { get; internal set; } = Variable.Options.Camel;

            /// <summary>
            /// Gets the snippet on the Options.
            /// </summary>
            /// <value>The snippet.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsSnippetRequired), ErrorMessageResourceType = typeof(Argument_Resources))]
            public Snippet.Options Snippets { get; internal set; } = Snippet.Options.Unspecified;

            /// <summary>
            /// Defines an implicit conversion from <see cref="Options" /> to <see cref="Formatters" />.
            /// </summary>
            /// <param name="options">The <see cref="Options" /> value to convert.</param>
            /// <returns>The converted <see cref="Formatters" /> value.</returns>
            public static implicit operator Formatters(Options options)
            {
                Guard.Against.Conversion<Options, Formatters>(options);

                return options.Formatter;
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

            private string GetDebuggerDisplay()
            {
                return $"{nameof(Options)} {{ " +
                    $"{nameof(Formatter)} = `{DebuggerDisplayFormatter.Format(Formatter)}`, " +
                    $"{nameof(Naming)} = `{DebuggerDisplayFormatter.Format(Naming)}`, " +
                    $"{nameof(Snippets)} = `{DebuggerDisplayFormatter.Format(Snippets)}` }}";
            }
        }
    }
}