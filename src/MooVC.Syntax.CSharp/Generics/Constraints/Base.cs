namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.CSharp.Members;

    [Monify(Type = typeof(Symbol))]
    [SkipAutoInstantiation]
    public sealed partial class Base
        : IValidatableObject
    {
        public static readonly Base Unspecified = Symbol.Unspecified;

        public bool IsUnspecified => this == Unspecified;

        public static implicit operator string(Base @base)
        {
            if (@base is null)
            {
                @base = Unspecified;
            }

            return @base.ToString();
        }

        public static implicit operator Snippet(Base @base)
        {
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