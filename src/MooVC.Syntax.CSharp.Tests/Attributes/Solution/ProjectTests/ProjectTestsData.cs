namespace MooVC.Syntax.CSharp.Attributes.Solution.ProjectTests;

using MooVC.Syntax.CSharp;

internal static class ProjectTestsData
{
    public const string DefaultId = "ProjectId";
    public const string DefaultName = "ProjectName";
    public const string DefaultPath = "src/Project.csproj";
    public const string DefaultType = "CSharp";

    public static Project Create(Snippet? id = default, Snippet? name = default, Snippet? path = default, Snippet? type = default)
    {
        return new Project
        {
            Id = id ?? Snippet.From(DefaultId),
            Name = name ?? Snippet.From(DefaultName),
            Path = path ?? Snippet.From(DefaultPath),
            Type = type ?? Snippet.From(DefaultType),
        };
    }
}