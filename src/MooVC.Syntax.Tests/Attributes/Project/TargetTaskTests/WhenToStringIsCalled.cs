namespace MooVC.Syntax.Attributes.Project.TargetTaskTests;

using System;
using System.Xml.Linq;
using MooVC.Syntax.Elements;

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
        Parameter parameter = TargetTaskTestsData.CreateParameter();
        Output output = TargetTaskTestsData.CreateOutput();

        TargetTask subject = TargetTaskTestsData.Create(
            condition: Snippet.From(TargetTaskTestsData.DefaultCondition),
            continueOnError: TargetTask.Options.WarnAndContinue,
            parameter: parameter,
            output: output);

        var outputElement = new XElement(
            "Output",
            new XAttribute(nameof(Output.Condition), TargetTaskTestsData.DefaultOutputCondition),
            new XAttribute(nameof(Output.ItemName), TargetTaskTestsData.DefaultOutputItemName),
            new XAttribute(nameof(Output.PropertyName), TargetTaskTestsData.DefaultOutputPropertyName),
            new XAttribute(nameof(Output.TaskParameter), TargetTaskTestsData.DefaultOutputTaskParameter));

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