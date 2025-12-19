namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Members;
    using Valuify;
    using static MooVC.Syntax.CSharp.Concepts.Definition_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Definition<T>
        : IValidatableObject
        where T : Construct, new()
    {
        public static readonly Definition<T> Empty = new Definition<T>();

        internal Definition()
        {
        }

        public T Construct { get; internal set; } = new T();

        [Ignore]
        public bool IsEmpty => this == Empty;

        public Qualifier Namespace { get; internal set; } = Qualifier.Unqualified;

        public ImmutableArray<Directive> Usings { get; internal set; } = ImmutableArray<Directive>.Empty;

        public override string ToString()
        {
            return ToSnippet(Options.Default);
        }

        public Snippet ToSnippet(Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Definition<T>)));

            if (IsEmpty)
            {
                return string.Empty;
            }

            Snippet @namespace = Namespace;
            var usings = Usings.ToSnippet(options.Snippets);
            Snippet construct = Construct.ToSnippet(options.Snippets);

            if (construct.IsEmpty)
            {
                return construct;
            }

            Snippet definition = Snippet.Empty;

            if (!usings.IsEmpty)
            {
                definition = usings
                    .Append(Environment.NewLine)
                    .Append(options.Snippets);
            }

            if (options.Namespace.IsBlock)
            {
                definition = definition.Block(options.Snippets, @namespace);
            }
            else
            {
                definition = definition
                    .Prepend(Environment.NewLine)
                    .Prepend(@namespace);
            }

            return definition.Prepend(@namespace);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsEmpty)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Construct), _ => !Construct.IsUndefined, Construct)
                .And(nameof(Namespace), _ => !Namespace.IsUnqualified, Namespace)
                .AndIf(!Usings.IsDefaultOrEmpty, nameof(Usings), @using => !@using.IsUndefined, Usings)
                .Results;
        }
    }
}