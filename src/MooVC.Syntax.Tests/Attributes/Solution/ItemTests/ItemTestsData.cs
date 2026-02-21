namespace MooVC.Syntax.Attributes.Solution.ItemTests;

using MooVC.Syntax.Elements;

internal static class ItemTestsData
{
    public const string DefaultId = "ItemId";
    public const string DefaultName = "ItemName";
    public const string DefaultPath = "assets/item.txt";
    public const string DefaultType = "Text";

    public static Item Create(
        Snippet? id = default,
        Snippet? name = default,
        Snippet? path = default,
        Snippet? type = default,
        Item? item = default)
    {
        return new Item
        {
            Id = id ?? Snippet.From(DefaultId),
            Name = name ?? Snippet.From(DefaultName),
            Path = path ?? Snippet.From(DefaultPath),
            Type = type ?? Snippet.From(DefaultType),
            Items = item is null ? [] : [item],
        };
    }

    public static Item CreateChild()
    {
        return new Item
        {
            Id = "ChildId",
            Name = "ChildName",
            Path = "assets/child.txt",
            Type = "ChildType",
        };
    }
}