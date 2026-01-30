namespace MooVC.Syntax.Attributes.Solution.PropertyTests;

using MooVC.Syntax.Elements;

internal static class PropertyTestsData
{
    public const string DefaultName = "Property";
    public const string DefaultValue = "Value";

    public static Property Create(Snippet? name = default, Snippet? value = default)
    {
        return new Property
        {
            Name = name ?? Snippet.From(DefaultName),
            Value = value ?? Snippet.From(DefaultValue),
        };
    }
}