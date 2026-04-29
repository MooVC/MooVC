namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Formatting;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Symbol_Resources;
    using CType = System.Type;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a symbol reference, including qualification and generic arguments.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
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
        /// Defines an implicit conversion from <see cref="Symbol" /> to <see cref="string" />.
        /// </summary>
        /// <param name="symbol">The <see cref="Symbol" /> value to convert.</param>
        /// <returns>The converted <see cref="string" /> value.</returns>
        public static implicit operator string(Symbol symbol)
        {
            Guard.Against.Conversion<Symbol, string>(symbol);

            return symbol.ToString();
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Symbol" /> to <see cref="Snippet" />.
        /// </summary>
        /// <param name="symbol">The <see cref="Symbol" /> value to convert.</param>
        /// <returns>The converted <see cref="Snippet" /> value.</returns>
        public static implicit operator Snippet(Symbol symbol)
        {
            Guard.Against.Conversion<Symbol, Snippet>(symbol);

            return Snippet.From(symbol.ToString());
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="CType" /> to <see cref="Symbol" />.
        /// </summary>
        /// <param name="type">The <see cref="CType" /> value to convert.</param>
        /// <returns>The converted <see cref="Symbol" /> value.</returns>
        public static implicit operator Symbol(CType type)
        {
            Guard.Against.Conversion<CType, Symbol>(type);

            return new Symbol()
                .IsArray(type.IsArray)
                .IsNullable(Nullable.GetUnderlyingType(type) != null)
                .Named(type);
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Qualification" /> to <see cref="Symbol" />.
        /// </summary>
        /// <param name="name">The <see cref="Qualification" /> value to convert.</param>
        /// <returns>The converted <see cref="Symbol" /> value.</returns>
        public static implicit operator Symbol(Qualification name)
        {
            Guard.Against.Conversion<Qualification, Symbol>(name);

            return new Symbol()
                .Named(name);
        }

        /// <summary>
        /// Defines an implicit conversion to <see cref="Symbol" />.
        /// </summary>
        /// <param name="name">The value to convert.</param>
        /// <returns>The converted <see cref="Symbol" /> value.</returns>
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
        /// <returns>
        /// <see langword="true" /> when <paramref name="left" /> is less than <paramref name="right" />;
        /// otherwise, <see langword="false" />.
        /// </returns>
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
        /// <returns>
        /// <see langword="true" /> when <paramref name="left" /> is greater than <paramref name="right" />;
        /// otherwise, <see langword="false" />.
        /// </returns>
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
        /// <returns>
        /// <see langword="true" /> when <paramref name="left" /> is less than or equal to <paramref name="right" />;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator <=(Symbol left, Symbol right)
        {
            return !(left > right);
        }

        /// <summary>
        /// Defines the greater than or equal to operator for the Symbol.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// <see langword="true" /> when <paramref name="left" /> is greater than or equal to <paramref name="right" />;
        /// otherwise, <see langword="false" />.
        /// </returns>
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

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Symbol)} {{ " +
                $"{nameof(Arguments)} = {DebuggerDisplayFormatter.Format(Arguments)}, " +
                $"{nameof(IsArray)} = {DebuggerDisplayFormatter.Format(IsArray)}, " +
                $"{nameof(IsNullable)} = {DebuggerDisplayFormatter.Format(IsNullable)}, " +
                $"{nameof(IsUndefined)} = {DebuggerDisplayFormatter.Format(IsUndefined)}, " +
                $"{nameof(Name)} = {DebuggerDisplayFormatter.Format(Name)} }}";
        }
    }
}