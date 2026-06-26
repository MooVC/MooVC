namespace MooVC.Syntax.Solution.ProjectTests.RelativePathTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsValue()
    {
        // Arrange
        const string path = "src/Project.csproj";
        var subject = new Project.RelativePath(path);

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(path);
    }
}