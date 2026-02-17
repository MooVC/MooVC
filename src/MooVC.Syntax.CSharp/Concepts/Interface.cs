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
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Formatting;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# type syntax interface.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Interface
        : Type
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Interface Undefined = new Interface();

        private const string Separator = " ";

        /// <summary>
        /// Gets a value indicating whether the Interface is undefined.
        /// </summary>
        /// <value>A value indicating whether the Interface is undefined.</value>
        [Ignore]
        public override bool IsUndefined => this == Undefined;

        /// <summary>
        /// Performs the perform to snippet operation for the C# type syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The snippet.</returns>
        protected override Snippet PerformToSnippet(Snippet.Options options)
        {
            Snippet signature = GetSignature(options);

            var events = Events.ToSnippet(new Event.Options { Implied = Scope.Public, Snippets = options });
            var indexers = Indexers.ToSnippet(new Indexer.Options { Implied = Scope.Public, Snippets = options });
            var properties = Properties.ToSnippet(new Property.Options { Implied = Scope.Public, Snippets = options });

            var methods = Methods
                .Select(method => method.Returns(result => result.WithMode(Result.Modality.Synchronous)))
                .ToImmutableArray()
                .ToSnippet(new Method.Options { Implied = Scope.Public, Snippets = options });

            Snippet body = Snippet.Blank.Combine(options, events, properties, indexers, methods);

            return body.Block(options, signature);
        }

        private Snippet GetSignature(Snippet.Options options)
        {
            var clauses = Declaration.Parameters.ToSnippet(parameter => parameter.Constraints.ToSnippet(options), options);
            string name = Declaration;
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