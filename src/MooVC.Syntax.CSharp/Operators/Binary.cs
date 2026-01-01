namespace MooVC.Syntax.CSharp.Operators
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.CSharp.Members;
    using MooVC.Syntax.Elements;
    using Valuify;
    using static MooVC.Syntax.CSharp.Operators.Binary_Resources;
    using Concept = MooVC.Syntax.CSharp.Concepts.Type;
    using Identifier = MooVC.Syntax.Elements.Identifier;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Binary
        : IValidatableObject
    {
        public static readonly Binary Undefined = new Binary();

        internal Binary()
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
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Body), nameof(Binary)));
            _ = Guard.Against.Null(type, message: ToSnippetTypeRequired.Format(nameof(Type), nameof(Binary)));

            return ToSnippet(type.Name, options);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Body.IsEmpty)
            {
                yield return new ValidationResult(ValidateBodyRequired.Format(nameof(Body), nameof(Binary)), new[] { nameof(Body) });
            }
        }

        private Snippet ToSnippet(Declaration declaration, Snippet.Options options)
        {
            if (IsUndefined || declaration.IsUnspecified)
            {
                return Snippet.Empty;
            }

            string @operator = Operator;
            string scope = Scope;
            var type = declaration.Name.ToSnippet(Identifier.Options.Pascal);
            var signature = Snippet.From(options, $"{scope} static {type} operator {@operator}({type} left, {type} right)");

            return Body.Block(options, signature);
        }
    }
}