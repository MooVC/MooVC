namespace MooVC.Syntax.CSharp.Members
{
    using System.ComponentModel.DataAnnotations;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Parameter_Resources;

    public partial class Parameter
    {
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            public static readonly Options Camel = new Options();

            public static readonly Options Pascal = new Options
            {
                Naming = Identifier.Options.Pascal,
            };

            [Required(ErrorMessageResourceName = nameof(OptionsNamingRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
            public Identifier.Options Naming { get; internal set; } = Identifier.Options.Camel;

            [Required(ErrorMessageResourceName = nameof(OptionsTypesRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
            public Symbol.Options Types { get; internal set; } = Symbol.Options.Default;
        }
    }
}