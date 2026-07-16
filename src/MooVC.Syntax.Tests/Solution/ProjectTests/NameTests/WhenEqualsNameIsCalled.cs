namespace MooVC.Syntax.Solution.ProjectTests.NameTests;

public sealed class WhenEqualsNameIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Project.Name("ProjectName");
        var other = new Project.Name("OtherProjectName");

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        const string name = "ProjectName";
        var subject = new Project.Name(name);
        var other = new Project.Name(name);

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Project.Name("ProjectName");
        Project.Name? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}