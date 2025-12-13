namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Generics;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Declaration_Resources;
    using Generic = MooVC.Syntax.CSharp.Generics.Parameter;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Declaration
        : IValidatableObject
    {
        public static readonly Declaration Unspecified = new Declaration();

        internal Declaration()
        {
        }

        [Ignore]
        public bool IsUnspecified => this == Unspecified;

        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        public ImmutableArray<Generic> Parameters { get; internal set; } = ImmutableArray<Generic>.Empty;

        public static implicit operator string(Declaration declaration)
        {
            Guard.Against.Conversion<Declaration, string>(declaration);

            return declaration.ToString();
        }

        public static implicit operator Snippet(Declaration declaration)
        {
            Guard.Against.Conversion<Declaration, Snippet>(declaration);

            return Snippet.From(declaration);
        }

        public override string ToString()
        {
            return ToString(Snippet.Options.Default);
        }

        public string ToString(Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Declaration)));

            if (IsUnspecified)
            {
                return string.Empty;
            }

            string signature = Name.ToString(Identifier.Options.Pascal);

            if (!Parameters.IsDefaultOrEmpty)
            {
                var parameters = Parameters.ToSnippet(Generic.Names, options);

                signature = $"{signature}<{parameters}>";
            }

            return signature;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnspecified)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Name), _ => !Name.IsUnnamed, Name)
                .AndIf(!Parameters.IsDefaultOrEmpty, nameof(Parameters), parameter => !parameter.IsUndefined, Parameters)
                .Results;
        }
    }
}