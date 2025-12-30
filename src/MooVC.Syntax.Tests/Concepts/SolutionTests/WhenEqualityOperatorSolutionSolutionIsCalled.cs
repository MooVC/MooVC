namespace MooVC.Syntax.Concepts.SolutionTests;

using MooVC.Syntax;
using MooVC.Syntax.Attributes.Solution;
using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorSolutionSolutionIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Solution? left = default;
        Solution? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Solution left = SolutionTestsData.Create();
        Solution right = SolutionTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Solution left = SolutionTestsData.Create();
        Solution right = SolutionTestsData.Create(property: new Property { Name = Snippet.From("Other") });

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}