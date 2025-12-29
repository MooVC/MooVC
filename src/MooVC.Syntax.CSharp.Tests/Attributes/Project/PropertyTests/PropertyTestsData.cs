namespace MooVC.Syntax.CSharp.Attributes.Project.PropertyTests;

using MooVC.Syntax.CSharp.Elements;

internal static class PropertyTestsData
{
    public const string DefaultCondition = "Condition";
    public const string DefaultName = "Property";
    public const string DefaultValue = "Value";

    public static Property Create(
        Snippet? condition = default,
        Identifier? name = default,
        Snippet? value = default)
    {
        return new Property
        {
            Condition = condition ?? Snippet.From(DefaultCondition),
            Name = name ?? new Identifier(DefaultName),
            Value = value ?? Snippet.From(DefaultValue),
        };
    }
}