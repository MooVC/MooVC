namespace MooVC.Syntax.CSharp
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.CSharp.Base_Resources;
    using CType = System.Type;

    /// <summary>
    /// Represents a token that can be expressed as either a <see cref="Name" /> or a <see cref="Symbol" />.
    /// </summary>
    public sealed class Token
        : IEnumerable<Qualifier>,
          IValidatableObject
    {
        /// <summary>
        /// Gets the unspecified token value.
        /// </summary>
        public static readonly Token Unspecified = new Token(Name.Unnamed, Symbol.Undefined);

        private Token(Name name, Symbol symbol)
        {
            Name = name ?? Name.Unnamed;
            Symbol = symbol ?? Symbol.Undefined;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is <see cref="Unspecified" />.
        /// </summary>
        public bool IsUnspecified => this == Unspecified;

        /// <summary>
        /// Gets the token name.
        /// </summary>
        public Name Name { get; private set; } = Name.Unnamed;

        /// <summary>
        /// Gets the token symbol.
        /// </summary>
        public Symbol Symbol { get; private set; } = Symbol.Undefined;

        /// <summary>
        /// Defines an implicit conversion from <see cref="Token" /> to <see cref="string" />.
        /// </summary>
        /// <param name="token">The <see cref="Token" /> value to convert.</param>
        /// <returns>The converted <see cref="string" /> value.</returns>
        public static implicit operator string(Token token)
        {
            Guard.Against.Conversion<Token, string>(token);

            return token.ToString();
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Token" /> to <see cref="Snippet" />.
        /// </summary>
        /// <param name="token">The <see cref="Token" /> value to convert.</param>
        /// <returns>The converted <see cref="Snippet" /> value.</returns>
        public static implicit operator Snippet(Token token)
        {
            Guard.Against.Conversion<Token, Snippet>(token);

            return token.ToSnippet(Type.Options.Default);
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Name" /> to <see cref="Token" />.
        /// </summary>
        /// <param name="name">The <see cref="Name" /> value to convert.</param>
        /// <returns>The converted <see cref="Token" /> value.</returns>
        public static implicit operator Token(Name name)
        {
            if (name is null || name.IsUnnamed)
            {
                return Unspecified;
            }

            return new Token(name, Symbol.Undefined);
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Symbol" /> to <see cref="Token" />.
        /// </summary>
        /// <param name="symbol">The <see cref="Symbol" /> value to convert.</param>
        /// <returns>The converted <see cref="Token" /> value.</returns>
        public static implicit operator Token(Symbol symbol)
        {
            if (symbol is null || symbol.IsUndefined)
            {
                return Unspecified;
            }

            return new Token(Name.Unnamed, symbol);
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="CType" /> to <see cref="Token" />.
        /// </summary>
        /// <param name="type">The <see cref="CType" /> value to convert.</param>
        /// <returns>The converted <see cref="Token" /> value.</returns>
        public static implicit operator Token(CType type)
        {
            Guard.Against.Conversion<CType, Token>(type);

            return (Symbol)type;
        }

        /// <summary>
        /// Returns an enumerator for the qualifiers contained in <see cref="Symbol" />.
        /// </summary>
        /// <returns>An enumerator over the symbol qualifiers.</returns>
        public IEnumerator<Qualifier> GetEnumerator()
        {
            return Symbol.GetEnumerator();
        }

        /// <summary>
        /// Converts this instance into a <see cref="Snippet" />.
        /// </summary>
        /// <param name="options">The type rendering options. Cannot be <see langword="null" />.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Type.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Type.Options), nameof(Type), nameof(Declaration)));

            if (IsUnspecified)
            {
                return Snippet.Empty;
            }

            return Name.IsUnnamed
                ? Symbol.ToSnippet(options)
                : Name;
        }

        /// <summary>
        /// Returns the C# representation of this token.
        /// </summary>
        /// <returns>The token as C# text.</returns>
        public override string ToString()
        {
            return ToSnippet(Type.Options.Default);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <param name="validationContext">The validation context used for diagnostics.</param>
        /// <returns>The validation results for this instance.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnspecified)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .IncludeIf(Symbol.IsUndefined, nameof(Name), _ => !Name.IsUnnamed, Name)
                .AndIf(Name.IsUnnamed, nameof(Symbol), _ => !Symbol.IsUndefined, Symbol)
                .Results;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}