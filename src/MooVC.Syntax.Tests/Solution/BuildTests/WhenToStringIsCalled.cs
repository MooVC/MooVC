namespace MooVC.Syntax.Solution.BuildTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenValueThenStringContainsProjectAndSolutionAttributes()
    {
        // Arrange
        Build subject = BuildTestsData.Create();

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).Contains(nameof(Build.Project));
        _ = await Assert.That(result).Contains(nameof(Build.Solution));
    }
}