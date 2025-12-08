namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Method_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Method
        : IValidatableObject
    {
        public static readonly Method Undefined = new Method();

        private const string ParameterSeparator = ", ";
        private const string SignatureSeparator = " ";

        public Snippet Body { get; set; } = Snippet.Empty;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Identifier Name { get; set; } = Identifier.Unnamed;

        public ImmutableArray<Parameter> Parameters { get; set; } = ImmutableArray<Parameter>.Empty;

        public Result Result { get; set; } = Result.Task;

        public Scope Scope { get; set; } = Scope.Public;

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
                    .Append(options, ";")
                    .ToString();
            }

            if (Body.IsSingleLine)
            {
                return signature
                    .Append(options, $" => {Body};")
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
                .And(nameof(Name), _ => !Name.IsUnnamed, Name)
                .And(nameof(Result), Result)
                .Results;
        }

        private Snippet GetSignature(Snippet.Options options)
        {
            string name = Name.ToString(Identifier.Options.Pascal);
            string parameters = ParameterSeparator.Combine(
                Parameters,
                parameter => parameter.ToString(Parameter.Options.Camel));
            string result = Result;
            string scope = Scope;
            string signature = SignatureSeparator.Combine(scope, result, $"{name}({parameters})");

            return Snippet.From(signature, options);
        }
    }
}
