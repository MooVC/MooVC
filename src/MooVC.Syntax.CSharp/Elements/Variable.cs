namespace MooVC.Syntax.CSharp.Elements
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.CSharp;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.CSharp.Elements.Variable_Resources;

    /// <summary>
    /// Represents a c# syntax element variable.
    /// </summary>
    [Monify(Type = typeof(Identifier))]
    [SkipAutoInstantiation]
    public sealed partial class Variable
        : IComparable<Variable>,
          IValidatableObject
    {
        /// <summary>
        /// Gets the unnamed on the Variable.
        /// </summary>
        public static readonly Variable Unnamed = Identifier.Unnamed;

        /// <summary>
        /// Initializes a new instance of the Variable class.
        /// </summary>
        public Variable(Identifier value)
        {
            _value = value ?? Identifier.Unnamed;
        }

        /// <summary>
        /// Gets a value indicating whether the Variable is unnamed.
        /// </summary>
        [Ignore]
        public bool IsUnnamed => this == Unnamed;

        /// <summary>
        /// Defines the Variable operator for the Variable.
        /// </summary>
        public static implicit operator Variable(Type type)
        {
            Guard.Against.Conversion<Type, Variable>(type);

            return type.GetName();
        }

        /// <summary>
        /// Defines the string operator for the Variable.
        /// </summary>
        public static implicit operator string(Variable variable)
        {
            Guard.Against.Conversion<Variable, string>(variable);

            return variable.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Variable.
        /// </summary>
        public static implicit operator Snippet(Variable variable)
        {
            Guard.Against.Conversion<Variable, Snippet>(variable);

            return variable.ToSnippet(Options.Camel);
        }

        /// <summary>
        /// Defines the < operator for the Variable.
        /// </summary>
        public static bool operator <(Variable left, Variable right)
        {
            if (left is null)
            {
                return right is object;
            }

            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Defines the > operator for the Variable.
        /// </summary>
        public static bool operator >(Variable left, Variable right)
        {
            if (left is null)
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Defines the <= operator for the Variable.
        /// </summary>
        public static bool operator <=(Variable left, Variable right)
        {
            return !(left > right);
        }

        /// <summary>
        /// Defines the >= operator for the Variable.
        /// </summary>
        public static bool operator >=(Variable left, Variable right)
        {
            return !(left < right);
        }

        /// <summary>
        /// Compares this Variable to another instance.
        /// </summary>
        public int CompareTo(Variable other)
        {
            return other is null
                ? 1
                : string.CompareOrdinal(_value, other._value);
        }

        /// <summary>
        /// Returns the string representation of the Variable.
        /// </summary>
        public override string ToString()
        {
            return ToSnippet(Options.Camel);
        }

        /// <summary>
        /// Creates a code snippet representation of the c# syntax element.
        /// </summary>
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

        /// <summary>
        /// Validates the Variable and returns validation results.
        /// </summary>
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