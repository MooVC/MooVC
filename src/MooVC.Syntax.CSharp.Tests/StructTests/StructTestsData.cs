namespace MooVC.Syntax.CSharp.StructTests;

using System.Collections.Immutable;

public static class StructTestsData
{
    public const string DefaultName = "Sample";

    public static Struct Create(
        Struct.Kinds? behavior = default,
        bool? isPartial = default,
        Scopes? scope = default,
        Operators? operators = default,
        Declaration? name = default,
        ImmutableArray<Attribute>? attributes = default,
        ImmutableArray<Constructor>? constructors = default,
        ImmutableArray<Event>? events = default,
        ImmutableArray<Field>? fields = default,
        ImmutableArray<Indexer>? indexers = default,
        ImmutableArray<Method>? methods = default,
        ImmutableArray<Parameter>? parameters = default,
        ImmutableArray<Property>? properties = default)
    {
        return new Struct
        {
            Attributes = attributes ?? [],
            Behavior = behavior ?? Struct.Kinds.Default,
            Constructors = constructors ?? [],
            Declaration = name ?? new Declaration { Name = DefaultName },
            Events = events ?? [],
            Fields = fields ?? [],
            Indexers = indexers ?? [],
            IsPartial = isPartial ?? false,
            Methods = methods ?? [],
            Operators = operators ?? new Operators(),
            Parameters = parameters ?? [],
            Properties = properties ?? [],
            Scope = scope ?? Scopes.Public,
        };
    }
}