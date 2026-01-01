namespace MooVC.Syntax.Concepts.SolutionTests;

using MooVC.Syntax.Attributes.Solution;
using MooVC.Syntax.Elements;
using ProjectReference = MooVC.Syntax.Attributes.Solution.Project;

internal static class SolutionTestsData
{
    public const string DefaultConfigurationName = "Debug";
    public const string DefaultConfigurationPlatform = "AnyCPU";
    public const string DefaultFileId = "FileId";
    public const string DefaultFileName = "FileName";
    public const string DefaultFilePath = "src/file.cs";
    public const string DefaultFolderId = "FolderId";
    public const string DefaultFolderName = "FolderName";
    public const string DefaultItemId = "ItemId";
    public const string DefaultItemName = "ItemName";
    public const string DefaultItemPath = "assets/item.txt";
    public const string DefaultItemType = "ItemType";
    public const string DefaultProjectId = "ProjectId";
    public const string DefaultProjectName = "ProjectName";
    public const string DefaultProjectPath = "src/Project.csproj";
    public const string DefaultProjectType = "CSharp";
    public const string DefaultPropertyName = "Property";
    public const string DefaultPropertyValue = "Value";

    public static Solution Create(
        Configuration? configuration = default,
        File? file = default,
        Folder? folder = default,
        Item? item = default,
        ProjectReference? project = default,
        Property? property = default)
    {
        return new Solution
        {
            Configurations = configuration is null ? [CreateConfiguration()] : [configuration],
            Files = file is null ? [CreateFile()] : [file],
            Folders = folder is null ? [CreateFolder()] : [folder],
            Items = item is null ? [CreateItem()] : [item],
            Projects = project is null ? [CreateProject()] : [project],
            Properties = property is null ? [CreateProperty()] : [property],
        };
    }

    public static Configuration CreateConfiguration()
    {
        return new Configuration
        {
            Name = Snippet.From(DefaultConfigurationName),
            Platform = Snippet.From(DefaultConfigurationPlatform),
        };
    }

    public static File CreateFile()
    {
        return new File
        {
            Id = Snippet.From(DefaultFileId),
            Name = Snippet.From(DefaultFileName),
            Path = Snippet.From(DefaultFilePath),
        };
    }

    public static Folder CreateFolder()
    {
        return new Folder
        {
            Id = Snippet.From(DefaultFolderId),
            Name = Snippet.From(DefaultFolderName),
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

    public static ProjectReference CreateProject()
    {
        return new ProjectReference
        {
            Id = Snippet.From(DefaultProjectId),
            Name = Snippet.From(DefaultProjectName),
            Path = Snippet.From(DefaultProjectPath),
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