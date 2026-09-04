namespace MooVC.Syntax.Solution.BuildTests;

public sealed class WhenInequalityOperatorBuildBuildIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Build left = BuildTestsData.Create(project: Snippet.From("Debug|AnyCPU"));
        Build right = BuildTestsData.Create(project: Snippet.From("Release|AnyCPU"));

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}