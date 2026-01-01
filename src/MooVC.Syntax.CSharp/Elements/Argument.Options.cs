namespace MooVC.Syntax.CSharp.Elements
{
    using System.ComponentModel.DataAnnotations;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.CSharp.Elements.Argument_Resources;
    using Code = MooVC.Syntax.Elements.Snippet;

    /// <summary>
    /// Represents a c# syntax element argument.
    /// </summary>
    public partial class Argument
    {
        /// <summary>
        /// Defines options for the Argument c# syntax element.
        /// </summary>
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            /// <summary>
            /// Gets the call option for the Argument c# syntax element.
            /// </summary>
            public static readonly Options Call = new Options();

            /// <summary>
            /// Gets the declaration option for the Argument c# syntax element.
            /// </summary>
            public static readonly Options Declaration = new Options
            {
                Formatter = Formatter.Declaration,
                Naming = Variable.Options.Pascal,
                Snippet = Code.Options.Default,
            };

            /// <summary>
            /// Gets or sets the formatter option for the Argument c# syntax element.
            /// </summary>
            [Required(ErrorMessageResourceName = nameof(OptionsFormatterRequired), ErrorMessageResourceType = typeof(Argument_Resources))]
            public Formatter Formatter { get; set; } = Formatter.Call;

            /// <summary>
            /// Gets or sets the naming option for the Argument c# syntax element.
            /// </summary>
            [Required(ErrorMessageResourceName = nameof(OptionsNamingRequired), ErrorMessageResourceType = typeof(Argument_Resources))]
            public Variable.Options Naming { get; set; } = Variable.Options.Camel;

            /// <summary>
            /// Gets or sets the snippet option for the Argument c# syntax element.
            /// </summary>
            [Required(ErrorMessageResourceName = nameof(OptionsSnippetRequired), ErrorMessageResourceType = typeof(Argument_Resources))]
            public Code.Options Snippet { get; set; } = Code.Options.Default;
        }
    }
}