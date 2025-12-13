namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp;
    using MooVC.Syntax.CSharp.Concepts;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Constructor_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Constructor
        : IValidatableObject
    {
        public static readonly Constructor Undefined = new Constructor();

        private const string Separator = " ";

        internal Constructor()
        {
        }

        public Snippet Body { get; internal set; } = Snippet.Empty;

        public Extensibility Extensibility { get; internal set; } = Extensibility.Implicit;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public ImmutableArray<Parameter> Parameters { get; internal set; } = ImmutableArray<Parameter>.Empty;

        public Scope Scope { get; internal set; } = Scope.Public;

        public static implicit operator string(Constructor constructor)
        {
            Guard.Against.Conversion<Constructor, string>(constructor);

            return constructor.ToString();
        }

        public static implicit operator Snippet(Constructor constructor)
        {
            Guard.Against.Conversion<Constructor, Snippet>(constructor);

            return Snippet.From(constructor);
        }

        public override string ToString()
        {
            return ToString(Identifier.Unnamed, Snippet.Options.Default);
        }

        public string ToString(Construct construct, Snippet.Options options)
        {
            _ = Guard.Against.Null(construct, message: ToStringConsructRequired.Format(nameof(Construct), nameof(Constructor)));
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Constructor)));

            if (IsUndefined)
            {
                return string.Empty;
            }

            Snippet signature = GetSignature(construct.Name.Name, options);

            return Body
                .Block(options, signature)
                .ToString();
        }

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
            string extensibility = Extensibility;
            var parameters = Parameters.ToSnippet(Parameter.Options.Camel);
            string scope = Scope;
            string signature = Separator.Combine(scope, extensibility, $"{name}({parameters})");

            return Snippet.From(options, signature);
        }

        private string ToString(Identifier name, Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Constructor)));

            if (IsUndefined)
            {
                return string.Empty;
            }

            Snippet signature = GetSignature(name, options);

            return Body
                .Block(options, signature)
                .ToString();
        }
    }
}