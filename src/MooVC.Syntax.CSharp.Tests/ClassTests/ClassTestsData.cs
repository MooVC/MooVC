namespace MooVC.Syntax.CSharp.ClassTests;

using System.Collections.Immutable;

public static class ClassTestsData
{
    public const string DefaultName = "Sample";

    public static Class Create(
        bool? isStatic = default,
        bool? isPartial = default,
        Modifiers? extensibility = default,
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
        return new Class
        {
            Attributes = attributes ?? [],
            Constructors = constructors ?? [],
            Events = events ?? [],
            Extensibility = extensibility ?? Modifiers.Sealed,
            Fields = fields ?? [],
            Indexers = indexers ?? [],
            IsPartial = isPartial ?? false,
            IsStatic = isStatic ?? false,
            Methods = methods ?? [],
            Declaration = name ?? new Declaration { Name = DefaultName },
            Operators = operators ?? new Operators(),
            Parameters = parameters ?? [],
            Properties = properties ?? [],
            Scope = scope ?? Scopes.Public,
        };
    }
}