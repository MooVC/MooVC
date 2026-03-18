namespace MooVC.Syntax.Solution.SolutionTests;

using System;

internal static class SolutionTestsData
{
    public const string DefaultFilePath = "src/file.cs";
    public const string DefaultFolderName = "/src/";
    public const string DefaultItemId = "ItemId";
    public const string DefaultItemName = "ItemName";
    public const string DefaultItemPath = "assets/item.txt";
    public const string DefaultItemType = "ItemType";
    public const string DefaultProjectName = "ProjectName";
    public const string DefaultProjectPath = "src/Project.csproj";
    public const string DefaultProjectType = "CSharp";
    public const string DefaultPropertyName = "Property";
    public const string DefaultPropertyValue = "Value";
    public static readonly Guid DefaultProjectId = Guid.Parse("6BF8B40B-7457-4B19-B93F-2FE3F68E9BE1");

    public static Solution Create(
        Configurations? configurations = default,
        File? file = default,
        Folder? folder = default,
        Item? item = default,
        Project? project = default,
        Property? property = default)
    {
        return new Solution
        {
            Configurations = configurations is null ? Configurations.Default : configurations,
            Files = file is null ? [CreateFile()] : [file],
            Folders = folder is null ? [CreateFolder()] : [folder],
            Items = item is null ? [CreateItem()] : [item],
            Projects = project is null ? [CreateProject()] : [project],
            Properties = property is null ? [CreateProperty()] : [property],
        };
    }

    public static File CreateFile()
    {
        return new File(DefaultFilePath);
    }

    public static Folder CreateFolder()
    {
        return new Folder
        {
            Name = new Folder.Path(DefaultFolderName),
        };
    }

    public static Item CreateItem()
    {
        return new Item
        {
            Id = Snippet.From(DefaultItemId),
            Name = Snippet.From(DefaultItemName),
            Path = Snippet.From(DefaultItemPath),
            Type = Snippet.From(DefaultItemType),
        };
    }

    public static Project CreateProject()
    {
        return new Project
        {
            Id = DefaultProjectId,
            DisplayName = new Project.Name(DefaultProjectName),
            Path = new Project.RelativePath(DefaultProjectPath),
            Type = Snippet.From(DefaultProjectType),
        };
    }

    public static Property CreateProperty()
    {
        return new Property
        {
            Name = Snippet.From(DefaultPropertyName),
            Value = Snippet.From(DefaultPropertyValue),
        };
    }
}