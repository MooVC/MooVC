namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

using System;
using MooVC.Syntax.Elements;

internal static class ProjectTestsData
{
    public const string DefaultName = "ProjectName";
    public const string DefaultPath = "src/Project.csproj";
    public const string DefaultType = "CSharp";
    public static readonly Guid DefaultId = Guid.Parse("C1C066AE-78B5-4FCE-9F8D-6A73E1338AC1");

    public static Project Create(
        Guid? id = default,
        Project.Name? name = default,
        Project.RelativePath? path = default,
        Snippet? type = default,
        Configurations.BuildType? build = default,
        Configurations.Platform? platform = default)
    {
        return new Project
        {
            Id = id ?? DefaultId,
            DisplayName = name ?? new Project.Name(DefaultName),
            Path = path ?? new Project.RelativePath(DefaultPath),
            Type = type ?? Snippet.From(DefaultType),
            Builds = build is null ? [] : [build],
            Platforms = platform is null ? [] : [platform],
        };
    }
}