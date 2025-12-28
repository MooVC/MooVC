namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Operators;

public static class StructTestsData
{
    public const string DefaultName = "Sample";

    public static Struct Create(
        Struct.Kind? behavior = default,
        bool? isPartial = default,
        Scope? scope = default,
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
            Behavior = behavior ?? Struct.Kind.Default,
            Constructors = constructors ?? [],
            Events = events ?? [],
            Fields = fields ?? [],
            Indexers = indexers ?? [],
            IsPartial = isPartial ?? false,
            Methods = methods ?? [],
            Name = name ?? new Declaration { Name = new Identifier(DefaultName) },
            Operators = operators ?? new Operators(),
            Parameters = parameters ?? [],
            Properties = properties ?? [],
            Scope = scope ?? Scope.Public,
        };
    }
}