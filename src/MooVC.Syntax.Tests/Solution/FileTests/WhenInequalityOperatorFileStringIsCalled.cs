namespace MooVC.Syntax.Solution.FileTests;

public sealed class WhenInequalityOperatorFileStringIsCalled
{
    private const string Same = "src/Readme.md";
    private const string Different = "src/Other.md";

    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        File? left = default;
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
        File left = Same;

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
        File left = Same;

        // Act
        bool resultLeftRight = left != Same;
        string right = Same;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }
}