namespace MooVC.Syntax.Attributes.Solution.FolderTests;

using System;
using MooVC.Syntax.Elements;

internal static class FolderTestsData
{
    public const string DefaultName = "/Folder/";

    public static Folder Create(
        Folder.Path? name = default,
        File? file = default,
        Item? item = default,
        Project? project = default)
    {
        return new Folder
        {
            Name = name ?? new Folder.Path(DefaultName),
            Files = file is null ? [] : [file],
            Items = item is null ? [] : [item],
            Projects = project is null ? [] : [project],
        };
    }

    public static File CreateFile()
    {
        return new File("src/file.cs");
    }

    public static Project CreateProject()
    {
        return new Project
        {
            Id = Guid.Parse("F720AF0F-8F5D-4C77-A4D0-804B9E8BAE89"),
            DisplayName = new Project.Name("ProjectName"),
            Path = new Project.RelativePath("src/Project.csproj"),
            Type = "CSharp",
        };
    }

    public static Item CreateItem()
    {
        return new Item
        {
            Id = "ItemId",
            Name = "ItemName",
            Path = "assets/item.txt",
            Type = "ItemType",
        };
    }
}