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
    using Generic = MooVC.Syntax.CSharp.Generics.Parameter;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Declaration
        : IValidatableObject
    {
        public static readonly Declaration Unspecified = new Declaration();

        [Ignore]
        public bool IsUnspecified => this == Unspecified;

        public Identifier Name { get; set; } = Identifier.Unnamed;

        public ImmutableArray<Generic> Parameters { get; set; } = ImmutableArray<Generic>.Empty;

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
            if (IsUnspecified)
            {
                return string.Empty;
            }

            string signature = Name.ToString(Identifier.Options.Pascal);

            if (!Parameters.IsDefaultOrEmpty)
            {
                var parameters = Parameters.ToSnippet(Generic.Names);

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