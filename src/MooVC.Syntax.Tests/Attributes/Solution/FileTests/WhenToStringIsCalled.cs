namespace MooVC.Syntax.Attributes.Solution.FileTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        File subject = File.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        File subject = FileTestsData.Create();

        var element = new XElement(
            nameof(File),
            new XAttribute(nameof(File.Id), FileTestsData.DefaultId),
            new XAttribute(nameof(File.Name), FileTestsData.DefaultName),
            new XAttribute(nameof(File.Path), FileTestsData.DefaultPath));

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}