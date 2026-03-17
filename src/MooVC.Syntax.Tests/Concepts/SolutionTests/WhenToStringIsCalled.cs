namespace MooVC.Syntax.Concepts.SolutionTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Solution subject = Solution.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Test]
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