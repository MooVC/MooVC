namespace MooVC.Generators.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="ITypeSymbol" />.
/// </summary>
internal static partial class ITypeSymbolExtensions
{
    /// <summary>
    /// Determines whether or not the <paramref name="symbol"/> has a corrosponding static class that defines extension methods
    /// and adheres to the naming convention {Class Name}Extensions.
    /// </summary>
    /// <param name="symbol">The symbol to check.</param>
    /// <returns>True if the <paramref name="symbol"/> has a matching extension methods class defined, otherwise False.</returns>
    public static bool HasExtensions(this ITypeSymbol symbol)
    {
        return symbol.ContainingNamespace
            .GetMembers()
            .OfType<INamedTypeSymbol>()
            .Any(type => type.IsStatic && type.Name.Equals($"{symbol.Name}Extensions"));
    }
}