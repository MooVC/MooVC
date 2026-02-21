namespace MooVC.Syntax.Attributes.Solution.ProjectTests.RelativePathTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenEqualityOperatorRelativePathRelativePathIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Project.RelativePath? left = default;
        Project.RelativePath? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        const string path = "src/Project.csproj";
        var left = new Project.RelativePath(path);
        var right = new Project.RelativePath(path);

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Project.RelativePath("src/Project.csproj");
        var right = new Project.RelativePath("src/Other.csproj");

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}