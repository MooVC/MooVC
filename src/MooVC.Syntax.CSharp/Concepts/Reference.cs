namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using MooVC.Syntax.CSharp.Generics;
    using MooVC.Syntax.CSharp.Generics.Constraints;
    using MooVC.Syntax.CSharp.Members;
    using Parameter = MooVC.Syntax.CSharp.Members.Parameter;

    public abstract partial class Reference
        : Construct
    {
        private const string Separator = " ";
        private readonly Parameter.Options _options;
        private readonly string _type;

        private protected Reference(Parameter.Options options, string type)
        {
            _options = options;
            _type = type;
        }

        public ImmutableArray<Constructor> Constructors { get; internal set; } = ImmutableArray<Constructor>.Empty;

        public Extensibility Extensibility { get; internal set; } = Extensibility.Sealed;

        public ImmutableArray<Field> Fields { get; internal set; } = ImmutableArray<Field>.Empty;

        public ImmutableArray<Parameter> Parameters { get; internal set; } = ImmutableArray<Parameter>.Empty;

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
            var clauses = Name.Parameters.ToSnippet(parameter => parameter.Constraints.ToSnippet(options), options);
            string extensibility = Extensibility;
            string name = Name;
            var parameters = Parameters.ToSnippet(_options);
            string scope = Scope;
            string signature = Separator.Combine(scope, extensibility, _type, $"{name}");

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