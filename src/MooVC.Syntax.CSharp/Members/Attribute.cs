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
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Attribute_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Attribute
        : IValidatableObject
    {
        public static readonly Attribute Unspecified = new Attribute();
        private static readonly Snippet separator = Snippet.From(", ");

        internal Attribute()
        {
        }

        public ImmutableArray<Argument> Arguments { get; internal set; } = ImmutableArray<Argument>.Empty;

        [Ignore]
        public bool IsUnspecified => this == Unspecified;

        public Symbol Name { get; internal set; } = Symbol.Undefined;

        public Specifier Target { get; internal set; } = Specifier.None;

        public static implicit operator string(Attribute attribute)
        {
            Guard.Against.Conversion<Attribute, string>(attribute);

            return attribute.ToString();
        }

        public static implicit operator Snippet(Attribute attribute)
        {
            Guard.Against.Conversion<Attribute, Snippet>(attribute);

            return attribute.ToSnippet(Snippet.Options.Default);
        }

        public override string ToString()
        {
            return ToSnippet(Snippet.Options.Default);
        }

        public Snippet ToSnippet(Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Arguments), nameof(Attribute)));

            if (Name.IsUndefined)
            {
                return Snippet.Empty;
            }

            var value = new StringBuilder();

            if (Target != Specifier.None)
            {
                value = value.Append($"{Target}:");
            }

            value = value.Append(Name);

            if (!Arguments.IsDefaultOrEmpty)
            {
                value = AppendArguments(options, value);
            }

            return Snippet.From(options, $"[{value}]");
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnspecified)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .IncludeIf(!Arguments.IsDefaultOrEmpty, nameof(Arguments), argument => !argument.IsUndefined, Arguments)
                .And(nameof(Name), _ => !Name.IsUndefined, Name)
                .Results;
        }

        private StringBuilder AppendArguments(Snippet.Options options, StringBuilder value)
        {
            Argument.Options declaration = Argument.Options.Declaration.WithSnippet(options);

            Snippet[] arguments = Arguments
                .Select(argument => argument.ToSnippet(declaration))
                .ToArray();

            Snippet syntax = separator.Combine(options, arguments);

            return value.Append($"({syntax})");
        }
    }
}