namespace MooVC.Syntax.Solution.BuildTests;

public sealed class WhenEqualsBuildIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Build subject = BuildTestsData.Create(project: Snippet.From("Debug|AnyCPU"));
        Build other = BuildTestsData.Create(project: Snippet.From("Release|AnyCPU"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}