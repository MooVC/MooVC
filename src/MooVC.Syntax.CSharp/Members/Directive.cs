namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Directive_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Directive
        : IValidatableObject
    {
        public static readonly Directive Undefined = new Directive();
        private const string Separator = " ";

        internal Directive()
        {
        }

        public Identifier Alias { get; internal set; } = Identifier.Unnamed;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public bool IsStatic { get; internal set; }

        [Ignore]
        public bool IsSystem => Qualifier.Length > 0 && Qualifier[0] == nameof(System);

        public Qualifier Qualifier { get; internal set; }

        public static implicit operator string(Directive directive)
        {
            Guard.Against.Conversion<Directive, string>(directive);

            return directive.ToString();
        }

        public static implicit operator Snippet(Directive directive)
        {
            Guard.Against.Conversion<Directive, Snippet>(directive);

            return Snippet.From(directive);
        }

        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            string prefix = GetPrefix();
            string qualifier = Qualifier.ToString();

            return Separator.Combine("using", prefix, qualifier);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (IsStatic && !Alias.IsUnnamed)
            {
                results = results.Append(new ValidationResult(
                    ValidateStaticAliasInvalid.Format(Alias, nameof(Alias), Qualifier, nameof(Qualifier)),
                    new[] { nameof(Alias) }));
            }

            return validationContext
                .Include(nameof(Alias), results, Alias)
                .And(nameof(Qualifier), Qualifier)
                .Results;
        }

        private string GetPrefix()
        {
            if (IsStatic)
            {
                return "static";
            }

            if (!Alias.IsUnnamed)
            {
                return $"{Alias.ToString(Identifier.Options.Pascal)} = ";
            }

            return string.Empty;
        }
    }
}