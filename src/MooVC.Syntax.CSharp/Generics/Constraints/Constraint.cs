namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Fluentify;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Constraint
        : IValidatableObject
    {
        public static readonly Constraint Unspecified = new Constraint();
        private const string Separator = ", ";

        public Base Base { get; set; } = Base.Unspecified;

        public ImmutableArray<Interface> Interfaces { get; set; } = ImmutableArray<Interface>.Empty;

        [Ignore]
        public bool IsUnspecified => this == Unspecified;

        public Nature Nature { get; set; } = Nature.Unspecified;

        public New New { get; set; } = New.NotRequired;

        public override string ToString()
        {
            if (IsUnspecified)
            {
                return string.Empty;
            }

            string @base = Base.ToString();
            string nature = Nature;
            string @new = New;

            IEnumerable<string> interfaces = Interfaces.IsDefaultOrEmpty
                ? Enumerable.Empty<string>()
                : Interfaces.Select(@interface => @interface.ToString());

            string[] constraints = interfaces
                .Prepend(@base)
                .Prepend(nature)
                .Append(@new)
                .ToArray();

            return $"where {Separator.Combine(constraints)}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnspecified)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(Base)
                .AndIf(!Interfaces.IsDefaultOrEmpty, Interfaces)
                .Results;
        }
    }
}