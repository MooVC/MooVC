namespace MooVC.Syntax.Concepts.SolutionTests;

public sealed class WhenEqualsSolutionIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create();

        // Act
        bool result = subject.Equals(default);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
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

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create();
        Solution other = SolutionTestsData.Create(file: "other.cs");

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}