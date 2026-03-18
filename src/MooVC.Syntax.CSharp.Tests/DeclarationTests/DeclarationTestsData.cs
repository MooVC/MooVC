namespace MooVC.Syntax.CSharp.DeclarationTests;

using System.Linq;
using Generic = MooVC.Syntax.CSharp.Generics.Generic;

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
            declaration.Generics = [.. parameterNames.Select(parameter => new Generic { Name = parameter })];
        }

        return declaration;
    }
}