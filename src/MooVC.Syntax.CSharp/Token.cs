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

    public sealed class Token
        : IEnumerable<Qualifier>,
          IValidatableObject
    {
        public static readonly Token Unspecified = new Token(Name.Unnamed, Symbol.Undefined);

        private Token(Name name, Symbol symbol)
        {
            Name = name ?? Name.Unnamed;
            Symbol = symbol ?? Symbol.Undefined;
        }

        public bool IsUnspecified => this == Unspecified;

        public Name Name { get; private set; } = Name.Unnamed;

        public Symbol Symbol { get; private set; } = Symbol.Undefined;

        public static implicit operator string(Token token)
        {
            Guard.Against.Conversion<Token, string>(token);

            return token.ToString();
        }

        public static implicit operator Snippet(Token token)
        {
            Guard.Against.Conversion<Token, Snippet>(token);

            return token.ToSnippet(Type.Options.Default);
        }

        public static implicit operator Token(Name name)
        {
            if (name is null || name.IsUnnamed)
            {
                return Unspecified;
            }

            return new Token(name, Symbol.Undefined);
        }

        public static implicit operator Token(Symbol symbol)
        {
            if (symbol is null || symbol.IsUndefined)
            {
                return Unspecified;
            }

            return new Token(Name.Unnamed, symbol);
        }

        public static implicit operator Token(CType type)
        {
            Guard.Against.Conversion<CType, Token>(type);

            return (Symbol)type;
        }

        public IEnumerator<Qualifier> GetEnumerator()
        {
            if (!Symbol.IsUndefined)
            {
                foreach (Qualifier qualifier in Symbol)
                {
                    yield return qualifier;
                }
            }
        }

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

        public override string ToString()
        {
            return ToSnippet(Type.Options.Default);
        }

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