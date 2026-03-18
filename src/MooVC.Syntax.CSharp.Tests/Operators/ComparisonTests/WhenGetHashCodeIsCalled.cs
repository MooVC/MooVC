namespace MooVC.Syntax.CSharp.Operators.ComparisonTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEquivalentValuesThenHashesMatch()
    {
        // Arrange
        Comparison first = ComparisonTestsData.Create();
        Comparison second = ComparisonTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Comparison first = ComparisonTestsData.Create();
        Comparison second = ComparisonTestsData.Create(@operator: Comparison.Type.GreaterThan);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }
}