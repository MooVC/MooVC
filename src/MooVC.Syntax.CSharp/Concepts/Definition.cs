namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.CSharp.Members;
    using Valuify;
    using static MooVC.Syntax.CSharp.Concepts.Definition_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Definition<T>
        : IValidatableObject
        where T : Type, new()
    {
        public static readonly Definition<T> Empty = new Definition<T>();

        internal Definition()
        {
        }

        [Ignore]
        public bool IsEmpty => this == Empty;

        public Qualifier Namespace { get; internal set; } = Qualifier.Unqualified;

        public T Type { get; internal set; } = new T();

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

            Snippet type = Type.ToSnippet(options.Snippets);

            if (type.IsEmpty)
            {
                return type;
            }

            Snippet @namespace = $"namespace {Namespace}";
            var usings = Usings.ToSnippet(options.Snippets);

            if (!usings.IsEmpty)
            {
                type = type
                    .Prepend(options.Snippets, Environment.NewLine)
                    .Prepend(options.Snippets, usings);
            }

            if (options.Namespace.IsBlock)
            {
                return type.Block(options.Snippets, @namespace);
            }

            @namespace = @namespace
                .Append(';')
                .Append(Environment.NewLine);

            return type.Stack(options.Snippets, @namespace);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsEmpty)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Type), _ => !Type.IsUndefined, Type)
                .And(nameof(Namespace), _ => !Namespace.IsUnqualified, Namespace)
                .AndIf(!Usings.IsDefaultOrEmpty, nameof(Usings), @using => !@using.IsUndefined, Usings)
                .Results;
        }
    }
}