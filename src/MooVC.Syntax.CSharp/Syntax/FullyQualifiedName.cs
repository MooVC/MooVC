namespace MooVC.Syntax.CSharp.Syntax
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using Ardalis.GuardClauses;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.CSharp.Generics;
    using MooVC.Syntax.CSharp.Members;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Parameter = MooVC.Syntax.CSharp.Generics.Parameter;

    internal sealed class FullyQualifiedName
    {
        public FullyQualifiedName(Qualifier @namespace, Name name, params FullyQualifiedName[] arguments)
        {
            Arguments = arguments.ToImmutableArray();
            Namespace = @namespace;
            Name = name;
        }

        public ImmutableArray<FullyQualifiedName> Arguments { get; }

        public Qualifier Namespace { get; }

        public Name Name { get; }

        public static implicit operator FullyQualifiedName(string fullyQualifiedName)
        {
            Guard.Against.Conversion<string, FullyQualifiedName>(fullyQualifiedName);

            return fullyQualifiedName.Decompose();
        }

        public static implicit operator Declaration(FullyQualifiedName fullyQualifiedName)
        {
            Guard.Against.Conversion<FullyQualifiedName, Declaration>(fullyQualifiedName);

            var parameters = new List<Parameter>(fullyQualifiedName.Arguments.Length);

            foreach (FullyQualifiedName argument in fullyQualifiedName.Arguments)
            {
                parameters.Add(new Parameter
                {
                    Name = argument.Name,
                });
            }

            return new Declaration
            {
                Name = fullyQualifiedName.Name,
                Parameters = parameters.ToImmutableArray(),
            };
        }

        public static implicit operator Symbol(FullyQualifiedName fullyQualifiedName)
        {
            Guard.Against.Conversion<FullyQualifiedName, Symbol>(fullyQualifiedName);

            var arguments = new List<Symbol>(fullyQualifiedName.Arguments.Length);

            foreach (FullyQualifiedName argument in fullyQualifiedName.Arguments)
            {
                arguments.Add(argument);
            }

            return new Symbol
            {
                Arguments = arguments.ToImmutableArray(),
                Name = fullyQualifiedName.Name,
                Qualifier = fullyQualifiedName.Namespace,
            };
        }
    }
}