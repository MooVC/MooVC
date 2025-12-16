namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Operators;

public static class InterfaceTestsData
{
    public const string DefaultName = "Sample";

    public static Interface Create(
        bool? isPartial = null,
        Scope? scope = null,
        Operators? operators = null,
        Declaration? name = null,
        ImmutableArray<Attribute>? attributes = null,
        ImmutableArray<Event>? events = null,
        ImmutableArray<Indexer>? indexers = null,
        ImmutableArray<Method>? methods = null,
        ImmutableArray<Property>? properties = null)
    {
        return new Interface
        {
            Attributes = attributes ?? ImmutableArray<Attribute>.Empty,
            Events = events ?? ImmutableArray<Event>.Empty,
            Indexers = indexers ?? ImmutableArray<Indexer>.Empty,
            IsPartial = isPartial ?? false,
            Methods = methods ?? ImmutableArray<Method>.Empty,
            Name = name ?? new Declaration { Name = new Identifier(DefaultName) },
            Operators = operators ?? new Operators(),
            Properties = properties ?? ImmutableArray<Property>.Empty,
            Scope = scope ?? Scope.Public,
        };
    }
}
