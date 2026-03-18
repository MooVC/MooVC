namespace MooVC.Syntax.Solution.ProjectTests.RelativePathTests;

public sealed class WhenInequalityOperatorRelativePathRelativePathIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Project.RelativePath? left = default;
        Project.RelativePath? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        const string path = "src/Project.csproj";
        var left = new Project.RelativePath(path);
        var right = new Project.RelativePath(path);

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Project.RelativePath("src/Project.csproj");
        var right = new Project.RelativePath("src/Other.csproj");

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}