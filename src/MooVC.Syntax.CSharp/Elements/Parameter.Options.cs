namespace MooVC.Syntax.CSharp.Elements
{
    using System.ComponentModel.DataAnnotations;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
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
            /// Gets the naming on the Options.
            /// </summary>
            /// <value>The naming.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsNamingRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
            public Variable.Options Naming { get; internal set; } = Variable.Options.Camel;

            /// <summary>
            /// Gets the types on the Options.
            /// </summary>
            /// <value>The types.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsTypesRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
            public Symbol.Options Types { get; internal set; } = Symbol.Options.Default;

            public static implicit operator Variable.Options(Options options)
            {
                Guard.Against.Conversion<Options, Variable.Options>(options);

                return options.Naming;
            }

            public static implicit operator Symbol.Options(Options options)
            {
                Guard.Against.Conversion<Options, Symbol.Options>(options);

                return options.Types;
            }
        }
    }
}