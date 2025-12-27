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

            Snippet construct = Construct.ToSnippet(options.Snippets);

            if (construct.IsEmpty)
            {
                return construct;
            }

            Snippet @namespace = $"namespace {Namespace}";
            var usings = Usings.ToSnippet(options.Snippets);

            if (!usings.IsEmpty)
            {
                construct = construct
                    .Prepend(options.Snippets, Environment.NewLine)
                    .Prepend(options.Snippets, usings);
            }

            if (options.Namespace.IsBlock)
            {
                return construct.Block(options.Snippets, @namespace);
            }

            @namespace = @namespace
                .Append(';')
                .Append(Environment.NewLine);

            return construct.Stack(options.Snippets, @namespace);
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