namespace MooVC.Syntax.CSharp.Elements
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Formatting;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Elements.Symbol_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# syntax element symbol.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Symbol
        : IComparable<Symbol>,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Symbol Undefined = new Symbol();
        private const string Separator = ", ";

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
        /// Gets a value indicating whether the Symbol is nullable.
        /// </summary>
        /// <value>A value indicating whether the Symbol is nullable.</value>
        public bool IsNullable { get; internal set; }

        /// <summary>
        /// Gets the name on the Symbol.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Moniker Name { get; internal set; } = Moniker.Unnamed;

        /// <summary>
        /// Gets the qualifier on the Symbol.
        /// </summary>
        /// <value>The qualifier.</value>
        [Descriptor("From")]
        public Qualifier Qualifier { get; internal set; } = Qualifier.Unqualified;

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
        public static implicit operator Symbol(Type type)
        {
            Guard.Against.Conversion<Type, Symbol>(type);

            return new Symbol()
                .From(type)
                .Named(type);
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
        /// Returns the string representation of the Symbol.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToString(Options.Default);
        }

        /// <summary>
        /// Creates a snippet representation of the C# syntax element.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Options options)
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
                .And(nameof(Qualifier), Qualifier)
                .Results;
        }

        private string ToString(Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Symbol)));

            if (IsUndefined)
            {
                return string.Empty;
            }

            string signature = Name;

            signature = GetQualifiedSignature(options, signature);

            if (!Arguments.IsDefaultOrEmpty)
            {
                string arguments = GetArgumentDeclarations(options);

                signature = $"{signature}<{arguments}>";
            }

            if (IsNullable)
            {
                return $"{signature}?";
            }

            return signature;
        }

        private string GetArgumentDeclarations(Options options)
        {
            string[] arguments = Arguments
                .Select(argument => (string)argument.ToSnippet(options))
                .ToArray();

            return Separator.Combine(arguments);
        }

        private Snippet GetQualifiedSignature(Options options, Snippet signature)
        {
            if (Qualifier.IsUnqualified || options.Qualification == Qualification.Minimum)
            {
                return signature;
            }

            signature = $"{Qualifier}.{signature}";

            if (options.Qualification == Qualification.Global)
            {
                return $"global::{signature}";
            }

            return signature;
        }
    }
}