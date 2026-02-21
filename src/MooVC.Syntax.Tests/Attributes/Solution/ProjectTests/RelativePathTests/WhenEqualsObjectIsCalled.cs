namespace MooVC.Syntax.Attributes.Solution.ProjectTests.RelativePathTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Project.RelativePath("src/Project.csproj");

        // Act
        bool result = subject.Equals(default(object));

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        var subject = new Project.RelativePath("src/Project.csproj");

        // Act
        bool result = subject.Equals("src/Other.csproj");

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenRelativePathWithSameValueThenReturnsTrue()
    {
        // Arrange
        const string path = "src/Project.csproj";
        var subject = new Project.RelativePath(path);
        object other = new Project.RelativePath(path);

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}