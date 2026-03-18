namespace MooVC.Syntax.Attributes.Solution.ProjectTests.RelativePathTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenEqualsRelativePathIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Project.RelativePath("src/Project.csproj");
        Project.RelativePath? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        const string path = "src/Project.csproj";
        var subject = new Project.RelativePath(path);
        var other = new Project.RelativePath(path);

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Project.RelativePath("src/Project.csproj");
        var other = new Project.RelativePath("src/Other.csproj");

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}