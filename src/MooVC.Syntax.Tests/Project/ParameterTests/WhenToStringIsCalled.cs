namespace MooVC.Syntax.Project.ParameterTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Parameter subject = Parameter.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValuesThenReturnsFragment()
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
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}