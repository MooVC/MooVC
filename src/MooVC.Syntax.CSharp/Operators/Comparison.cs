namespace MooVC.Syntax.CSharp.Operators
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Concepts;
    using MooVC.Syntax.CSharp.Members;
    using Valuify;
    using static MooVC.Syntax.CSharp.Operators.Comparison_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Comparison
        : IValidatableObject
    {
        public static readonly Comparison Undefined = new Comparison();

        internal Comparison()
        {
        }

        public Snippet Body { get; internal set; } = Snippet.Empty;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Type Operator { get; internal set; } = Type.Unspecified;

        public Scope Scope { get; internal set; } = Scope.Public;

        public override string ToString()
        {
            return ToString(Declaration.Unspecified, Snippet.Options.Default);
        }

        public string ToString(Construct construct, Snippet.Options options)
        {
            _ = Guard.Against.Null(construct, message: ToStringConsructRequired.Format(nameof(Construct), nameof(Comparison)));
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Snippet.Options), nameof(Body), nameof(Comparison)));

            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToString(construct.Name, options);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Body.IsEmpty)
            {
                yield return new ValidationResult(ValidateBodyRequired.Format(nameof(Body), nameof(Comparison)), new[] { nameof(Body) });
            }
        }

        private string ToString(Declaration declaration, Snippet.Options options)
        {
            if (declaration.IsUnspecified)
            {
                return string.Empty;
            }

            string @operator = Operator;
            string scope = Scope;
            string type = declaration.Name.ToString(Identifier.Options.Pascal);
            var signature = Snippet.From($"{scope} static bool operator {@operator}({type} left, {type} right)");

            return Body.Block(options, signature);
        }
    }
}