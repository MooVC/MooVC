namespace MooVC.Syntax.CSharp
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Formatting;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Constructor_Resources;
    using static MooVC.Syntax.Snippet.Options.Blocks;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# member syntax constructor.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Constructor
        : IEnumerable<Qualifier>,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Constructor Undefined = new Constructor();

        private const string Separator = " ";

        /// <summary>
        /// Initializes a new instance of the Constructor class.
        /// </summary>
        internal Constructor()
        {
        }

        /// <summary>
        /// Gets the attributes associated with the Property.
        /// </summary>
        /// <value>The attributes.</value>
        [Descriptor("AttributedWith")]
        public ImmutableArray<Attribute> Attributes { get; internal set; } = ImmutableArray<Attribute>.Empty;

        /// <summary>
        /// Gets the body on the Constructor.
        /// </summary>
        /// <value>The body.</value>
        public Snippet Body { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the extensibility on the Constructor.
        /// </summary>
        /// <value>The extensibility.</value>
        public Extensibility Extensibility { get; internal set; } = Extensibility.Implicit;

        /// <summary>
        /// Gets a value indicating whether the Constructor is undefined.
        /// </summary>
        /// <value>A value indicating whether the Constructor is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the parameters on the Constructor.
        /// </summary>
        /// <value>The parameters.</value>
        public ImmutableArray<Parameter> Parameters { get; internal set; } = ImmutableArray<Parameter>.Empty;

        /// <summary>
        /// Gets the scope on the Constructor.
        /// </summary>
        /// <value>The scope.</value>
        public Scopes Scope { get; internal set; } = Scopes.Public;

        /// <summary>
        /// Defines the string operator for the Constructor.
        /// </summary>
        /// <param name="constructor">The constructor.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Constructor constructor)
        {
            Guard.Against.Conversion<Constructor, string>(constructor);

            return constructor.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Constructor.
        /// </summary>
        /// <param name="constructor">The constructor.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Constructor constructor)
        {
            Guard.Against.Conversion<Constructor, Snippet>(constructor);

            return Snippet.From(constructor);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection of symbols.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection of symbols.</returns>
        public IEnumerator<Qualifier> GetEnumerator()
        {
            foreach (Qualifier qualifier in Attributes.SelectMany(attribute => attribute)
                .Concat(Parameters.SelectMany(parameter => parameter)))
            {
                yield return qualifier;
            }
        }

        /// <summary>
        /// Returns the string representation of the Constructor.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Name.Unnamed, Type.Options.Default);
        }

        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="type">The type.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Type.Options options, Type type)
        {
            _ = Guard.Against.Null(type, message: ToStringTypeRequired.Format(nameof(Type), nameof(Constructor)));

            return ToSnippet(type.Declaration.Name, options);
        }

        /// <summary>
        /// Validates the Constructor.
        /// </summary>
        /// <remarks>Required members include: Parameters.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .IncludeIf(!Parameters.IsDefaultOrEmpty, nameof(Parameters), parameter => !parameter.IsUndefined, Parameters)
                .Results;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Snippet GetSignature(Name name, Type.Options options)
        {
            var attributes = Attributes.ToSnippet(options);
            string extensibility = Extensibility;
            var parameters = Parameters.ToSnippet(Parameter.Options.Camel);
            string scope = Scope;
            string signature = Separator.Combine(scope, extensibility, $"{name}({parameters})");

            return Snippet
                .From(options, signature)
                .Prepend(options, attributes);
        }

        private string ToSnippet(Name name, Type.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Body), nameof(Constructor)));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            Snippet signature = GetSignature(name, options);
            Snippet.Options snippets = FormatBlockStyle(options);

            return Body.Block(snippets, signature);
        }

        private Snippet.Options FormatBlockStyle(Snippet.Options options)
        {
            if (Body.IsSingleLine && options.Block.Inline.IsLambda)
            {
                return options.WithBlock(block => block
                    .WithInline(Styles.SingleLine));
            }

            return options;
        }
    }
}