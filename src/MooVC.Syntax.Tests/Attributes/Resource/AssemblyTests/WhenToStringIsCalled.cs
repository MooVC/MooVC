namespace MooVC.Syntax.Attributes.Resource.AssemblyTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Test]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Assembly subject = Assembly.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Test]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Assembly subject = AssemblyTestsData.Create();

        var element = new XElement(
            "assembly",
            new XAttribute("alias", AssemblyTestsData.DefaultAlias),
            new XAttribute("name", AssemblyTestsData.DefaultName));

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}