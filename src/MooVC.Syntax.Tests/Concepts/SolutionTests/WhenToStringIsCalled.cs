namespace MooVC.Syntax.Concepts.SolutionTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Solution subject = Solution.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValuesThenReturnsDocument()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create();
        string expected = subject.ToDocument().ToString();

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }
}