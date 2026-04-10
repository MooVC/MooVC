namespace MooVC.Syntax.CSharp.ConstructorTests;

using System.Collections.Immutable;

internal static class ConstructorTestsData
{
    public const string DefaultName = "Widget";
    private const string DefaultBody = "Initialize();";

    public static Constructor Create(
        Snippet? body = default,
        Extensibility? extensibility = default,
        ImmutableArray<Parameter> parameters = default,
        Scopes? scope = default)
    {
        return new Constructor
        {
            Body = body ?? Snippet.From(DefaultBody),
            Extensibility = extensibility ?? Extensibility.Implicit,
            Parameters = parameters.IsDefault
                ? []
                : parameters,
            Scope = scope ?? Scopes.Public,
        };
    }

    public static Class CreateType(string? name = DefaultName)
    {
        return new Class
        {
            Declaration = new() { Name = name ?? string.Empty },
        };
    }
}