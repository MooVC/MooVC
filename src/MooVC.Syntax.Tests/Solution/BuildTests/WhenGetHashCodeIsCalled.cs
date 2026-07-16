namespace MooVC.Syntax.Solution.BuildTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEquivalentValuesThenHashCodesMatch()
    {
        // Arrange
        Build left = BuildTestsData.Create();
        Build right = BuildTestsData.Create();

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsEqualTo(rightHash);
    }
}