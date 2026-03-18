namespace MooVC.Syntax.Attributes.Project.PropertyTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Property subject = Property.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValuesThenReturnsFragment()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        var element = new XElement(
            PropertyTestsData.DefaultName,
            new XAttribute(nameof(Property.Condition), PropertyTestsData.DefaultCondition),
            PropertyTestsData.DefaultValue);

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}