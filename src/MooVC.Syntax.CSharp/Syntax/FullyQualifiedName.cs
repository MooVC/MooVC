namespace MooVC.Syntax.CSharp.Syntax
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using Ardalis.GuardClauses;
    using MooVC.Syntax.CSharp;
    using MooVC.Syntax.Validation;
    using Generic = MooVC.Syntax.CSharp.Generic;

    /// <summary>
    /// Represents a parsed fully qualified C# type name.
    /// </summary>
    internal sealed class FullyQualifiedName
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FullyQualifiedName"/> class.
        /// </summary>
        /// <param name="namespace">The namespace portion.</param>
        /// <param name="name">The type name portion.</param>
        /// <param name="arguments">The generic type arguments.</param>
        public FullyQualifiedName(Qualifier @namespace, Name name, params FullyQualifiedName[] arguments)
        {
            Arguments = arguments.ToImmutableArray();
            Namespace = @namespace;
            Name = name;
        }

        /// <summary>
        /// Gets the generic type arguments.
        /// </summary>
        public ImmutableArray<FullyQualifiedName> Arguments { get; }

        /// <summary>
        /// Gets the namespace portion.
        /// </summary>
        public Qualifier Namespace { get; }

        /// <summary>
        /// Gets the type name portion.
        /// </summary>
        public Name Name { get; }

        /// <summary>
        /// Converts a fully qualified type name string into a parsed model.
        /// </summary>
        /// <param name="fullyQualifiedName">The fully qualified type name.</param>
        /// <returns>The parsed model.</returns>
        public static implicit operator FullyQualifiedName(string fullyQualifiedName)
        {
            Guard.Against.Conversion<string, FullyQualifiedName>(fullyQualifiedName);

            return fullyQualifiedName.Decompose();
        }

        /// <summary>
        /// Converts a parsed type name into a declaration.
        /// </summary>
        /// <param name="fullyQualifiedName">The parsed type name.</param>
        /// <returns>The corresponding declaration.</returns>
        public static implicit operator Declaration(FullyQualifiedName fullyQualifiedName)
        {
            Guard.Against.Conversion<FullyQualifiedName, Declaration>(fullyQualifiedName);

            var parameters = new List<Generic>(fullyQualifiedName.Arguments.Length);

            foreach (FullyQualifiedName argument in fullyQualifiedName.Arguments)
            {
                parameters.Add(new Generic
                {
                    Name = argument.Name,
                });
            }

            return new Declaration
            {
                Name = fullyQualifiedName.Name,
                Generics = parameters.ToImmutableArray(),
            };
        }

        /// <summary>
        /// Converts a parsed type name into a symbol.
        /// </summary>
        /// <param name="fullyQualifiedName">The parsed type name.</param>
        /// <returns>The corresponding symbol.</returns>
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