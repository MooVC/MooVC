namespace MooVC.Generators.Syntax;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

internal static partial class TypeDeclarationSyntaxExtensions
{
    public static bool IsPartial(this TypeDeclarationSyntax syntax)
    {
        return syntax.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PartialKeyword));
    }
}