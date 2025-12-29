namespace MooVC.Syntax.CSharp.Attributes.Project.TaskOutputTests;

using MooVC.Syntax.CSharp.Elements;

internal static class TaskOutputTestsData
{
    public const string DefaultCondition = "Condition";
    public const string DefaultItemName = "Item";
    public const string DefaultPropertyName = "Property";
    public const string DefaultTaskParameter = "Parameter";

    public static TaskOutput Create(
        Snippet? condition = default,
        Identifier? itemName = default,
        Identifier? propertyName = default,
        Identifier? taskParameter = default)
    {
        return new TaskOutput
        {
            Condition = condition ?? Snippet.From(DefaultCondition),
            ItemName = itemName ?? new Identifier(DefaultItemName),
            PropertyName = propertyName ?? new Identifier(DefaultPropertyName),
            TaskParameter = taskParameter ?? new Identifier(DefaultTaskParameter),
        };
    }
}