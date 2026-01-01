namespace MooVC.Syntax.CSharp.Elements
{
    using System.ComponentModel.DataAnnotations;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.CSharp.Elements.Argument_Resources;
    using Code = MooVC.Syntax.Elements.Snippet;

    public partial class Argument
    {
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            public static readonly Options Call = new Options();

            public static readonly Options Declaration = new Options
            {
                Formatter = Formatter.Declaration,
                Naming = Variable.Options.Pascal,
                Snippet = Code.Options.Default,
            };

            [Required(ErrorMessageResourceName = nameof(OptionsFormatterRequired), ErrorMessageResourceType = typeof(Argument_Resources))]
            public Formatter Formatter { get; set; } = Formatter.Call;

            [Required(ErrorMessageResourceName = nameof(OptionsNamingRequired), ErrorMessageResourceType = typeof(Argument_Resources))]
            public Variable.Options Naming { get; set; } = Variable.Options.Camel;

            [Required(ErrorMessageResourceName = nameof(OptionsSnippetRequired), ErrorMessageResourceType = typeof(Argument_Resources))]
            public Code.Options Snippet { get; set; } = Code.Options.Default;
        }
    }
}