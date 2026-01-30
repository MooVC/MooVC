namespace MooVC.Syntax.Attributes.Project.ImportTests;

using MooVC.Syntax.Elements;

internal static class ImportTestsData
{
    public const string DefaultCondition = "Condition";
    public const string DefaultLabel = "Label";
    public const string DefaultProject = "Project";
    public const string DefaultSdk = "Sdk";

    public static Import Create(Snippet? condition = default, Snippet? label = default, Snippet? project = default, Snippet? sdk = default)
    {
        return new Import
        {
            Condition = condition ?? Snippet.From(DefaultCondition),
            Label = label ?? Snippet.From(DefaultLabel),
            Project = project ?? Snippet.From(DefaultProject),
            Sdk = sdk ?? Snippet.From(DefaultSdk),
        };
    }
}