namespace MooVC.Syntax.CSharp.Elements
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.Text;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.CSharp;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.CSharp.Elements.Variable_Resources;

    [Monify(Type = typeof(Identifier))]
    [SkipAutoInstantiation]
    public sealed partial class Variable
        : IComparable<Variable>,
          IValidatableObject
    {
        public static readonly Variable Unnamed = Identifier.Unnamed;

        public Variable(Identifier value)
        {
            _value = value ?? Identifier.Unnamed;
        }

        [Ignore]
        public bool IsUnnamed => this == Unnamed;

        public static implicit operator Variable(Type type)
        {
            Guard.Against.Conversion<Type, Variable>(type);

            return type.GetName();
        }

        public static implicit operator string(Variable variable)
        {
            Guard.Against.Conversion<Variable, string>(variable);

            return variable.ToString();
        }

        public static implicit operator Snippet(Variable variable)
        {
            Guard.Against.Conversion<Variable, Snippet>(variable);

            return variable.ToSnippet(Options.Camel);
        }

        public static bool operator <(Variable left, Variable right)
        {
            if (left is null)
            {
                return right is object;
            }

            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Variable left, Variable right)
        {
            if (left is null)
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Variable left, Variable right)
        {
            return !(left > right);
        }

        public static bool operator >=(Variable left, Variable right)
        {
            return !(left < right);
        }

        public int CompareTo(Variable other)
        {
            return other is null
                ? 1
                : string.CompareOrdinal(_value, other._value);
        }

        public override string ToString()
        {
            return ToSnippet(Options.Camel);
        }

        public Snippet ToSnippet(Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Variable)));

            string value = _value.ToSnippet(options);

            if (Aliases.IsSystem(value))
            {
                return value.ToCamelCase();
            }

            const char ReservationPrefix = '@';
            const char UnderscorePrefix = '_';

            var identifier = new StringBuilder(value);

            if (options.UseUnderscore)
            {
                identifier = identifier.Prepend(UnderscorePrefix);
            }
            else if (options.Casing != Identifier.Casing.Pascal && identifier.IsReserved())
            {
                identifier = identifier.Prepend(ReservationPrefix);
            }

            return identifier.ToString();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnnamed || Aliases.IsSystem(_value))
            {
                yield break;
            }

            foreach (ValidationResult result in _value.Validate(validationContext))
            {
                yield return new ValidationResult(result.ErrorMessage, new[] { nameof(Variable) });
            }
        }
    }
}