namespace MooVC.Syntax.Attributes.Project.TaskOutputTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        TaskOutput subject = TaskOutput.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        TaskOutput subject = TaskOutputTestsData.Create();
        var element = new XElement(
            "Output",
            new XAttribute(nameof(TaskOutput.Condition), TaskOutputTestsData.DefaultCondition),
            new XAttribute(nameof(TaskOutput.ItemName), TaskOutputTestsData.DefaultItemName),
            new XAttribute(nameof(TaskOutput.PropertyName), TaskOutputTestsData.DefaultPropertyName),
            new XAttribute(nameof(TaskOutput.TaskParameter), TaskOutputTestsData.DefaultTaskParameter));

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}