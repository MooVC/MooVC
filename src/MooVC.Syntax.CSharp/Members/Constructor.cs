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
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Constructor_Resources;
    using Identifier = MooVC.Syntax.Elements.Identifier;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a c# member syntax constructor.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Constructor
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the Constructor.
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
        /// Gets or sets the body on the Constructor.
        /// </summary>
        public Snippet Body { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the extensibility on the Constructor.
        /// </summary>
        public Extensibility Extensibility { get; internal set; } = Extensibility.Implicit;

        /// <summary>
        /// Gets a value indicating whether the Constructor is undefined.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the parameters on the Constructor.
        /// </summary>
        public ImmutableArray<Parameter> Parameters { get; internal set; } = ImmutableArray<Parameter>.Empty;

        /// <summary>
        /// Gets or sets the scope on the Constructor.
        /// </summary>
        public Scope Scope { get; internal set; } = Scope.Public;

        /// <summary>
        /// Defines the string operator for the Constructor.
        /// </summary>
        public static implicit operator string(Constructor constructor)
        {
            Guard.Against.Conversion<Constructor, string>(constructor);

            return constructor.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Constructor.
        /// </summary>
        public static implicit operator Snippet(Constructor constructor)
        {
            Guard.Against.Conversion<Constructor, Snippet>(constructor);

            return Snippet.From(constructor);
        }

        /// <summary>
        /// Returns the string representation of the Constructor.
        /// </summary>
        public override string ToString()
        {
            return ToSnippet(Identifier.Unnamed, Snippet.Options.Default);
        }

        /// <summary>
        /// Creates a code snippet representation of the c# member syntax.
        /// </summary>
        public Snippet ToSnippet(Snippet.Options options, Type type)
        {
            _ = Guard.Against.Null(type, message: ToStringTypeRequired.Format(nameof(Type), nameof(Constructor)));

            return ToSnippet(type.Name.Name, options);
        }

        /// <summary>
        /// Validates the Constructor and returns validation results.
        /// </summary>
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