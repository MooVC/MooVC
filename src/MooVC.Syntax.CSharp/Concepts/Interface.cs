namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.CSharp.Generics;
    using MooVC.Syntax.CSharp.Generics.Constraints;
    using MooVC.Syntax.CSharp.Members;
    using MooVC.Syntax.CSharp.Syntax;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Interface
        : Type
    {
        public static readonly Interface Undefined = new Interface();

        private const string Separator = " ";

        internal Interface()
        {
        }

        [Ignore]
        public override bool IsUndefined => this == Undefined;

        protected override Snippet PerformToSnippet(Snippet.Options options)
        {
            Snippet signature = GetSignature(options);

            var events = Events.ToSnippet(options);
            var indexers = Indexers.ToSnippet(options);
            var properties = Properties.ToSnippet(options);

            var methods = Methods
                .Select(method => method.WithResult(result => result.WithMode(Result.Modality.Synchronous)))
                .ToImmutableArray()
                .ToSnippet(options);

            Snippet body = Snippet.Blank.Combine(options, events, properties, indexers, methods);

            return body.Block(options, signature);
        }

        private Snippet GetSignature(Snippet.Options options)
        {
            var clauses = Name.Parameters.ToSnippet(parameter => parameter.Constraints.ToSnippet(options), options);
            string name = Name;
            string partial = IsPartial.Partial();
            string scope = Scope;
            string signature = Separator.Combine(scope, partial, $"interface {name}");

            if (!clauses.IsEmpty)
            {
                return clauses
                    .Shift(options)
                    .Prepend(options, Environment.NewLine)
                    .Prepend(options, signature);
            }

            return Snippet.From(options, signature);
        }
    }
}