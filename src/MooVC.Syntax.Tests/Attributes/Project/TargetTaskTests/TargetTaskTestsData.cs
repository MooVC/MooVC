namespace MooVC.Syntax.Attributes.Project.TargetTaskTests;

using MooVC.Syntax.Elements;

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
        Name? name = default,
        Output? output = default,
        Parameter? parameter = default)
    {
        var value = new TargetTask
        {
            Condition = condition ?? Snippet.From(DefaultCondition),
            ContinueOnError = continueOnError ?? TargetTask.Options.ErrorAndStop,
            Name = name ?? DefaultName,
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

    public static Output CreateOutput()
    {
        return new Output
        {
            Condition = Snippet.From(DefaultOutputCondition),
            ItemName = DefaultOutputItemName,
            PropertyName = DefaultOutputPropertyName,
            TaskParameter = DefaultOutputTaskParameter,
        };
    }

    public static Parameter CreateParameter()
    {
        return new Parameter
        {
            Name = DefaultParameterName,
            Value = Snippet.From(DefaultParameterValue),
        };
    }
}