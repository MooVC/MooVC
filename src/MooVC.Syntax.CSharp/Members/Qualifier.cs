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
        : IComparable<Qualifier>,
          IValidatableObject
    {
        public static readonly Qualifier Unqualified = ImmutableArray<Segment>.Empty;

        private const string Separator = ".";

        public bool IsUnqualified => this == Unqualified;

        public int Length => _value.Length;

        public Segment this[int index] => _value[index];

        public static implicit operator Qualifier(Type type)
        {
            Guard.Against.Conversion<Type, Qualifier>(type);

            return type.Namespace;
        }

        public static implicit operator Qualifier(string value)
        {
            Guard.Against.Conversion<string, Qualifier>(value);

            return value
                .Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries)
                .Select(segment => new Segment(segment))
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

        public static bool operator <(Qualifier left, Qualifier right)
        {
            if (left is null)
            {
                return right is object;
            }

            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Qualifier left, Qualifier right)
        {
            if (left is null)
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Qualifier left, Qualifier right)
        {
            return !(left > right);
        }

        public static bool operator >=(Qualifier left, Qualifier right)
        {
            return !(left < right);
        }

        public int CompareTo(Qualifier other)
        {
            if (other is null)
            {
                return 1;
            }

            int unqualified = CompareUnqualified(other);

            if (unqualified != 0)
            {
                return unqualified;
            }

            int system = CompareSystemFirst(other);

            if (system != 0)
            {
                return system;
            }

            return CompareSegments(other);
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

        public Snippet ToSnippet(Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Declaration)));

            if (IsUnqualified)
            {
                return Snippet.Empty;
            }

            return Snippet.From(options, ToString());
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

        private static bool IsSystemFirst(ImmutableArray<Segment> value)
        {
            return !value.IsDefaultOrEmpty && value.Length > 0 && value[0].ToString() == "System";
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

        private int CompareUnqualified(Qualifier other)
        {
            if (IsUnqualified)
            {
                return other.IsUnqualified ? 0 : -1;
            }

            return other.IsUnqualified ? 1 : 0;
        }

        private int CompareSystemFirst(Qualifier other)
        {
            bool left = IsSystemFirst(_value);
            bool right = IsSystemFirst(other._value);

            if (left == right)
            {
                return 0;
            }

            return left ? -1 : 1;
        }

        private int CompareSegments(Qualifier other)
        {
            int length = _value.Length.CompareTo(other._value.Length);

            if (length != 0)
            {
                return length;
            }

            for (int index = 0; index < _value.Length; index++)
            {
                int segment = _value[index].CompareTo(other._value[index]);

                if (segment != 0)
                {
                    return segment;
                }
            }

            return 0;
        }
    }
}