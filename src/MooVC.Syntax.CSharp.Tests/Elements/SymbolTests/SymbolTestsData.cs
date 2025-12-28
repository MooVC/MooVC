namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

using System.Linq;

internal static class SymbolTestsData
{
    public const string DefaultName = "Result";

    public static Symbol Create(string? name = DefaultName, Qualifier? qualifier = null, params Symbol[] arguments)
    {
        var symbol = new Symbol();

        if (!string.IsNullOrEmpty(name))
        {
            symbol.Name = new Identifier(name);
        }

        if (qualifier is not null)
        {
            symbol.Qualifier = qualifier;
        }

        if (arguments?.Length > 0)
        {
            symbol.Arguments = [.. arguments];
        }

        return symbol;
    }

    public static Symbol CreateWithArgumentNames(string? name = DefaultName, params string[] argumentNames)
    {
        Symbol[] arguments = argumentNames
            .Select(argument => new Symbol { Name = new Identifier(argument) })
            .ToArray();

        return Create(name, arguments: arguments);
    }
}