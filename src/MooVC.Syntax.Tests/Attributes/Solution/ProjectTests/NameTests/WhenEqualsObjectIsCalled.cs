namespace MooVC.Syntax.Attributes.Solution.ProjectTests.NameTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Project.Name("ProjectName");

        // Act
        bool result = subject.Equals(default(object));

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        var subject = new Project.Name("ProjectName");

        // Act
        bool result = subject.Equals("OtherProjectName");

        // Assert
        await Assert.That(result).IsFalse();
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
        await Assert.That(result).IsTrue();
    }
}