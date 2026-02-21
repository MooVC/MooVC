namespace MooVC.Syntax.Attributes.Resource.DataTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Data subject = Data.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Data subject = DataTestsData.Create();

        var element = new XElement(
            "data",
            new XAttribute("name", DataTestsData.DefaultName),
            new XAttribute("type", DataTestsData.DefaultType),
            new XAttribute("mimetype", DataTestsData.DefaultMimeType),
            new XElement("value", DataTestsData.DefaultValue),
            new XElement("comment", DataTestsData.DefaultComment));

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}