namespace MooVC.Syntax.Solution.ProjectTests.NameTests;

public sealed class WhenInequalityOperatorNameNameIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Project.Name? left = default;
        Project.Name? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        const string name = "ProjectName";
        var left = new Project.Name(name);
        var right = new Project.Name(name);

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Project.Name("ProjectName");
        var right = new Project.Name("OtherProjectName");

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}