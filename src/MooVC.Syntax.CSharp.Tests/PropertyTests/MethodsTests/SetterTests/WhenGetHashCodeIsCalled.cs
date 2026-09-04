namespace MooVC.Syntax.CSharp.PropertyTests.MethodsTests.SetterTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentInstancesThenHashCodesAreNotEqual()
    {
        // Arrange
        var first = new Property.Methods.Setter { Behaviour = Snippet.From("value") };
        var second = new Property.Methods.Setter { Behaviour = Snippet.From("alternative") };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenEquivalentInstancesThenHashCodesAreEqual()
    {
        // Arrange
        var first = new Property.Methods.Setter { Behaviour = Snippet.From("value") };
        var second = new Property.Methods.Setter { Behaviour = Snippet.From("value") };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}