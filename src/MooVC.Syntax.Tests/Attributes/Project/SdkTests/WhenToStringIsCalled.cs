namespace MooVC.Syntax.Attributes.Project.SdkTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUnspecifiedThenReturnsEmpty()
    {
        // Arrange
        Sdk subject = Sdk.Unspecified;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Sdk subject = SdkTestsData.Create();
        var element = new XElement(
            nameof(Sdk),
            new XAttribute(nameof(Sdk.Name), SdkTestsData.DefaultName.ToString()),
            new XAttribute(nameof(Sdk.Version), SdkTestsData.DefaultVersion),
            new XAttribute(nameof(Sdk.MinimumVersion), SdkTestsData.DefaultMinimumVersion));

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}