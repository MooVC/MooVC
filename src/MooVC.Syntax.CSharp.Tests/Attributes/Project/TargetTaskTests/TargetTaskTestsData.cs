namespace MooVC.Syntax.CSharp.Attributes.Project.TargetTaskTests;

using MooVC.Syntax.CSharp.Elements;

internal static class TargetTaskTestsData
{
    public const string DefaultCondition = "Condition";
    public const string DefaultName = "Build";
    public const string DefaultOutputCondition = "OutputCondition";
    public const string DefaultOutputItemName = "Item";
    public const string DefaultOutputPropertyName = "Property";
    public const string DefaultOutputTaskParameter = "TaskParameter";
    public const string DefaultParameterName = "Parameter";
    public const string DefaultParameterValue = "Value";

    public static TargetTask Create(
        Snippet? condition = default,
        TargetTask.Options? continueOnError = default,
        Identifier? name = default,
        TaskOutput? output = default,
        TaskParameter? parameter = default)
    {
        var value = new TargetTask
        {
            Condition = condition ?? Snippet.From(DefaultCondition),
            ContinueOnError = continueOnError ?? TargetTask.Options.ErrorAndStop,
            Name = name ?? new Identifier(DefaultName),
        };

        if (output is not null)
        {
            value = value.WithOutputs(output);
        }

        if (parameter is not null)
        {
            value = value.WithParameters(parameter);
        }

        return value;
    }

    public static TaskOutput CreateOutput()
    {
        return new TaskOutput
        {
            Condition = Snippet.From(DefaultOutputCondition),
            ItemName = new Identifier(DefaultOutputItemName),
            PropertyName = new Identifier(DefaultOutputPropertyName),
            TaskParameter = new Identifier(DefaultOutputTaskParameter),
        };
    }

    public static TaskParameter CreateParameter()
    {
        return new TaskParameter
        {
            Name = new Identifier(DefaultParameterName),
            Value = Snippet.From(DefaultParameterValue),
        };
    }
}