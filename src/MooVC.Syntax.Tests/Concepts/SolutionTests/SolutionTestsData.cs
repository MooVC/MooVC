namespace MooVC.Syntax.Concepts.SolutionTests;

using System;
using MooVC.Syntax.Attributes.Solution;
using MooVC.Syntax.Elements;
using ProjectReference = MooVC.Syntax.Attributes.Solution.Project;

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
        ProjectReference? project = default,
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
            Id = DefaultItemId,
            Name = DefaultItemName,
            Path = DefaultItemPath,
            Type = DefaultItemType,
        };
    }

    public static ProjectReference CreateProject()
    {
        return new ProjectReference
        {
            Id = DefaultProjectId,
            DisplayName = new ProjectReference.Name(DefaultProjectName),
            Path = new ProjectReference.RelativePath(DefaultProjectPath),
            Type = DefaultProjectType,
        };
    }

    public static Property CreateProperty()
    {
        return new Property
        {
            Name = DefaultPropertyName,
            Value = DefaultPropertyValue,
        };
    }
}