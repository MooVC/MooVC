namespace MooVC.Syntax.CSharp.Operators
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Concepts;
    using MooVC.Syntax.CSharp.Members;
    using Valuify;
    using static MooVC.Syntax.CSharp.Operators.Conversion_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Conversion
        : IValidatableObject
    {
        public static readonly Conversion Undefined = new Conversion();

        internal Conversion()
        {
        }

        public Snippet Body { get; internal set; } = Snippet.Empty;

        public Intent Direction { get; internal set; } = Intent.To;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Type Mode { get; internal set; } = Type.Implicit;

        public Scope Scope { get; internal set; } = Scope.Public;

        public Symbol Subject { get; internal set; } = Symbol.Undefined;

        public override string ToString()
        {
            return ToString(Declaration.Unspecified, Snippet.Options.Default);
        }

        public string ToString(Construct construct, Snippet.Options options)
        {
            _ = Guard.Against.Null(construct, message: ToStringConsructRequired.Format(nameof(Construct), nameof(Conversion)));
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Snippet.Options), nameof(Body), nameof(Conversion)));

            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToString(construct.Name, options);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (Body.IsEmpty)
            {
                results = results.Append(new ValidationResult(ValidateBodyRequired.Format(nameof(Body), nameof(Conversion)), new[] { nameof(Body) }));
            }

            if (Subject.IsUndefined)
            {
                results = results.Append(new ValidationResult(ValidateSubjectRequired.Format(nameof(Subject), nameof(Conversion)), new[] { nameof(Subject) }));
            }

            return validationContext
                .Include(nameof(Subject), results, Subject)
                .Results;
        }

        private string ToString(Declaration declaration, Snippet.Options options)
        {
            if (declaration.IsUnspecified)
            {
                return string.Empty;
            }

            GetInputAndResult(declaration, out string input, out string result);

            string mode = Mode;
            string scope = Scope;
            var signature = Snippet.From($"{scope} static {mode} operator {result}({input} subject)");

            return Body.Block(options, signature);
        }

        private void GetInputAndResult(Declaration declaration, out string input, out string result)
        {
            if (Direction == Intent.To)
            {
                input = declaration;
                result = Subject;
            }
            else
            {
                input = Subject;
                result = declaration;
            }
        }
    }
}