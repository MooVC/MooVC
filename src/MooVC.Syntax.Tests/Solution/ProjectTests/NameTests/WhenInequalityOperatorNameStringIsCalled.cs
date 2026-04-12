namespace MooVC.Syntax.Solution.ProjectTests.NameTests;

public sealed class WhenInequalityOperatorNameStringIsCalled
{
    private const string Same = "ProjectName";
    private const string Different = "OtherProjectName";

    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Project.Name? left = default;
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
        var left = new Project.Name(Same);

        // Act
        bool resultLeftRight = left != Different;
        bool resultRightLeft = Different != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Project.Name(Same);

        // Act
        bool resultLeftRight = left != Same;
        bool resultRightLeft = Same != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }
}