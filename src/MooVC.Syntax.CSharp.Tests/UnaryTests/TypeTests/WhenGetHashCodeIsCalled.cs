namespace MooVC.Syntax.CSharp.UnaryTests.TypeTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        Unary.Type first = Unary.Type.Not;
        Unary.Type second = Unary.Type.Increment;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenEquivalentValuesThenReturnsTheSameHash()
    {
        // Arrange
        Unary.Type first = Unary.Type.Not;
        Unary.Type second = Unary.Type.Not;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}