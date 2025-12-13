namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp;
    using MooVC.Syntax.CSharp.Generics;
    using MooVC.Syntax.CSharp.Generics.Constraints;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Method_Resources;
    using Ignore = Valuify.IgnoreAttribute;

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
            return ToString(Snippet.Options.Default);
        }

        public string ToString(Snippet.Options options)
        {
            _ = Guard.Against.Null(
                options,
                message: ToStringOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Method)));

            if (IsUndefined)
            {
                return string.Empty;
            }

            Snippet signature = GetSignature(options);

            if (Body.IsEmpty)
            {
                return signature
                    .Append(';')
                    .ToString();
            }

            return Body
                .Block(options, signature)
                .ToString();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .IncludeIf(!Parameters.IsDefaultOrEmpty, nameof(Parameters), parameter => !parameter.IsUndefined, Parameters)
                .And(nameof(Name), _ => !Name.IsUnspecified, Name)
                .And(nameof(Result), Result)
                .Results;
        }

        private Snippet GetSignature(Snippet.Options options)
        {
            string extensibility = Extensibility;
            string name = Name;
            var parameters = Parameters.ToSnippet(Parameter.Options.Camel);
            string result = Result;
            string scope = Scope;
            var clauses = Name.Parameters.ToSnippet(parameter => parameter.Constraints.ToSnippet(options), options);
            string signature = Separator.Combine(scope, extensibility, result, $"{name}({parameters})");

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