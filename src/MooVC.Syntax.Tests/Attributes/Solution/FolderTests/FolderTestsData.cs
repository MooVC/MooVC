namespace MooVC.Syntax.Attributes.Solution.FolderTests;

using MooVC.Syntax;
using MooVC.Syntax.Elements;

internal static class FolderTestsData
{
    public const string DefaultId = "FolderId";
    public const string DefaultName = "FolderName";

    public static Folder Create(
        Snippet? id = default,
        Snippet? name = default,
        File? file = default,
        Folder? folder = default,
        Item? item = default)
    {
        return new Folder
        {
            Id = id ?? Snippet.From(DefaultId),
            Name = name ?? Snippet.From(DefaultName),
            Files = file is null ? [] : [file],
            Folders = folder is null ? [] : [folder],
            Items = item is null ? [] : [item],
        };
    }

    public static File CreateFile()
    {
        return new File
        {
            Id = Snippet.From("FileId"),
            Name = Snippet.From("FileName"),
            Path = Snippet.From("src/file.cs"),
        };
    }

    public static Folder CreateChildFolder()
    {
        return new Folder
        {
            Id = Snippet.From("ChildFolderId"),
            Name = Snippet.From("ChildFolderName"),
        };
    }

    public static Item CreateItem()
    {
        return new Item
        {
            Id = Snippet.From("ItemId"),
            Name = Snippet.From("ItemName"),
            Path = Snippet.From("assets/item.txt"),
            Type = Snippet.From("ItemType"),
        };
    }
}