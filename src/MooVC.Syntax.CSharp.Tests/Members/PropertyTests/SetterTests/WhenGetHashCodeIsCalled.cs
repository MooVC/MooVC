namespace MooVC.Syntax.CSharp.Members.PropertyTests.SetterTests;

using MooVC.Syntax.Elements;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEquivalentInstancesThenHashCodesAreEqual()
    {
        // Arrange
        var first = new Property.Setter { Behaviour = "value" };
        var second = new Property.Setter { Behaviour = "value" };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Fact]
    public void GivenDifferentInstancesThenHashCodesAreNotEqual()
    {
        // Arrange
        var first = new Property.Setter { Behaviour = "value" };
        var second = new Property.Setter { Behaviour = "alternative" };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}