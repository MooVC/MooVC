namespace MooVC.Syntax.Attributes.Solution.ProjectTests.NameTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenEqualityOperatorNameNameIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Project.Name? left = default;
        Project.Name? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        const string name = "ProjectName";
        var left = new Project.Name(name);
        var right = new Project.Name(name);

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Project.Name("ProjectName");
        var right = new Project.Name("OtherProjectName");

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}