namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenTheSameValueThenReturnsTheSameHash()
    {
        // Arrange
        Comparison.Type first = Comparison.Type.Equality;
        Comparison.Type second = Comparison.Type.Equality;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        Comparison.Type first = Comparison.Type.Equality;
        Comparison.Type second = Comparison.Type.Inequality;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}