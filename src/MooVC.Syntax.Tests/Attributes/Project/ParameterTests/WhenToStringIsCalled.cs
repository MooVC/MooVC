namespace MooVC.Syntax.Attributes.Project.ParameterTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Parameter subject = Parameter.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Parameter subject = ParameterTestsData.Create();
        var element = new XElement(
            "Parameter",
            new XAttribute(nameof(Parameter.Name), ParameterTestsData.DefaultName),
            ParameterTestsData.DefaultValue);

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}