namespace MooVC.Syntax.Attributes.Project.MetadataTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Metadata subject = Metadata.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Metadata subject = MetadataTestsData.Create();
        var element = new XElement(
            MetadataTestsData.DefaultName,
            new XAttribute(nameof(Metadata.Condition), MetadataTestsData.DefaultCondition),
            MetadataTestsData.DefaultValue);

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}