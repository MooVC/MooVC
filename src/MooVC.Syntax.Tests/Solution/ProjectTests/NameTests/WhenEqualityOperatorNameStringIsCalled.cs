namespace MooVC.Syntax.Solution.ProjectTests.NameTests;

public sealed class WhenEqualityOperatorNameStringIsCalled
{
    private const string Same = "ProjectName";
    private const string Different = "OtherProjectName";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Project.Name? left = default;
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
        var left = new Project.Name(Same);

        // Act
        bool resultLeftRight = left == Different;
        bool resultRightLeft = Different == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Project.Name(Same);

        // Act
        bool resultLeftRight = left == Same;
        bool resultRightLeft = Same == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }
}