namespace MooVC.Syntax.Attributes.Project.ItemGroupTests;

using MooVC.Syntax.Elements;

internal static class ItemGroupTestsData
{
    public const string DefaultCondition = "Condition";
    public const string DefaultInclude = "Include";
    public const string DefaultLabel = "Label";

    public static ItemGroup Create(Snippet? condition = default, Snippet? label = default, Item? item = default)
    {
        var values = new ItemGroup
        {
            Condition = condition ?? Snippet.From(DefaultCondition),
            Label = label ?? Snippet.From(DefaultLabel),
        };

        if (item is not null)
        {
            values = values.WithItems(item);
        }

        return values;
    }

    public static Item CreateItem()
    {
        return new Item
        {
            Include = DefaultInclude,
        };
    }
}