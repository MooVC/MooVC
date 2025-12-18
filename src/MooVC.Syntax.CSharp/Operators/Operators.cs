namespace MooVC.Syntax.CSharp.Operators
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Concepts;
    using Valuify;
    using static MooVC.Syntax.CSharp.Operators.Operators_Resources;

    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Operators
        : IValidatableObject
    {
        public static readonly Operators Undefined = new Operators();

        internal Operators()
        {
        }

        public ImmutableArray<Binary> Binaries { get; internal set; } = ImmutableArray<Binary>.Empty;

        public ImmutableArray<Comparison> Comparisons { get; internal set; } = ImmutableArray<Comparison>.Empty;

        public ImmutableArray<Conversion> Conversions { get; internal set; } = ImmutableArray<Conversion>.Empty;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public ImmutableArray<Unary> Unaries { get; internal set; } = ImmutableArray<Unary>.Empty;

        public override string ToString()
        {
            return ToString(Class.Undefined, Snippet.Options.Default);
        }

        public string ToString(Construct construct, Snippet.Options options)
        {
            _ = Guard.Against.Null(construct, message: ToStringConsructRequired.Format(nameof(Construct), nameof(Binary)));
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Operators)));

            if (IsUndefined)
            {
                return string.Empty;
            }

            var binaries = Binaries.ToSnippet(construct, options);
            var comparisons = Comparisons.ToSnippet(construct, options);
            var conversions = Conversions.ToSnippet(construct, options);
            var unaries = Unaries.ToSnippet(construct, options);

            return options.NewLine.Combine(options, binaries, comparisons, conversions, unaries);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .IncludeIf(!Binaries.IsDefaultOrEmpty, nameof(Binaries), Binaries)
                .AndIf(!Comparisons.IsDefaultOrEmpty, nameof(Comparisons), Comparisons)
                .AndIf(!Conversions.IsDefaultOrEmpty, nameof(Conversions), Conversions)
                .AndIf(!Unaries.IsDefaultOrEmpty, nameof(Unaries), Unaries)
                .Results;
        }
    }
}