namespace MooVC.Syntax.Attributes.Solution.FileTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenFileThenReturnsStringValue()
    {
        // Arrange
        var subject = new File(FileTestsData.DefaultPath);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(FileTestsData.DefaultPath);
    }
}