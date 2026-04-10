namespace MooVC.Syntax.CSharp
{
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.CSharp.DefinitionExtensions_Resources;

    public static partial class DefinitionExtensions
    {
        public static Definition ImportReferences(this Definition definition)
        {
            _ = Guard.Against.Null(definition, message: ImportReferencesDefinitionRequired);

            return definition.Enumerate((qualifier, current) => current.Referencing(qualifier), qualifiers => qualifiers);
        }
    }
}