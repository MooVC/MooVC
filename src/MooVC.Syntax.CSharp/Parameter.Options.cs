namespace MooVC.Syntax.CSharp
{
    using System.ComponentModel.DataAnnotations;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Parameter_Resources;

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
            /// Gets the Attribute options.
            /// </summary>
            /// <value>The Attribute options.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsAttributesRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
            public Attribute.Options Attributes { get; internal set; } = Attribute.Options.Inline;

            /// <summary>
            /// Gets the naming on the Options.
            /// </summary>
            /// <value>The naming.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsNamingRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
            public Variable.Options Naming { get; internal set; } = Variable.Options.Camel;

            /// <summary>
            /// Gets the options for the Snippets.
            /// </summary>
            /// <value>The behaviour.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsSnippetsRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
            public Snippet.Options Snippets { get; internal set; } = Snippet.Options.Default;

            /// <summary>
            /// Gets the types on the Options.
            /// </summary>
            /// <value>The types.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsTypesRequired), ErrorMessageResourceType = typeof(Parameter_Resources))]
            public Symbol.Options Types { get; internal set; } = Symbol.Options.Default;

            /// <summary>
            /// Converts Parameter options into Attribute options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The Attribute options.</returns>
            public static implicit operator Attribute.Options(Options options)
            {
                Guard.Against.Conversion<Options, Attribute.Options>(options);

                return options.Attributes;
            }

            /// <summary>
            /// Converts parameter options into snippet options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The snippet options.</returns>
            public static implicit operator Snippet.Options(Options options)
            {
                Guard.Against.Conversion<Options, Snippet.Options>(options);

                return options.Snippets;
            }

            /// <summary>
            /// Converts parameter options into symbol options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The symbol options.</returns>
            public static implicit operator Symbol.Options(Options options)
            {
                Guard.Against.Conversion<Options, Symbol.Options>(options);

                return options.Types;
            }

            /// <summary>
            /// Converts parameter options into variable naming options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The variable options.</returns>
            public static implicit operator Variable.Options(Options options)
            {
                Guard.Against.Conversion<Options, Variable.Options>(options);

                return options.Naming;
            }
        }
    }
}