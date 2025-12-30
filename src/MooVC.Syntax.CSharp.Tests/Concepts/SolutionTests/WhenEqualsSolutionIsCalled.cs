namespace MooVC.Syntax.CSharp.Concepts.SolutionTests;

using MooVC.Syntax.CSharp;
using MooVC.Syntax.CSharp.Attributes.Solution;

public sealed class WhenEqualsSolutionIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create();

        // Act
        bool result = subject.Equals(default);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create();
        Solution other = SolutionTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create();
        Solution other = SolutionTestsData.Create(file: new File { Path = Snippet.From("other.cs") });

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}