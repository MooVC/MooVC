namespace MooVC.Syntax.CSharp.Elements
{
    using System.ComponentModel.DataAnnotations;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.CSharp.Elements.Parameter_Resources;

    /// <summary>
    /// Represents a C# syntax element parameter.
    /// </summary>
    public partial class Parameter
    {
        /// <summary>
        /// Defines options for the Parameter C# syntax element.
        /// </summary>
        [AutoInitializeWith(nameof(Camel))]
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            /// <summary>
            /// Represents the camel for the Options.
            /// </summary>
            public static readonly Options Camel = new Options();

            /// <summary>
            /// Represents the pascal for the Options.
            /// </summary>
            public static readonly Options Pascal = new Options
            {
                Naming = Variable.Options.Pascal,
            };

            /// <summary>
            /// Gets or sets the naming on the Options.
            /// </summary>
            /// <value>The naming.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsNamingRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
            public Variable.Options Naming { get; internal set; } = Variable.Options.Camel;

            /// <summary>
            /// Gets or sets the types on the Options.
            /// </summary>
            /// <value>The types.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsTypesRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
            public Symbol.Options Types { get; internal set; } = Symbol.Options.Default;
        }
    }
}