namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Linq;
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.CSharp.DefinitionExtensions_Resources;

    /// <summary>
    /// Provides helper methods for configuring <see cref="Definition" /> instances.
    /// </summary>
    public static partial class DefinitionExtensions
    {
        /// <summary>
        /// Imports all referenced qualifiers from the definition's type into the definition reference list.
        /// </summary>
        /// <param name="definition">The definition to update. Cannot be <see langword="null" />.</param>
        /// <param name="exclusions">The qualifiers to exclude from the import. Cannot be <see langword="null" />.</param>
        /// <returns>The updated definition.</returns>
        public static Definition ImportReferences(this Definition definition, params Qualifier[] exclusions)
        {
            _ = Guard.Against.Null(definition, message: ImportReferencesDefinitionRequired);

            Definition ApplyWithExclusions(Qualifier qualifier, Definition current)
            {
                if (exclusions.Any(exclusion => exclusion == qualifier))
                {
                    return current;
                }

                return ApplyWithoutExclusions(qualifier, current);
            }

            Definition ApplyWithoutExclusions(Qualifier qualifier, Definition current)
            {
                return current.Referencing(qualifier);
            }

            Func<Qualifier, Definition, Definition> without = ApplyWithoutExclusions;
            Func<Qualifier, Definition, Definition> with = ApplyWithExclusions;

            Func<Qualifier, Definition, Definition> action = exclusions is null || exclusions.Length == 0
                ? without
                : with;

            return definition.Enumerate(action, qualifiers => qualifiers);
        }
    }
}