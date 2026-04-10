namespace MooVC.Syntax.CSharp
{
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
        /// <returns>The updated definition.</returns>
        public static Definition ImportReferences(this Definition definition)
        {
            _ = Guard.Against.Null(definition, message: ImportReferencesDefinitionRequired);

            return definition.Enumerate((qualifier, current) => current.Referencing(qualifier), qualifiers => qualifiers);
        }
    }
}