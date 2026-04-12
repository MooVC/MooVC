namespace MooVC.Syntax.Solution.ProjectTests.RelativePathTests;

public sealed class WhenInequalityOperatorRelativePathStringIsCalled
{
    private const string Same = "src/Project.csproj";
    private const string Different = "src/Other.csproj";

    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Project.RelativePath? left = default;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Project.RelativePath(Same);

        // Act
        bool resultLeftRight = left != Different;
        string right = Different;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Project.RelativePath(Same);

        // Act
        bool resultLeftRight = left != Same;
        string right = Same;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }
}