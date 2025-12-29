namespace MooVC.Syntax.CSharp.Attributes.Project.TaskParameterTests;

using MooVC.Syntax.CSharp.Elements;

internal static class TaskParameterTestsData
{
    public const string DefaultName = "Parameter";
    public const string DefaultValue = "Value";

    public static TaskParameter Create(
        Identifier? name = default,
        Snippet? value = default)
    {
        return new TaskParameter
        {
            Name = name ?? new Identifier(DefaultName),
            Value = value ?? Snippet.From(DefaultValue),
        };
    }
}