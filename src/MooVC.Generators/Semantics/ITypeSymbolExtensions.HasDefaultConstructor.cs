namespace MooVC.Generators.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="ITypeSymbol" />.
/// </summary>
internal static partial class ITypeSymbolExtensions
{
    /// <summary>
    /// Determines whether or not the <paramref name="symbol"/> supports a default constructor.
    /// </summary>
    /// <param name="symbol">The symbol to check.</param>
    /// <returns>True if the <paramref name="symbol"/> supports a default constructor, otherwise False.</returns>
    public static bool HasDefaultConstructor(this ITypeSymbol symbol)
    {
        if (symbol.IsAbstract)
        {
            return false;
        }

        IMethodSymbol[] constructors = symbol
            .GetMembers()
            .OfType<IMethodSymbol>()
            .Where(method => method.MethodKind == MethodKind.Constructor && !method.IsStatic)
            .ToArray();

        if (constructors.Length == 0)
        {
            return true;
        }

        IMethodSymbol? @default = Array.Find(constructors, constructor => constructor.Parameters.IsEmpty);

        return @default is not null && @default.DeclaredAccessibility.HasFlag(Accessibility.Internal);
    }
}