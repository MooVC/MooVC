namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

using System;
using System.Xml.Linq;
using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Resource subject = Resource.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragments()
    {
        // Arrange
        var location = new Path(ResourceTestsData.DefaultLocationPath);
        var subject = new Resource { Location = location };
        Path designer = location.ChangeExtension("Designer.cs");

        var compileElement = new XElement(
            "Compile",
            new XAttribute("Update", designer.ToString()),
            new XElement("DesignTime", "True"),
            new XElement("AutoGen", "True"),
            new XElement("DependentUpon", location.FileName));

        var embeddedResourceElement = new XElement(
            "EmbeddedResource",
            new XAttribute("Update", location.ToString()),
            new XElement("Generator", "ResXFileCodeGenerator"),
            new XElement("LastGenOutput", designer.FileName));

        string expected = compileElement + Environment.NewLine + embeddedResourceElement + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}