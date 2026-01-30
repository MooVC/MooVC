namespace MooVC.Syntax.Attributes.Resource.HeaderTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Header subject = Header.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Header subject = HeaderTestsData.Create();

        var element = new XElement(
            "resheader",
            new XAttribute("name", HeaderTestsData.DefaultName),
            new XElement("value", HeaderTestsData.DefaultValue));

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}