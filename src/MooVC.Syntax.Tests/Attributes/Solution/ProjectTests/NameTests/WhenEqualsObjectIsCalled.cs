namespace MooVC.Syntax.Attributes.Solution.ProjectTests.NameTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Project.Name("ProjectName");

        // Act
        bool result = subject.Equals(default(object));

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        var subject = new Project.Name("ProjectName");

        // Act
        bool result = subject.Equals("OtherProjectName");

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenNameWithSameValueThenReturnsTrue()
    {
        // Arrange
        const string name = "ProjectName";
        var subject = new Project.Name(name);
        object other = new Project.Name(name);

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}