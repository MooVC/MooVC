namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Symbol_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Symbol
        : IValidatableObject
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

        public override string ToString()
        {
            return ToString(Options.Default);
        }

        public string ToString(Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Symbol)));

            if (IsUndefined)
            {
                return string.Empty;
            }

            string signature = Name.ToString(Identifier.Options.Pascal);

            signature = GetQualifiedSignature(options, signature);

            if (!Arguments.IsDefaultOrEmpty)
            {
                string arguments = GetArgumentDeclarations(options);

                signature = $"{signature}<{arguments}>";
            }

            if (IsNullable)
            {
                return string.Concat(signature, "?");
            }

            return signature;
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

        private string GetArgumentDeclarations(Options options)
        {
            string[] arguments = Arguments
                .Select(argument => argument.ToString(options))
                .ToArray();

            return Separator.Combine(arguments);
        }

        private string GetQualifiedSignature(Options options, string signature)
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