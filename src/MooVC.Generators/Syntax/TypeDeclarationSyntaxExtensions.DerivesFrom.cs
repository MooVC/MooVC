namespace MooVC.Generators.Syntax;

using Microsoft.CodeAnalysis.CSharp.Syntax;

internal static partial class TypeDeclarationSyntaxExtensions
{
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