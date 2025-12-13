namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Fluentify;
    using MooVC.Syntax.CSharp.Generics;
    using MooVC.Syntax.CSharp.Generics.Constraints;
    using MooVC.Syntax.CSharp.Members;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;
    using Parameter = MooVC.Syntax.CSharp.Members.Parameter;

    [Fluentify]
    [Valuify]
    public sealed partial class Struct
        : Construct
    {
        public static readonly Struct Undefined = new Struct();
        private const string Separator = " ";

        public ImmutableArray<Constructor> Constructors { get; internal set; } = ImmutableArray<Constructor>.Empty;

        public ImmutableArray<Field> Fields { get; internal set; } = ImmutableArray<Field>.Empty;

        public ImmutableArray<Parameter> Parameters { get; internal set; } = ImmutableArray<Parameter>.Empty;

        [Ignore]
        public override bool IsUndefined => this == Undefined;

        public Kind Behavior { get; internal set; }

        public override string ToString()
        {
            return ToString(Snippet.Options.Default);
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = base.Validate(validationContext);

            return validationContext
                .IncludeIf(!Constructors.IsDefaultOrEmpty, nameof(Constructors), results, Constructors)
                .AndIf(!Fields.IsDefaultOrEmpty, nameof(Fields), Fields)
                .AndIf(!Parameters.IsDefaultOrEmpty, nameof(Parameters), Parameters)
                .Results;
        }

        protected override Snippet ToSnippet(Snippet.Options options)
        {
            Snippet signature = GetSignature(options);

            var constructors = Constructors.ToSnippet(this, options);
            var events = Events.ToSnippet(options);
            var fields = Fields.ToSnippet(options);
            var indexers = Indexers.ToSnippet(options);
            var properties = Properties.ToSnippet(options);
            var methods = Methods.ToSnippet(options);
            Snippet body = options.BlankSpace.Combine(options, fields, constructors, events, indexers, properties, methods);

            return body.Block(options, signature);
        }

        private Snippet GetSignature(Snippet.Options options)
        {
            Kind behavior = Behavior;
            var clauses = Name.Parameters.ToSnippet(parameter => parameter.Constraints.ToSnippet(options), options);
            string name = Name;
            var parameters = Parameters.ToSnippet(Parameter.Options.Pascal);
            string scope = Scope;
            string signature = Separator.Combine(scope, behavior, "struct", $"{name}");

            if (!parameters.IsEmpty)
            {
                signature = $"{signature}({parameters})";
            }

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