namespace MooVC.Syntax.Solution.FileTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenFileThenReturnsStringValue()
    {
        // Arrange
        var subject = new File(FileTestsData.DefaultPath);

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(FileTestsData.DefaultPath);
    }
}