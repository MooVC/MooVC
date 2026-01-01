namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.CSharp.Generics;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Declaration_Resources;
    using Identifier = MooVC.Syntax.Elements.Identifier;
    using Ignore = Valuify.IgnoreAttribute;
    using Parameter = MooVC.Syntax.CSharp.Generics.Parameter;

    /// <summary>
    /// Represents a c# member syntax declaration.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Declaration
        : IComparable<Declaration>,
          IValidatableObject
    {
        /// <summary>
        /// Gets the unspecified on the Declaration.
        /// </summary>
        public static readonly Declaration Unspecified = new Declaration();

        /// <summary>
        /// Initializes a new instance of the Declaration class.
        /// </summary>
        internal Declaration()
        {
        }

        /// <summary>
        /// Gets a value indicating whether the Declaration is unspecified.
        /// </summary>
        [Ignore]
        public bool IsUnspecified => this == Unspecified;

        /// <summary>
        /// Gets or sets the name on the Declaration.
        /// </summary>
        [Descriptor("Named")]
        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        /// <summary>
        /// Gets or sets the parameters on the Declaration.
        /// </summary>
        public ImmutableArray<Parameter> Parameters { get; internal set; } = ImmutableArray<Parameter>.Empty;

        /// <summary>
        /// Defines the string operator for the Declaration.
        /// </summary>
        public static implicit operator string(Declaration declaration)
        {
            Guard.Against.Conversion<Declaration, string>(declaration);

            return declaration.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Declaration.
        /// </summary>
        public static implicit operator Snippet(Declaration declaration)
        {
            Guard.Against.Conversion<Declaration, Snippet>(declaration);

            return Snippet.From(declaration);
        }

        /// <summary>
        /// Defines the < operator for the Declaration.
        /// </summary>
        public static bool operator <(Declaration left, Declaration right)
        {
            if (left is null)
            {
                return right is object;
            }

            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Defines the > operator for the Declaration.
        /// </summary>
        public static bool operator >(Declaration left, Declaration right)
        {
            if (left is null)
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Defines the <= operator for the Declaration.
        /// </summary>
        public static bool operator <=(Declaration left, Declaration right)
        {
            return !(left > right);
        }

        /// <summary>
        /// Defines the >= operator for the Declaration.
        /// </summary>
        public static bool operator >=(Declaration left, Declaration right)
        {
            return !(left < right);
        }

        /// <summary>
        /// Compares this Declaration to another instance.
        /// </summary>
        public int CompareTo(Declaration other)
        {
            return other is null
                ? 1
                : Name.CompareTo(other.Name);
        }

        /// <summary>
        /// Returns the string representation of the Declaration.
        /// </summary>
        public override string ToString()
        {
            return ToSnippet(Snippet.Options.Default);
        }

        /// <summary>
        /// Creates a code snippet representation of the c# member syntax.
        /// </summary>
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
                var parameters = Parameters.ToSnippet(Parameter.Names, options);

                signature = $"{signature}<{parameters}>";
            }

            return Snippet.From(options, signature);
        }

        /// <summary>
        /// Validates the Declaration and returns validation results.
        /// </summary>
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