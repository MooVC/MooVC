namespace MooVC.Syntax.CSharp.Attributes.Solution.PropertyTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Property subject = Property.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();

        var element = new XElement(
            nameof(Property),
            new XAttribute(nameof(Property.Name), PropertyTestsData.DefaultName),
            new XAttribute(nameof(Property.Value), PropertyTestsData.DefaultValue));

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}