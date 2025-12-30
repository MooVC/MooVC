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
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Elements.Symbol_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Symbol
        : IComparable<Symbol>,
          IValidatableObject
    {
        public static readonly Symbol Undefined = new Symbol();
        private const string Separator = ", ";

        internal Symbol()
        {
        }

        public ImmutableArray<Symbol> Arguments { get; internal set; } = ImmutableArray<Symbol>.Empty;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public bool IsNullable { get; internal set; }

        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        public Qualifier Qualifier { get; internal set; } = Qualifier.Unqualified;

        public static implicit operator string(Symbol symbol)
        {
            Guard.Against.Conversion<Symbol, string>(symbol);

            return symbol.ToString();
        }

        public static implicit operator Snippet(Symbol symbol)
        {
            Guard.Against.Conversion<Symbol, Snippet>(symbol);

            return Snippet.From(symbol);
        }

        public static implicit operator Symbol(Type type)
        {
            Guard.Against.Conversion<Type, Symbol>(type);

            return new Symbol()
                .WithName(type)
                .WithQualifier(type);
        }

        public static bool operator <(Symbol left, Symbol right)
        {
            if (left is null)
            {
                return right is object;
            }

            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Symbol left, Symbol right)
        {
            if (left is null)
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Symbol left, Symbol right)
        {
            return !(left > right);
        }

        public static bool operator >=(Symbol left, Symbol right)
        {
            return !(left < right);
        }

        public int CompareTo(Symbol other)
        {
            return other is null
                ? 1
                : Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return ToString(Options.Default);
        }

        public Snippet ToSnippet(Options options)
        {
            return ToString(options);
        }

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

            var signature = Name.ToSnippet(Identifier.Options.Pascal);

            signature = GetQualifiedSignature(options, signature);

            if (!Arguments.IsDefaultOrEmpty)
            {
                string arguments = GetArgumentDeclarations(options);

                signature = $"{signature}<{arguments}>";
            }

            if (IsNullable)
            {
                return signature.Append('?');
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