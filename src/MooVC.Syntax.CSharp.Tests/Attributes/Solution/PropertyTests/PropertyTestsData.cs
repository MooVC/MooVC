namespace MooVC.Syntax.CSharp.Attributes.Solution.PropertyTests;

using MooVC.Syntax.CSharp;

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