namespace MooVC.Syntax.Project.PropertyTests;

internal static class PropertyTestsData
{
    public const string DefaultCondition = "Condition";
    public const string DefaultName = "Property";
    public const string DefaultValue = "Value";

    public static Property Create(Snippet? condition = default, Name? name = default, Snippet? value = default)
    {
        return new Property
        {
            Condition = condition ?? Snippet.From(DefaultCondition),
            Name = name ?? DefaultName,
            Value = value ?? Snippet.From(DefaultValue),
        };
    }
}