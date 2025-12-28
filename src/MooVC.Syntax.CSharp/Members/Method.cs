namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.CSharp.Generics;
    using MooVC.Syntax.CSharp.Generics.Constraints;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Method_Resources;
    using Ignore = Valuify.IgnoreAttribute;
    using Parameter = MooVC.Syntax.CSharp.Elements.Parameter;

    [Fluentify]
    [Valuify]
    public sealed partial class Method
        : IValidatableObject
    {
        public static readonly Method Undefined = new Method();

        private const string Separator = " ";

        internal Method()
        {
        }

        public Snippet Body { get; internal set; } = Snippet.Empty;

        public Extensibility Extensibility { get; internal set; } = Extensibility.Implicit;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Declaration Name { get; internal set; } = Declaration.Unspecified;

        public ImmutableArray<Parameter> Parameters { get; internal set; } = ImmutableArray<Parameter>.Empty;

        public Result Result { get; internal set; } = Result.Task;

        public Scope Scope { get; internal set; } = Scope.Public;

        public static implicit operator string(Method method)
        {
            Guard.Against.Conversion<Method, string>(method);

            return method.ToString();
        }

        public static implicit operator Snippet(Method method)
        {
            Guard.Against.Conversion<Method, Snippet>(method);

            return Snippet.From(method);
        }

        public override string ToString()
        {
            return ToSnippet(Snippet.Options.Default);
        }

        public Snippet ToSnippet(Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Method)));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            Snippet signature = GetSignature(options);

            if (Body.IsEmpty)
            {
                return signature.Append(';');
            }

            return Body.Block(options, signature);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (!Extensibility.IsPermitted(
                Extensibility.Abstract,
                Extensibility.Implicit,
                Extensibility.Override,
                Extensibility.Sealed + Extensibility.Override,
                Extensibility.Virtual))
            {
                results = results.Append(new ValidationResult(
                    ValidateExtensibilityInvalid.Format(nameof(Extensibility), Extensibility, nameof(Event)),
                    new[] { nameof(Extensibility) }));
            }

            return validationContext
                .IncludeIf(!Parameters.IsDefaultOrEmpty, nameof(Parameters), parameter => !parameter.IsUndefined, results, Parameters)
                .And(nameof(Name), _ => !Name.IsUnspecified, Name)
                .And(nameof(Result), Result)
                .Results;
        }

        private Snippet GetSignature(Snippet.Options options)
        {
            string extensibility = Extensibility;
            string name = Name;
            var parameters = Parameters.ToSnippet(Parameter.Options.Camel);
            string result = Result.IsVoid ? "void" : Result;
            string scope = Scope;
            var clauses = Name.Parameters.ToSnippet(parameter => parameter.Constraints.ToSnippet(options), options);
            string signature = Separator.Combine(scope, extensibility, result, $"{name}({parameters})");

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