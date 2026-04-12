namespace MooVC.Syntax.Solution.ProjectTests.RelativePathTests;

public sealed class WhenEqualityOperatorRelativePathStringIsCalled
{
    private const string Same = "src/Project.csproj";
    private const string Different = "src/Other.csproj";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Project.RelativePath? left = default;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Project.RelativePath(Same);

        // Act
        bool resultLeftRight = left == Different;
        string right = Different;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Project.RelativePath(Same);

        // Act
        bool resultLeftRight = left == Same;
        string right = Same;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }
}