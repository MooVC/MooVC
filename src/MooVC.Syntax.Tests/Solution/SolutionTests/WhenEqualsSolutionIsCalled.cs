namespace MooVC.Syntax.Solution.SolutionTests;

public sealed class WhenEqualsSolutionIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create();
        Solution other = SolutionTestsData.Create(file: "other.cs");

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create();
        Solution other = SolutionTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create();

        // Act
        bool result = subject.Equals(default);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}