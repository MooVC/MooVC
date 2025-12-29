namespace MooVC.Syntax.CSharp.Attributes.Project.TargetTaskTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        TargetTask subject = TargetTask.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        TaskParameter parameter = TargetTaskTestsData.CreateParameter();
        TaskOutput output = TargetTaskTestsData.CreateOutput();
        TargetTask subject = TargetTaskTestsData.Create(
            condition: Snippet.From(TargetTaskTestsData.DefaultCondition),
            continueOnError: TargetTask.Options.WarnAndContinue,
            parameter: parameter,
            output: output);

        var outputElement = new XElement(
            "Output",
            new XAttribute(nameof(TaskOutput.Condition), TargetTaskTestsData.DefaultOutputCondition),
            new XAttribute(nameof(TaskOutput.ItemName), TargetTaskTestsData.DefaultOutputItemName),
            new XAttribute(nameof(TaskOutput.PropertyName), TargetTaskTestsData.DefaultOutputPropertyName),
            new XAttribute(nameof(TaskOutput.TaskParameter), TargetTaskTestsData.DefaultOutputTaskParameter));

        var element = new XElement(
            TargetTaskTestsData.DefaultName,
            new XAttribute(nameof(TargetTask.Condition), TargetTaskTestsData.DefaultCondition),
            new XAttribute("ContinueOnError", TargetTask.Options.WarnAndContinue.ToString()),
            new XAttribute(TargetTaskTestsData.DefaultParameterName, TargetTaskTestsData.DefaultParameterValue),
            outputElement);

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}