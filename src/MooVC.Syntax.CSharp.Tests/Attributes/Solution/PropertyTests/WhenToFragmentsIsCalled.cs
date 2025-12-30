namespace MooVC.Syntax.CSharp.Attributes.Solution.PropertyTests;

using System.Xml.Linq;

public sealed class WhenToFragmentsIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Property subject = Property.Undefined;

        // Act
        var result = subject.ToFragments();

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();

        var expected = new XElement(
            nameof(Property),
            new XAttribute(nameof(Property.Name), PropertyTestsData.DefaultName),
            new XAttribute(nameof(Property.Value), PropertyTestsData.DefaultValue));

        // Act
        var result = subject.ToFragments();

        // Assert
        var fragment = result.ShouldHaveSingleItem();
        XNode.DeepEquals(expected, fragment).ShouldBeTrue();
    }
}