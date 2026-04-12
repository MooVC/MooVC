namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using Fluentify;
    using MooVC.Syntax.CSharp.Syntax;
    using MooVC.Syntax.Formatting;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# interface declaration model.
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
        protected override Snippet PerformToSnippet(Options options)
        {
            Snippet signature = GetSignature(options);

            var events = Events.ToSnippet(options.Events.WithImplied(Scopes.Public));
            var indexers = Indexers.ToSnippet(options.Indexers.WithImplied(Scopes.Public));
            var properties = Properties.ToSnippet(options.Properties.WithImplied(Scopes.Public));

            var methods = Methods
                .Select(method => method.Returns(result => result.WithMode(Result.Modes.Synchronous)))
                .ToImmutableArray()
                .ToSnippet(options.Methods.WithImplied(Scopes.Public));

            var elements = new Snippet[] { events, properties, indexers, methods };
            IEnumerable<Snippet> types = Types.Select(type => type.ToSnippet(options));
            Snippet body = Snippet.Blank.Combine(options, elements.Concat(types).ToArray());

            return body.Block(options.Snippets, signature);
        }

        private Snippet GetSignature(Options options)
        {
            var attributes = Attributes.ToSnippet(options);
            var clauses = Declaration.Arguments.ToSnippet(parameter => parameter.ToConstraintsSnippet(options), options);
            string name = Declaration;
            string partial = IsPartial.Partial();
            string scope = Scope;
            string signature = Separator.Combine(scope, partial, $"interface {name}");

            if (!clauses.IsEmpty)
            {
                return clauses
                    .Shift(options)
                    .Prepend(options, Environment.NewLine)
                    .Prepend(options, signature)
                    .Prepend(options, attributes);
            }

            return Snippet.From(options, signature);
        }
    }
}