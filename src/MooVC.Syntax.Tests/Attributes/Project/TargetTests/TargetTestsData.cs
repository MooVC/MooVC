namespace MooVC.Syntax.Attributes.Project.TargetTests;

using MooVC.Syntax.Elements;

internal static class TargetTestsData
{
    public const string DefaultAfterTargets = "AfterTargets";
    public const string DefaultBeforeTargets = "BeforeTargets";
    public const string DefaultCondition = "Condition";
    public const string DefaultDependsOnTargets = "DependsOnTargets";
    public const string DefaultInputs = "Inputs";
    public const string DefaultLabel = "Label";
    public const string DefaultName = "Build";
    public const string DefaultOutputs = "Outputs";
    public const string DefaultReturns = "Returns";
    public const string DefaultTaskCondition = "TaskCondition";
    public const string DefaultTaskName = "Compile";

    public static Target Create(
        Snippet? afterTargets = default,
        Snippet? beforeTargets = default,
        Snippet? condition = default,
        Snippet? dependsOnTargets = default,
        Snippet? inputs = default,
        bool keepDuplicateOutputs = false,
        Snippet? label = default,
        Name? name = default,
        Snippet? outputs = default,
        Snippet? returns = default,
        TargetTask? task = default)
    {
        var value = new Target
        {
            AfterTargets = afterTargets ?? Snippet.From(DefaultAfterTargets),
            BeforeTargets = beforeTargets ?? Snippet.From(DefaultBeforeTargets),
            Condition = condition ?? Snippet.From(DefaultCondition),
            DependsOnTargets = dependsOnTargets ?? Snippet.From(DefaultDependsOnTargets),
            Inputs = inputs ?? Snippet.From(DefaultInputs),
            KeepDuplicateOutputs = keepDuplicateOutputs,
            Label = label ?? Snippet.From(DefaultLabel),
            Name = name ?? DefaultName,
            Outputs = outputs ?? Snippet.From(DefaultOutputs),
            Returns = returns ?? Snippet.From(DefaultReturns),
        };

        if (task is not null)
        {
            value = value.WithTasks(task);
        }

        return value;
    }

    public static TargetTask CreateTask()
    {
        return new TargetTask
        {
            Condition = Snippet.From(DefaultTaskCondition),
            Name = DefaultTaskName,
        };
    }
}