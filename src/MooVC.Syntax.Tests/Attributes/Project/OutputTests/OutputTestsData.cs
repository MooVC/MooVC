namespace MooVC.Syntax.Attributes.Project.OutputTests;

using MooVC.Syntax.Elements;

internal static class OutputTestsData
{
    public const string DefaultCondition = "Condition";
    public const string DefaultItemName = "Item";
    public const string DefaultPropertyName = "Property";
    public const string DefaultTaskParameter = "Parameter";

    public static Output Create(
        Snippet? condition = default,
        Name? itemName = default,
        Name? propertyName = default,
        Name? taskParameter = default)
    {
        return new Output
        {
            Condition = condition ?? Snippet.From(DefaultCondition),
            ItemName = itemName ?? DefaultItemName,
            PropertyName = propertyName ?? DefaultPropertyName,
            TaskParameter = taskParameter ?? DefaultTaskParameter,
        };
    }
}