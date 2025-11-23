namespace MooVC.Syntax.CSharp.Members.AttributeTests;

using System.Collections.Immutable;

public static class AttributeTestsData
{
    public const string DefaultName = "Obsolete";

    public static Attribute Create(
        string? name = DefaultName,
        Attribute.Specifier? target = null,
        params Argument[] arguments)
    {
        ImmutableArray<Argument> provided = arguments.Length == 0
            ? ImmutableArray<Argument>.Empty
            : arguments.ToImmutableArray();

        return new Attribute
        {
            Arguments = provided,
            Name = new Symbol { Name = name is null ? Identifier.Unnamed : new Identifier(name) },
            Target = target ?? Attribute.Specifier.None,
        };
    }
}
