namespace MooVC.Syntax.CSharp.DeclarationTests;

using System.Linq;

internal static class DeclarationTestsData
{
    public const string DefaultName = "Result";

    public static Declaration Create(string? name = DefaultName, params string[] parameterNames)
    {
        var declaration = new Declaration();

        if (!string.IsNullOrEmpty(name))
        {
            declaration.Name = name;
        }

        if (parameterNames?.Length > 0)
        {
            declaration.Generics = [.. parameterNames.Select(parameter => new() { Name = parameter })];
        }

        return declaration;
    }
}