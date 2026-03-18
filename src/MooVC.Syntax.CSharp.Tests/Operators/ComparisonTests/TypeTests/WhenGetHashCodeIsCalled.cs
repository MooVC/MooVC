namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenTheSameValueThenReturnsTheSameHash()
    {
        // Arrange
        Comparison.Type first = Comparison.Type.Equality;
        Comparison.Type second = Comparison.Type.Equality;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        Comparison.Type first = Comparison.Type.Equality;
        Comparison.Type second = Comparison.Type.Inequality;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }
}