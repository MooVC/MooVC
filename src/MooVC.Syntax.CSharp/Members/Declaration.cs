namespace MooVC.Syntax.CSharp.Members
{
    using System;
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
        : IComparable<Declaration>,
          IValidatableObject
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

        public static bool operator <(Declaration left, Declaration right)
        {
            if (left is null)
            {
                return right is object;
            }

            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Declaration left, Declaration right)
        {
            if (left is null)
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Declaration left, Declaration right)
        {
            return !(left > right);
        }

        public static bool operator >=(Declaration left, Declaration right)
        {
            return !(left < right);
        }

        public int CompareTo(Declaration other)
        {
            return other is null
                ? 1
                : Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return ToSnippet(Snippet.Options.Default);
        }

        public Snippet ToSnippet(Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Declaration)));

            if (IsUnspecified)
            {
                return Snippet.Empty;
            }

            string signature = Name.ToSnippet(Identifier.Options.Pascal);

            if (!Parameters.IsDefaultOrEmpty)
            {
                var parameters = Parameters.ToSnippet(Generic.Names, options);

                signature = $"{signature}<{parameters}>";
            }

            return Snippet.From(options, signature);
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