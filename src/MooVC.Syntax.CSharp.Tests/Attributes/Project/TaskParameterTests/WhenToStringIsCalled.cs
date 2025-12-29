namespace MooVC.Syntax.CSharp.Attributes.Project.TaskParameterTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        TaskParameter subject = TaskParameter.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        TaskParameter subject = TaskParameterTestsData.Create();
        var element = new XElement(
            "Parameter",
            new XAttribute(nameof(TaskParameter.Name), TaskParameterTestsData.DefaultName),
            TaskParameterTestsData.DefaultValue);

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}