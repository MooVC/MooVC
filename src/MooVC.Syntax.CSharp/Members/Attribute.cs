namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Linq;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Attribute
        : IValidatableObject
    {
        public static readonly Attribute Unspecified = new Attribute();

        private const string Separator = ", ";

        public ImmutableArray<Argument> Arguments { get; set; } = ImmutableArray<Argument>.Empty;

        [Ignore]
        public bool IsUnspecified => this == Unspecified;

        public Symbol Name { get; set; } = Symbol.Unspecified;

        public Specifier Target { get; set; } = Specifier.None;

        public static implicit operator string(Attribute attribute)
        {
            Guard.Against.Conversion<Attribute, string>(attribute);

            return attribute.ToString();
        }

        public static implicit operator Snippet(Attribute attribute)
        {
            Guard.Against.Conversion<Attribute, Snippet>(attribute);

            return Snippet.From(attribute);
        }

        public override string ToString()
        {
            if (Name.IsUnspecified)
            {
                return string.Empty;
            }

            var value = new StringBuilder();

            if (Target != Specifier.None)
            {
                value = value.Append($"{Target}:");
            }

            value = value.Append(Name);

            string arguments = string.Empty;

            if (!Arguments.IsDefaultOrEmpty)
            {
                arguments = Separator.Combine(Arguments, argument => argument.ToString(Argument.Options.Declaration));

                value = value.Append($"({arguments})");
            }

            return $"[{value}]";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnspecified)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .IncludeIf(!Arguments.IsDefaultOrEmpty, nameof(Arguments), argument => !argument.IsUndefined, Arguments)
                .And(nameof(Name), _ => !Name.IsUnspecified, Name)
                .Results;
        }
    }
}