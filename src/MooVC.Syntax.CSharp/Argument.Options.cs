namespace MooVC.Syntax.CSharp
{
    using System.ComponentModel.DataAnnotations;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Argument_Resources;
    using Code = MooVC.Syntax.Snippet;

    /// <summary>
    /// Represents a C# syntax element argument.
    /// </summary>
    public partial class Argument
    {
        /// <summary>
        /// Defines options for the Argument C# syntax element.
        /// </summary>
        [AutoInitializeWith(nameof(Call))]
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
                Formatter = Formatter.Declaration,
                Naming = Variable.Options.Pascal,
                Snippet = Code.Options.Default,
            };

            /// <summary>
            /// Gets the formatter on the Options.
            /// </summary>
            /// <value>The formatter.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsFormatterRequired), ErrorMessageResourceType = typeof(Argument_Resources))]
            public Formatter Formatter { get; internal set; } = Formatter.Call;

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
            public Code.Options Snippet { get; internal set; } = Code.Options.Default;

            /// <summary>
            /// Converts argument options into formatter options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The formatter options.</returns>
            public static implicit operator Formatter(Options options)
            {
                Guard.Against.Conversion<Options, Formatter>(options);

                return options.Formatter;
            }

            /// <summary>
            /// Converts argument options into variable naming options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The variable options.</returns>
            public static implicit operator Variable.Options(Options options)
            {
                Guard.Against.Conversion<Options, Variable.Options>(options);

                return options.Naming;
            }

            /// <summary>
            /// Converts argument options into code options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The code options.</returns>
            public static implicit operator Code.Options(Options options)
            {
                Guard.Against.Conversion<Options, Code.Options>(options);

                return options.Snippet;
            }
        }
    }
}