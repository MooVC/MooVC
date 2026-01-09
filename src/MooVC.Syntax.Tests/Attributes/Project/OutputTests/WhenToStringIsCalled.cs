namespace MooVC.Syntax.Attributes.Project.OutputTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Output subject = Output.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Output subject = OutputTestsData.Create();
        var element = new XElement(
            "Output",
            new XAttribute(nameof(Output.Condition), OutputTestsData.DefaultCondition),
            new XAttribute(nameof(Output.ItemName), OutputTestsData.DefaultItemName),
            new XAttribute(nameof(Output.PropertyName), OutputTestsData.DefaultPropertyName),
            new XAttribute(nameof(Output.TaskParameter), OutputTestsData.DefaultTaskParameter));

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}