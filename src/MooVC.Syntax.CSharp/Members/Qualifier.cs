namespace MooVC.Syntax.CSharp.Members
{
    using System;
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

        public static implicit operator Qualifier(Type type)
        {
            Guard.Against.Conversion<Type, Qualifier>(type);

            return type.Namespace;
        }

        public static implicit operator Qualifier(string value)
        {
            Guard.Against.Conversion<string, Qualifier>(value);

            return value
                .Split(new string[] { Separator }, StringSplitOptions.RemoveEmptyEntries)
                .Select(segment => new Segment(value))
                .ToImmutableArray();
        }

        public static implicit operator Qualifier(Segment[] values)
        {
            Guard.Against.Conversion<Segment[], Qualifier>(values);

            if (values.Length == 0)
            {
                return Unqualified;
            }

            return ImmutableArray.Create(values);
        }

        public static implicit operator Segment[](Qualifier qualifier)
        {
            Guard.Against.Conversion<Qualifier, Segment[]>(qualifier);

            return qualifier._value.ToArray();
        }

        public static implicit operator string(Qualifier qualifier)
        {
            Guard.Against.Conversion<Qualifier, string>(qualifier);

            return qualifier.ToString();
        }

        public static implicit operator Snippet(Qualifier qualifier)
        {
            Guard.Against.Conversion<Qualifier, Snippet>(qualifier);

            return Snippet.From(qualifier);
        }

        public override string ToString()
        {
            if (IsUnqualified)
            {
                return string.Empty;
            }

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
                    new ValidationResult(
                        ValidateValueRequired.Format(nameof(Qualifier), nameof(Segment)),
                        new[] { nameof(Qualifier) }),
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