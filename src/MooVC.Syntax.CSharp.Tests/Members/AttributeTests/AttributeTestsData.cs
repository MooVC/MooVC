namespace MooVC.Syntax.CSharp.Members.AttributeTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public static class AttributeTestsData
{
    public const string DefaultName = "Obsolete";

    public static Attribute Create(string? name = DefaultName, Attribute.Specifier? target = default, params Argument[] arguments)
    {
        ImmutableArray<Argument> provided = arguments.Length == 0
            ? []
            : [.. arguments];

        return new Attribute
        {
            Arguments = provided,
            Name = new Symbol
            {
                Name = name is null
                    ? Symbol.Moniker.Unnamed
                    : new Symbol.Moniker(name),
            },
            Target = target ?? Attribute.Specifier.None,
        };
    }
}