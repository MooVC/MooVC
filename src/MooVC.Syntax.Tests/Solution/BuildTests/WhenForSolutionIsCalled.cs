namespace MooVC.Syntax.Solution.BuildTests;

public sealed class WhenForSolutionIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsNewInstanceWithUpdatedSolution()
    {
        // Arrange
        Build original = BuildTestsData.Create();
        var updated = Snippet.From("Release|Any CPU");

        // Act
        Build result = original.ForSolution(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Project).IsEqualTo(original.Project);
        _ = await Assert.That(result.Solution).IsEqualTo(updated);
    }
}