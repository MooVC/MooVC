namespace MooVC.Syntax.CSharp.Members.PropertyTests.SetterTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEquivalentInstancesThenHashCodesAreEqual()
    {
        // Arrange
        var first = new Property.Setter { Behaviour = Snippet.From("value") };
        var second = new Property.Setter { Behaviour = Snippet.From("value") };

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
        var first = new Property.Setter { Behaviour = Snippet.From("value") };
        var second = new Property.Setter { Behaviour = Snippet.From("alternative") };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}