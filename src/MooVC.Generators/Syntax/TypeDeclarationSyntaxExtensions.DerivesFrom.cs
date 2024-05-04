namespace MooVC.Generators.Syntax;

using Microsoft.CodeAnalysis.CSharp.Syntax;

/// <summary>
/// Provides extensions relating to <see cref="TypeDeclarationSyntax" />.
/// </summary>
internal static partial class TypeDeclarationSyntaxExtensions
{
    /// <summary>
    /// Determines whether or not the <paramref name="syntax"/> includes a definition that indicates the type implements a specific <paramref name="type"/>.
    /// </summary>
    /// <param name="syntax">The syntax to check.</param>
    /// <param name="type">The name of the type to match.</param>
    /// <returns>True if the <paramref name="syntax"/> indicates that it implements <paramref name="type"/>, otherwise False.</returns>
    public static bool DerivesFrom(this TypeDeclarationSyntax syntax, string type)
    {
        if (syntax.BaseList is null)
        {
            return false;
        }

        return syntax.BaseList.Types
            .Select(@base => @base.Type)
            .OfType<SimpleNameSyntax>()
            .Any(name => name.Identifier.ValueText == type);
    }
}