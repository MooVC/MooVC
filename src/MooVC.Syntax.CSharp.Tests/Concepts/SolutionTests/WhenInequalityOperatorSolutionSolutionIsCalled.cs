namespace MooVC.Syntax.CSharp.Concepts.SolutionTests;

using MooVC.Syntax.CSharp;
using MooVC.Syntax.CSharp.Attributes.Solution;

public sealed class WhenInequalityOperatorSolutionSolutionIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Solution? left = default;
        Solution? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Solution left = SolutionTestsData.Create();
        Solution right = SolutionTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Solution left = SolutionTestsData.Create();
        Solution right = SolutionTestsData.Create(configuration: new Configuration { Name = Snippet.From("Other") });

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}