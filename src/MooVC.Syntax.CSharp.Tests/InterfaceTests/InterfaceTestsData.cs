namespace MooVC.Syntax.CSharp.InterfaceTests;

using System.Collections.Immutable;

public static class InterfaceTestsData
{
    public const string DefaultName = "Sample";

    public static Interface Create(
        bool? isPartial = default,
        Scope? scope = default,
        Operators? operators = default,
        Declaration? name = default,
        ImmutableArray<Attribute>? attributes = default,
        ImmutableArray<Event>? events = default,
        ImmutableArray<Indexer>? indexers = default,
        ImmutableArray<Method>? methods = default,
        ImmutableArray<Property>? properties = default)
    {
        return new Interface
        {
            Attributes = attributes ?? [],
            Events = events ?? [],
            Indexers = indexers ?? [],
            IsPartial = isPartial ?? false,
            Methods = methods ?? [],
            Declaration = name ?? new Declaration { Name = DefaultName },
            Operators = operators ?? new Operators(),
            Properties = properties ?? [],
            Scope = scope ?? Scope.Public,
        };
    }
}