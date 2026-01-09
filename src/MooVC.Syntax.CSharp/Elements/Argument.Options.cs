namespace MooVC.Syntax.CSharp.Elements
{
    using System.ComponentModel.DataAnnotations;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.CSharp.Elements.Argument_Resources;
    using Code = MooVC.Syntax.Elements.Snippet;

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
            /// Gets or sets the formatter on the Options.
            /// </summary>
            /// <value>The formatter.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsFormatterRequired), ErrorMessageResourceType = typeof(Argument_Resources))]
            public Formatter Formatter { get; set; } = Formatter.Call;

            /// <summary>
            /// Gets or sets the naming on the Options.
            /// </summary>
            /// <value>The naming.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsNamingRequired), ErrorMessageResourceType = typeof(Argument_Resources))]
            public Variable.Options Naming { get; set; } = Variable.Options.Camel;

            /// <summary>
            /// Gets or sets the snippet on the Options.
            /// </summary>
            /// <value>The snippet.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsSnippetRequired), ErrorMessageResourceType = typeof(Argument_Resources))]
            public Code.Options Snippet { get; set; } = Code.Options.Default;
        }
    }
}