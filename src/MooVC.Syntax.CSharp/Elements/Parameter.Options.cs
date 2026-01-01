namespace MooVC.Syntax.CSharp.Elements
{
    using System.ComponentModel.DataAnnotations;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.CSharp.Elements.Parameter_Resources;

    /// <summary>
    /// Represents a c# syntax element parameter.
    /// </summary>
    public partial class Parameter
    {
        /// <summary>
        /// Defines options for the Parameter c# syntax element.
        /// </summary>
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            /// <summary>
            /// Gets the camel option for the Parameter c# syntax element.
            /// </summary>
            public static readonly Options Camel = new Options();

            /// <summary>
            /// Gets the pascal option for the Parameter c# syntax element.
            /// </summary>
            public static readonly Options Pascal = new Options
            {
                Naming = Variable.Options.Pascal,
            };

            /// <summary>
            /// Gets or sets the naming option for the Parameter c# syntax element.
            /// </summary>
            [Required(ErrorMessageResourceName = nameof(OptionsNamingRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
            public Variable.Options Naming { get; internal set; } = Variable.Options.Camel;

            /// <summary>
            /// Gets or sets the types option for the Parameter c# syntax element.
            /// </summary>
            [Required(ErrorMessageResourceName = nameof(OptionsTypesRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
            public Symbol.Options Types { get; internal set; } = Symbol.Options.Default;
        }
    }
}