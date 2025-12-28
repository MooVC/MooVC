namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.CSharp.Generics;
    using MooVC.Syntax.CSharp.Generics.Constraints;
    using MooVC.Syntax.CSharp.Members;
    using MooVC.Syntax.CSharp.Syntax;
    using static MooVC.Syntax.CSharp.Concepts.Reference_Resources;
    using Parameter = MooVC.Syntax.CSharp.Elements.Parameter;

    public abstract partial class Reference
        : Type
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

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = base.Validate(validationContext);

            if (!Extensibility.IsPermitted(Extensibility.Abstract, Extensibility.Implicit, Extensibility.Sealed))
            {
                results = results.Append(new ValidationResult(
                    ValidateExtensibilityInvalid.Format(nameof(Extensibility), Extensibility, GetType().Name),
                    new[] { nameof(Extensibility) }));
            }

            return validationContext
                .IncludeIf(!Constructors.IsDefaultOrEmpty, nameof(Constructors), results, Constructors)
                .AndIf(!Fields.IsDefaultOrEmpty, nameof(Fields), Fields)
                .AndIf(!Parameters.IsDefaultOrEmpty, nameof(Parameters), Parameters)
                .Results;
        }

        protected virtual string GetSignature(string extensibility, string partial, string name, string scope)
        {
            return Separator.Combine(scope, extensibility, partial, _type, $"{name}");
        }

        protected override Snippet PerformToSnippet(Snippet.Options options)
        {
            Snippet signature = GetSignature(options);

            var constructors = Constructors.ToSnippet(options, this);
            var events = Events.ToSnippet(options);
            var fields = Fields.ToSnippet(options);
            var indexers = Indexers.ToSnippet(options);
            var operators = Operators.ToSnippet(options, this);
            var properties = Properties.ToSnippet(options);
            var methods = Methods.ToSnippet(options);
            Snippet body = Snippet.Blank.Combine(options, fields, constructors, events, properties, indexers, operators, methods);

            return body.Block(options, signature);
        }

        private Snippet GetSignature(Snippet.Options options)
        {
            var clauses = Name.Parameters.ToSnippet(parameter => parameter.Constraints.ToSnippet(options), options);
            string extensibility = Extensibility;
            string name = Name;
            var parameters = Parameters.ToSnippet(_options);
            string partial = IsPartial.Partial();
            string scope = Scope;
            string signature = GetSignature(extensibility, partial, name, scope);

            if (!parameters.IsEmpty)
            {
                signature = $"{signature}({parameters})";
            }

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