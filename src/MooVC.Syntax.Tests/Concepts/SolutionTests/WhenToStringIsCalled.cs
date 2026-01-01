namespace MooVC.Syntax.Concepts.SolutionTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Solution subject = Solution.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsDocument()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create();
        string expected = subject.ToDocument().ToString();

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}