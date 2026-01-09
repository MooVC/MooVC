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
        Identifier? itemName = default,
        Identifier? propertyName = default,
        Identifier? taskParameter = default)
    {
        return new Output
        {
            Condition = condition ?? Snippet.From(DefaultCondition),
            ItemName = itemName ?? new Identifier(DefaultItemName),
            PropertyName = propertyName ?? new Identifier(DefaultPropertyName),
            TaskParameter = taskParameter ?? new Identifier(DefaultTaskParameter),
        };
    }
}