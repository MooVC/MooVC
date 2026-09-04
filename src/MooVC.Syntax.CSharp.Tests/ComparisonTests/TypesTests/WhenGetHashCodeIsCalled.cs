namespace MooVC.Syntax.CSharp.ComparisonTests.TypesTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        Comparison.Types first = Comparison.Types.Equality;
        Comparison.Types second = Comparison.Types.Inequality;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenTheSameValueThenReturnsTheSameHash()
    {
        // Arrange
        Comparison.Types first = Comparison.Types.Equality;
        Comparison.Types second = Comparison.Types.Equality;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}