namespace MooVC.Syntax.CSharp.Operators
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.CSharp.Members;
    using Valuify;
    using static MooVC.Syntax.CSharp.Operators.Unary_Resources;
    using Concept = MooVC.Syntax.CSharp.Concepts.Type;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Unary
        : IValidatableObject
    {
        public static readonly Unary Undefined = new Unary();

        internal Unary()
        {
        }

        public Snippet Body { get; internal set; } = Snippet.Empty;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Type Operator { get; internal set; } = Type.Unspecified;

        public Scope Scope { get; internal set; } = Scope.Public;

        public override string ToString()
        {
            return ToSnippet(Declaration.Unspecified, Snippet.Options.Default);
        }

        public string ToString(Snippet.Options options, Concept type)
        {
            return ToSnippet(options, type);
        }

        public Snippet ToSnippet(Snippet.Options options, Concept type)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Body), nameof(Unary)));
            _ = Guard.Against.Null(type, message: ToSnippetTypeRequired.Format(nameof(Type), nameof(Unary)));

            return ToSnippet(type.Name, options);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Body.IsEmpty)
            {
                yield return new ValidationResult(ValidateBodyRequired.Format(nameof(Body), nameof(Unary)), new[] { nameof(Body) });
            }
        }

        private Snippet ToSnippet(Declaration declaration, Snippet.Options options)
        {
            if (IsUndefined || declaration.IsUnspecified)
            {
                return Snippet.Empty;
            }

            string @operator = Operator;
            var name = declaration.Name.ToSnippet(Identifier.Options.Camel);
            string scope = Scope;
            var type = declaration.Name.ToSnippet(Identifier.Options.Pascal);
            var signature = Snippet.From(options, $"{scope} static {type} operator {@operator}({type} {name})");

            return Body.Block(options, signature);
        }
    }
}