namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Formatting;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Symbol_Resources;
    using Ignore = Valuify.IgnoreAttribute;
    using Kind = System.Type;

    /// <summary>
    /// Represents a C# syntax element symbol.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Symbol
        : IComparable<Symbol>,
          IEnumerable<Qualifier>,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Symbol Undefined = new Symbol();
        private const string Separator = ", ";

        internal Symbol()
        {
        }

        /// <summary>
        /// Gets the arguments on the Symbol.
        /// </summary>
        /// <value>The arguments.</value>
        public ImmutableArray<Symbol> Arguments { get; internal set; } = ImmutableArray<Symbol>.Empty;

        /// <summary>
        /// Gets a value indicating whether the Symbol is undefined.
        /// </summary>
        /// <value>A value indicating whether the Symbol is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets a value indicating whether the Symbol is an array.
        /// </summary>
        /// <value>A value indicating whether the Symbol is an array.</value>
        public bool IsArray { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the Symbol is nullable.
        /// </summary>
        /// <value>A value indicating whether the Symbol is nullable.</value>
        public bool IsNullable { get; internal set; }

        /// <summary>
        /// Gets the name on the Symbol.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Qualification Name { get; internal set; } = Qualification.Unnamed;

        /// <summary>
        /// Defines the string operator for the Symbol.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Symbol symbol)
        {
            Guard.Against.Conversion<Symbol, string>(symbol);

            return symbol.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Symbol.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Symbol symbol)
        {
            Guard.Against.Conversion<Symbol, Snippet>(symbol);

            return Snippet.From(symbol);
        }

        /// <summary>
        /// Defines the Symbol operator for the Symbol.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The symbol.</returns>
        public static implicit operator Symbol(Kind type)
        {
            Guard.Against.Conversion<Kind, Symbol>(type);

            return new Symbol()
                .IsArray(type.IsArray)
                .IsNullable(Nullable.GetUnderlyingType(type) != null)
                .Named(type);
        }

        /// <summary>
        /// Implicitly converts a QualifiedName to a Symbol instance.
        /// </summary>
        /// <param name="name">The QualifiedName to convert.</param>
        /// <returns>The Symbol.</returns>
        public static implicit operator Symbol(Qualification name)
        {
            Guard.Against.Conversion<Qualification, Symbol>(name);

            return new Symbol()
                .Named(name);
        }

        /// <summary>
        /// Implicitly converts a tuple containing a name and qualifier to an Name instance.
        /// </summary>
        /// <param name="name">The tuple containing the name and qualifier to be converted into an Name.</param>
        /// <returns>The Name.</returns>
        public static implicit operator Symbol((Moniker Name, Qualifier Qualifier) name)
        {
            Guard.Against.Conversion<(Moniker Name, Qualifier Qualifier), Symbol>(name);

            return new Qualification()
                .From(name.Qualifier)
                .KnownAs(name.Name);
        }

        /// <summary>
        /// Defines the less than operator for the Symbol.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator <(Symbol left, Symbol right)
        {
            if (left is null)
            {
                return right is object;
            }

            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Defines the greater than operator for the Symbol.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator >(Symbol left, Symbol right)
        {
            if (left is null)
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Defines the less than or equal to operator for the Symbol.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator <=(Symbol left, Symbol right)
        {
            return !(left > right);
        }

        /// <summary>
        /// Defines the greater than or equal to operator for the Symbol.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator >=(Symbol left, Symbol right)
        {
            return !(left < right);
        }

        /// <summary>
        /// Compares this Symbol to another instance.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>A signed integer indicating relative order.</returns>
        public int CompareTo(Symbol other)
        {
            return other is null
                ? 1
                : Name.CompareTo(other.Name);
        }

        /// <summary>
        /// Returns an enumerator that iterates through all symbols contained in the arguments.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection of symbols.</returns>
        public IEnumerator<Qualifier> GetEnumerator()
        {
            foreach (Qualifier qualifier in Arguments.SelectMany(argument => argument))
            {
                yield return qualifier;
            }

            if (!Name.Qualifier.IsUnqualified)
            {
                yield return Name.Qualifier;
            }
        }

        /// <summary>
        /// Returns the string representation of the Symbol.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToString(Qualification.Options.Default);
        }

        /// <summary>
        /// Creates a snippet representation of the C# syntax element.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Qualification.Options options)
        {
            return ToString(options);
        }

        /// <summary>
        /// Validates the Symbol.
        /// </summary>
        /// <remarks>Required members include: Arguments, Name, Qualifier.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .IncludeIf(!Arguments.IsDefaultOrEmpty, nameof(Arguments), argument => !argument.IsUndefined, Arguments)
                .And(nameof(Name), _ => !Name.IsUnnamed, Name)
                .Results;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private string ToString(Qualification.Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Symbol)));

            if (IsUndefined)
            {
                return string.Empty;
            }

            string signature = Name.ToSnippet(options);

            if (!Arguments.IsDefaultOrEmpty)
            {
                string arguments = GetArgumentDeclarations(options);

                signature = $"{signature}<{arguments}>";
            }

            if (IsArray)
            {
                signature = $"{signature}[]";
            }

            if (IsNullable)
            {
                return $"{signature}?";
            }

            return signature;
        }

        private string GetArgumentDeclarations(Qualification.Options options)
        {
            string[] arguments = Arguments
                .Select(argument => (string)argument.ToSnippet(options))
                .ToArray();

            return Separator.Combine(arguments);
        }
    }
}