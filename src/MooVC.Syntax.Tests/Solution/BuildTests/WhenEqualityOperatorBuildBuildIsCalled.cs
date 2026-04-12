namespace MooVC.Syntax.Solution.BuildTests;

public sealed class WhenEqualityOperatorBuildBuildIsCalled
{
    [Test]
    public async Task GivenEquivalentValuesThenReturnsTrue()
    {
        // Arrange
        Build left = BuildTestsData.Create();
        Build right = BuildTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}