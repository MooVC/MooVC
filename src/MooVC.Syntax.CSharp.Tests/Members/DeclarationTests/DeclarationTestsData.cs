namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

using System.Linq;
using Parameter = MooVC.Syntax.CSharp.Generics.Parameter;

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
            declaration.Parameters = [.. parameterNames.Select(parameter => new Parameter { Name = parameter })];
        }

        return declaration;
    }
}