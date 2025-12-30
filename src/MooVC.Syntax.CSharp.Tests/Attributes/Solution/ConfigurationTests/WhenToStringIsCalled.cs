namespace MooVC.Syntax.CSharp.Attributes.Solution.ConfigurationTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Configuration subject = Configuration.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Configuration subject = ConfigurationTestsData.Create();

        var element = new XElement(
            nameof(Configuration),
            new XAttribute(nameof(Configuration.Name), ConfigurationTestsData.DefaultName),
            new XAttribute(nameof(Configuration.Platform), ConfigurationTestsData.DefaultPlatform));

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}