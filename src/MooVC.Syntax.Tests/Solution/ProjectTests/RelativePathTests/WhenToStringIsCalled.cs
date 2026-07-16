namespace MooVC.Syntax.Solution.ProjectTests.RelativePathTests;

public sealed class WhenToStringIsCalled
{
    private const string Value = "src/Project.csproj";

    [Test]
    public async Task GivenRelativePathThenReturnsUnderlyingValue()
    {
        // Arrange
        var subject = new Project.RelativePath(Value);

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(Value);
    }
}