namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Concepts;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Formatting;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Constructor_Resources;
    using Identifier = MooVC.Syntax.Elements.Identifier;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# member syntax constructor.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Constructor
        : IValidatableObject
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
        public Scope Scope { get; internal set; } = Scope.Public;

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
        /// Returns the string representation of the Constructor.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Identifier.Unnamed, Snippet.Options.Default);
        }

        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="type">The type.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Snippet.Options options, Type type)
        {
            _ = Guard.Against.Null(type, message: ToStringTypeRequired.Format(nameof(Type), nameof(Constructor)));

            return ToSnippet(type.Name.Name, options);
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

        private Snippet GetSignature(Identifier name, Snippet.Options options)
        {
            string construct = name.ToSnippet(Identifier.Options.Pascal);
            string extensibility = Extensibility;
            var parameters = Parameters.ToSnippet(Parameter.Options.Camel);
            string scope = Scope;
            string signature = Separator.Combine(scope, extensibility, $"{construct}({parameters})");

            return Snippet.From(options, signature);
        }

        private string ToSnippet(Identifier name, Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Body), nameof(Constructor)));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            Snippet signature = GetSignature(name, options);

            return Body.Block(options, signature);
        }
    }
}