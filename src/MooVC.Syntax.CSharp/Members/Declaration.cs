namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Fluentify;
    using MooVC.Syntax.CSharp.Generics;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Declaration_Resources;
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

        public ImmutableArray<Parameter> Parameters { get; set; } = ImmutableArray<Parameter>.Empty;

        public Identifier Name { get; set; } = Identifier.Unnamed;

        public override string ToString()
        {
            if (IsUnspecified)
            {
                return string.Empty;
            }

            string signature = Name;

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
                .IncludeIf(!Parameters.IsDefaultOrEmpty, nameof(Parameters), results, Parameters)
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