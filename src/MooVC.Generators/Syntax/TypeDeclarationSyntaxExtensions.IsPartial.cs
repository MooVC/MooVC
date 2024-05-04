namespace MooVC.Generators.Syntax;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

/// <summary>
/// Provides extensions relating to <see cref="TypeDeclarationSyntax" />.
/// </summary>
internal static partial class TypeDeclarationSyntaxExtensions
{
    /// <summary>
    /// Determines whether or not the <paramref name="syntax"/> includes the partial keyword.
    /// </summary>
    /// <param name="syntax">The syntax to check.</param>
    /// <returns>True if the partial keyword is included within the <paramref name="syntax"/>, otherwise False.</returns>
    public static bool IsPartial(this TypeDeclarationSyntax syntax)
    {
        return syntax.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PartialKeyword));
    }
}