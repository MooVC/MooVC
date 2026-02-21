namespace MooVC.Syntax.Attributes.Project.ImportTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Import subject = Import.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Import subject = ImportTestsData.Create();
        var element = new XElement(
            nameof(Import),
            new XAttribute(nameof(Import.Project), ImportTestsData.DefaultProject),
            new XAttribute(nameof(Import.Sdk), ImportTestsData.DefaultSdk),
            new XAttribute(nameof(Import.Condition), ImportTestsData.DefaultCondition),
            new XAttribute(nameof(Import.Label), ImportTestsData.DefaultLabel));

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}