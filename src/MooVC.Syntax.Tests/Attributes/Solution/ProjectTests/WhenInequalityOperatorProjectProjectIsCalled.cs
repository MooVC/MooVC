namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

public sealed class WhenInequalityOperatorProjectProjectIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Project? left = default;
        Project? right = default;

        // Act
        bool result = left != right;

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Project left = ProjectTestsData.Create();
        Project right = ProjectTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Project left = ProjectTestsData.Create();
        Project right = ProjectTestsData.Create(path: new Project.RelativePath("other.csproj"));

        // Act
        bool result = left != right;

        // Assert
        await Assert.That(result).IsTrue();
    }
}