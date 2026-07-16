namespace MooVC.Syntax.CSharp.SymbolTests;

using System.Linq;

internal static class SymbolTestsData
{
    public const string DefaultName = "Result";

    public static Symbol Create(string? name = DefaultName, params Symbol[] arguments)
    {
        var symbol = new Symbol();

        if (!string.IsNullOrEmpty(name))
        {
            symbol.Name = name;
        }

        if (arguments?.Length > 0)
        {
            symbol.Arguments = [.. arguments];
        }

        return symbol;
    }

    public static Symbol CreateWithArgumentNames(string? name = DefaultName, params string[] argumentNames)
    {
        Symbol[] arguments = [.. argumentNames.Select(argument => new Symbol() { Name = argument })];

        return Create(name, arguments: arguments);
    }
}