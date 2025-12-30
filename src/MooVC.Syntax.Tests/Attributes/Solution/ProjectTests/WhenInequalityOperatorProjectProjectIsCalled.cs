namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

using MooVC.Syntax;
using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorProjectProjectIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Project? left = default;
        Project? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Project left = ProjectTestsData.Create();
        Project right = ProjectTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Project left = ProjectTestsData.Create();
        Project right = ProjectTestsData.Create(path: Snippet.From("other.csproj"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}