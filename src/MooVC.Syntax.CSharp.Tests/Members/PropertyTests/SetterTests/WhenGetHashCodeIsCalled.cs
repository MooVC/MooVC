namespace MooVC.Syntax.CSharp.Members.PropertyTests.SetterTests;

using MooVC.Syntax.Elements;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEquivalentInstancesThenHashCodesAreEqual()
    {
        // Arrange
        var first = new Property.Setter { Behaviour = Snippet.From("value") };
        var second = new Property.Setter { Behaviour = Snippet.From("value") };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentInstancesThenHashCodesAreNotEqual()
    {
        // Arrange
        var first = new Property.Setter { Behaviour = Snippet.From("value") };
        var second = new Property.Setter { Behaviour = Snippet.From("alternative") };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }
}