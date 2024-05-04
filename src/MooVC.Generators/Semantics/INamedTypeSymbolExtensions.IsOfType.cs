namespace MooVC.Generators.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol" />.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    /// <summary>
    /// Determines whether or not the symbol is of the type specified by <paramref name="type"/>
    /// and has the same number of generic type arguments specified by <paramref name="arguments"/>.
    /// </summary>
    /// <param name="symbol">The symbol to check.</param>
    /// <param name="type">The name of the type.</param>
    /// <param name="arguments">The number of generic type arguments required to serve as a match.</param>
    /// <returns>
    /// True if the <paramref name="symbol"/> has the same name as <paramref name="type"/>
    /// and an equal number of generic type arguments as <paramref name="arguments"/>, otherwise false.
    /// </returns>
    public static bool IsOfType(this INamedTypeSymbol symbol, string type, int arguments = 0)
    {
        if (symbol.Name == type)
        {
            if (arguments > 0)
            {
                return symbol.IsGenericType && symbol.TypeArguments.Length == arguments;
            }

            return true;
        }

        return false;
    }
}