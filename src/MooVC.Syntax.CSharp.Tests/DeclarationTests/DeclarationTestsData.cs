namespace MooVC.Syntax.CSharp.DeclarationTests;

using System.Linq;
using Argument = MooVC.Syntax.CSharp.Generics.Argument;

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
            declaration.Arguments = [.. parameterNames.Select(parameter => new Argument { Name = parameter })];
        }

        return declaration;
    }
}