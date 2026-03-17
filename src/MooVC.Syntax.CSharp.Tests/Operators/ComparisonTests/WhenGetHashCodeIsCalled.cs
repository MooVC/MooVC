namespace MooVC.Syntax.CSharp.Operators.ComparisonTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public void GivenEquivalentValuesThenHashesMatch()
    {
        // Arrange
        Comparison first = ComparisonTestsData.Create();
        Comparison second = ComparisonTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Test]
    public void GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Comparison first = ComparisonTestsData.Create();
        Comparison second = ComparisonTestsData.Create(@operator: Comparison.Type.GreaterThan);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}