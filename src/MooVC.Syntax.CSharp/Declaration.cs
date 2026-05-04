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
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Declaration_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a declaration statement used inside type bodies.
    /// </summary>
    [AutoInitializeWith(nameof(Unspecified))]
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    [Fluentify]
    [Valuify]
    public sealed partial class Declaration
        : IComparable<Declaration>,
          IEnumerable<Qualifier>,
          IValidatableObject
    {
        /// <summary>
        /// Gets the unspecified instance.
        /// </summary>
        public static readonly Declaration Unspecified = new Declaration();

        /// <summary>
        /// Initializes a new instance of the Declaration class.
        /// </summary>
        internal Declaration()
        {
        }

        /// <summary>
        /// Gets the generics on the Declaration.
        /// </summary>
        /// <value>The generics.</value>
        public ImmutableArray<Generic> Arguments { get; internal set; } = ImmutableArray<Generic>.Empty;

        /// <summary>
        /// Gets a value indicating whether the Declaration is unspecified.
        /// </summary>
        /// <value>A value indicating whether the Declaration is unspecified.</value>
        [Ignore]
        public bool IsUnspecified => this == Unspecified;

        /// <summary>
        /// Gets the name on the Declaration.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Name Name { get; internal set; } = Name.Unnamed;

        /// <summary>
        /// Defines an implicit conversion from <see cref="Declaration" /> to <see cref="string" />.
        /// </summary>
        /// <param name="declaration">The <see cref="Declaration" /> value to convert.</param>
        /// <returns>The converted <see cref="string" /> value.</returns>
        public static implicit operator string(Declaration declaration)
        {
            Guard.Against.Conversion<Declaration, string>(declaration);

            return declaration.ToString();
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Declaration" /> to <see cref="Snippet" />.
        /// </summary>
        /// <param name="declaration">The <see cref="Declaration" /> value to convert.</param>
        /// <returns>The converted <see cref="Snippet" /> value.</returns>
        public static implicit operator Snippet(Declaration declaration)
        {
            Guard.Against.Conversion<Declaration, Snippet>(declaration);

            return declaration.ToSnippet(Snippet.Options.Default);
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="string" /> to <see cref="Declaration" />.
        /// </summary>
        /// <param name="name">The <see cref="string" /> value to convert.</param>
        /// <returns>The converted <see cref="Declaration" /> value.</returns>
        public static implicit operator Declaration(string name)
        {
            Guard.Against.Conversion<string, Declaration>(name);

            return new Declaration()
                .Named(name);
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Name" /> to <see cref="Declaration" />.
        /// </summary>
        /// <param name="name">The <see cref="Name" /> value to convert.</param>
        /// <returns>The converted <see cref="Declaration" /> value.</returns>
        public static implicit operator Declaration(Name name)
        {
            Guard.Against.Conversion<Name, Declaration>(name);

            return new Declaration()
                .Named(name);
        }

        /// <summary>
        /// Defines the less than operator for the Declaration.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// <see langword="true" /> when <paramref name="left" /> is less than <paramref name="right" />;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator <(Declaration left, Declaration right)
        {
            if (left is null)
            {
                return right is object;
            }

            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Defines the greater than operator for the Declaration.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// <see langword="true" /> when <paramref name="left" /> is greater than <paramref name="right" />;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator >(Declaration left, Declaration right)
        {
            if (left is null)
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Defines the less than or equal to operator for the Declaration.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// <see langword="true" /> when <paramref name="left" /> is less than or equal to <paramref name="right" />;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator <=(Declaration left, Declaration right)
        {
            return !(left > right);
        }

        /// <summary>
        /// Defines the greater than or equal to operator for the Declaration.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// <see langword="true" /> when <paramref name="left" /> is greater than or equal to <paramref name="right" />;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator >=(Declaration left, Declaration right)
        {
            return !(left < right);
        }

        /// <summary>
        /// Compares this Declaration to another instance.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>A signed integer indicating relative order.</returns>
        public int CompareTo(Declaration other)
        {
            return other is null
                ? 1
                : Name.CompareTo(other.Name);
        }

        /// <summary>
        /// Returns an enumerator that iterates through all symbols contained in the generics collections.
        /// </summary>
        /// <remarks>The enumerator iterates over each symbol in all generics collections in sequence. The
        /// order of enumeration matches the order of the generics collections and their contained symbols.</remarks>
        /// <returns>An enumerator that can be used to iterate through the symbols in all generics collections.</returns>
        public IEnumerator<Qualifier> GetEnumerator()
        {
            foreach (Qualifier qualifier in Arguments.SelectMany(generic => generic))
            {
                yield return qualifier;
            }
        }

        /// <summary>
        /// Returns the string representation of the Declaration.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Snippet.Options.Default);
        }

        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Declaration)));

            if (IsUnspecified)
            {
                return Snippet.Empty;
            }

            string signature = Name;

            if (!Arguments.IsDefaultOrEmpty)
            {
                var parameters = Arguments.ToSnippet(Generic.Names, options);

                signature = $"{signature}<{parameters}>";
            }

            return Snippet.From(options, signature);
        }

        /// <summary>
        /// Validates the Declaration.
        /// </summary>
        /// <remarks>Required members include: Name, Parameters.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnspecified)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .IncludeIf(!Arguments.IsDefaultOrEmpty, nameof(Arguments), generic => !generic.IsUndefined, Arguments)
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

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Declaration)} {{ " +
                $"{nameof(Arguments)} = `{DebuggerDisplayFormatter.Format(Arguments)}`, " +
                $"{nameof(IsUnspecified)} = `{DebuggerDisplayFormatter.Format(IsUnspecified)}`, " +
                $"{nameof(Name)} = `{DebuggerDisplayFormatter.Format(Name)}` }}";
        }
    }
}