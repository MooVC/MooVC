namespace MooVC.Syntax.CSharp.Members.PropertyTests.SetterTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEquivalentInstancesThenHashCodesAreEqual()
    {
        // Arrange
        Property.Setter first = new Property.Setter { Behaviour = Snippet.From("value") };
        Property.Setter second = new Property.Setter { Behaviour = Snippet.From("value") };

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
        Property.Setter first = new Property.Setter { Behaviour = Snippet.From("value") };
        Property.Setter second = new Property.Setter { Behaviour = Snippet.From("alternative") };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}
