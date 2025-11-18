namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

using System;
using System.Collections.Immutable;
using System.Linq;
using MooVC.Syntax.CSharp.Generics;

internal static class DeclarationTestsData
{
    public const string DefaultName = "Result";

    public static Declaration Create(string? name = DefaultName, params string[] parameterNames)
    {
        var declaration = new Declaration();

        if (!string.IsNullOrEmpty(name))
        {
            declaration.Name = new Identifier(name);
        }

        if (parameterNames?.Length > 0)
        {
            declaration.Parameters = parameterNames
                .Select(parameter => new Parameter { Name = new Identifier(parameter) })
                .ToImmutableArray();
        }

        return declaration;
    }
}
