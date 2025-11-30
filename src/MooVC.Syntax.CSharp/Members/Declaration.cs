namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
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
        private const string Separator = ", ";

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
                string parameters = GetParameterDeclarations();

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

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (Name.IsUnnamed)
            {
                results = results.Append(new ValidationResult(ValidateNameRequired.Format(nameof(Name), nameof(Declaration)), new[] { nameof(Name) }));
            }

            return validationContext
                .IncludeIf(!Parameters.IsDefaultOrEmpty, nameof(Parameters), parameter => !parameter.IsUndefined, results, Parameters)
                .And(nameof(Name), Name)
                .Results;
        }

        private string GetParameterDeclarations()
        {
            string[] parameters = Parameters
                .Select(parameter => parameter.Name.ToString())
                .ToArray();

            return Separator.Combine(parameters);
        }
    }
}