namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using static MooVC.Syntax.CSharp.Members.Qualifier_Resources;

    [Monify(Type = typeof(ImmutableArray<Segment>))]
    [SkipAutoInstantiation]
    public partial class Qualifier
        : IValidatableObject
    {
        public static readonly Qualifier Unqualified = ImmutableArray<Segment>.Empty;

        private const string Separator = ".";

        public bool IsUnqualified => this == Unqualified;

        public static implicit operator Qualifier(Segment[] values)
        {
            _ = Guard.Against.Null(values, message: ValuesRequired.Format(nameof(Segment), nameof(Qualifier)));

            return ImmutableArray.Create(values);
        }

        public static implicit operator Segment[](Qualifier qualifier)
        {
            _ = Guard.Against.Null(qualifier, message: QualifierRequired.Format(nameof(Qualifier), nameof(Segment)));

            return qualifier._value.ToArray();
        }

        public override string ToString()
        {
            string[] segments = _value
                .Where(segment => !segment.IsEmpty)
                .Select(segment => segment.ToString())
                .ToArray();

            return Separator.Combine(segments);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnqualified)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            if (_value.IsDefaultOrEmpty)
            {
                return new[]
                {
                    new ValidationResult(ValidateValueRequired.Format(nameof(Qualifier), nameof(Segment)), new[] { nameof(Qualifier) }),
                };
            }

            return Validate(_value, validationContext);
        }

        private static IEnumerable<ValidationResult> Validate(ImmutableArray<Segment> segments, ValidationContext validationContext)
        {
            var processed = new List<Segment>();
            var results = new List<ValidationResult>();

            for (int index = 0; index < segments.Length; index++)
            {
                Segment value = segments[index];

                if (value is null || value.IsEmpty)
                {
                    string preceding = string.Join(Separator, processed);

                    results.Add(new ValidationResult(
                        ValidateSegmentRequired.Format(index, nameof(Segment), nameof(Qualifier), preceding),
                        new[] { $"{nameof(Qualifier)}[{index}]" }));

                    value = "{Undefined}";
                }
                else
                {
                    results.AddRange(value.Validate(validationContext));
                }

                processed.Add(value);
            }

            return results;
        }
    }
}