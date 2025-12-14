namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using Fluentify;
    using MooVC.Syntax.CSharp.Generics;
    using MooVC.Syntax.CSharp.Generics.Constraints;
    using MooVC.Syntax.CSharp.Members;
    using MooVC.Syntax.CSharp.Syntax;
    using Valuify;

    [Fluentify]
    [Valuify]
    public sealed partial class Interface
        : Construct
    {
        public static readonly Interface Undefined = new Interface();

        private const string Separator = " ";

        internal Interface()
        {
        }

        public override bool IsUndefined => this == Undefined;

        protected override Snippet ToSnippet(Snippet.Options options)
        {
            Snippet signature = GetSignature(options);

            var events = Events.ToSnippet(options);
            var indexers = Indexers.ToSnippet(options);
            var properties = Properties.ToSnippet(options);
            var methods = Methods.ToSnippet(options);
            Snippet body = options.BlankSpace.Combine(options, events, indexers, properties, methods);

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
                    .Prepend(options, options.NewLine)
                    .Prepend(options, signature);
            }

            return Snippet.From(options, signature);
        }
    }
}