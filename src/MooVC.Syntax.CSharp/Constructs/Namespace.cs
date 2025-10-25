namespace MooVC.Syntax.CSharp.Constructs
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Monify;
    using static MooVC.Syntax.CSharp.Constructs.Namespace_Resources;

    [Monify(Type = typeof(ImmutableArray<Segment>))]
    public partial class Namespace
        : IValidatableObject
    {
        private const string Separator = ".";

        public static implicit operator Namespace(Segment[] values)
        {
            _ = Guard.Against.Null(values, message: ValuesRequired.Format(nameof(Segment), nameof(Namespace)));

            return ImmutableArray.Create(values);
        }

        public static implicit operator Segment[](Namespace @namespace)
        {
            _ = Guard.Against.Null(@namespace, message: NamespaceRequired.Format(nameof(Namespace), nameof(Segment)));

            return @namespace._value.ToArray();
        }

        public override string ToString()
        {
            return string.Join(Separator, _value);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            const int Empty = 0;

            if (_value.Length == Empty)
            {
                yield return new ValidationResult(ValidateValueRequired.Format(nameof(Namespace), nameof(Segment)), new[] { nameof(Namespace) });
            }

            var segments = new List<Segment>();

            for (int index = 0; index < _value.Length; index++)
            {
                Segment value = _value[index];

                if (value is null)
                {
                    string preceding = string.Join(Separator, segments);

                    yield return new ValidationResult(
                        ValidateSegmentRequired.Format(index, nameof(Namespace), preceding),
                        new[] { $"{nameof(Namespace)}[{index}]" });
                }

                segments.Add(value);
            }
        }
    }
}