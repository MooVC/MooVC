namespace MooVC.Syntax.CSharp
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.CSharp.Implementation_Resources;

    public partial class Implementation
    {
        public sealed class Argument
            : IEnumerable<Symbol>,
              IValidatableObject
        {
            public static readonly Argument Unspecified = new Argument(Name.Unnamed, Symbol.Undefined);

            private Argument(Name name, Symbol symbol)
            {
                Name = name ?? Name.Unnamed;
                Symbol = symbol ?? Symbol.Undefined;
            }

            public bool IsUnspecified => this == Unspecified;

            public Name Name { get; private set; } = Name.Unnamed;

            public Symbol Symbol { get; private set; } = Symbol.Undefined;

            public static implicit operator string(Argument argument)
            {
                Guard.Against.Conversion<Argument, string>(argument);

                return argument.ToString();
            }

            public static implicit operator Snippet(Argument argument)
            {
                Guard.Against.Conversion<Argument, Snippet>(argument);

                return argument.ToSnippet(Type.Options.Default);
            }

            public static implicit operator Argument(Name name)
            {
                if (name is null || name.IsUnnamed)
                {
                    return Unspecified;
                }

                return new Argument(name, Symbol.Undefined);
            }

            public static implicit operator Argument(Symbol symbol)
            {
                if (symbol is null || symbol.IsUndefined)
                {
                    return Unspecified;
                }

                return new Argument(Name.Unnamed, symbol);
            }

            public IEnumerator<Symbol> GetEnumerator()
            {
                if (!Symbol.IsUndefined)
                {
                    yield return Symbol;
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
}