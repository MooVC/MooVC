namespace MooVC.Syntax.Attributes.Solution.ProjectTests.NameTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenEqualityOperatorNameNameIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
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