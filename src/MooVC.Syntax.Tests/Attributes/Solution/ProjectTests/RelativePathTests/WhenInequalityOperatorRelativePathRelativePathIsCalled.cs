namespace MooVC.Syntax.Attributes.Solution.ProjectTests.RelativePathTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenInequalityOperatorRelativePathRelativePathIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Project.RelativePath? left = default;
        Project.RelativePath? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        const string path = "src/Project.csproj";
        var left = new Project.RelativePath(path);
        var right = new Project.RelativePath(path);

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Project.RelativePath("src/Project.csproj");
        var right = new Project.RelativePath("src/Other.csproj");

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}