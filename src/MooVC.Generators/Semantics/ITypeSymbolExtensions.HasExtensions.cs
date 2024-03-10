namespace MooVC.Generators.Semantics;

using Microsoft.CodeAnalysis;

internal static partial class ITypeSymbolExtensions
{
    public static bool HasExtensions(this ITypeSymbol symbol)
    {
        return symbol.ContainingNamespace
            .GetMembers()
            .OfType<INamedTypeSymbol>()
            .Any(type => type.IsStatic && type.Name.Equals($"{symbol.Name}Extensions"));
    }
}