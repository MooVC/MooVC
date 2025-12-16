namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Operators;

public static class StructTestsData
{
    public const string DefaultName = "Sample";

    public static Struct Create(
        Struct.Kind? behavior = null,
        bool? isPartial = null,
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
        return new Struct
        {
            Attributes = attributes ?? ImmutableArray<Attribute>.Empty,
            Behavior = behavior ?? Struct.Kind.Default,
            Constructors = constructors ?? ImmutableArray<Constructor>.Empty,
            Events = events ?? ImmutableArray<Event>.Empty,
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
