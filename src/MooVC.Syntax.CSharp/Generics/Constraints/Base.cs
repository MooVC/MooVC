namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.CSharp.Elements;

    [Monify(Type = typeof(Symbol))]
    [SkipAutoInstantiation]
    public sealed partial class Base
        : IValidatableObject
    {
        public static readonly Base Unspecified = Symbol.Undefined;

        public bool IsUnspecified => this == Unspecified;

        public static implicit operator string(Base @base)
        {
            Guard.Against.Conversion<Base, string>(@base);

            return @base.ToString();
        }

        public static implicit operator Snippet(Base @base)
        {
            Guard.Against.Conversion<Base, Snippet>(@base);

            return Snippet.From(@base);
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnspecified)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return _value.Validate(validationContext);
        }
    }
}