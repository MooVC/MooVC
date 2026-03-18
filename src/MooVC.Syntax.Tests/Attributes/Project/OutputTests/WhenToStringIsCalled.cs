namespace MooVC.Syntax.Attributes.Project.OutputTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Output subject = Output.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValuesThenReturnsFragment()
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
        await Assert.That(result).IsEqualTo(expected);
    }
}