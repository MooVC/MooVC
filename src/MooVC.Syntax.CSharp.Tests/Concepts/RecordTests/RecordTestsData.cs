namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Operators;

public static class RecordTestsData
{
    public const string DefaultName = "Sample";

    public static Record Create(
        bool? isPartial = null,
        Extensibility? extensibility = null,
        Scope? scope = null,
        Operators? operators = null,
        Declaration? name = null,
        ImmutableArray<Attribute>? attributes = null,
        ImmutableArray<Constructor>? constructors = null,
        ImmutableArray<Event>? events = null,
        ImmutableArray<Field>? fields = null,
        ImmutableArray<Indexer>? indexers = null,
        ImmutableArray<Method>? methods = null,
        ImmutableArray<Parameter>? parameters = null,
        ImmutableArray<Property>? properties = null)
    {
        return new Record
        {
            Attributes = attributes ?? ImmutableArray<Attribute>.Empty,
            Constructors = constructors ?? ImmutableArray<Constructor>.Empty,
            Events = events ?? ImmutableArray<Event>.Empty,
            Extensibility = extensibility ?? Members.Extensibility.Sealed,
            Fields = fields ?? ImmutableArray<Field>.Empty,
            Indexers = indexers ?? ImmutableArray<Indexer>.Empty,
            IsPartial = isPartial ?? false,
            Methods = methods ?? ImmutableArray<Method>.Empty,
            Name = name ?? new Declaration { Name = new Identifier(DefaultName) },
            Operators = operators ?? new Operators(),
            Parameters = parameters ?? ImmutableArray<Parameter>.Empty,
            Properties = properties ?? ImmutableArray<Property>.Empty,
            Scope = scope ?? Scope.Public,
        };
    }
}
