namespace MooVC.Syntax.CSharp.Members
{
    using System.ComponentModel.DataAnnotations;
    using static MooVC.Syntax.CSharp.Members.Argument_Resources;

    public partial class Argument
    {
        public sealed partial class Options
        {
            public static readonly Options Call = new Options();

            public static readonly Options Declaration = new Options
            {
                Naming = Identifier.Options.Pascal,
                Formatter = Formatter.Declaration,
            };

            [Required(ErrorMessageResourceName = nameof(OptionsNamingRequired), ErrorMessageResourceType = typeof(Argument_Resources))]
            public Identifier.Options Naming { get; set; } = Identifier.Options.Camel;

            [Required(ErrorMessageResourceName = nameof(OptionsFormatterRequired), ErrorMessageResourceType = typeof(Argument_Resources))]
            public Formatter Formatter { get; set; } = Formatter.Call;
        }
    }
}