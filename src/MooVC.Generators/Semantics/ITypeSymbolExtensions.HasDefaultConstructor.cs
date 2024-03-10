namespace MooVC.Generators.Semantics;

using Microsoft.CodeAnalysis;

internal static partial class INamedTypeSymbolExtensions
{
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