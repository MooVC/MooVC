namespace MooVC.Generators.Semantics;

using Microsoft.CodeAnalysis;

internal static partial class INamedTypeSymbolExtensions
{
    public static bool DerivesFrom(this INamedTypeSymbol symbol, string type, int arguments = 0)
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