namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Concepts;

internal static class ConstructorTestsData
{
    public const string DefaultName = "Widget";
    private const string DefaultBody = "Initialize();";

    public static Constructor Create(
        Snippet? body = default,
        Extensibility? extensibility = default,
        ImmutableArray<Parameter> parameters = default,
        Scope? scope = default)
    {
        return new Constructor
        {
            Body = body ?? Snippet.From(DefaultBody),
            Extensibility = extensibility ?? Extensibility.Implicit,
            Parameters = parameters.IsDefault
                ? []
                : parameters,
            Scope = scope ?? Scope.Public,
        };
    }

    public static Class CreateType(string? name = DefaultName)
    {
        return new Class
        {
            Name = new Declaration { Name = new Identifier(name ?? string.Empty) },
        };
    }
}