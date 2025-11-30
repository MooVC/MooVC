namespace MooVC.Syntax.CSharp.Members.ParameterTests;

using System.Collections.Immutable;

public static class ParameterTestsData
{
    public const string DefaultName = "value";

    public static Parameter Create(
        string? name = DefaultName,
        Parameter.Mode? modifier = default,
        Snippet? @default = default,
        params Attribute[] attributes)
    {
        ImmutableArray<Attribute> provided = attributes.Length == 0
            ? []
            : [.. attributes];

        return new Parameter
        {
            Attributes = provided,
            Default = @default ?? Snippet.Empty,
            Modifier = modifier ?? Parameter.Mode.None,
            Name = name is null
                ? Identifier.Unnamed
                : new Identifier(name),
        };
    }
}
