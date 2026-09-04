namespace MooVC.Syntax.Solution.BuildTests;

public sealed class WhenForProjectIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsNewInstanceWithUpdatedProject()
    {
        // Arrange
        Build original = BuildTestsData.Create();
        var updated = Snippet.From("Release|AnyCPU");

        // Act
        Build result = original.ForProject(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Project).IsEqualTo(updated);
        _ = await Assert.That(result.Solution).IsEqualTo(original.Solution);
    }
}