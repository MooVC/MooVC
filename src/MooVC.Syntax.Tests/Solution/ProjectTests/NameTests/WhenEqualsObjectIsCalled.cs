namespace MooVC.Syntax.Solution.ProjectTests.NameTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        var subject = new Project.Name("ProjectName");

        // Act
        bool result = subject.Equals("OtherProjectName");

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenNameWithSameValueThenReturnsTrue()
    {
        // Arrange
        const string name = "ProjectName";
        var subject = new Project.Name(name);
        object other = new Project.Name(name);

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

        // Act
        bool result = subject.Equals(default(object));

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}